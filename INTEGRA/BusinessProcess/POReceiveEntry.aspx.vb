Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Imports System.Drawing.Color
Public Class POReceiveEntry
    Inherits System.Web.UI.Page
    Dim objGeneralCode As New GeneralCode
    Dim objPORecvDetail As New PORecvDetail
    Dim objPORecvMaster As New PORecvMaster
    Dim PORecvMasterID As Long
    Dim dr As DataRow
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim DtYarnPCDetail As New DataTable
    Dim objDataView As DataView
    Dim PageName As String
    Dim ObjIMSStoreLedger As New IMSStoreLedger
    Dim ObjLocation As New Location
    Dim userid As Long
    Dim objPORecvDetailHistory As New PORecvDetailHistory
    Dim ObjIssue As New IssueMst
    Dim dtRecvDetail, dtPurchaseOrder, dtStyle As DataTable
    Dim objPOMaster As New POMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PageName = Request.QueryString("PageName")
        PORecvMasterID = Request.QueryString("PORecvMasterID")
        userid = Session("UserId")
        If Not Page.IsPostBack Then
            BindParty()
            BindPO(0)
            BindItem()
            BindLocation()
            BindSeason()
            Session("dtRecvDetail") = Nothing
            Session("objDataView") = Nothing
            If Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                lblFabItem.Text = "Fabric :"
            Else
                Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
                If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                    lblFabItem.Text = "Fabric :"

                ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                    lblFabItem.Text = "Item :"

                ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                    lblFabItem.Text = "Item :"
                End If
            End If
            If PORecvMasterID > 0 Then
                Edit()
                btnSave.Text = "Update"
                btnSave.Visible = "true"
                btnCancel.Visible = "true"
            Else
                btnSave.Text = "Save"
                txtPOReceiveDate.Text = Date.Today
                RECNoGenerateOnLoad()
            End If
        End If
        PageHeader("PO RECEIVING ENTRY FORM")
    End Sub
    Sub BindParty()
        Try
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
            If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                Dim dt As DataTable
                dt = objPORecvMaster.BindSupplierForRecPOONew()
                cmbPartyname.DataSource = dt
                cmbPartyname.DataTextField = "SupplierName"
                cmbPartyname.DataValueField = "SupplierDatabaseid"
                cmbPartyname.DataBind()
                cmbPartyname.Items.Insert(0, New ListItem("Select", "0"))
            ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                Dim dt As DataTable
                dt = objPORecvMaster.BindSupplierForRecPOONewForAstore()
                cmbPartyname.DataSource = dt
                cmbPartyname.DataTextField = "SupplierName"
                cmbPartyname.DataValueField = "SupplierDatabaseid"
                cmbPartyname.DataBind()
                cmbPartyname.Items.Insert(0, New ListItem("Select", "0"))
            ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                Dim dt As DataTable
                dt = objPORecvMaster.BindSupplierForRecPOONewForAstoreGSTore()
                cmbPartyname.DataSource = dt
                cmbPartyname.DataTextField = "SupplierName"
                cmbPartyname.DataValueField = "SupplierDatabaseid"
                cmbPartyname.DataBind()
                cmbPartyname.Items.Insert(0, New ListItem("Select", "0"))
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub BindPO(ByVal SupplierID As Long)
        Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
        If DtCheck.Rows(0)("Department") = "Fabric Store" Then
            Dim dtP As DataTable
            dtP = objPORecvMaster.BindPOSupNItemWiseDPEditNew(cmbPartyname.SelectedValue)
            cmbPONo.DataSource = dtP
            cmbPONo.DataTextField = "POJO"
            cmbPONo.DataValueField = "POID"
            cmbPONo.DataBind()
            cmbPONo.Items.Insert(0, New ListItem("Select", "0"))
        ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
            Dim dtP As DataTable
            dtP = objPORecvMaster.BindPOSupNItemWiseDPEditNewForAcc(cmbPartyname.SelectedValue)
            cmbPONo.DataSource = dtP
            cmbPONo.DataTextField = "POJO"
            cmbPONo.DataValueField = "POID"
            cmbPONo.DataBind()
            cmbPONo.Items.Insert(0, New ListItem("Select", "0"))
        ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
            Dim dtP As DataTable
            dtP = objPORecvMaster.BindPOSupNItemWiseDPEditNewForAccGstore(cmbPartyname.SelectedValue)
            cmbPONo.DataSource = dtP
            cmbPONo.DataTextField = "POJO"
            cmbPONo.DataValueField = "POID"
            cmbPONo.DataBind()
            cmbPONo.Items.Insert(0, New ListItem("Select", "0"))
        End If
    End Sub
    Protected Sub cmbPartyname_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPartyname.SelectedIndexChanged
        Try
            BindPO(cmbPartyname.SelectedValue)
        Catch ex As Exception
        End Try
    End Sub
    Sub BindItem()
        Try
            If Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                Dim dt As DataTable
                dt = objPORecvMaster.BindItemFBDPNew(cmbPartyname.SelectedValue, cmbPONo.SelectedValue)
                cmbFabric.DataSource = dt
                cmbFabric.DataTextField = "ItemName"
                cmbFabric.DataValueField = "PODetailID"
                cmbFabric.DataBind()
                cmbFabric.Items.Insert(0, New ListItem("Select", "0"))
            Else
                Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
                If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                    Dim dt As DataTable
                    dt = objPORecvMaster.BindItemFBDPNew(cmbPartyname.SelectedValue, cmbPONo.SelectedValue)
                    cmbFabric.DataSource = dt
                    cmbFabric.DataTextField = "ItemName"
                    cmbFabric.DataValueField = "PODetailID"
                    cmbFabric.DataBind()
                    cmbFabric.Items.Insert(0, New ListItem("Select", "0"))
                ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                    Dim dt As DataTable
                    dt = objPORecvMaster.BindItemFBDPNewForAcc(cmbPartyname.SelectedValue, cmbPONo.SelectedValue)
                    cmbFabric.DataSource = dt
                    cmbFabric.DataTextField = "ItemName"
                    cmbFabric.DataValueField = "PODetailID"
                    cmbFabric.DataBind()
                    cmbFabric.Items.Insert(0, New ListItem("Select", "0"))
                ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                    Dim dtP As DataTable
                    dtP = objPORecvMaster.BindItemFBDPNewForAccGstore(cmbPartyname.SelectedValue, cmbPONo.SelectedValue)
                    cmbFabric.DataSource = dtP
                    cmbFabric.DataTextField = "ItemName"
                    cmbFabric.DataValueField = "PODetailID"
                    cmbFabric.DataBind()
                    cmbFabric.Items.Insert(0, New ListItem("Select", "0"))
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbPONo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPONo.SelectedIndexChanged
        Try
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
            If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                BindItem()
            Else
                BindItem()
                Dim dt As DataTable = objPORecvMaster.GetDeliveryDateForAstore(cmbPONo.SelectedValue, cmbPartyname.SelectedValue)
                txtDeliveryDate.Text = dt.Rows(0)("DeliveryDate")
                txtTotalQty.Text = dt.Rows(0)("Quantity")
                objDataView = LoadDataForAstore(cmbPONo.SelectedValue)
                Session("objDataView") = objDataView
                BindGrid()
                Dim YarnRecvDate As Date = txtPOReceiveDate.Text
                Dim day As String = YarnRecvDate.Day
                Dim Month As String = YarnRecvDate.Month
                Dim Year As String = YarnRecvDate.Year
                Dim PartyName As String = cmbPartyname.SelectedItem.Text.Substring(0, 2).ToString()
                btnSave.Visible = True
                btnCancel.Visible = True
                pnlReceivedData.Visible = True
            End If
        Catch ex As Exception
        End Try
    End Sub
    Function LoadDataForAstore(ByVal POID As Long) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objPORecvMaster.GETGridDATANew2nEWForAstoreForNew(cmbPONo.SelectedValue, cmbPartyname.SelectedValue)
        cmbStyle.DataSource = objDataTable
        cmbStyle.DataTextField = "Style"
        cmbStyle.DataValueField = "POID"
        cmbStyle.DataBind()
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Sub BindSeason()
        Dim dt As DataTable = ObjIssue.GetSeasonFromIssue()
        CMBSeason.DataSource = dt
        CMBSeason.DataValueField = "SeasonDatabaseId"
        CMBSeason.DataTextField = "SeasonName"
        CMBSeason.DataBind()
        CMBSeason.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Sub BindSrNo()
        Dim dtt As DataTable = ObjIssue.GetSrNoFromIssueForAny()
        CMBSrNo.DataSource = dtt
        CMBSrNo.DataValueField = "JobOrderId"
        CMBSrNo.DataTextField = "SrNo"
        CMBSrNo.DataBind()
        CMBSrNo.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Protected Sub cmbFabric_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFabric.SelectedIndexChanged
        Try
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
            If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                Dim dt As DataTable = objPORecvMaster.GetDeliveryDate(cmbFabric.SelectedValue, cmbPONo.SelectedValue, cmbPartyname.SelectedValue)
                txtDeliveryDate.Text = dt.Rows(0)("DeliveryDate")
                txtTotalQty.Text = dt.Rows(0)("Quantity")
                objDataView = LoadData(cmbPONo.SelectedValue)
                Session("objDataView") = objDataView
                BindGrid()
                Dim YarnRecvDate As Date = txtPOReceiveDate.Text
                Dim day As String = YarnRecvDate.Day
                Dim Month As String = YarnRecvDate.Month
                Dim Year As String = YarnRecvDate.Year
                Dim PartyName As String = cmbPartyname.SelectedItem.Text.Substring(0, 2).ToString()
                btnSave.Visible = True
                btnCancel.Visible = True
                pnlReceivedData.Visible = True
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub Edit()
        Try
            Dim dt As DataTable
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
            If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                dt = objPORecvMaster.GetEditNew(PORecvMasterID)
            Else
                dt = objPORecvMaster.GetEditNewForAstore(PORecvMasterID)
            End If
            If dt.Rows(0)("SeasonDatabaseId") <> 0 Then
                CMBSeason.SelectedValue = dt.Rows(0)("SeasonDatabaseId")
                Dim dttt As DataTable = ObjIssue.GetSrNoFromIssue(CMBSeason.SelectedValue)
                CMBSrNo.DataSource = dttt
                CMBSrNo.DataValueField = "JobOrderId"
                CMBSrNo.DataTextField = "SrNo"
                CMBSrNo.DataBind()
                CMBSrNo.Items.Insert(0, New ListItem("Select", "0"))
            End If
            If dt.Rows(0)("JobOrderId") <> 0 Then
                CMBSrNo.SelectedValue = dt.Rows(0)("JobOrderId")
            End If
            lblUseriD.Text = dt.Rows(0)("UserID")
            txtPOReceiveDate.Text = dt.Rows(0)("PORecvDate")
            txtIGPNo.Text = dt.Rows(0)("GatePassNo")
            txtpartDCNo.Text = dt.Rows(0)("PartyDCNo")
            BindParty()
            cmbPartyname.SelectedValue = dt.Rows(0)("SupplierID")
            cmbPartyname.SelectedItem.Text = dt.Rows(0)("SupplierName")
            BindPO(0)
            cmbPONo.SelectedValue = dt.Rows(0)("Poidd")
            BindItem()
            lblAuditorStatus.Text = dt.Rows(0)("AuditorStatus")
            lblAuditorID.Text = dt.Rows(0)("AuditorID")
            cmbFabric.SelectedItem.Text = dt.Rows(0)("FabricRecv")
            cmbFabric.SelectedValue = dt.Rows(0)("PoDetailId")
            Dim dtt As DataTable = objPORecvMaster.GetDeliveryDate(cmbFabric.SelectedValue, cmbPONo.SelectedValue, cmbPartyname.SelectedValue)
            txtDeliveryDate.Text = dtt.Rows(0)("DeliveryDate")
            txtTotalQty.Text = dtt.Rows(0)("Quantity")
            LoadDataEdit(cmbPONo.SelectedValue)
            cmbStyle.SelectedItem.Text = dt.Rows(0)("Style")
            BindLocation()
            cmbLocation.SelectedValue = dt.Rows(0)("LocationID")
            If dt.Rows.Count > 0 Then
                dgPORecDetail.DataSource = dt
                dgPORecDetail.RecordCount = dt.Rows.Count
                dgPORecDetail.DataBind()
                dgPORecDetail.Visible = True
                pnlReceivedData.Visible = True
            Else
                dgPORecDetail.Visible = False
            End If
            Dim x As Integer
            For x = 0 To dgPORecDetail.Items.Count - 1
                Dim txtVehicleNo As TextBox = CType(dgPORecDetail.Items.Item(x).FindControl("txtVehicleNo"), TextBox)
                Dim cmbOfficeLocation As DropDownList = CType(dgPORecDetail.Items.Item(x).FindControl("cmbOfficeLocation"), DropDownList)
                Dim txtReceiveDate As TextBox = CType(dgPORecDetail.Items.Item(x).FindControl("txtReceiveDate"), TextBox)
                Dim TXTLotNo As TextBox = CType(dgPORecDetail.Items.Item(x).FindControl("TXTLotNo"), TextBox)
                Dim TXTNoOfRoll As TextBox = CType(dgPORecDetail.Items.Item(x).FindControl("TXTNoOfRoll"), TextBox)
                Dim txtReceivedQty As TextBox = CType(dgPORecDetail.Items.Item(x).FindControl("txtReceivedQty"), TextBox)
                Dim txtfreshQty As TextBox = CType(dgPORecDetail.Items.Item(x).FindControl("txtfreshQty"), TextBox)
                Dim txtBQualityQty As TextBox = CType(dgPORecDetail.Items.Item(x).FindControl("txtBQualityQty"), TextBox)
                txtVehicleNo.Text = dt.Rows(x)("VehicleNo")
                txtReceiveDate.Text = dt.Rows(x)("ReceiveDate")
                TXTLotNo.Text = dt.Rows(x)("LotNo")
                TXTNoOfRoll.Text = dt.Rows(x)("NoOfRoll")
                txtReceivedQty.Text = dt.Rows(x)("RecvQtyinBag")
                txtfreshQty.Text = dt.Rows(x)("freshQty")
                txtBQualityQty.Text = dt.Rows(x)("BQualityQty")
            Next
        Catch ex As Exception
        End Try
    End Sub
    Sub BindLocation()
        Dim dt As DataTable
        dt = objPORecvMaster.BindLocation()
        cmbLocation.DataSource = dt
        cmbLocation.DataTextField = "Location"
        cmbLocation.DataValueField = "LocationId"
        cmbLocation.DataBind()
        cmbLocation.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub RECNoGenerateOnLoad()
        Try
            Dim VoucherNo As String
            Dim Voucherdate As Date = txtPOReceiveDate.Text
            Dim year As String = Voucherdate.Year
            Dim yearP As String = Voucherdate.Year
            year = year.Substring(2, 2)
            Dim LastVoucherNo As String = objPORecvMaster.GetLastVoucherNo(yearP)
            Dim LastCode As String
            If LastVoucherNo = "" Then
                LastCode = "0001"
            Else
                LastCode = LastVoucherNo.Substring(10, 4)
                If LastCode < 10 Then
                    If LastCode = 9 Then
                        LastCode = "00" & Val(LastCode + 1)
                    Else
                        LastCode = "000" & Val(LastCode + 1)
                    End If
                ElseIf LastCode < 100 Or LastCode = 10 Then
                    If LastCode = 99 Then
                        LastCode = "0" & Val(LastCode + 1)
                    Else
                        LastCode = "00" & Val(LastCode + 1)
                    End If
                ElseIf LastCode < 1000 Or LastCode = 100 Then
                    If LastCode = 999 Then
                        LastCode = Val(LastCode + 1)
                    Else
                        LastCode = "0" & Val(LastCode + 1)
                    End If
                Else
                    LastCode = Val(LastCode + 1)
                End If
            End If
            VoucherNo = "IN" & "/" & "DAP" & "/" & year & "" & "/" & LastCode
            txtIGPNo.Text = VoucherNo
        Catch ex As Exception
        End Try
    End Sub
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgPORecDetail.PageIndexChanged
        BindGrid()
    End Sub
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgPORecDetail.SortCommand
        BindGrid()
    End Sub
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgPORecDetail.ItemDataBound
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("POReceiveViewNew.aspx")
    End Sub
    Private Sub BindGrid()
        Dim x As Integer
        Try
            Dim objDatatable As New DataTable
            If PORecvMasterID > 0 Then
                objDatatable = Session("objDataView")
            Else
                objDatatable = Session("objDataView").ToTable()
            End If
            If objDatatable.Rows.Count > 0 Then
                dgPORecDetail.Visible = True
                dgPORecDetail.RecordCount = objDatatable.Rows.Count
                dgPORecDetail.DataSource = objDatatable
                dgPORecDetail.DataBind()
            Else
                dgPORecDetail.Visible = False
            End If
            For x = 0 To dgPORecDetail.Items.Count - 1
                Dim txtVehicleNo As TextBox = CType(dgPORecDetail.Items.Item(x).FindControl("txtVehicleNo"), TextBox)
                Dim cmbOfficeLocation As DropDownList = CType(dgPORecDetail.Items.Item(x).FindControl("cmbOfficeLocation"), DropDownList)
                Dim txtReceiveDate As TextBox = CType(dgPORecDetail.Items.Item(x).FindControl("txtReceiveDate"), TextBox)
                txtReceiveDate.Text = Date.Now
            Next
        Catch ex As Exception
        End Try
    End Sub
    Function LoadData(ByVal POID As Long) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        Dim DT As DataTable = objPORecvMaster.GetDeliveryDate(cmbFabric.SelectedValue, cmbPONo.SelectedValue, cmbPartyname.SelectedValue)
        Dim ItemID As Long = DT.Rows(0)("ItemId")
        objDataTable = objPORecvMaster.GETGridDATANew2nEWNewYasirLatest(cmbPONo.SelectedValue, cmbPartyname.SelectedValue, cmbFabric.SelectedValue, ItemID)
        cmbStyle.DataSource = objDataTable
        cmbStyle.DataTextField = "Style"
        cmbStyle.DataValueField = "POID"
        cmbStyle.DataBind()
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Function LoadDataEdit(ByVal POID As Long) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objPORecvMaster.GETGridDATANew2ForEdit(cmbPONo.SelectedValue, cmbPartyname.SelectedValue, cmbFabric.SelectedValue, PORecvMasterID)
        cmbStyle.DataSource = objDataTable
        cmbStyle.DataTextField = "Style"
        cmbStyle.DataValueField = "POID"
        cmbStyle.DataBind()
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If txtIGPNo.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("IGPNo Empty.")
            ElseIf txtPOReceiveDate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Yarn Receive Date Empty.")
            ElseIf cmbPartyname.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Party Name.")
            ElseIf txtpartDCNo.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Part DCNo. Empty.")
            ElseIf cmbLocation.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Location")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                If dgPORecDetail.Items.Count > 0 Then
                    Dim x As Integer
                    Dim ReceivedQty As Decimal = 0
                    Dim TotalPOQTY As Decimal = 0
                    For x = 0 To dgPORecDetail.Items.Count - 1
                        Dim txtReceivedQty As TextBox = CType(dgPORecDetail.Items.Item(x).FindControl("txtReceivedQty"), TextBox)
                        TotalPOQTY = dgPORecDetail.Items(x).Cells(6).Text
                        ReceivedQty = Val(txtReceivedQty.Text)
                    Next
                    If PORecvMasterID > 0 Then
                        SavePOReceiveMaster()
                        Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
                        If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                            SavePOReceiveDetail()
                        ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                            SavePOReceiveDetailForAstore()
                        Else
                            SavePOReceiveDetailForAstore()
                        End If
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                        Response.Redirect("POReceiveViewNew.aspx")
                    Else
                        SavePOReceiveMaster()
                        Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
                        If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                            SavePOReceiveDetail()
                        ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                            SavePOReceiveDetailForAstore()
                        Else
                            SavePOReceiveDetailForAstore()
                        End If
                        Response.Redirect("POReceiveViewNew.aspx")
                    End If
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Detail Empty")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub CMBSeason_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBSeason.SelectedIndexChanged
        Try
            Dim dtt As DataTable = ObjIssue.GetSrNoFromIssue(CMBSeason.SelectedValue)
            CMBSrNo.DataSource = dtt
            CMBSrNo.DataValueField = "JobOrderId"
            CMBSrNo.DataTextField = "SrNo"
            CMBSrNo.DataBind()
            CMBSrNo.Items.Insert(0, New ListItem("Select", "0"))
        Catch ex As Exception
        End Try
    End Sub
    Sub SavePOReceiveMaster()
        Try
            With objPORecvMaster
                If PORecvMasterID > 0 Then
                    .PORecvMasterID = PORecvMasterID
                Else
                    .PORecvMasterID = 0
                End If
                .PORecvDate = objGeneralCode.GetDate(txtPOReceiveDate.Text)
                If PORecvMasterID > 0 Then
                Else
                    Dim dt As DataTable = objPOMaster.GetLastVoucherNoAlreadtExistForReceiving(txtIGPNo.Text)
                    If dt.Rows.Count > 0 Then
                        RECNoGenerateOnLoad()
                    End If
                End If
                .GatePassNo = txtIGPNo.Text
                .PartyDCNo = txtpartDCNo.Text
                .SupplierID = cmbPartyname.SelectedValue
                If CMBSeason.SelectedItem.Text = "Select" Then
                    .SeasonDatabaseID = 0
                    .SeasonName = ""
                Else
                    .SeasonDatabaseID = CMBSeason.SelectedValue
                    .SeasonName = CMBSeason.SelectedItem.Text
                End If
                If CMBSeason.SelectedItem.Text = "Select" Then
                    .JobOrderID = 0
                    .SrNoo = ""
                Else
                    If CMBSrNo.SelectedItem.Text = "Select" Then
                        .JobOrderID = 0
                        .SrNoo = ""
                    Else
                        .JobOrderID = CMBSrNo.SelectedValue
                        .SrNoo = CMBSrNo.SelectedItem.Text
                    End If
                End If
                If lblAuditorStatus.Text = "" Then
                    .AuditorStatus = 0
                Else
                    .AuditorStatus = lblAuditorStatus.Text
                End If
                If lblAuditorID.Text = "" Then
                    .AuditorID = 0
                Else
                    .AuditorID = lblAuditorID.Text
                End If
                Dim PartyName As String = cmbPartyname.SelectedItem.Text.Substring(0, 2).ToString()
                .POID = cmbPONo.SelectedValue
                .Style = cmbStyle.SelectedItem.Text
                .FabricRecv = cmbFabric.SelectedItem.Text
                .LocationID = cmbLocation.SelectedValue
                If lblUseriD.Text = "" Then
                    .UserID = userid
                Else
                    .UserID = lblUseriD.Text
                End If
                .SavePORecvMaster()
            End With
        Catch ex As Exception
        End Try
    End Sub
    Sub SavePOReceiveDetail()
        Try
            Dim x As Integer
            For x = 0 To dgPORecDetail.Items.Count - 1
                Dim txtReceivedQty As TextBox = CType(dgPORecDetail.Items.Item(x).FindControl("txtReceivedQty"), TextBox)
                Dim txtVehicleNo As TextBox = CType(dgPORecDetail.Items.Item(x).FindControl("txtVehicleNo"), TextBox)
                Dim cmbOfficeLocation As DropDownList = CType(dgPORecDetail.Items.Item(x).FindControl("cmbOfficeLocation"), DropDownList)
                Dim txtReceiveDate As TextBox = CType(dgPORecDetail.Items.Item(x).FindControl("txtReceiveDate"), TextBox)
                Dim TXTLotNo As TextBox = CType(dgPORecDetail.Items.Item(x).FindControl("TXTLotNo"), TextBox)
                Dim TXTNoOfRoll As TextBox = CType(dgPORecDetail.Items.Item(x).FindControl("TXTNoOfRoll"), TextBox)
                Dim txtfreshQty As TextBox = DirectCast(dgPORecDetail.Items(x).FindControl("txtfreshQty"), TextBox)
                Dim txtBQualityQty As TextBox = DirectCast(dgPORecDetail.Items(x).FindControl("txtBQualityQty"), TextBox)
                With objPORecvDetail
                    .PORecvDetailID = 0
                    If PORecvMasterID > 0 Then
                        .PORecvMasterID = PORecvMasterID
                        .PORecvDetailID = dgPORecDetail.Items(x).Cells(0).Text
                    Else
                        .PORecvMasterID = objPORecvMaster.GetID
                        .PORecvDetailID = 0
                    End If
                    .PODetailID = dgPORecDetail.Items(x).Cells(1).Text
                    .Style = dgPORecDetail.Items(x).Cells(3).Text
                    .POQuantity = dgPORecDetail.Items(x).Cells(6).Text
                    If PORecvMasterID > 0 Then
                        .RecvQuantity = Val(txtReceivedQty.Text)
                    Else
                        .RecvQuantity = Val(txtReceivedQty.Text)
                    End If
                    .VehicleNo = txtVehicleNo.Text
                    .StoreLocationID = 0
                    .ReceiveDate = txtReceiveDate.Text
                    .ReturnQty = dgPORecDetail.Items(x).Cells(18).Text
                    .ItemID = dgPORecDetail.Items(x).Cells(16).Text
                    .LotNo = TXTLotNo.Text
                    If TXTNoOfRoll.Text = "" Then
                        .NoOfRoll = 0
                    Else
                        .NoOfRoll = TXTNoOfRoll.Text
                    End If
                        .IsCompleted = 0
                        .InvoiceQty = 0
                    .freshQty = txtfreshQty.Text
                    .BQualityQty = txtBQualityQty.Text
                    .SavePORecvDetail()
                End With
                Dim txtReceivedQtyy As TextBox = CType(dgPORecDetail.Items.Item(x).FindControl("txtReceivedQty"), TextBox)
                Dim txtVehicleNoo As TextBox = CType(dgPORecDetail.Items.Item(x).FindControl("txtVehicleNo"), TextBox)
                Dim cmbOfficeLocationn As DropDownList = CType(dgPORecDetail.Items.Item(x).FindControl("cmbOfficeLocation"), DropDownList)
                Dim txtReceiveDatee As TextBox = CType(dgPORecDetail.Items.Item(x).FindControl("txtReceiveDate"), TextBox)
                With objPORecvDetailHistory
                    .PORecvDetailID = 0
                    If PORecvMasterID > 0 Then
                        .PORecvMasterID = PORecvMasterID
                    Else
                        .PORecvMasterID = objPORecvMaster.GetID
                    End If
                    .PODetailID = dgPORecDetail.Items(x).Cells(1).Text
                    .Style = dgPORecDetail.Items(x).Cells(3).Text
                    .POQuantity = dgPORecDetail.Items(x).Cells(6).Text
                    .RecvQuantity = txtReceivedQtyy.Text
                    .VehicleNo = txtVehicleNo.Text
                    .StoreLocationID = 0
                    .ReceiveDate = txtReceiveDate.Text
                    .IGPNo = txtIGPNo.Text
                    .PartyDCNo = txtpartDCNo.Text
                    .SupplierID = cmbPartyname.SelectedValue
                    .Balance = Val(dgPORecDetail.Items(x).Cells(8).Text) - Val(txtReceivedQtyy.Text)
                    .SavePORecvDetailHistory()
                End With
                With ObjIMSStoreLedger
                    .StoreLedgerID = 0
                    .IMSItemID = dgPORecDetail.Items(x).Cells(16).Text
                    .CreationDate = Date.Now()
                    .TransactionDate = Date.Now.Date()
                    .TransactionType = "SRV"
                    .OpenQty = 0
                    .OpenAmount = 0
                    .ReceiveQty = Val(txtReceivedQty.Text)
                    .ReceiveAmount = Val(txtReceivedQty.Text) * Val(dgPORecDetail.Items(x).Cells(16).Text)
                    .IssueQty = 0
                    .IssueAmount = 0
                    Dim dtQty As DataTable = ObjIMSStoreLedger.GetCloseQtyWithLocation(dgPORecDetail.Items(x).Cells(16).Text, cmbLocation.SelectedValue)
                    If dtQty.Rows.Count > 0 Then
                        .CloseQty = Val(dtQty.Rows(0)("CloseQty")) + Val(txtReceivedQty.Text)
                    Else
                        .CloseQty = Val(txtReceivedQty.Text)
                    End If
                    Dim dtAmt As DataTable = ObjIMSStoreLedger.GetCloseAmountWithLocation(dgPORecDetail.Items(x).Cells(16).Text, cmbLocation.SelectedValue)
                    If dtAmt.Rows.Count > 0 Then
                        .CloseAmount = Val(dtAmt.Rows(0)("CloseAmount")) + (Val(txtReceivedQty.Text) * Val(dgPORecDetail.Items(x).Cells(16).Text))
                    Else
                        .CloseAmount = (Val(txtReceivedQty.Text) * Val(dgPORecDetail.Items(x).Cells(16).Text))
                    End If
                    .LocationID = cmbLocation.SelectedValue
                    .SaveIMSStoreLedger()
                End With
            Next
        Catch ex As Exception
        End Try
    End Sub
    Sub SavePOReceiveDetailForAstore()
        Try
            Dim x As Integer
            For x = 0 To dgPORecDetail.Items.Count - 1
                Dim txtReceivedQty As TextBox = CType(dgPORecDetail.Items.Item(x).FindControl("txtReceivedQty"), TextBox)
                Dim txtVehicleNo As TextBox = CType(dgPORecDetail.Items.Item(x).FindControl("txtVehicleNo"), TextBox)
                Dim cmbOfficeLocation As DropDownList = CType(dgPORecDetail.Items.Item(x).FindControl("cmbOfficeLocation"), DropDownList)
                Dim txtReceiveDate As TextBox = CType(dgPORecDetail.Items.Item(x).FindControl("txtReceiveDate"), TextBox)
                Dim TXTLotNo As TextBox = CType(dgPORecDetail.Items.Item(x).FindControl("TXTLotNo"), TextBox)
                Dim TXTNoOfRoll As TextBox = CType(dgPORecDetail.Items.Item(x).FindControl("TXTNoOfRoll"), TextBox)
                Dim txtfreshQty As TextBox = DirectCast(dgPORecDetail.Items(x).FindControl("txtfreshQty"), TextBox)
                Dim txtBQualityQty As TextBox = DirectCast(dgPORecDetail.Items(x).FindControl("txtBQualityQty"), TextBox)
                Dim ChkSelect As CheckBox = DirectCast(dgPORecDetail.Items(x).FindControl("ChkSelect"), CheckBox)
                If ChkSelect.Checked = True Then
                    With objPORecvDetail
                        .PORecvDetailID = 0
                        If PORecvMasterID > 0 Then
                            .PORecvMasterID = PORecvMasterID
                            .PORecvDetailID = dgPORecDetail.Items(x).Cells(0).Text
                        Else
                            .PORecvMasterID = objPORecvMaster.GetID
                            .PORecvDetailID = 0
                        End If
                        .PODetailID = dgPORecDetail.Items(x).Cells(1).Text
                        .Style = dgPORecDetail.Items(x).Cells(3).Text
                        .POQuantity = dgPORecDetail.Items(x).Cells(6).Text
                        If PORecvMasterID > 0 Then
                            .RecvQuantity = Val(txtReceivedQty.Text)
                        Else
                            .RecvQuantity = Val(txtReceivedQty.Text)
                        End If
                        .VehicleNo = txtVehicleNo.Text
                        .StoreLocationID = 0
                        .ReceiveDate = txtReceiveDate.Text
                        .ReturnQty = dgPORecDetail.Items(x).Cells(18).Text
                        .ItemID = dgPORecDetail.Items(x).Cells(16).Text
                        .LotNo = TXTLotNo.Text
                        If TXTNoOfRoll.Text = "" Then
                            .NoOfRoll = 0
                        Else
                            .NoOfRoll = TXTNoOfRoll.Text
                        End If
                        .IsCompleted = 0
                        .InvoiceQty = 0
                        .freshQty = txtfreshQty.Text
                        .BQualityQty = txtBQualityQty.Text
                        .SavePORecvDetail()
                    End With
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub BtnAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnAdd.Click
        Try
            PnlGodowntxt.Visible = True
            PnlGodownCmb.Visible = False
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub BtnSaveGodown_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSaveGodown.Click
        Try
            If txtGodown.Text = "" Then
                With ObjLocation
                    .LocationId = 0
                    .Location = txtGodown.Text
                End With
            Else
                With ObjLocation
                    .LocationId = 0
                    .Location = txtGodown.Text
                    .SaveGodown()
                End With
            End If
        Catch ex As Exception
        End Try
        PnlGodowntxt.Visible = False
        PnlGodownCmb.Visible = True
        BindLocation()
    End Sub
    Protected Sub txtfreshQty_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            For i As Integer = 0 To dgPORecDetail.Items.Count - 1
                Dim txtfreshQty As TextBox = DirectCast(dgPORecDetail.Items(i).FindControl("txtfreshQty"), TextBox)
                Dim txtBQualityQty As TextBox = DirectCast(dgPORecDetail.Items(i).FindControl("txtBQualityQty"), TextBox)
                Dim txtReceivedQty As TextBox = DirectCast(dgPORecDetail.Items(i).FindControl("txtReceivedQty"), TextBox)
                If txtfreshQty.Text = "" Then
                    txtfreshQty.Text = 0
                End If
                If txtBQualityQty.Text = "" Then
                    txtBQualityQty.Text = 0
                End If
                txtReceivedQty.Text = Val(txtfreshQty.Text) + Val(txtBQualityQty.Text)
            Next
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtBQualityQty_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            For i As Integer = 0 To dgPORecDetail.Items.Count - 1
                Dim txtfreshQty As TextBox = DirectCast(dgPORecDetail.Items(i).FindControl("txtfreshQty"), TextBox)
                Dim txtBQualityQty As TextBox = DirectCast(dgPORecDetail.Items(i).FindControl("txtBQualityQty"), TextBox)
                Dim txtReceivedQty As TextBox = DirectCast(dgPORecDetail.Items(i).FindControl("txtReceivedQty"), TextBox)
                If txtfreshQty.Text = "" Then
                    txtfreshQty.Text = 0
                End If
                If txtBQualityQty.Text = "" Then
                    txtBQualityQty.Text = 0
                End If
                txtReceivedQty.Text = Val(txtfreshQty.Text) + Val(txtBQualityQty.Text)
            Next
        Catch ex As Exception
        End Try
    End Sub
End Class








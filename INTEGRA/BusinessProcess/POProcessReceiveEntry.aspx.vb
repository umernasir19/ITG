Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Imports System.Drawing.Color
Public Class POProcessReceiveEntry
    Inherits System.Web.UI.Page
    Dim objGeneralCode As New GeneralCode
    Dim objPORecvDetail As New POProcessRecvDetail
    Dim objPORecvMaster As New POProcessRecvMaster
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
    Dim objPORecvDetailHistory As New POProcessRecvDetailHistory
    Dim ObjIssue As New IssueMst
    Dim objPORecvMasterr As New PORecvMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PageName = Request.QueryString("PageName")
        PORecvMasterID = Request.QueryString("POProcessRecvMasterID")   ' here PORecvMasterID variable use as a POProcessRecvMasterID
        userid = Session("UserId")
        If Not Page.IsPostBack Then
            BindParty()
            BindLocation()
            BindSeason()
            BindSrNo()
            Session("objDataView") = Nothing
            If Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                lblFabItem.Text = "Fabric :"
            Else
                Dim DtCheck As DataTable = objPORecvMasterr.CheckDepartment(userid)
                If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                    lblFabItem.Text = "Fabric :"
                ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                    lblFabItem.Text = "Fabric :"
                End If
            End If
            If PORecvMasterID > 0 Then
                EditMode()
                btnSave.Text = "Update"
            Else
                btnSave.Text = "Save"
                txtPOReceiveDate.Text = Date.Today
                RECNoGenerateOnLoad()
            End If
        End If
        PageHeader("PO RECEIVING ENTRY FORM")
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
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
    Sub BindItem()
        Try
            Dim dt As DataTable
            Dim dti As DataTable
            Dim DtCheck As DataTable = objPORecvMasterr.CheckDepartment(userid)
            If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                dt = objPORecvMaster.BindItemFBDPNew(cmbPartyname.SelectedValue, cmbPONo.SelectedValue)
                cmbFabric.DataSource = dt
                cmbFabric.DataTextField = "ItemName"
                cmbFabric.DataValueField = "ProcessOrderDtlId"
                cmbFabric.DataBind()
                cmbFabric.Items.Insert(0, New ListItem("Select", "0"))
            ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                dt = objPORecvMaster.BindItemFBDPNew(cmbPartyname.SelectedValue, cmbPONo.SelectedValue)
                cmbFabric.DataSource = dt
                cmbFabric.DataTextField = "ItemName"
                cmbFabric.DataValueField = "ProcessOrderDtlId"
                cmbFabric.DataBind()
                cmbFabric.Items.Insert(0, New ListItem("Select", "0"))
            Else
                dt = objPORecvMaster.BindItemFBDPNew(cmbPartyname.SelectedValue, cmbPONo.SelectedValue)
                cmbFabric.DataSource = dt
                cmbFabric.DataTextField = "ItemName"
                cmbFabric.DataValueField = "ProcessOrderDtlId"
                cmbFabric.DataBind()
                cmbFabric.Items.Insert(0, New ListItem("Select", "0"))
            End If
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
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgPORecDetail.SortCommand
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgPORecDetail.ItemDataBound
        'BindGrid()
    End Sub
    Sub EditMode()
        Try
            Dim dt As DataTable = objPORecvMaster.GetYarnReceivingOnEditNewNew(PORecvMasterID)
                txtIGPNo.Text = dt.Rows(0)("GatePassNo")
                txtPOReceiveDate.Text = dt.Rows(0)("PORecvDate")
                cmbPartyname.SelectedValue = dt.Rows(0)("SupplierID")
                BindProcessOrder()
                cmbPONo.SelectedValue = dt.Rows(0)("ProcessOrderMstID")
                BindItem()
            cmbFabric.SelectedValue = dt.Rows(0)("ProcessOrderDtlID")
            If dt.Rows(0)("SeasonDatabaseId") <> 0 Then
                CMBSeason.SelectedValue = dt.Rows(0)("SeasonDatabaseId")
            End If
            If dt.Rows(0)("JobOrderId") <> 0 Then
                CMBSrNo.SelectedValue = dt.Rows(0)("JobOrderId")
            End If
                txtpartDCNo.Text = dt.Rows(0)("PartyDCNo")
                cmbLocation.SelectedValue = dt.Rows(0)("LocationID")
            Dim dtt As DataTable = objPORecvMaster.GetDeliveryDate(cmbFabric.SelectedValue, cmbPONo.SelectedValue, cmbPartyname.SelectedValue)
            txtDeliveryDate.Text = dtt.Rows(0)("DeliveryDate")
            txtTotalQty.Text = dtt.Rows(0)("Quantity")
            Dim dttt As DataTable = objPORecvMaster.GETGridDATANewForProcessonEdit(cmbPONo.SelectedValue, cmbPartyname.SelectedValue, cmbFabric.SelectedValue, PORecvMasterID)
            cmbStyle.DataSource = dttt
            cmbStyle.DataTextField = "Style"
            cmbStyle.DataValueField = "ProcessOrderMstID"
            cmbStyle.DataBind()

            dgPORecDetail.DataSource = dt
            dgPORecDetail.DataBind()
            dgPORecDetail.Visible = True
            pnlReceivedData.Visible = True
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

                Dim dtOfficeLocation As DataTable
                dtOfficeLocation = objPORecvMaster.BindOfficeLocations()
                cmbOfficeLocation.DataSource = dtOfficeLocation
                cmbOfficeLocation.DataTextField = "StoreLocationName"
                cmbOfficeLocation.DataValueField = "FactoryLocationID"
                cmbOfficeLocation.DataBind()
                cmbOfficeLocation.Items.Insert(0, New ListItem("Select Factory Location", "0"))
                cmbOfficeLocation.SelectedValue = dt.Rows(x)("FactoryLocationID")
                txtVehicleNo.Text = dt.Rows(x)("VehicleNo")
                txtReceiveDate.Text = dt.Rows(x)("ReceiveDate")
                TXTLotNo.Text = dt.Rows(x)("LotNo")
                TXTNoOfRoll.Text = dt.Rows(x)("NoOfRoll")
                txtReceivedQty.Text = dt.Rows(x)("RecvQtyinBag")
                txtfreshQty.Text = dt.Rows(x)("freshQty")
                txtBQualityQty.Text = dt.Rows(x)("BQualityQty")

            Next

            btnSave.Visible = True
            btnCancel.Visible = True

        Catch ex As Exception

        End Try
    End Sub

    Sub BindParty()
        Try
            Dim dt As DataTable
            dt = objPORecvMaster.BindSupplierForRecPOONew()
            cmbPartyname.DataSource = dt
            cmbPartyname.DataTextField = "SupplierName"
            cmbPartyname.DataValueField = "SupplierDatabaseid"
            cmbPartyname.DataBind()
            cmbPartyname.Items.Insert(0, New ListItem("Select", "0"))
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("POProcessReceiveViewNew.aspx")
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
                txtVehicleNo.Text = objDatatable.Rows(x)("VehicleNo")
                txtReceiveDate.Text = Date.Now
            Next
          
        Catch ex As Exception
        End Try
    End Sub

    Function LoadData(ByVal POID As Long) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        Dim DT As DataTable = objPORecvMaster.GetDeliveryDate(cmbFabric.SelectedValue, cmbPONo.SelectedValue, cmbPartyname.SelectedValue)
        Dim ItemID As Long = DT.Rows(0)("ProcessItemNameId")
        objDataTable = objPORecvMaster.GETGridDATANewForProcess(cmbPONo.SelectedValue, cmbPartyname.SelectedValue, cmbFabric.SelectedValue, ItemID)
        cmbStyle.DataSource = objDataTable
        cmbStyle.DataTextField = "Style"
        cmbStyle.DataValueField = "ProcessOrderMstID"
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
                        ReceivedQty = Val(txtReceivedQty.Text) + Convert.ToDecimal(dgPORecDetail.Items(x).Cells(7).Text)
                    Next

                    SavePOReceiveMaster()
                    SavePOReceiveDetail()
                    Response.Redirect("POProcessReceiveViewNew.aspx")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Detail Empty")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SavePOReceiveMaster()
        Try
            With objPORecvMaster
                If PORecvMasterID > 0 Then
                    .POProcessRecvMasterID = PORecvMasterID
                Else
                    .POProcessRecvMasterID = 0
                End If
                .PORecvDate = objGeneralCode.GetDate(txtPOReceiveDate.Text)
                .GatePassNo = txtIGPNo.Text
                .PartyDCNo = txtpartDCNo.Text
                .SupplierID = cmbPartyname.SelectedValue
                Dim PORecvDate As Date = txtPOReceiveDate.Text
                Dim day As String = PORecvDate.Day
                Dim Month As String = PORecvDate.Month
                Dim Year As String = PORecvDate.Year
                Dim PartyName As String = cmbPartyname.SelectedItem.Text.Substring(0, 2).ToString()
                .ProcessOrderMstID = cmbPONo.SelectedValue
                .Style = cmbStyle.SelectedItem.Text
                .FabricId = cmbFabric.SelectedValue
                .LocationID = cmbLocation.SelectedValue
                If CMBSeason.SelectedItem.Text = "Select" Then
                    .SeasonDatabaseID = 0
                    .SeasonName = ""
                Else
                    .SeasonDatabaseID = CMBSeason.SelectedValue
                    .SeasonName = CMBSeason.SelectedItem.Text
                End If
                If CMBSrNo.SelectedItem.Text = "Select" Then
                    .JobOrderID = 0
                    .SrNoo = ""
                Else
                    .JobOrderID = CMBSrNo.SelectedValue
                    .SrNoo = CMBSrNo.SelectedItem.Text
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
                Dim txtfreshQty As TextBox = CType(dgPORecDetail.Items.Item(x).FindControl("txtfreshQty"), TextBox)
                Dim txtBQualityQty As TextBox = CType(dgPORecDetail.Items.Item(x).FindControl("txtBQualityQty"), TextBox)
                With objPORecvDetail
                    .POProcessRecvDetailID = dgPORecDetail.Items(x).Cells(0).Text
                    If PORecvMasterID > 0 Then
                        .POProcessRecvMasterID = PORecvMasterID
                    Else
                        .POProcessRecvMasterID = objPORecvMaster.GetID
                    End If
                    .ProcessOrderDtlID = dgPORecDetail.Items(x).Cells(1).Text
                    .Style = dgPORecDetail.Items(x).Cells(3).Text
                    .POQuantity = dgPORecDetail.Items(x).Cells(6).Text
                    .RecvQuantity = Val(txtReceivedQty.Text)
                    .VehicleNo = txtVehicleNo.Text
                    .StoreLocationID = 0
                    .ReceiveDate = txtReceiveDate.Text
                    .ReturnQty = dgPORecDetail.Items(x).Cells(19).Text
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
                    .POProcessRecvDetailID = 0
                    If PORecvMasterID > 0 Then
                        .POProcessRecvMasterID = PORecvMasterID
                    Else
                        .POProcessRecvMasterID = objPORecvMaster.GetID
                    End If
                    .ProcessOrderDtlID = dgPORecDetail.Items(x).Cells(1).Text
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
                    .IMSItemID = dgPORecDetail.Items(x).Cells(17).Text
                    .CreationDate = Date.Now()
                    .TransactionDate = Date.Now.Date()
                    .TransactionType = "ProcessSRV"
                    .OpenQty = 0
                    .OpenAmount = 0
                    .ReceiveQty = Val(txtReceivedQty.Text)
                    .ReceiveAmount = Val(txtReceivedQty.Text) * Val(dgPORecDetail.Items(x).Cells(19).Text)
                    .IssueQty = 0
                    .IssueAmount = 0
                    'Dim dtQty As DataTable = ObjIMSStoreLedger.GetCloseQtyWithLocation(dgPORecDetail.Items(x).Cells(15).Text, cmbLocation.SelectedValue)
                    Dim dtQty As DataTable = ObjIMSStoreLedger.GetCloseQtyWithLocation(dgPORecDetail.Items(x).Cells(19).Text, cmbLocation.SelectedValue)
                    If dtQty.Rows.Count > 0 Then
                        .CloseQty = Val(dtQty.Rows(0)("CloseQty")) + Val(txtReceivedQty.Text)
                    Else
                        .CloseQty = Val(txtReceivedQty.Text)
                    End If
                    Dim dtAmt As DataTable = ObjIMSStoreLedger.GetCloseAmountWithLocation(dgPORecDetail.Items(x).Cells(19).Text, cmbLocation.SelectedValue)
                    'Dim dtAmt As DataTable = ObjIMSStoreLedger.GetCloseAmountWithLocation(dgPORecDetail.Items(x).Cells(15).Text, cmbLocation.SelectedValue)
                    If dtAmt.Rows.Count > 0 Then
                        '.CloseAmount = Val(dtAmt.Rows(0)("CloseAmount")) + (Val(txtReceivedQty.Text) * Val(dgPORecDetail.Items(x).Cells(15).Text))
                        .CloseAmount = Val(dtAmt.Rows(0)("CloseAmount")) + (Val(txtReceivedQty.Text) * Val(dgPORecDetail.Items(x).Cells(19).Text))
                    Else
                        '.CloseAmount = (Val(txtReceivedQty.Text) * Val(dgPORecDetail.Items(x).Cells(15).Text))
                        .CloseAmount = (Val(txtReceivedQty.Text) * Val(dgPORecDetail.Items(x).Cells(19).Text))
                    End If

                    .LocationID = cmbLocation.SelectedValue
                    .SaveIMSStoreLedger()
                End With
                'End If
            Next
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbPartyname_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPartyname.SelectedIndexChanged
        Try
            BindProcessOrder()
        Catch ex As Exception
        End Try
    End Sub

    Sub BindProcessOrder()
        Try
            Dim dt As DataTable
            dt = objPORecvMaster.BindPOSupNItemWiseDPNew(cmbPartyname.SelectedValue)
            cmbPONo.DataSource = dt
            cmbPONo.DataTextField = "POJO"
            cmbPONo.DataValueField = "ProcessOrderMstID"
            cmbPONo.DataBind()
            cmbPONo.Items.Insert(0, New ListItem("Select", "0"))
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub cmbPONo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPONo.SelectedIndexChanged
        Try
            BindItem()
          

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbFabric_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFabric.SelectedIndexChanged
        Try
            OnChangeEventOfBindFabric()
        Catch ex As Exception
        End Try
    End Sub
    Sub OnChangeEventOfBindFabric()
        Try

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








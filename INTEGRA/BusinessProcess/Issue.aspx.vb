Imports Integra.EuroCentra
Imports System.Data
Imports System.Data.DataTable
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Xml
Imports System.Text
Public Class Issue
    Inherits System.Web.UI.Page
    Dim ObjIssue As New IssueMst
    Dim ObjIssueDtl As New IssueDetail
    Dim dtDetail As DataTable
    Dim Dr As DataRow
    Dim PORecvMasterID As Long
    Dim userid, lIssueID As Long
    Dim ObjItem As New IMSItem
    Dim ObjIMSStoreLedger As New IMSStoreLedger
    Dim ObjLocation As New Location
    Dim ObjIMSStoreIssue As New IMSStoreIssue
    Dim ObjIMSStoreIssueDetail As New IMSStoreIssueDetail
    Dim objPORecvMaster As New PORecvMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        userid = Session("UserId")
        lIssueID = Request.QueryString("IssueID")
        If Not Page.IsPostBack Then
            Session("dtIssueDetail") = Nothing
            Session("CMBEntry") = Nothing
            BindLocation()
            BindDept()
            BindSeason()
            txtCreationDate.Text = Date.Today
            If Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                lblItemFab.Text = "Fabric Code :"
                lblItemFab.Visible = True
            Else
                Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
                If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                    lblItemFab.Text = "Fabric Code :"
                    lblItemFab.Visible = True
                ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                    lblItemFab.Text = "Item Code:"
                    lblItemFab.Visible = True
                ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                    lblItemFab.Text = "Item Code:"
                    lblItemFab.Visible = True
                End If
            End If
            If lIssueID > 0 Then
                EditMode()
                btnSave.Text = "Update"
            Else
                btnSave.Text = "Save"
                txtRemarks.Text = "N/A"
            End If
        End If
        PageHeader("ISSUE ENTRY FORM")
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub EditMode()
        Try
            Dim dt As DataTable
            dt = ObjIMSStoreIssue.GetEditDataForFabricIssueNewNew(lIssueID)
            txtCreationDate.Text = dt.Rows(0)("CreationDate")
            cmbLocation.SelectedValue = dt.Rows(0)("LocationId")
            TXTManualChallanNo.Text = dt.Rows(0)("ManualChallanNo")
            lblAuditorStatus.Text = dt.Rows(0)("AuditorStatus")
            lblAuditorID.Text = dt.Rows(0)("AuditorID")
            lblUseriD.Text = dt.Rows(0)("UserID")
            dtDetail = New DataTable
            With dtDetail
                .Columns.Add("IssueDtlID", GetType(Long))
                .Columns.Add("ItemID", GetType(String))
                .Columns.Add("ItemName", GetType(String))
                .Columns.Add("ReceiveQty", GetType(String))
                .Columns.Add("IssueQty", GetType(String))
                .Columns.Add("DeptDatabaseID", GetType(String))
                .Columns.Add("Department", GetType(String))
                .Columns.Add("Contractor", GetType(String))
                .Columns.Add("Remarks", GetType(String))
                .Columns.Add("EntryType", GetType(String))
                .Columns.Add("SeasonDatabaseID", GetType(String))
                .Columns.Add("SeasonName", GetType(String))
                .Columns.Add("JobOrderID", GetType(String))
                .Columns.Add("SrNoo", GetType(String))
                .Columns.Add("POID", GetType(String))
                .Columns.Add("PONO", GetType(String))
                .Columns.Add("Rate", GetType(String))
            End With
            Dim x As Integer
            For x = 0 To dt.Rows.Count - 1
                Dr = dtDetail.NewRow()
                Dr("IssueDtlID") = dt.Rows(x)("IssueDtlID")
                Dr("ItemID") = dt.Rows(x)("ItemID")
                Dr("ItemName") = dt.Rows(x)("ItemName")
                Dr("ReceiveQty") = dt.Rows(x)("RecvQtyy")
                Dr("IssueQty") = dt.Rows(x)("IssueQty")
                Dr("DeptDatabaseID") = dt.Rows(x)("DeptDatabaseID")
                Dr("Department") = dt.Rows(x)("DeptDatabaseName")
                Dr("Contractor") = dt.Rows(x)("Contractor")
                Dr("Remarks") = dt.Rows(x)("Remarks")
                Dr("EntryType") = dt.Rows(x)("EntryType")
                Dr("SeasonDatabaseID") = dt.Rows(x)("SeasonDatabaseIDD")
                Dr("SeasonName") = dt.Rows(x)("SeasonNAMEE")
                Dr("JobOrderID") = dt.Rows(x)("JobOrderIDD")
                Dr("SrNoo") = dt.Rows(x)("SRNOOO")
                Dr("POID") = dt.Rows(x)("POID")
                Dr("PONO") = dt.Rows(x)("PONO")
                Dr("Rate") = dt.Rows(x)("Ratee")
                dtDetail.Rows.Add(Dr)
            Next
            Session("dtIssueDetail") = dtDetail
            BindGrid()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtItemCode_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtItemCode.TextChanged
        Try
            Dim dt As DataTable = ObjIssue.GetIMSItemID(txtItemCode.Text)
            If dt.Rows.Count > 0 Then
                lblID.Text = dt.Rows(0)("IMSItemID")
                BindPONOItemWise()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub BindLocation()
        Dim dt As DataTable
        dt = ObjIssue.BindLocation()
        cmbLocation.DataSource = dt
        cmbLocation.DataTextField = "Location"
        cmbLocation.DataValueField = "LocationId"
        cmbLocation.DataBind()
        cmbLocation.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Sub BindPONo()
        Dim dt As DataTable

        If Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
            dt = ObjIssue.BindPOFabric()
        Else
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
            If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                dt = ObjIssue.BindPOFabric()
            ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                dt = ObjIssue.BindPOForAcc()
            ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                dt = ObjIssue.BindPOForAccGStore()
            End If
        End If
        cmbPoNo.DataSource = dt
        cmbPoNo.DataTextField = "PONO"
        cmbPoNo.DataValueField = "POID"
        cmbPoNo.DataBind()
        cmbPoNo.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Sub BindDept()
        Dim dt As DataTable
        If Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
            dt = ObjIssue.BindDeptFabNew()
        Else
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
            If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                dt = ObjIssue.BindDeptFabNew()
            ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                dt = ObjIssue.BindDeptFabNew()
            ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                dt = ObjIssue.BindDeptFabNew()
            End If
        End If
        cmbDept.DataSource = dt
        cmbDept.DataValueField = "DeptDatabaseID"
        cmbDept.DataTextField = "DeptDatabaseName"
        cmbDept.DataBind()
        cmbDept.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Sub BindRecvQty()
        Dim dt As DataTable
        Dim dtt As DataTable
        Try
            dt = ObjIssue.BindRecvQtyWithPOForNewIusse(cmbPoNo.SelectedValue, lblID.Text)
            txtReceive.Text = dt.Rows.Item(0)("RecvQuantity")
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
    Protected Sub cmbPoNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPoNo.SelectedIndexChanged
        Try
            Dim dtr As DataTable
            dtr = ObjIssue.GetAlreadyRecvNewNew(cmbPoNo.SelectedValue, lblID.Text)
            If dtr.Rows.Count > 0 Then
                txtAlreadyIssued.Text = dtr.Rows.Item(0)("AlreadyIssued")
            Else
                txtAlreadyIssued.Text = "0"
            End If
            BindRecvQty()
            Dim dt As DataTable
            dt = ObjIssue.GetRate(cmbPoNo.SelectedValue, lblID.Text)
            If dt.Rows.Count > 0 Then
                txtRate.Text = dt.Rows(0)("Rate")
            Else
                txtRate.Text = 0
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub BindPONOItemWise()
        Dim dt As DataTable
        If Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
            dt = ObjIssue.BindPOFabricNew(lblID.Text)
        Else
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
            If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                dt = ObjIssue.BindPOFabricNew(lblID.Text)
            ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                dt = ObjIssue.BindPOFabricNewAcc(lblID.Text)
            ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                dt = ObjIssue.BindPOFabricNewAccGStore(lblID.Text)
            End If
        End If
       cmbPoNo.DataSource = dt
        cmbPoNo.DataTextField = "POJO"
        cmbPoNo.DataValueField = "POID"
        cmbPoNo.DataBind()
        cmbPoNo.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Sub SaveSession()
        If (Not CType(Session("dtIssueDetail"), DataTable) Is Nothing) Then
            dtDetail = Session("dtIssueDetail")
        Else
            dtDetail = New DataTable
            With dtDetail
                .Columns.Add("IssueDtlID", GetType(Long))
                .Columns.Add("ItemID", GetType(String))
                .Columns.Add("ItemName", GetType(String))
                .Columns.Add("ReceiveQty", GetType(String))
                .Columns.Add("IssueQty", GetType(String))
                .Columns.Add("DeptDatabaseID", GetType(String))
                .Columns.Add("Department", GetType(String))
                .Columns.Add("Contractor", GetType(String))
                .Columns.Add("Remarks", GetType(String))
                .Columns.Add("EntryType", GetType(String))
                .Columns.Add("SeasonDatabaseID", GetType(String))
                .Columns.Add("SeasonName", GetType(String))
                .Columns.Add("JobOrderID", GetType(String))
                .Columns.Add("SrNoo", GetType(String))
                .Columns.Add("POID", GetType(String))
                .Columns.Add("PONO", GetType(String))
                .Columns.Add("Rate", GetType(String))
            End With
        End If
        Dr = dtDetail.NewRow()
        If lblIssueDtlID.Text = "" Then
            Dr("IssueDtlID") = 0
        Else
            Dr("IssueDtlID") = lblIssueDtlID.Text
        End If
        Dr("ItemID") = lblID.Text
        Dim dt As DataTable = ObjIssue.GetIMSItemNameForIssue(txtItemCode.Text)
        Dr("ItemName") = dt.Rows(0)("ItemName")
        Dr("ReceiveQty") = txtReceive.Text
        Dr("IssueQty") = txtIssue.Text
        Dr("DeptDatabaseID") = cmbDept.SelectedValue
        Dr("Department") = cmbDept.SelectedItem.Text
        Dr("Contractor") = txtContractor.Text
        If txtRemarks.Text = "" Then
            Dr("Remarks") = "N/A"
        Else
            Dr("Remarks") = txtRemarks.Text
        End If
        If txtEntryType.Text = "" Then
            Dr("EntryType") = ""
        Else
            Dr("EntryType") = txtEntryType.Text
        End If
        If CMBSeason.SelectedItem.Text = "Select" Then
            Dr("SeasonDatabaseID") = 0
            Dr("SeasonName") = ""
        Else
            Dr("SeasonDatabaseID") = CMBSeason.SelectedValue
            Dr("SeasonName") = CMBSeason.SelectedItem.Text
        End If
        If chkSrNo.Checked = True Then
            If CMBSrNo.SelectedItem.Text = "Select" Then
                Dr("JobOrderID") = 0
                Dr("SrNoo") = ""
            Else
                Dr("JobOrderID") = CMBSrNo.SelectedValue
                Dr("SrNoo") = CMBSrNo.SelectedItem.Text
            End If
        Else
            Dr("JobOrderID") = 0
            Dr("SrNoo") = ""
        End If
        Dr("POID") = cmbPoNo.SelectedValue
        Dr("PONO") = cmbPoNo.SelectedItem.Text
        If txtRate.Text = "" Then
            Dr("Rate") = 0
        Else
            Dr("Rate") = txtRate.Text
        End If
        dtDetail.Rows.Add(Dr)
        Session("dtIssueDetail") = dtDetail
    End Sub
    Private Sub BindGrid()
        Try
            Dim objDatatble As DataTable
            objDatatble = Session("dtIssueDetail")
            dgAdd.Visible = True
            dgAdd.RecordCount = objDatatble.Rows.Count
            dgAdd.DataSource = objDatatble
            dgAdd.DataBind()      
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            If Val(txtIssue.Text) + Val(txtAlreadyIssued.Text) > Val(txtReceive.Text) Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Issue is Greater")
            ElseIf txtIssue.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Issue Qty Empty")
            ElseIf cmbDept.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Dept.")
            ElseIf cmbDept.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Dept.")
            Else
                If chkSrNo.Checked = True Then
                    If CMBSeason.SelectedItem.Text = "Select" Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Season.")
                    ElseIf CMBSrNo.SelectedItem.Text = "Select" Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Sr No.")
                    Else
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                        SaveSession()
                        BindGrid()
                        clear()
                        btnSave.Visible = True
                        btnCancel.Visible = True
                        BindSeason()
                        UmbindSrNo()
                        UNBINDPO()
                    End If
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    SaveSession()
                    BindGrid()
                    clear()
                    btnSave.Visible = True
                    btnCancel.Visible = True
                    BindSeason()
                    UmbindSrNo()
                    UNBINDPO()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub UNBINDPO()
        Dim dt As DataTable
        dt = ObjIssue.BindPOFabricNew(0)
        cmbPoNo.DataSource = dt
        cmbPoNo.DataTextField = "POJO"
        cmbPoNo.DataValueField = "POID"
        cmbPoNo.DataBind()
        cmbPoNo.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Sub UmbindSrNo()
        Dim dtt As DataTable = ObjIssue.GetSrNoFromIssue(0)
        CMBSrNo.DataSource = dtt
        CMBSrNo.DataValueField = "JobOrderId"
        CMBSrNo.DataTextField = "SrNo"
        CMBSrNo.DataBind()
    End Sub
    Sub clear()
        Try
            txtIssue.Text = ""
            cmbDept.SelectedValue = 0
            txtContractor.Text = ""
            txtRemarks.Text = ""
            txtEntryType.Text = ""
            lblID.Text = ""
            txtItemCode.Text = ""
            txtAlreadyIssued.Text = ""
            txtIssue.Text = ""
            txtReceive.Text = ""
            txtRate.Text = ""
        Catch ex As Exception
        End Try
    End Sub
    Sub save()
        With ObjIssue
            If lIssueID > 0 Then
                .IssueID = lIssueID
            Else
                .IssueID = 0
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
            .POType = "N/A"
            .CreationDate = txtCreationDate.Text
            If Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                .FabricStatus = True
            Else
                Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
                If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                    .FabricStatus = True
                ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                    .FabricStatus = False
                ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                    .FabricStatus = False
                End If
            End If
            .LocationId = cmbLocation.SelectedValue
            .ManualChallanNo = TXTManualChallanNo.Text.ToUpper
            If lblUseriD.Text = "" Then
                .UserID = userid
            Else
                .UserID = lblUseriD.Text
            End If
            .saveIssue()
        End With
    End Sub
    Sub savedtl()
        Try
            Dim x As Integer
            For x = 0 To dgAdd.Items.Count - 1
                With ObjIssueDtl
                    .IssueDtlID = dgAdd.Items(x).Cells(0).Text
                    If lIssueID > 0 Then
                        .IssueID = lIssueID
                    Else
                        .IssueID = ObjIssue.GetID()
                    End If
                    .ItemID = dgAdd.Items(x).Cells(1).Text
                    .DeptDatabaseID = dgAdd.Items(x).Cells(2).Text
                    .Contractor = dgAdd.Items(x).Cells(8).Text
                    .RecvQty = dgAdd.Items(x).Cells(5).Text
                    .IssueQty = dgAdd.Items(x).Cells(6).Text
                    .Remarks = dgAdd.Items(x).Cells(9).Text
                    .EntryType = dgAdd.Items(x).Cells(4).Text
                    .IssueReturn = 0
                    .Rate = dgAdd.Items(x).Cells(16).Text
                    .SeasonDatabaseID = dgAdd.Items(x).Cells(10).Text
                    .SeasonName = dgAdd.Items(x).Cells(12).Text.Replace("&nbsp;", "")
                    .JobOrderID = dgAdd.Items(x).Cells(11).Text
                    .SrNoo = dgAdd.Items(x).Cells(13).Text.Replace("&nbsp;", "")
                    .POID = dgAdd.Items(x).Cells(14).Text
                    .saveIssueDtl()
                End With
                If lIssueID > 0 Then
                Else
                    With ObjIMSStoreLedger
                        .StoreLedgerID = 0
                        .IMSItemID = dgAdd.Items(x).Cells(1).Text
                        .CreationDate = Date.Now()
                        .TransactionDate = Date.Now.Date()
                        .TransactionType = "PO-Issue"
                        .OpenQty = 0
                        .OpenAmount = 0
                        .ReceiveQty = 0
                        .ReceiveAmount = 0
                        .IssueQty = dgAdd.Items(x).Cells(6).Text
                        .IssueAmount = 0
                        Dim dtQty As DataTable = ObjIMSStoreLedger.GetCloseQtyWithLocation(dgAdd.Items(x).Cells(1).Text, cmbLocation.SelectedValue)
                        If dtQty.Rows.Count > 0 Then
                            .CloseQty = Val(dtQty.Rows(0)("CloseQty")) - Val(dgAdd.Items(x).Cells(6).Text)
                        Else
                            .CloseQty = -Val(dgAdd.Items(x).Cells(6).Text)
                        End If
                        .CloseAmount = 0
                        .LocationID = cmbLocation.SelectedValue
                        .SaveIMSStoreLedger()
                    End With
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If cmbLocation.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Select location")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                save()
                savedtl()
                Response.Redirect("IssueView.aspx")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("IssueView.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtIssue_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIssue.TextChanged
        Try
            Dim a As Integer = 0
            
          If Val(txtAlreadyIssued.Text) + Val(txtIssue.Text) > Val(txtReceive.Text) Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Issue Exceed.")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                End If

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub BtnAddGodwn_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnAddGodwn.Click
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
    Protected Sub dgAdd_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgAdd.ItemCommand
        Try
            Select Case e.CommandName
                Case "Edit"
                    dtDetail = CType(Session("dtIssueDetail"), DataTable)
                    If (Not dtDetail Is Nothing) Then
                        If (dtDetail.Rows.Count > 0) Then
                            Dim IssueDetailId As Integer = dgAdd.Items(e.Item.ItemIndex).Cells(0).Text
                            SetDetailValuesByDataTable(e.Item.ItemIndex)
                            dtDetail.Rows.RemoveAt(e.Item.ItemIndex)
                            BindGrid()
                            btnAdd.Visible = True
                        End If
                    End If
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Sub SetDetailValuesByDataTable(ByVal dtrowNo As Long)
        Try
            If dtDetail.Rows(dtrowNo)("SeasonDatabaseID") > 0 Then
                CMBSeason.SelectedValue = dtDetail.Rows(dtrowNo)("SeasonDatabaseID")
                Dim dtttd As DataTable = ObjIssue.GetSrNoFromIssue(CMBSeason.SelectedValue)
                CMBSrNo.DataSource = dtttd
                CMBSrNo.DataValueField = "JobOrderId"
                CMBSrNo.DataTextField = "SrNo"
                CMBSrNo.DataBind()
                CMBSrNo.Items.Insert(0, New ListItem("Select", "0"))
            Else
                BindSeason()
            End If
            If dtDetail.Rows(dtrowNo)("JobOrderID") > 0 Then

                CMBSrNo.SelectedValue = dtDetail.Rows(dtrowNo)("JobOrderID")
            Else
                CMBSrNo.SelectedItem.Text = "Select"
            End If
            lblIssueDtlID.Text = dtDetail.Rows(dtrowNo)("IssueDtlID")
            BindDept()
            cmbDept.SelectedValue = dtDetail.Rows(dtrowNo)("DeptDatabaseID")
            lblID.Text = dtDetail.Rows(dtrowNo)("ItemID")
            Dim dt As DataTable = ObjIssue.GetItemCode(lblID.Text)
            Dim dtt As DataTable
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
            If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                dtt = ObjIssue.BindPOFabricNew(lblID.Text)
            ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                dtt = ObjIssue.BindPOFabricNewForAstore(lblID.Text)
            End If
            cmbPoNo.DataSource = dtt
            cmbPoNo.DataTextField = "POJO"
            cmbPoNo.DataValueField = "POID"
            cmbPoNo.DataBind()
            Dim dttt As DataTable = ObjIssue.BindRecvQtyWithStyleNewNew(lblID.Text, cmbPoNo.SelectedValue)
            txtItemCode.Text = dt.Rows(0)("ItemCodee")
            txtReceive.Text = dtDetail.Rows(dtrowNo)("ReceiveQty")
            txtIssue.Text = dtDetail.Rows(dtrowNo)("IssueQty")
            Dim dtr As DataTable
            dtr = ObjIssue.GetAlreadyRecvNewNew(cmbPoNo.SelectedValue, lblID.Text)
            If dtr.Rows.Count > 0 Then
                txtAlreadyIssued.Text = dtr.Rows.Item(0)("AlreadyIssued") - Val(dtDetail.Rows(dtrowNo)("IssueQty"))
            Else
                txtAlreadyIssued.Text = "0"
            End If
            txtContractor.Text = dtDetail.Rows(dtrowNo)("Contractor")
            txtRemarks.Text = dtDetail.Rows(dtrowNo)("Remarks")
            txtEntryType.Text = dtDetail.Rows(dtrowNo)("EntryType")
            txtRate.Text = dtDetail.Rows(dtrowNo)("Rate")
        Catch ex As Exception
        End Try
    End Sub
End Class


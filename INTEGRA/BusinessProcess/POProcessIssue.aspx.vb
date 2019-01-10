Imports Integra.EuroCentra
Imports System.Data
Imports System.Data.DataTable
Public Class POProcessIssue
    Inherits System.Web.UI.Page
    Dim ObjIssue As New POProcessIssueMst
    Dim ObjIssueDtl As New POProcessIssueDetail
    Dim dtDetail As DataTable
    Dim Dr As DataRow
    Dim PORecvMasterID, lProcessIssueID As Long
    Dim userid As Long
    Dim ObjItem As New IMSItem
    Dim ObjIMSStoreLedger As New IMSStoreLedger
    Dim ObjLocation As New Location
    Dim objIssueMstnew As New IssueMst
    Dim ObjIMSStoreIssue As New IMSStoreIssue
    Dim ObjIMSStoreIssueDetail As New IMSStoreIssueDetail
    Dim ObjIssueNew As New IssueMst
    Dim objPORecvMaster As New PORecvMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        userid = Session("UserId")
        lProcessIssueID = Request.QueryString("ProcessIssueID")
        If Not Page.IsPostBack Then
            Session("dtIssueDetail") = Nothing
            Session("CMBEntry") = Nothing
            BindLocation()
            BindSeason()
            BindSrNo()
            BindDept()
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
                End If
            End If

            If lProcessIssueID > 0 Then
                EditMode()
                btnSave.Text = "Update"
                btnSave.Visible = True
                btnCancel.Visible = True
            Else
                btnSave.Text = "Save"
                txtRemarks.Text = "N/A"
                btnCancel.Visible = True
            End If



        End If
        PageHeader("PROCESS ISSUE ENTRY FORM")
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub EditMode()
        Try
            Dim dt As DataTable = ObjIMSStoreIssue.GetEditDataForProcessIssue(lProcessIssueID)
            txtCreationDate.Text = dt.Rows(0)("CreationDate")
            cmbLocation.SelectedValue = dt.Rows(0)("LocationId")
            TXTManualChallanNo.Text = dt.Rows(0)("ManualChallanNo")
            lblID.Text = dt.Rows(0)("ItemID")
            'If dt.Rows(0)("SeasonDatabaseId") <> 0 Then
            '    CMBSeason.SelectedValue = dt.Rows(0)("SeasonDatabaseId")
            'End If
            'If dt.Rows(0)("JobOrderId") <> 0 Then
            '    CMBSrNo.SelectedValue = dt.Rows(0)("JobOrderId")
            'End If
            Dim dtt As DataTable = objIssueMstnew.BindPOFabricNewNewForProcess(lblID.Text)
            cmbPoNo.DataSource = dtt
            cmbPoNo.DataValueField = "ProcessOrderMstID"
            cmbPoNo.DataTextField = "POJO"
            cmbPoNo.DataBind()
            cmbPoNo.SelectedValue = dt.Rows(0)("ProcessOrderMstID")
            Dim dttt As DataTable = objIssueMstnew.GetItemCode(lblID.Text)
            txtItemCode.Text = dttt.Rows(0)("ItemCodee")
            Dim dtr As DataTable
            dtr = objIssueMstnew.GetAlreadyRecvNewNewForProcessIssue(cmbPoNo.SelectedValue, lblID.Text)
            If dtr.Rows.Count > 0 Then
                txtAlreadyIssued.Text = dtr.Rows.Item(0)("AlreadyIssued")
            Else
                txtAlreadyIssued.Text = "0"
            End If

            Dim dtRate As DataTable
            dtRate = ObjIssue.GetRate(cmbPoNo.SelectedValue, lblID.Text)
            If dtRate.Rows.Count > 0 Then
                txtRate.Text = dtRate.Rows(0)("Rate")
            Else
                txtRate.Text = 0
            End If

            BindRecvQty()
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
            End With
            Dim x As Integer
            For x = 0 To dt.Rows.Count - 1
                Dr = dtDetail.NewRow()
                Dr("IssueDtlID") = dt.Rows(x)("ProcessIssueDtlID")
                Dr("ItemID") = dt.Rows(x)("ItemID")
                Dr("ItemName") = dt.Rows(x)("ItemName")
                Dr("ReceiveQty") = dt.Rows(x)("RecvQty")
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
                dtDetail.Rows.Add(Dr)
            Next
            Session("dtIssueDetail") = dtDetail
            BindGrid()

        Catch ex As Exception
        End Try
    End Sub
    Sub BindSeason()
        Dim dt As DataTable = objIssueMstnew.GetSeasonFromIssue()
        CMBSeason.DataSource = dt
        CMBSeason.DataValueField = "SeasonDatabaseId"
        CMBSeason.DataTextField = "SeasonName"
        CMBSeason.DataBind()
        CMBSeason.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Sub BindSrNo()
        Dim dtt As DataTable = objIssueMstnew.GetSrNoFromIssueForAny()
        CMBSrNo.DataSource = dtt
        CMBSrNo.DataValueField = "JobOrderId"
        CMBSrNo.DataTextField = "SrNo"
        CMBSrNo.DataBind()
        CMBSrNo.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Protected Sub CMBSeason_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBSeason.SelectedIndexChanged
        Try
            Dim dtt As DataTable = objIssueMstnew.GetSrNoFromIssue(CMBSeason.SelectedValue)
            CMBSrNo.DataSource = dtt
            CMBSrNo.DataValueField = "JobOrderId"
            CMBSrNo.DataTextField = "SrNo"
            CMBSrNo.DataBind()
            CMBSrNo.Items.Insert(0, New ListItem("Select", "0"))
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtItemCode_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtItemCode.TextChanged
        Try
            Dim dt As DataTable = objIssueMstnew.GetIMSItemID(txtItemCode.Text)
            If dt.Rows.Count > 0 Then
                lblID.Text = dt.Rows(0)("IMSItemID")
                BindPONOItemWise()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub BindLocation()
        Dim dt As DataTable
        dt = objIssueMstnew.BindLocation()
        cmbLocation.DataSource = dt
        cmbLocation.DataTextField = "Location"
        cmbLocation.DataValueField = "LocationId"
        cmbLocation.DataBind()
        cmbLocation.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Sub BindPONo()
        Dim dt As DataTable
        If Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
            dt = objIssueMstnew.BindPOFabricForProcessIssue()
        Else
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
            If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                dt = objIssueMstnew.BindPOFabricForProcessIssue()
            ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                dt = objIssueMstnew.BindPO()
            End If
        End If
        cmbPoNo.DataSource = dt
        cmbPoNo.DataTextField = "PONO"
        cmbPoNo.DataValueField = "ProcessOrderMstID"
        cmbPoNo.DataBind()
        cmbPoNo.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Sub BindDept()
        Dim dt As DataTable
        If Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
            dt = objIssueMstnew.BindDeptFabNew()
        Else
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
            If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                dt = objIssueMstnew.BindDeptFabNew()
            ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                dt = objIssueMstnew.BindDept()
            End If
        End If
        cmbDept.DataSource = dt
        cmbDept.DataValueField = "DeptDatabaseID"
        cmbDept.DataTextField = "DeptDatabaseName"
        cmbDept.DataBind()
        cmbDept.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Sub BindRecvQty()
        Dim dt, dtt As DataTable
        Try
            dt = objIssueMstnew.BindRecvQtyWithPONewNewNew(cmbPoNo.SelectedValue, lblID.Text)
            ' dtt = ObjIssueNew.GetQtyyyyyyyFORGodwonForprocess(lblID.Text)
            txtReceive.Text = dt.Rows.Item(0)("RecvQuantity") '+ dtt.Rows(0)("QtyIssue")
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbPoNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPoNo.SelectedIndexChanged
        Try
            Dim dtr As DataTable
            dtr = objIssueMstnew.GetAlreadyRecvNewNewForProcessIssue(cmbPoNo.SelectedValue, lblID.Text)
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

        dt = objIssueMstnew.BindPOFabricNewForProcessIssue(lblID.Text)
        cmbPoNo.DataSource = dt
        cmbPoNo.DataTextField = "POJO"
        cmbPoNo.DataValueField = "ProcessOrderMstID"
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
            End With
        End If
        Dr = dtDetail.NewRow()
        If lblIssueDtlID.Text = "" Then
            Dr("IssueDtlID") = 0
        Else
            Dr("IssueDtlID") = lblIssueDtlID.Text
        End If
       Dr("ItemID") = lblID.Text
        Dim dt As DataTable = objIssueMstnew.GetIMSItemNameForIssue(txtItemCode.Text)
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
            Dr("EntryType") = "N/A"
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
        If CMBSrNo.SelectedItem.Text = "Select" Then
            Dr("JobOrderID") = 0
            Dr("SrNoo") = ""
        Else
            Dr("JobOrderID") = CMBSrNo.SelectedValue
            Dr("SrNoo") = CMBSrNo.SelectedItem.Text
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
                If Val(txtIssue.Text) > Val(txtReceive.Text) - Val(txtAlreadyIssued.Text) Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Issue is Greater")
                ElseIf txtIssue.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Issue Empty")
                ElseIf cmbDept.SelectedValue = 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Dept.")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    SaveSession()
                    BindGrid()
                    clear()
                    btnSave.Visible = True
                    btnCancel.Visible = True
                End If
        Catch ex As Exception
        End Try
    End Sub
    Sub clear()
        Try
            txtReceive.Text = ""
            txtIssue.Text = ""
            cmbDept.SelectedValue = 0
            txtContractor.Text = ""
            txtRemarks.Text = ""
            txtAlreadyIssued.Text = ""
            txtEntryType.Text = ""
        Catch ex As Exception
        End Try
    End Sub
    Sub save()
        With ObjIssue
            If lProcessIssueID > 0 Then
                .processIssueID = lProcessIssueID
            Else
                .processIssueID = 0
            End If
            .POType = "N/A"
            .CreationDate = txtCreationDate.Text
                    .ProcessOrderMstID = cmbPoNo.SelectedValue
            .FabricStatus = True
            .LocationId = cmbLocation.SelectedValue
            .ManualChallanNo = TXTManualChallanNo.Text.ToUpper
            'If CMBSeason.SelectedItem.Text = "Select" Then
            '    .SeasonDatabaseID = 0
            '    .SeasonName = ""
            'Else
            '    .SeasonDatabaseID = CMBSeason.SelectedValue
            '    .SeasonName = CMBSeason.SelectedItem.Text
            'End If
            'If CMBSrNo.SelectedItem.Text = "Select" Then
            '    .JobOrderID = 0
            '    .SrNoo = ""
            'Else
            '    .JobOrderID = CMBSrNo.SelectedValue
            '    .SrNoo = CMBSrNo.SelectedItem.Text
            'End If
            .saveIssue()
        End With
    End Sub
    Sub savedtl()
        Try
            Dim x As Integer
            For x = 0 To dgAdd.Items.Count - 1
                With ObjIssueDtl
                    .processIssueDtlID = dgAdd.Items(x).Cells(0).Text
                    If lProcessIssueID > 0 Then
                        .processIssueID = lProcessIssueID

                    Else
                        .processIssueID = ObjIssue.GetID()
                    End If
                    .ItemID = dgAdd.Items(x).Cells(1).Text
                    .DeptDatabaseID = dgAdd.Items(x).Cells(2).Text
                    .Contractor = dgAdd.Items(x).Cells(8).Text
                    .RecvQty = dgAdd.Items(x).Cells(5).Text
                    .IssueQty = dgAdd.Items(x).Cells(6).Text
                    .Remarks = dgAdd.Items(x).Cells(9).Text
                    .EntryType = dgAdd.Items(x).Cells(4).Text
                    .IssueReturn = 0
                    .Rate = txtRate.Text
                    .SeasonDatabaseID = dgAdd.Items(x).Cells(10).Text
                    .SeasonName = dgAdd.Items(x).Cells(12).Text.Replace("&nbsp;", "")
                    .JobOrderID = dgAdd.Items(x).Cells(11).Text
                    .SrNoo = dgAdd.Items(x).Cells(13).Text.Replace("&nbsp;", "")

                    .saveIssueDtl()
                End With
                If lProcessIssueID > 0 Then
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
            End If
            Response.Redirect("POProcessIssueView.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("POProcessIssueView.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtIssue_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIssue.TextChanged
        Try
           
                If Val(txtAlreadyIssued.Text) + Val(txtIssue.Text) > Val(txtReceive.Text) Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Issue Exceed.")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                End If

        Catch ex As Exception
        End Try
    End Sub
    'Protected Sub cmbEntryType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbEntryType.SelectedIndexChanged
    '    Try
    '        EntryType()
    '    Catch ex As Exception
    '    End Try
    'End Sub
    'Sub EntryType()
    '    If cmbEntryType.SelectedItem.Text = "In Stock" Then
    '        lblItemFab.Text = "Enter Item :"
    '        ' tdItem.Visible = False
    '        ' '  tdPOLabel.Visible = False
    '        '  tdcmbPONO.Visible = False
    '        cmbDept.Style.Value = "margin-left: 0px;"
    '        txtContractor.Style.Value = "margin-left: -197px;"
    '        tdRecv.Style.Value = "margin-left: -109px;"
    '        tdShowMe.Visible = True
    '        Session("CMBEntry") = cmbEntryType.SelectedItem.Text
    '    ElseIf cmbEntryType.SelectedItem.Text = "New Entry" Then
    '        If userid = 241 Then
    '            lblItemFab.Text = "Fabric :"
    '        Else
    '            lblItemFab.Text = "Item :"
    '        End If
    '        cmbDept.Style.Value = "margin-left: 10px;"
    '        txtContractor.Style.Value = "margin-left: 0px;"
    '        tdRecv.Style.Value = "margin-left: 0px;"
    '        ' tdItem.Visible = True
    '        ' tdPOLabel.Visible = True
    '        '   tdcmbPONO.Visible = True
    '        tdShowMe.Visible = False

    '    End If
    'End Sub
    'Protected Sub txtSearchItem_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearchItem.TextChanged
    '    Try
    '        If txtSearchItem.Text = "" Then
    '            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Enter Valid ItemName")
    '        ElseIf txtSearchItem.Text <> "" Then

    '            GetRecvData()
    '            Dim dtr As DataTable

    '            dtr = objIssueMstnew.GetAlreadyRecvNew(lblIMSItemId.Text)
    '            If dtr.Rows.Count > 0 Then
    '                txtAlreadyIssued.Text = dtr.Rows.Item(0)("AlreadyIssued")
    '            Else
    '                txtAlreadyIssued.Text = "0"
    '            End If

    '            BindRecvQtyEntryTypeWise()


    '        End If
    '    Catch ex As Exception
    '    End Try
    'End Sub
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
            Else
                CMBSeason.SelectedItem.Text = "Select"
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
            Dim dt As DataTable = objIssueMstnew.GetItemCode(lblID.Text)
            Dim dtt As DataTable = objIssueMstnew.BindPOFabricNewForProcess(lblID.Text)
            cmbPoNo.DataSource = dtt
            cmbPoNo.DataTextField = "POJO"
            cmbPoNo.DataValueField = "ProcessOrderMstID"
            cmbPoNo.DataBind()
            txtItemCode.Text = dt.Rows(0)("ItemCodee")
            txtReceive.Text = dtDetail.Rows(dtrowNo)("ReceiveQty")
            txtIssue.Text = dtDetail.Rows(dtrowNo)("IssueQty")
            txtAlreadyIssued.Text = Val(txtAlreadyIssued.Text) - Val(dtDetail.Rows(dtrowNo)("IssueQty"))
            txtContractor.Text = dtDetail.Rows(dtrowNo)("Contractor")
            txtRemarks.Text = dtDetail.Rows(dtrowNo)("Remarks")
            txtEntryType.Text = dtDetail.Rows(dtrowNo)("EntryType")
        Catch ex As Exception
        End Try
    End Sub
End Class
Imports Integra.EuroCentra
Imports System.Data
Imports System.Data.DataTable
Public Class IssueProcessOr
    Inherits System.Web.UI.Page
    Dim ObjIssue As New IssueProcessMst
    Dim ObjIssueDtl As New IssueProcessDetail
    Dim dtDetail As DataTable
    Dim Dr As DataRow
    Dim PORecvMasterID As Long
    Dim userid As Long
    Dim ObjItem As New IMSItem
    Dim ObjIMSStoreLedger As New IMSStoreLedger
    Dim ObjLocation As New Location
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        userid = Session("UserId")
        If Not Page.IsPostBack Then
            Session("dtIssueProcessDetail") = Nothing
            Session("CMBEntry") = Nothing
            BindLocation()

            EntryType()
            BindDept()
            txtCreationDate.Text = Date.Today
            If userid = 241 Then
                lblItemFab.Text = "Fabric Code :"
                lblItemFab.Visible = True
            Else
                lblItemFab.Text = "Item Code:"
                lblItemFab.Visible = True
            End If
            txtRemarks.Text = "N/A"
        End If
    End Sub
    Protected Sub txtItemCode_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtItemCode.TextChanged
        Try
            Dim dt As DataTable = ObjIssue.GetIMSItemID(txtItemCode.Text)
            If dt.Rows.Count > 0 Then
                lblID.Text = dt.Rows(0)("IMSItemID")
                BindPONOItemWise()

                GetRecvData()
                Dim dtr As DataTable
                dtr = ObjIssue.GetAlreadyRecvNew(cmbPoNo.SelectedValue, lblID.Text)
                If dtr.Rows.Count > 0 Then
                    txtAlreadyIssued.Text = dtr.Rows.Item(0)("AlreadyIssued")
                Else
                    txtAlreadyIssued.Text = "0"
                End If
                BindRecvQty()

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
        If userid = 241 Then
            dt = ObjIssue.BindPOFabric()
        Else
            dt = ObjIssue.BindPO()
        End If
        cmbPoNo.DataSource = dt
        cmbPoNo.DataTextField = "PONO"
        cmbPoNo.DataValueField = "ProcessOrderMstID"
        cmbPoNo.DataBind()
        cmbPoNo.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    'Sub BindItemName()
    '    Dim dt As DataTable
    '    dt = ObjIssue.BindItemWithStyle(cmbPoNo.SelectedValue)
    '    cmbItemName.DataSource = dt
    '    cmbItemName.DataValueField = "ItemID"
    '    cmbItemName.DataTextField = "ItemName"
    '    cmbItemName.DataBind()
    '    cmbItemName.Items.Insert(0, New ListItem("Select", "0"))
    'End Sub
    Sub BindDept()
        Dim dt As DataTable
        If userid = 241 Then
            dt = ObjIssue.BindDeptFabNew()
        Else
            dt = ObjIssue.BindDept()
        End If
        cmbDept.DataSource = dt
        cmbDept.DataValueField = "DeptDatabaseID"
        cmbDept.DataTextField = "DeptDatabaseName"
        cmbDept.DataBind()
        cmbDept.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Sub BindRecvQtyEntryTypeWise()
        Dim dt As DataTable
        Try
            dt = ObjIssue.BindRecvQtyWithEntryType(lblIMSItemId.Text)
            txtReceive.Text = dt.Rows.Item(0)("RecvQuantity")
            lblPORecvDetailId.Text = dt.Rows.Item(0)("POProcessRecvDetailID")
            txtEntryType.Text = dt.Rows.Item(0)("EntryType")
        Catch ex As Exception

        End Try
    End Sub
    Sub BindRecvQty()
        Dim dt As DataTable
        Try
            dt = ObjIssue.BindRecvQtyWithStyleNewNew(lblID.Text, cmbPoNo.SelectedValue)
            txtReceive.Text = dt.Rows.Item(0)("RecvQuantity")
            lblPORecvDetailId.Text = dt.Rows.Item(0)("POProcessRecvDetailID")

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub cmbPoNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPoNo.SelectedIndexChanged
        Try
            GetRecvData()
            Dim dtr As DataTable
            dtr = ObjIssue.GetAlreadyRecvNew(cmbPoNo.SelectedValue, lblID.Text)
            If dtr.Rows.Count > 0 Then
                txtAlreadyIssued.Text = dtr.Rows.Item(0)("AlreadyIssued")
            Else
                txtAlreadyIssued.Text = "0"
            End If
            BindRecvQty()
        Catch ex As Exception

        End Try
    End Sub
    Sub GetRecvData()
        Dim dt As DataTable
        If cmbEntryType.SelectedItem.Text = "In Stock" Then
            'dt = ObjIssue.GetPoMstByInStockItem(txtSearchItem.Text)
            'lblIMSItemId.Text = dt.Rows.Item(0)("IMSItemId")
        Else
            dt = ObjIssue.GetPoMstrecvidNew(cmbPoNo.SelectedValue)
            lblPORecvMasterID.Text = dt.Rows.Item(0)("POProcessRecvMasterID")
        End If
    End Sub
    'Protected Sub cmbItemName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbItemName.SelectedIndexChanged
    '    Try
    '        BindPONOItemWise()

    '    Catch ex As Exception
    '    End Try
    'End Sub
    Sub BindPONOItemWise()
        Dim dt As DataTable

        dt = ObjIssue.BindPOFabricNew(lblID.Text)
        cmbPoNo.DataSource = dt
        cmbPoNo.DataTextField = "POJO"
        cmbPoNo.DataValueField = "ProcessOrderMstID"
        cmbPoNo.DataBind()
        'cmbPoNo.Items.Insert(0, New ListItem("Select", "0"))

    End Sub
    Sub SaveSession()
        If (Not CType(Session("dtIssueProcessDetail"), DataTable) Is Nothing) Then
            dtDetail = Session("dtIssueProcessDetail")
        Else
            dtDetail = New DataTable
            With dtDetail
                .Columns.Add("IssueProcessDtlID", GetType(Long))
                .Columns.Add("ItemID", GetType(String))
                .Columns.Add("ItemName", GetType(String))
                .Columns.Add("ReceiveQty", GetType(String))
                .Columns.Add("IssueQty", GetType(String))
                .Columns.Add("DeptDatabaseID", GetType(String))
                .Columns.Add("Department", GetType(String))
                .Columns.Add("Contractor", GetType(String))
                .Columns.Add("Remarks", GetType(String))
                .Columns.Add("EntryType", GetType(String))
            End With
        End If
        Dr = dtDetail.NewRow()
        Dr("IssueProcessDtlID") = 0
        If cmbEntryType.SelectedItem.Text = "In Stock" Then
            Dr("ItemID") = lblIMSItemId.Text
        Else
            Dr("ItemID") = lblID.Text
        End If
        If cmbEntryType.SelectedItem.Text = "In Stock" Then
            Dr("ItemName") = txtSearchItem.Text
        Else
            Dr("ItemName") = txtItemCode.Text 'cmbItemName.SelectedItem.Text
        End If
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
        dtDetail.Rows.Add(Dr)
        Session("dtIssueProcessDetail") = dtDetail
    End Sub
    Private Sub BindGrid()
        Try
            Dim objDatatble As DataTable
            objDatatble = Session("dtIssueProcessDetail")

            dgAdd.Visible = True
            dgAdd.RecordCount = objDatatble.Rows.Count
            dgAdd.DataSource = objDatatble
            dgAdd.DataBind()

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            If cmbEntryType.SelectedItem.Text = "In Stock" Then
                If Val(txtIssue.Text) > Val(txtReceive.Text) Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Issue is Greater.")
                ElseIf txtIssue.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Issue Empty")
                ElseIf cmbDept.SelectedValue = 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Dept.")
                ElseIf cmbEntryType.SelectedItem.Text = "Select" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Entry Type.")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    SaveSession()
                    BindGrid()
                    clear()
                    btnSave.Visible = True
                    btnCancel.Visible = True
                End If
            Else
                If Val(txtIssue.Text) > Val(txtReceive.Text) - Val(txtAlreadyIssued.Text) Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Issue is Greater")
                ElseIf txtIssue.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Issue Empty")
                ElseIf cmbDept.SelectedValue = 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Dept.")
                ElseIf cmbEntryType.SelectedItem.Text = "Select" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Entry Type.")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    SaveSession()
                    BindGrid()
                    clear()
                    btnSave.Visible = True
                    btnCancel.Visible = True
                End If
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
            ' BindStyle()
        Catch ex As Exception
        End Try
    End Sub
    Sub save()
        With ObjIssue
            .IssueProcessID = 0
            .POType = "N/A"
            .CreationDate = txtCreationDate.Text
            If cmbEntryType.SelectedItem.Text = "In Stock" Then
                .ProcessOrderMstID = 0
                .POProcessRecvMasterID = 0
            Else
                .ProcessOrderMstID = cmbPoNo.SelectedValue
                .POProcessRecvMasterID = lblPORecvMasterID.Text
            End If
            If userid = 241 Then
                .FabricStatus = True
            Else
                .FabricStatus = False
            End If
            .LocationId = cmbLocation.SelectedValue
            .ManualChallanNo = TXTManualChallanNo.Text.ToUpper
            .saveIssue()
        End With
    End Sub
    Sub savedtl()
        Try
            Dim x As Integer
            For x = 0 To dgAdd.Items.Count - 1
                With ObjIssueDtl
                    .IssueProcessDtlID = dgAdd.Items(x).Cells(0).Text
                    .IssueProcessID = ObjIssue.GetID()
                    .POProcessRecvDetailID = lblPORecvDetailId.Text
                    .ItemID = dgAdd.Items(x).Cells(1).Text
                    .DeptDatabaseID = dgAdd.Items(x).Cells(2).Text
                    .Contractor = dgAdd.Items(x).Cells(8).Text
                    .RecvQty = dgAdd.Items(x).Cells(5).Text
                    .IssueQty = dgAdd.Items(x).Cells(6).Text
                    .Remarks = dgAdd.Items(x).Cells(9).Text
                    .EntryType = dgAdd.Items(x).Cells(4).Text
                    .IssueReturn = 0
                    .saveIssueDtl()
                End With
                '''When work on update plz check IssueReturnqty
                With ObjIMSStoreLedger
                    .StoreLedgerID = 0
                    .IMSItemID = dgAdd.Items(x).Cells(1).Text
                    .CreationDate = Date.Now()
                    .TransactionDate = Date.Now.Date()
                    .TransactionType = "POProcess-Issue"
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
                    '    .CloseQty = ObjIMSStoreLedger.GetCloseQty(dgAdd.Items(x).Cells(1).Text) - Val(dgAdd.Items(x).Cells(6).Text)
                    .CloseAmount = 0
                    .LocationID = cmbLocation.SelectedValue
                    .SaveIMSStoreLedger()
                End With
                '   Dim OpenQty As Decimal = Val(dgAdd.Items(x).Cells(5).Text) - Val(dgAdd.Items(x).Cells(6).Text)
                '   Dim ItemId As Long = dgAdd.Items(x).Cells(1).Text
                'ObjItem.UpdateIMSITEM(OpenQty, ItemId)
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
                Response.Redirect("IssueProcessView.aspx")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("IssueProcessView.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtIssue_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIssue.TextChanged
        Try
            Dim a As Integer = 0
            'Dim IssueQty As Decimal = 0
            'For a = 0 To dgAdd.Items.Count - 1
            '    IssueQty = IssueQty + dgAdd.Items(x).Cells(5).Text
            'Next
            If cmbEntryType.SelectedItem.Text = "In Stock" Then
                If Val(txtIssue.Text) > Val(txtReceive.Text) Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Issue Exceed.")
                    'ElseIf txtIssue.Text = 0 Then
                    '    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("You can not issue 0")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                End If
            Else
                If Val(txtAlreadyIssued.Text) + Val(txtIssue.Text) > Val(txtReceive.Text) Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Issue Exceed.")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbEntryType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbEntryType.SelectedIndexChanged
        Try
            EntryType()
        Catch ex As Exception
        End Try
    End Sub
    Sub EntryType()
        If cmbEntryType.SelectedItem.Text = "In Stock" Then
            lblItemFab.Text = "Enter Item :"
            ' tdItem.Visible = False
            tdPOLabel.Visible = False
            tdcmbPONO.Visible = False
            cmbDept.Style.Value = "margin-left: 0px;"
            txtContractor.Style.Value = "margin-left: -197px;"
            tdRecv.Style.Value = "margin-left: -109px;"
            tdShowMe.Visible = True
            Session("CMBEntry") = cmbEntryType.SelectedItem.Text
        ElseIf cmbEntryType.SelectedItem.Text = "New Entry" Then
            If userid = 241 Then
                lblItemFab.Text = "Process Item :"
            Else
                lblItemFab.Text = "Item :"
            End If
            cmbDept.Style.Value = "margin-left: 10px;"
            txtContractor.Style.Value = "margin-left: 0px;"
            tdRecv.Style.Value = "margin-left: 0px;"
            ' tdItem.Visible = True
            tdPOLabel.Visible = True
            tdcmbPONO.Visible = True
            tdShowMe.Visible = False

        End If
    End Sub
    Protected Sub txtSearchItem_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearchItem.TextChanged
        Try
            If txtSearchItem.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Enter Valid ItemName")
            ElseIf txtSearchItem.Text <> "" Then

                GetRecvData()
                Dim dtr As DataTable
                'dtr = ObjIssue.GetAlreadyRecv(cmbPoNo.SelectedValue, cmbItemName.SelectedValue)
                dtr = ObjIssue.GetAlreadyRecvNew(lblIMSItemId.Text)
                If dtr.Rows.Count > 0 Then
                    txtAlreadyIssued.Text = dtr.Rows.Item(0)("AlreadyIssued")
                Else
                    txtAlreadyIssued.Text = "0"
                End If
                ' BindRecvQty()
                BindRecvQtyEntryTypeWise()

                'If objDataView.Count > 0 Then
                '    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                'Else
                '    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("ItemName Not Exist")
                'End If
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
End Class


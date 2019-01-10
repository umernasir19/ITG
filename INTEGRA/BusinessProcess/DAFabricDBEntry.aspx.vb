Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Xml

Public Class DAFabricDBEntry
    Inherits System.Web.UI.Page
    Dim objDPFabricDbMst As New DPFabricDbMst
    Dim objDPFabricDbDtl As New DPFabricDbDtl
    Dim objDtaBaseSupplier As New SupplierDataBase
    Dim objIMSSupplierDetail As New SupplierDatabaseDetail
    Dim objComposition As New Composition
    Dim objDPFinish As New DPFinish
    Dim objDPDye As New DPDye
    Dim objType As New DPType
    Dim Dt As DataTable
    Dim Dr As DataRow
    Dim dtDetail As DataTable
    Dim lFabricDbMstID, userid As Long
    Dim Type As String
    Dim ObjTblRND As New TblDPRND
    Dim dyewash As New DPFabricDbMst
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lFabricDbMstID = Request.QueryString("lFabricDbMstID")
        Type = Request.QueryString("Type")
        userid = Session("UserId")
        If Not Page.IsPostBack Then
            Session("dtDetail") = Nothing
            BindComposition()
            BindFINISH()
            'BindDye()
            BindType()
            'BindSupplier()
            If lFabricDbMstID > 0 Then
                btnSave.Text = "Update"
                Edit()
            Else
            End If
        End If
        PageHeader("Fabric DB")
    End Sub
    Protected Sub txtCompositionn_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtCompositionn.TextChanged
        Try
            Dim Dt As DataTable = ObjTblRND.GetCheckCompositionIDForFDB(txtCompositionn.Text)
            If Dt.Rows.Count > 0 Then
                Dim Dtt As DataTable = ObjTblRND.GetCompositionIDForFDB(txtCompositionn.Text)
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                lblCompositionID.Text = Dtt.Rows(0)("CompositionID")
                AutoGenerateFabricName()
                UpType.Update()
                UpdatePanel1.Update()
                'UpcmbDyeWash.Update()
                UpFinishGSM.Update()
                Upfabricname.Update()
              
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Composition Not Exist")
                txtCompositionn.Text = ""
                lblCompositionID.Text = ""
                txtCompositionn.Focus()

            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtFinishGSMm_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtFinishGSMm.TextChanged
        Try
            Dim Dt As DataTable = ObjTblRND.GetCheckFinsihWidthIDForFDB(txtFinishGSMm.Text)
            If Dt.Rows.Count > 0 Then
                Dim Dtt As DataTable = ObjTblRND.GetCheckFinsihWidthIDForFDB(txtFinishGSMm.Text)
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                lblFinishGSMID.Text = Dtt.Rows(0)("FinishID")
                AutoGenerateFabricName()
                UpType.Update()
                UpdatePanel1.Update()
                'UpcmbDyeWash.Update()
                UpFinishGSM.Update()
                Upfabricname.Update()
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Finish GSM Not Exist")
                txtFinishGSMm.Text = ""
                lblFinishGSMID.Text = ""
                txtCompositionn.Focus()

            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub AutoGenerateFabricName()
        Dim Type As String
        Dim Composition As String
        Dim Finish As String
        Dim Dye As String
        Dim DalNo As String = txtDALNo.Text.ToUpper
        Dim FabricQuality As String = txtFabricQuality.Text.ToUpper
        If cmbType.SelectedItem.Text = "N/A" Then
            Type = ""
        Else
            Type = cmbType.SelectedItem.Text
        End If
        If txtCompositionn.Text = "" Then
            Composition = ""
        Else
            Composition = txtCompositionn.Text
        End If
        If txtFinishGSMm.Text = "" Then
            Finish = ""
        Else
            Finish = txtFinishGSMm.Text
        End If
        'If cmbDyeWash.SelectedItem.Text = "Select" Then
        '    Dye = ""
        'Else
        '    Dye = cmbDyeWash.SelectedItem.Text
        'End If
        If cmbDyeWash.Text = "" Then
            Dye = ""
        Else
            Dye = cmbDyeWash.Text
        End If

        txtfabricname.Text = DalNo + " " + FabricQuality + " " + Type + " " + Composition + " " + Finish + " " + Dye
      
    End Sub
    Protected Sub txtFabricQuality_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtFabricQuality.TextChanged
        Try

            AutoGenerateFabricName()
            UpType.Update()
            UpdatePanel1.Update()
            'UpcmbDyeWash.Update()
            UpFinishGSM.Update()
            Upfabricname.Update()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtDALNo_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtDALNo.TextChanged
        Try
            Dim Dt As DataTable = ObjTblRND.GetCheckDALNO(txtDALNo.Text)
            If Dt.Rows.Count > 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Dal No Already Exist")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                AutoGenerateFabricName()
                UpType.Update()
                UpdatePanel1.Update()
                ' UpcmbDyeWash.Update()
                UpFinishGSM.Update()
                Upfabricname.Update()
            End If

           
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbType_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbType.SelectedIndexChanged
        Try
            AutoGenerateFabricName()
            UpType.Update()
            UpdatePanel1.Update()
            ' UpcmbDyeWash.Update()
            UpFinishGSM.Update()
            Upfabricname.Update()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbComposition_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbComposition.SelectedIndexChanged
        Try
            AutoGenerateFabricName()
            UpType.Update()
            UpdatePanel1.Update()
            'UpcmbDyeWash.Update()
            UpFinishGSM.Update()
            Upfabricname.Update()
        Catch ex As Exception

        End Try
    End Sub
    'Protected Sub cmbDyeWash_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbDyeWash.SelectedIndexChanged
    '    Try
    '        AutoGenerateFabricName()
    '        UpType.Update()
    '        UpdatePanel1.Update()
    '        UpcmbDyeWash.Update()
    '        UpFinishGSM.Update()
    '        Upfabricname.Update()
    '    Catch ex As Exception

    '    End Try
    'End Sub
    Protected Sub cmbDyeWash_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDyeWash.TextChanged
        Try
            lblDyeWash.Text = dyewash.GetDyeDyename(cmbDyeWash.Text)
            Try
                If (lblDyeWash.Text <> "") Then
                    AutoGenerateFabricName()
                    UpType.Update()
                    UpdatePanel1.Update()
                    ' UpcmbDyeWash.Update()
                    UpFinishGSM.Update()
                    Upfabricname.Update()
                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbFinishGSM_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbFinishGSM.SelectedIndexChanged
        Try
            AutoGenerateFabricName()
            UpType.Update()
            UpdatePanel1.Update()
            'UpcmbDyeWash.Update()
            UpFinishGSM.Update()
            Upfabricname.Update()
        Catch ex As Exception

        End Try
    End Sub
    Sub Edit()
        Dt = objDPFabricDbMst.GetEdit(lFabricDbMstID)
        If Dt.Rows.Count > 0 Then
            txtCreationDate.SelectedDate = Dt.Rows(0)("CreationDate")
            txtDALNo.Text = Dt.Rows(0)("DalNo")
            txtFabricCode.Text = Dt.Rows(0)("FabricCode")
            txtSupplier.Text = Dt.Rows(0)("SupplierArtNo")

            ' atif work 24 july 2018
            lblPartyid.Text = Dt.Rows(0)("SupplierID")
            txtPartyAccount.Text = Dt.Rows(0)("SupplierName")


            txtFabricQuality.Text = Dt.Rows(0)("FabricQuality")
            txtcolour.Text = Dt.Rows(0)("Color")
            lblCompositionID.Text = Dt.Rows(0)("CompositionId")
            txtFabricWidth.Text = Dt.Rows(0)("FabricWidth")
            txtAfterwashGSM.Text = Dt.Rows(0)("AfterWashGsm")
            txtShrinkage.Text = Dt.Rows(0)("Shrinkage")
            txtGeneralRemarks.Text = Dt.Rows(0)("GeneralRemarks")
            txtopqty.Text = Dt.Rows(0)("OPQty")
            txtpurchaseQty.Text = Dt.Rows(0)("PurchaseQty")
            lblFinishGSMID.Text = Dt.Rows(0)("FinishId")

            cmbDyeWash.Text = Dt.Rows(0)("DyeWash")
            lblDyeWash.Text = Dt.Rows(0)("DyeId")
            ' cmbDyeWash.SelectedValue = Dt.Rows(0)("DyeId")

            cmbType.SelectedValue = Dt.Rows(0)("DPTypeId")
            txtBefWashGSM.Text = Dt.Rows(0)("BefWashGSM")
            txtMillShrinkage.Text = Dt.Rows(0)("MillShrinkage")
            txtfabricname.Text = Dt.Rows(0)("FabricName")
            txtonz.Text = Dt.Rows(0)("Onz")
            txtCompositionn.Text = Dt.Rows(0)("Compositionname")
            txtFinishGSMm.Text = Dt.Rows(0)("FinishGSM")
            lblUserId.Text = Dt.Rows(0)("UserId")
        End If
        Dim DTFD As DataTable = objDPFabricDbMst.GetEditDETAIL(lFabricDbMstID)
        If DTFD.Rows.Count > 0 Then
            dtDetail = New DataTable
            With dtDetail
                .Columns.Add("FabricDBDtlId", GetType(Long))
                .Columns.Add("Price", GetType(String))
                .Columns.Add("PricingDate", GetType(String))
                .Columns.Add("PricingRemarks", GetType(String))
                .Columns.Add("ConfirmPrice", GetType(String))
            End With
            Dim x As Integer
            For x = 0 To DTFD.Rows.Count - 1
                Dr = dtDetail.NewRow()
                Dr("FabricDBDtlId") = DTFD.Rows(x)("FabricDBDtlId")
                Dr("Price") = DTFD.Rows(x)("Price")
                Dr("PricingDate") = DTFD.Rows(x)("PricingDate")
                Dr("PricingRemarks") = DTFD.Rows(x)("PricingRemarks")
                Dr("ConfirmPrice") = DTFD.Rows(x)("ConfirmPrice")
                dtDetail.Rows.Add(Dr)
                Session("dtDetail") = dtDetail
            Next
            BindGrid()
        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub BindComposition()
        Try
            Dim dtcomp As DataTable
            dtcomp = objDPFabricDbMst.Getcomposition
            cmbComposition.DataSource = dtcomp
            cmbComposition.DataTextField = "CompositionName"
            cmbComposition.DataValueField = "CompositionID"
            cmbComposition.DataBind()
            UpdatePanel2.Update()
        Catch ex As Exception
        End Try
    End Sub
    Sub BindType()
        Try
            Dim dtType As DataTable
            dtType = objDPFabricDbMst.GetdpTYPE
            cmbType.DataSource = dtType
            cmbType.DataTextField = "DPTypeName"
            cmbType.DataValueField = "DPTypeID"
            cmbType.DataBind()
            UpType.Update()
        Catch ex As Exception
        End Try
    End Sub
    Sub BindFINISH()
        Try
            Dim dtFinish As DataTable
            dtFinish = objDPFabricDbMst.GetFinish
            cmbFinishGSM.DataSource = dtFinish
            cmbFinishGSM.DataTextField = "FinishName"
            cmbFinishGSM.DataValueField = "FinishID"
            cmbFinishGSM.DataBind()
            UpFinishGSM.Update()
        Catch ex As Exception
        End Try
    End Sub
    Sub BindDye()
        '    Try
        Dim dtDye As DataTable
        dtDye = objDPFabricDbMst.GetDye()
        '        cmbDyeWash.DataSource = dtDye
        '        cmbDyeWash.DataTextField = "DyeName"
        '        cmbDyeWash.DataValueField = "DyeID"
        '        cmbDyeWash.DataBind()
        '        cmbDyeWash.Items.Insert(0, New RadComboBoxItem("Select", 0))
        '        UpcmbDyeWash.Update()
        '    Catch ex As Exception
        '    End Try
    End Sub
    'Sub BindSupplier()
    '    Try
    '        Dim dtsupplier As DataTable
    '        dtsupplier = objDPFabricDbMst.GetSupplierComboNNew
    '        cmbSupplier.DataSource = dtsupplier
    '        cmbSupplier.DataTextField = "SupplierName"
    '        cmbSupplier.DataValueField = "SupplierDatabaseID"
    '        cmbSupplier.DataBind()
    '        cmbSupplier.Items.Insert(0, New RadComboBoxItem("Select", 0))
    '        UpdatePanel2.Update()
    '    Catch ex As Exception
    '    End Try
    'End Sub
    Protected Sub dgFaricDtl_DeleteCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgFaricDtl.DeleteCommand
        dtDetail = CType(Session("dtDetail"), DataTable)
        If (Not dtDetail Is Nothing) Then
            If (dtDetail.Rows.Count > 0) Then
                Dim FabricDbDtlId As Integer = dtDetail.Rows(e.Item.ItemIndex)("FabricDbDtlId")
                dtDetail.Rows.RemoveAt(e.Item.ItemIndex)
                objDPFabricDbDtl.Deletedetail(FabricDbDtlId)
                BindGrid()
            Else
            End If

        End If
    End Sub
    Protected Sub btnAddDetail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddDetail.Click
        Try
            If txtPrice.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Price")
            ElseIf txtPricingDate.ValidationDate = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Pricing Date")
            Else
                SaveSession()
                BindGrid()
                ClearControlsG()

                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")

            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveSession()
        If (Not CType(Session("dtDetail"), DataTable) Is Nothing) Then
            dtDetail = Session("dtDetail")
        Else
            dtDetail = New DataTable
            With dtDetail
                .Columns.Add("FabricDBDtlId", GetType(Long))
                .Columns.Add("Price", GetType(String))
                .Columns.Add("PricingDate", GetType(String))
                .Columns.Add("PricingRemarks", GetType(String))
                .Columns.Add("ConfirmPrice", GetType(String))
            End With
        End If
        Dr = dtDetail.NewRow()
        Dr("FabricDBDtlId") = 0
        If txtPrice.Text = "" Then
            Dr("Price") = 0
        Else
            Dr("Price") = txtPrice.Text
        End If
        Dr("PricingDate") = txtPricingDate.SelectedDate
        If txtPriceRemarks.Text = "" Then
            Dr("PricingRemarks") = " "
        Else
            Dr("PricingRemarks") = txtPriceRemarks.Text
        End If

        Dr("ConfirmPrice") = 0
        dtDetail.Rows.Add(Dr)
        Session("dtDetail") = dtDetail
    End Sub
    Private Sub BindGrid()
        Try
            Dim objDatatble As DataTable
            objDatatble = Session("dtDetail")
            If objDatatble.Rows.Count > 0 Then
                dgFaricDtl.Visible = True
                dgFaricDtl.VirtualItemCount = objDatatble.Rows.Count
                dgFaricDtl.DataSource = objDatatble
                dgFaricDtl.DataBind()
            Else
                dgFaricDtl.Visible = False
            End If
            Dim x As Integer
            Dim chkSelect As CheckBox
            For x = 0 To dgFaricDtl.Items.Count - 1
                Dim item As GridDataItem = DirectCast(dgFaricDtl.MasterTableView.Items(x), GridDataItem)
                chkSelect = CType(dgFaricDtl.Items(x).FindControl("chkSelect"), CheckBox)
                Dim ConFirmPrice As Boolean = item("ConfirmPrice").Text
                If ConFirmPrice = False Then
                    chkSelect.Checked = False
                Else
                    chkSelect.Checked = True
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
    Sub ClearControlsG()

        txtPrice.Text = ""
        txtPriceRemarks.Text = ""
        txtPricingDate.SelectedDate = ""

    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            If txtCreationDate.ValidationDate = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Date")
            ElseIf txtDALNo.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Dal No")
            ElseIf txtCompositionn.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Composition")
                'ElseIf cmbSupplier.SelectedItem.Text = "Select" Then
                '    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Supplier")
            ElseIf txtPartyAccount.Text = "" And lblPartyid.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Supplier")
            ElseIf cmbDyeWash.Text = "" And lblDyeWash.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Dye")
            ElseIf txtFinishGSMm.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Finish")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                Dim x As Integer
                Dim chkSelect As CheckBox
                Dim checkCount As Decimal = 0
                For x = 0 To dgFaricDtl.Items.Count - 1
                    chkSelect = CType(dgFaricDtl.Items(x).FindControl("chkSelect"), CheckBox)
                    If chkSelect.Checked = True Then
                        checkCount = checkCount + 1
                    End If
                Next
                Dim dtcheck As DataTable = objDPFabricDbMst.CheckDal(txtDALNo.Text)
                If checkCount > 1 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Multiple check not allowed")
                Else
                    If lFabricDbMstID > 0 Then
                        SaveData()
                        Response.Redirect("DPFabricDBView.aspx?Type=" & Type)
                    Else
                        If dtcheck.Rows.Count > 0 Then
                            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Dal No already exists")
                        Else
                            SaveData()
                            Response.Redirect("DPFabricDBView.aspx?Type=" & Type)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("DPFabricDBView.aspx?Type=" & Type)
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveData()
        With objDPFabricDbMst
            If lFabricDbMstID > 0 Then
                .FabricDBMstId = lFabricDbMstID
            Else
                .FabricDBMstId = 0
            End If

            .CreationDate = txtCreationDate.SelectedDate
            .DalNo = txtDALNo.Text.ToUpper
            If txtFabricCode.Text = "" Then
                .FabricCode = "N/A"
            Else
                .FabricCode = txtFabricCode.Text.ToUpper
            End If

            .SupplierArtNo = txtSupplier.Text.ToUpper
            ' .SupplierID = cmbSupplier.SelectedValue
            .SupplierID = lblPartyid.Text
            .FabricQuality = txtFabricQuality.Text.ToUpper
            .Color = txtcolour.Text.ToUpper
            .CompositionId = lblCompositionID.Text 'cmbComposition.SelectedValue
            '.DyeWash = cmbDyeWash.SelectedItem.Text.ToUpper
            .DyeWash = cmbDyeWash.Text.ToUpper
            .FinishGSM = txtFinishGSMm.Text.ToUpper 'cmbFinishGSM.SelectedItem.Text.ToUpper
            .FabricWidth = txtFabricWidth.Text.ToUpper
            .AfterWashGsm = txtAfterwashGSM.Text.ToUpper
            .Shrinkage = txtShrinkage.Text.ToUpper
            .GeneralRemarks = txtGeneralRemarks.Text.ToUpper
            If txtopqty.Text = "" Then
                .OPQty = 0
            Else
                .OPQty = txtopqty.Text
            End If

            If txtpurchaseQty.Text = "" Then
                .PurchaseQty = 0
            Else
                .PurchaseQty = txtpurchaseQty.Text
            End If

            If Session("RoleId") = 46 And Session("Type") = "R.N.D" Then
                If lFabricDbMstID > 0 Then
                    .UserID = lblUserId.Text
                Else
                    .UserID = 270
                End If
            ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                If lFabricDbMstID > 0 Then
                    .UserID = lblUserId.Text
                Else
                    .UserID = 270
                End If
            Else
                If lFabricDbMstID > 0 Then
                    .UserID = lblUserId.Text
                Else
                    .UserID = userid
                End If
            End If
            .FinishId = lblFinishGSMID.Text 'cmbFinishGSM.SelectedValue
            '.DyeId = cmbDyeWash.SelectedValue
            .DyeId = lblDyeWash.Text
            .DPTypeId = cmbType.SelectedValue
            .BefWashGSM = txtBefWashGSM.Text.ToUpper
            .MillShrinkage = txtMillShrinkage.Text.ToUpper
            .FabricName = txtfabricname.Text.ToUpper
            .Onz = txtonz.Text.ToUpper
            .SaveFB()
        End With
        Dim chkSelect As CheckBox
        Dim x As Integer
        For x = 0 To dgFaricDtl.Items.Count - 1
            Dim item As GridDataItem = DirectCast(dgFaricDtl.MasterTableView.Items(x), GridDataItem)
            chkSelect = CType(dgFaricDtl.Items(x).FindControl("chkSelect"), CheckBox)
            With objDPFabricDbDtl
                .FabricDbDtlId = item("FabricDBDtlId").Text
                If lFabricDbMstID > 0 Then
                    .FabricDBMstId = lFabricDbMstID
                Else
                    .FabricDBMstId = objDPFabricDbMst.GetCurrentId
                End If
                .Price = item("Price").Text
                .PricingDate = item("PricingDate").Text
                .PricingRemarks = item("PricingRemarks").Text.ToUpper
                If chkSelect.Checked = True Then
                    .ConfirmPrice = 1
                Else
                    .ConfirmPrice = 0
                End If
                .SaveFBdt()

            End With
        Next
    End Sub
    Protected Sub btnAddComp_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAddComp.Click
        Try
            txtCompositionn.Visible = False
            txtCompositionnAdd.Visible = True
            btnAddComp.Visible = False
            btnSaveComp.Visible = True
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnSaveComp_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSaveComp.Click
        Try
            If txtCompositionnAdd.Text = "" Then
            Else

                Dim DtCheck As DataTable = objDPFabricDbMst.CheckExistingCompositionName(txtCompositionnAdd.Text)
                If DtCheck.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Composition Name Already Exist")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    With objComposition
                        .CompositionID = 0
                        .CompositionName = txtCompositionnAdd.Text.ToUpper
                        .SaveComposition()
                    End With
                End If
            End If
            txtCompositionn.Visible = True
            txtCompositionn.Text = ""
            lblCompositionID.Text = ""
            txtCompositionnAdd.Text = ""
            txtCompositionnAdd.Visible = False
            btnAddComp.Visible = True
            btnSaveComp.Visible = False
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnAddFinish_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAddFinish.Click
        Try

            txtFinishGSMmAdd.Text = ""
            txtFinishGSMmAdd.Visible = True
            txtFinishGSMm.Visible = False
            btnAddFinish.Visible = False
            btnSaveFinish.Visible = True
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnSaveFinish_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSaveFinish.Click
        Try
            If txtFinishGSMmAdd.Text = "" Then
            Else
                Dim DtCheck As DataTable = objDPFabricDbMst.CheckExistingFinishName(txtFinishGSMmAdd.Text)
                If DtCheck.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Finish Name Already Exist")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    With objDPFinish
                        .FinishID = 0
                        .FinishName = txtFinishGSMmAdd.Text.ToUpper
                        .SaveFinish()
                    End With
                End If
            End If
            txtFinishGSMm.Text = ""
            lblFinishGSMID.Text = ""
            txtFinishGSMmAdd.Text = ""
            txtFinishGSMmAdd.Visible = False
            txtFinishGSMm.Visible = True
            btnAddFinish.Visible = True
            btnSaveFinish.Visible = False
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnAddDye_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAddDye.Click
        Try
            cmbDyeWash.Visible = False
            txtdyewash.Visible = True
            btnAddDye.Visible = False
            BtnSaveDye.Visible = True
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub BtnSaveDye_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSaveDye.Click
        Try
            If txtdyewash.Text = "" Then
            Else
                Dim DtCheck As DataTable = objDPFabricDbMst.CheckExistingDye(txtdyewash.Text)
                If DtCheck.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Dye Name Already Exist")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    With objDPDye
                        .DyeID = 0
                        .DyeName = txtdyewash.Text.ToUpper
                        .SaveDye()
                    End With

                End If

            End If
            ' BindDye()
            txtdyewash.Text = ""
            cmbDyeWash.Visible = True
            txtdyewash.Visible = False
            btnAddDye.Visible = True
            BtnSaveDye.Visible = False
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnAddType_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAddType.Click
        Try
            cmbType.Visible = False
            txtType.Visible = True
            btnAddType.Visible = False
            BtnSaveType.Visible = True
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub BtnSaveType_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSaveType.Click
        Try
            If txtType.Text = "" Then
            Else

                Dim DtCheck As DataTable = objDPFabricDbMst.CheckExistingType(txtType.Text)
                If DtCheck.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Type Already Exist")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    With objType
                        .DPTypeID = 0
                        .DPTypeName = txtType.Text.ToUpper
                        .SaveDPType()
                    End With

                End If


            End If
            BindType()
            txtType.Text = ""
            cmbType.Visible = True
            txtType.Visible = False
            btnAddType.Visible = True
            BtnSaveType.Visible = False
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnAddSuuplier_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAddSuuplier.Click
        Try
            txtPartyAccount.Visible = False
            'cmbSupplier.Visible = False
            txtSupplierName.Visible = True
            btnAddSuuplier.Visible = False
            BtnSaveSupplier.Visible = True
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub BtnSaveSupplier_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSaveSupplier.Click
        Try
            If txtSupplierName.Text = "" Then

            Else

                With objDtaBaseSupplier
                    .SupplierDatabaseId = 0
                    .SupplierName = txtSupplierName.Text
                    .SupplieAddress = "N/A"
                    .IsActive = 1
                    .TelephoneNo = ""
                    .Email = ""
                    Dim FinalCode As String = "0"
                    Dim a As String = .GetID
                    If a <= "9" Then
                        FinalCode = "1000" + a
                    ElseIf a <= "99" Then
                        FinalCode = "100" + a
                    ElseIf a <= "999" Then
                        FinalCode = "100" + a
                    Else
                        FinalCode = "10" + a
                    End If
                    .SupplierCategoryId = 12
                    .SupplierCode = FinalCode
                    .FaxNo = "N/A"
                    .AccountCode = ""
                    .userid = 237
                    .SaveSupplierDatabase()
                End With

                With objIMSSupplierDetail
                    .SupplierDatabaseDetailId = 0
                    .SupplierDatabaseId = objDtaBaseSupplier.GetID
                    .ContactPerson = "N/A"
                    .CellNumber = ""
                    .SaveSupplierDatabaseDetail()
                End With
            End If
            ' BindSupplier()
            txtSupplierName.Text = ""
            'cmbSupplier.Visible = True
            txtPartyAccount.Visible = True

            txtSupplierName.Visible = False
            btnAddSuuplier.Visible = True
            BtnSaveSupplier.Visible = False
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtPartyAccount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPartyAccount.TextChanged
        Try
            Dim dtAc As DataTable
            If txtPartyAccount.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Enter Valid SupplierName.")
            ElseIf txtPartyAccount.Text <> "" Then
                dtAc = objDtaBaseSupplier.gETsUPPLIERpo(txtPartyAccount.Text)
                If dtAc.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    lblPartyid.Text = dtAc.Rows(0)("SupplierdatabaseID")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("SupplierName Name Not Exist")
                    lblPartyid.Text = 0
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
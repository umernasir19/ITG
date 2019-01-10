Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Xml
Public Class FabricConsumption
    Inherits System.Web.UI.Page
    Dim lFabricConsumptionID, ASSS As Long
    Dim userid As Long
    Dim objFabricCons As New FabricConsump
    Dim objFabricConsumptionDetail As New FabricConsumptionDetail
    Dim Dr As DataRow
    Dim dtFabricConDetail As DataTable
    Dim objSizeRange As New SizeRange
    Dim ObjPatternDepartTaskListDtl As New PatternDepartTaskListDtl
    Dim objPatternDepartTaskListMst As New PatternDepartTaskListMstNew
    Dim VoucherNo As String
    Dim Voucherdate As Date = Date.Now
    Dim ObjDepartmentDataBase As New DepartmetDataBase
    Dim objPORecvMaster As New PORecvMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lFabricConsumptionID = Request.QueryString("lFabricConsumptionID")
        ASSS = Request.QueryString("Status")
        userid = Session("UserId")
        If Not Page.IsPostBack Then
            Session("dtFabricConDetail") = Nothing
            bindSeason()
            If userid = 238 Then
                pnlHalfPortion.Enabled = False
                If ASSS = 1 Then
                    ckhAllowToggtFromFStore.Visible = True
                Else
                    ckhAllowToggtFromMerch.Visible = True
                End If

            ElseIf Session("RoleId") = 46 And Session("Type") = "G.G.T" Then
                pnlHalfPortion.Enabled = False
                If ASSS = 1 Then
                    ckhAllowToggtFromFStore.Visible = True
                Else
                    ckhAllowToggtFromMerch.Visible = True
                End If

            ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                 pnlHalfPortion.Enabled = True
                ckhAllowToggtFromFStore.Visible = True
                ckhAllowToggtFromMerch.Visible = False

            Else
                Dim DtCheckk As DataTable = objPORecvMaster.CheckDepartment(userid)
                If DtCheckk.Rows(0)("Department") = "Merchandising" Then
                    pnlHalfPortion.Enabled = True
                    ckhAllowToggtFromMerch.Visible = True
                    ckhAllowToggtFromFStore.Visible = False
                ElseIf DtCheckk.Rows(0)("Department") = "Fabric Store" Then
                    pnlHalfPortion.Enabled = True
                    ckhAllowToggtFromFStore.Visible = True
                    ckhAllowToggtFromMerch.Visible = False
                End If
            End If
            BindType()
            BindUnit()
            BindCustomer()
            BindSupplier()
            If lFabricConsumptionID > 0 Then
                btnSave.Text = "Update"
                Edit()
            Else
                btnSave.Text = "Save"
                txtEntryDate.Text = Date.Now
                NoGenerateOnLoad()
            End If

            End If
    End Sub
    Sub BindSupplier()
        Try
            Dim dtsupplier As DataTable
            dtsupplier = objFabricCons.GetSupplierComboNNew
            cmbSupplier.DataSource = dtsupplier
            cmbSupplier.DataTextField = "SupplierName"
            cmbSupplier.DataValueField = "SupplierDatabaseID"
            cmbSupplier.DataBind()

        Catch ex As Exception
        End Try
    End Sub
    Sub BindCustomer()
        Dim dtsupplier As DataTable
        dtsupplier = objFabricCons.GetCustomer
        cmbBuyer.DataSource = dtsupplier
        cmbBuyer.DataTextField = "CustomerName"
        cmbBuyer.DataValueField = "CustomerID"
        cmbBuyer.DataBind()
    End Sub
    Sub Edit()
        Dim dt As DataTable
        dt = objFabricCons.GetEditDataForFabricConsumption(lFabricConsumptionID)
        txtCreationDate.Text = dt.Rows(0)("FabricConDate")
            cmbType.SelectedValue = dt.Rows(0)("TypeID")
            txtSrNo.Text = dt.Rows(0)("SrNo")
            txtStyle.Text = dt.Rows(0)("StyleNo")
            txtDesc.Text = dt.Rows(0)("Description")
            txtfabricCons.Text = dt.Rows(0)("FabricConstruction")
        txtFabricwidth.Text = dt.Rows(0)("FinishedFabricWidth")
        lblAllowToGgtFromFstore.Text = dt.Rows(0)("GGTStatusFromFStore")
        lblAllowToGgtFromMerch.Text = dt.Rows(0)("GGTStatusFromMerch")
        txtEntryDate.Text = dt.Rows(0)("CreationDate")
        ' txtsize.Text = dt.Rows(0)("Sizes")
            txtratio.Text = dt.Rows(0)("Ratio")
        txttotal.Text = dt.Rows(0)("Total")

        '   txtmarkerlength.Text = dt.Rows(0)("MarkerLengthWithMtrs")
        '  txtshrinkage.Text = dt.Rows(0)("Shrinkage")
        ' txtInqConsmp.Text = dt.Rows(0)("NewInquiryConsumption")
        'txtOtherConsmp.Text = dt.Rows(0)("OrderConsumptionPerPiece")
        'txtActualConsmp.Text = dt.Rows(0)("ActualConsumptionPerPeice")
        txtShrinkageApprox.Text = dt.Rows(0)("ShrinkageApprox")
        lblidd.Text = dt.Rows(0)("UserId")
        'txtMesh.Text = dt.Rows(0)("MeshPerPiece")
        'txtPatchPocket.Text = dt.Rows(0)("PatchPocketPerPiece")
        'txtPiping.Text = dt.Rows(0)("PipingPerPiece")
        'txtContrastFab.Text = dt.Rows(0)("ContrastFabricPerPiece")
        'txtInsideBeltFab.Text = dt.Rows(0)("InsideBeltFabric")
        'txtPocketlining.Text = dt.Rows(0)("PocketLiningPiece")
        'txtOther.Text = dt.Rows(0)("Others")
        txtPrepared1.Text = dt.Rows(0)("PreparedBy1")
        txtPrepared2.Text = dt.Rows(0)("PreparedBy2")
        txtPrepared3.Text = dt.Rows(0)("PreparedBy3")
        txtPrepared4.Text = dt.Rows(0)("PreparedBy4")
        txtPrepared5.Text = dt.Rows(0)("PreparedBy5")
        cmbBuyer.SelectedValue = dt.Rows(0)("Buyerid")
        txtDalNoO.Text = dt.Rows(0)("DalNo")
        CMBSeason.SelectedValue = dt.Rows(0)("SeasonDatabaseID")


        Dim AGGT As Boolean = dt.Rows(0)("AllowToGGTFromFStore")
        If AGGT = True Then
            ckhAllowToggtFromFStore.Checked = True
        ElseIf AGGT = False Then
            ckhAllowToggtFromFStore.Checked = False
        End If

        Dim AGGTT As Boolean = dt.Rows(0)("AllowToGGTFromMerch")
        If AGGTT = True Then
            ckhAllowToggtFromMerch.Checked = True
        ElseIf AGGTT = False Then
            ckhAllowToggtFromMerch.Checked = False
        End If

        cmbSupplier.SelectedValue = dt.Rows(0)("Supplierid")
        lblCons.Text = cmbType.SelectedItem.Text + " Con. Per/Pcs"
        Dim dtstyle As DataTable = objFabricConsumptionDetail.GetEditFabircCon(lFabricConsumptionID)
        dtFabricConDetail = New DataTable
        With dtFabricConDetail
            .Columns.Add("FabricConsumptionDetailID", GetType(Long))
            .Columns.Add("Description", GetType(String))
            .Columns.Add("IsBodyFabric", GetType(Boolean))
            .Columns.Add("Size", GetType(String))
            .Columns.Add("StyleWidth", GetType(String))
            .Columns.Add("ShrinkageLength", GetType(String))
            .Columns.Add("ShrinkageWidth", GetType(String))
            .Columns.Add("MarkerLengthWithSize", GetType(String))
            .Columns.Add("ConsumptionPerPcs", GetType(String))
            .Columns.Add("Price", GetType(Decimal))
            .Columns.Add("OtherDetail", GetType(String))
            .Columns.Add("ConsumptionUnitid", GetType(Long))
            .Columns.Add("Unit", GetType(String))
        End With
        Dim y As Integer
        For y = 0 To dtStyle.Rows.Count - 1

            Dr = dtFabricConDetail.NewRow()
            Dr("FabricConsumptionDetailID") = dtstyle.Rows(y)("FabricConsumptionDetailID")
            Dr("Description") = dtStyle.Rows(y)("Description")
            Dr("Size") = dtstyle.Rows(y)("Sizes")
            Dr("StyleWidth") = dtStyle.Rows(y)("StyleWidth")
            Dr("ShrinkageLength") = dtStyle.Rows(y)("ShrinkageLength")
            Dr("ShrinkageWidth") = dtStyle.Rows(y)("ShrinkageWidth")
            Dr("MarkerLengthWithSize") = dtStyle.Rows(y)("MarkerLengthWithSize")
            Dr("ConsumptionPerPcs") = dtStyle.Rows(y)("ConsumptionPerPcs")
            Dr("OtherDetail") = dtStyle.Rows(y)("OtherDetail")
            Dr("ConsumptionUnitid") = dtstyle.Rows(y)("ConsumptionUnitidd")
            Dr("Unit") = dtStyle.Rows(y)("Unit")
            dtFabricConDetail.Rows.Add(Dr)
        Next
        Session("dtFabricConDetail") = dtFabricConDetail
        BindStyleDetailGrid()

    End Sub
    Protected Sub txtSrNo_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtSrNo.TextChanged
        Try
            Dim DT As DataTable = objFabricCons.GetSeasonForJobOrder(txtSrNo.Text)
            If DT.Rows.Count > 0 Then
                CMBSeason.SelectedValue = DT.Rows(0)("SeasonDatabaseID")
             End If
        Catch ex As Exception

        End Try
    End Sub
    Sub bindSeason()
        Dim DT As DataTable = objSizeRange.GetSeasons()
        CMBSeason.DataSource = DT
        CMBSeason.DataTextField = "SeasonName"
        CMBSeason.DataValueField = "SeasonDatabaseID"
        CMBSeason.DataBind()
        CMBSeason.Items.Insert(0, New RadComboBoxItem("Select", 0))
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            If cmbType.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Select Type")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                saveFabricConsmp()
                SaveFabricConDtl()
                If lFabricConsumptionID > 0 Then
                Else
                    SaveTaskList()
                End If
                If Session("RoleId") = 46 And Session("Type") = "Merchandising" Then
                    Response.Redirect("FabricConsumptionView.aspx")

                ElseIf Session("RoleId") = 46 And Session("Type") = "G.G.T" Then
                    If ASSS = 1 Then
                        Response.Redirect("FabricConsumptionViewForFStore.aspx")
                    Else
                        Response.Redirect("FabricConsumptionViewForMerch.aspx")
                    End If

                ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                    Response.Redirect("FabricConsumptionView.aspx")
                Else
                    Dim DtCheckk As DataTable = objPORecvMaster.CheckDepartment(userid)
                    If DtCheckk.Rows(0)("Department") = "Merchandising" Then
                        Response.Redirect("FabricConsumptionView.aspx")
                    ElseIf DtCheckk.Rows(0)("Department") = "Fabric Store" Then
                        Response.Redirect("FabricConsumptionView.aspx")
                    ElseIf DtCheckk.Rows(0)("Department") = "G.G.T" Then
                        If ASSS = 1 Then
                            Response.Redirect("FabricConsumptionViewForFStore.aspx")
                        Else
                            Response.Redirect("FabricConsumptionViewForMerch.aspx")
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub BindType()
        Try
            Dim dtType As DataTable
            dtType = objFabricCons.GetFabricConsmpType
            cmbType.DataSource = dtType
            cmbType.DataTextField = "FabricConsumptionType"
            cmbType.DataValueField = "FabricConsumptionTypeID"
            cmbType.DataBind()
            cmbType.Items.Insert(0, New ListItem("Select", "0"))
        Catch ex As Exception
        End Try
    End Sub
    Sub saveFabricConsmp()
        Try
            With objFabricCons
                If lFabricConsumptionID > 0 Then
                    .FabricConsumptionID = lFabricConsumptionID
                Else
                    .FabricConsumptionID = 0
                End If


                If Session("RoleId") = 46 And Session("Type") = "Merchandising" Then
                    If lFabricConsumptionID > 0 Then
                        .UserID = lblidd.Text
                    Else
                        .UserID = 270
                    End If

                ElseIf Session("RoleId") = 46 And Session("Type") = "G.G.T" Then
                    If lFabricConsumptionID > 0 Then
                        .UserID = lblidd.Text
                    Else
                        .UserID = 270
                    End If

                ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                    If lFabricConsumptionID > 0 Then
                        .UserID = lblidd.Text
                    Else
                        .UserID = 270
                    End If

                Else
                    If lFabricConsumptionID > 0 Then
                        .UserID = lblidd.Text
                    Else
                        .UserID = Session("UserId")
                    End If

                End If
                
                .TypeID = cmbType.SelectedValue
                If txtCreationDate.Text = "" Then
                    .FabricConDate = "01/01/1990"
                Else
                    .FabricConDate = txtCreationDate.Text
                End If

                .CreationDate = txtEntryDate.Text
                If txtSrNo.Text = "" Then
                    .SrNo = "N/A"
                Else
                    .SrNo = txtSrNo.Text
                End If
                If txtStyle.Text = "" Then
                    .StyleNo = "N/A"
                Else
                    .StyleNo = txtStyle.Text.ToUpper
                End If
                If txtDesc.Text = "" Then
                    .Description = "N/A"
                Else
                    .Description = txtDesc.Text.ToUpper
                End If
                If txtfabricCons.Text = "" Then
                    .FabricConstruction = "N/A"
                Else
                    .FabricConstruction = txtfabricCons.Text.ToUpper
                End If
                If txtFabricwidth.Text = "" Then
                    .FinishedFabricWidth = "N/A"
                Else
                    .FinishedFabricWidth = txtFabricwidth.Text.ToUpper
                End If

                If txtratio.Text = "" Then
                    .Ratio = "N/A"
                Else
                    .Ratio = txtratio.Text.ToUpper
                End If
                If txttotal.Text = "" Then
                    .Total = "N/A"
                Else
                    .Total = txttotal.Text.ToUpper
                End If

                If txtShrinkageApprox.Text = "" Then
                    .ShrinkageApprox = " "
                Else
                    .ShrinkageApprox = txtShrinkageApprox.Text.ToUpper
                End If

                If txtPrepared1.Text = "" Then
                    .PreparedBy1 = ""
                Else
                    .PreparedBy1 = txtPrepared1.Text.ToUpper
                End If
                If txtPrepared2.Text = "" Then
                    .PreparedBy2 = ""
                Else
                    .PreparedBy2 = txtPrepared2.Text.ToUpper
                End If
                If txtPrepared3.Text = "" Then
                    .PreparedBy3 = ""
                Else
                    .PreparedBy3 = txtPrepared3.Text.ToUpper
                End If
                If txtPrepared4.Text = "" Then
                    .PreparedBy4 = ""
                Else
                    .PreparedBy4 = txtPrepared4.Text.ToUpper
                End If
                If txtPrepared5.Text = "" Then
                    .PreparedBy5 = ""
                Else
                    .PreparedBy5 = txtPrepared5.Text.ToUpper
                End If
                .Buyerid = cmbBuyer.SelectedValue
                .DalNo = txtDalNoO.Text
                .Supplierid = cmbSupplier.SelectedValue

                If ckhAllowToggtFromFStore.Checked = True Then
                    .AllowToGGTFromFStore = 1
                Else
                    .AllowToGGTFromFStore = 0
                End If
                If ckhAllowToggtFromMerch.Checked = True Then
                    .AllowToGGTFromMerch = 1
                Else
                    .AllowToGGTFromMerch = 0
                End If

                If ASSS = 1 Then
                    If lFabricConsumptionID > 0 Then
                        If userid = "238" Then

                            .GGTStatusFromFStore = 1
                        Else
                            .GGTStatusFromFStore = lblAllowToGgtFromFstore.Text
                        End If

                    Else
                        .GGTStatusFromFStore = 0
                    End If
                Else
                    If lFabricConsumptionID > 0 Then
                        If userid = "238" Then
                            .GGTStatusFromMerch = 1
                        Else
                            .GGTStatusFromMerch = lblAllowToGgtFromMerch.Text
                        End If
                    Else
                        .GGTStatusFromMerch = 0
                    End If

                End If
                .ConsumptionDate = Date.Now
                .SeasonDatabaseID = CMBSeason.SelectedValue
                .saveFabricConsmp()
            End With

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btncancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btncancel.Click
        If Session("RoleId") = 46 And Session("Type") = "Merchandising" Then
            Response.Redirect("FabricConsumptionView.aspx")

        ElseIf Session("RoleId") = 46 And Session("Type") = "G.G.T" Then
            If ASSS = 1 Then
                Response.Redirect("FabricConsumptionViewForFStore.aspx")
            Else
                Response.Redirect("FabricConsumptionViewForMerch.aspx")
            End If

        ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
           Response.Redirect("FabricConsumptionView.aspx")
        Else
            Dim DtCheckk As DataTable = objPORecvMaster.CheckDepartment(userid)
            If DtCheckk.Rows(0)("Department") = "Merchandising" Then
                Response.Redirect("FabricConsumptionView.aspx")
            ElseIf DtCheckk.Rows(0)("Department") = "Fabric Store" Then
                Response.Redirect("FabricConsumptionView.aspx")
            ElseIf DtCheckk.Rows(0)("Department") = "G.G.T" Then
                If ASSS = 1 Then
                    Response.Redirect("FabricConsumptionViewForFStore.aspx")
                Else
                    Response.Redirect("FabricConsumptionViewForMerch.aspx")
                End If
            End If
        End If
    End Sub
    Protected Sub cmbType_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbType.SelectedIndexChanged
        lblCons.Text = cmbType.SelectedItem.Text + " Con. Per/Pcs"
    End Sub
    Protected Sub txtStyle_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtStyle.TextChanged
        Try
            Dim dt As DataTable = objFabricCons.GetFromStyleDatabase(txtStyle.Text)
            If dt.Rows.Count > 0 Then
                txtDesc.Text = dt.Rows(0)("Description")

            End If

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtDalNoO_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtDalNoO.TextChanged
        Try
            'Dim dtFBData As DataTable = objFabricCons.GetFBData(txtDalNoO.Text)
            Dim dtFBData As DataTable = objFabricCons.GetItemDatabasedata(txtDalNoO.Text)
            If dtFBData.Rows.Count > 0 Then
                txtfabricCons.Text = dtFBData.Rows(0)("ItemName")
                txtFabricwidth.Text = dtFBData.Rows(0)("Width")
                'txtShrinkageApprox.Text = dtFBData.Rows(0)("Shrinkage")

                'txtfabricCons.Text = dtFBData.Rows(0)("FabricQualityy")
                'txtFabricwidth.Text = dtFBData.Rows(0)("FabricWidth")
                'txtShrinkageApprox.Text = dtFBData.Rows(0)("Shrinkage")
                ' cmbSupplier.SelectedValue = dtFBData.Rows(0)("SupplierID")
            Else
                txtfabricCons.Text = ""
                txtFabricwidth.Text = ""
                txtShrinkageApprox.Text = ""
                cmbSupplier.SelectedValue = 0
            End If


        Catch ex As Exception

        End Try
    End Sub
    Protected Sub BtnStyleDetail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnStyleDetail.Click
        Try
            ' If checkcount > 0 Then
            '    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Only one Body fabric allow")
            'Else
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
            SaveSessionStyleDetailGrid()
            ClearControl()
            ' End If
        Catch ex As Exception

        End Try


    End Sub
    Sub ClearControl()
        lblDPRNDStyleDetailID.Text = 0
        txtStyleDescription.Text = ""

        txtSizes.Text = ""
        txtStyleWidth.Text = ""
        txtShrink.Text = ""
        txtShrinkageWidth.Text = ""
        txtMarketLength.Text = ""

        txtConsumption.Text = ""

    End Sub
    Sub SaveSessionStyleDetailGrid()


        If (Not CType(Session("dtFabricConDetail"), DataTable) Is Nothing) Then
            dtFabricConDetail = Session("dtFabricConDetail")
        Else
            dtFabricConDetail = New DataTable
            With dtFabricConDetail
                .Columns.Add("FabricConsumptionDetailID", GetType(Long))
                .Columns.Add("Description", GetType(String))
                .Columns.Add("Size", GetType(String))
                .Columns.Add("StyleWidth", GetType(String))
                .Columns.Add("ShrinkageLength", GetType(String))
                .Columns.Add("ShrinkageWidth", GetType(String))
                .Columns.Add("MarkerLengthWithSize", GetType(String))
                .Columns.Add("ConsumptionPerPcs", GetType(String))
                .Columns.Add("OtherDetail", GetType(String))
                .Columns.Add("ConsumptionUnitid", GetType(Long))
                .Columns.Add("Unit", GetType(String))

            End With
        End If



        Dr = dtFabricConDetail.NewRow()
        Dr("FabricConsumptionDetailID") = lblDPRNDStyleDetailID.Text
        If txtStyleDescription.Text = "" Then
            Dr("Description") = " "
        Else
            Dr("Description") = txtStyleDescription.Text
        End If
        If txtSizes.Text = "" Then
            Dr("Size") = " "
        Else
            Dr("Size") = txtSizes.Text
        End If
        If txtStyleWidth.Text = "" Then
            Dr("StyleWidth") = " "
        Else
            Dr("StyleWidth") = txtStyleWidth.Text
        End If
        If txtShrink.Text = "" Then
            Dr("ShrinkageLength") = " "
        Else
            Dr("ShrinkageLength") = txtShrink.Text
        End If
        If txtShrinkageWidth.Text = "" Then
            Dr("ShrinkageWidth") = " "
        Else
            Dr("ShrinkageWidth") = txtShrinkageWidth.Text
        End If
        If txtMarketLength.Text = "" Then
            Dr("MarkerLengthWithSize") = " "
        Else
            Dr("MarkerLengthWithSize") = txtMarketLength.Text
        End If
        If txtConsumption.Text = "" Then
            Dr("ConsumptionPerPcs") = 0
        Else
            Dr("ConsumptionPerPcs") = txtConsumption.Text
        End If
        If txtOtherDtl.Text = "" Then
            Dr("OtherDetail") = " "
        Else

            Dr("OtherDetail") = txtOtherDtl.Text
        End If

        Dr("ConsumptionUnitid") = cmbUnit.SelectedValue
        Dr("Unit") = cmbUnit.SelectedItem.Text

        dtFabricConDetail.Rows.Add(Dr)
        Session("dtFabricConDetail") = dtFabricConDetail
        BindStyleDetailGrid()

    End Sub
    Sub BindUnit()
        Try
            Dim dtPONO As DataTable
            dtPONO = objFabricCons.GetBindUnit()
            cmbUnit.DataSource = dtPONO
            cmbUnit.DataTextField = "Unit"
            cmbUnit.DataValueField = "ConsumptionUnitID"
            cmbUnit.DataBind()
            cmbUnit.Items.Insert(0, New RadComboBoxItem("Select", 0))
        Catch ex As Exception
        End Try
    End Sub
    Sub BindStyleDetailGrid()
        If dtFabricConDetail.Rows.Count > 0 Then
            DgStyleDetail.DataSource = dtFabricConDetail
            DgStyleDetail.DataBind()
            DgStyleDetail.Visible = True
        Else
            DgStyleDetail.Visible = False
        End If
    End Sub
    Protected Sub DgStyleDetail_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles DgStyleDetail.ItemCommand
        Select Case e.CommandName
            Case "Edit"
                dtFabricConDetail = CType(Session("dtFabricConDetail"), DataTable)
                If (Not dtFabricConDetail Is Nothing) Then
                    If (dtFabricConDetail.Rows.Count > 0) Then
                        Dim item As GridDataItem = DirectCast(DgStyleDetail.MasterTableView.Items(e.Item.ItemIndex), GridDataItem)
                        Dim FabricConsumptionDetailID As Integer = item("FabricConsumptionDetailID").Text
                        SetDetailValuesByDataTable(e.Item.ItemIndex)
                        dtFabricConDetail.Rows.RemoveAt(e.Item.ItemIndex)
                        BindStyleDetailGrid()

                    End If
                End If
            Case "Delete"
                dtFabricConDetail = CType(Session("dtFabricConDetail"), DataTable)
                If (Not dtFabricConDetail Is Nothing) Then
                    If (dtFabricConDetail.Rows.Count > 0) Then
                        Dim FabricConsumptionDetailID As Integer = dtFabricConDetail.Rows(e.Item.ItemIndex)("FabricConsumptionDetailID")
                        dtFabricConDetail.Rows.RemoveAt(e.Item.ItemIndex)
                        objFabricConsumptionDetail.DeleteStyledetail(FabricConsumptionDetailID)
                        BindStyleDetailGrid()
                    Else
                    End If

                End If
        End Select
    End Sub
    Sub SetDetailValuesByDataTable(ByVal dtrowNo As Long)
        Try
            lblDPRNDStyleDetailID.Text = dtFabricConDetail.Rows(dtrowNo)("FabricConsumptionDetailID")
            txtStyleDescription.Text = dtFabricConDetail.Rows(dtrowNo)("Description")
            

            txtSizes.Text = dtFabricConDetail.Rows(dtrowNo)("Size")
            txtStyleWidth.Text = dtFabricConDetail.Rows(dtrowNo)("StyleWidth")
            txtShrink.Text = dtFabricConDetail.Rows(dtrowNo)("ShrinkageLength")
            txtShrinkageWidth.Text = dtFabricConDetail.Rows(dtrowNo)("ShrinkageWidth")
            txtMarketLength.Text = dtFabricConDetail.Rows(dtrowNo)("MarkerLengthWithSize")
            txtConsumption.Text = dtFabricConDetail.Rows(dtrowNo)("ConsumptionPerPcs")

            txtOtherDtl.Text = dtFabricConDetail.Rows(dtrowNo)("OtherDetail")
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveFabricConDtl()
        Try
            Dim x As Integer
            For x = 0 To DgStyleDetail.Items.Count - 1
                Dim item As GridDataItem = DirectCast(DgStyleDetail.MasterTableView.Items(x), GridDataItem)
                With objFabricConsumptionDetail
                    .FabricConsumptionDetailID = item("FabricConsumptionDetailID").Text

                    If lFabricConsumptionID > 0 Then
                        .FabricConsumptionID = lFabricConsumptionID
                    Else
                        .FabricConsumptionID = objFabricCons.GetID
                    End If
                    .Description = item("Description").Text.ToUpper
                    .Sizes = item("Size").Text.ToUpper
                    .StyleWidth = item("StyleWidth").Text.ToUpper
                    .ShrinkageLength = item("ShrinkageLength").Text.ToUpper
                    .ShrinkageWidth = item("ShrinkageWidth").Text.ToUpper
                    .MarkerLengthWithSize = item("MarkerLengthWithSize").Text.ToUpper
                    .ConsumptionPerPcs = item("ConsumptionPerPcs").Text
                    .OtherDetail = item("OtherDetail").Text.ToUpper
                    .ConsumptionUnitid = item("ConsumptionUnitid").Text.ToUpper

                    .SaveStyleDtl()
                End With
            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveTaskList()
        With objPatternDepartTaskListMst
            .PATTERNDEPARTMENTTASKLISTMstid = 0
            .UserId = Session("UserId")
            .TypeID = cmbType.SelectedValue
            .Style = txtStyle.Text
            .StyleID = 0
            .SRNO = txtSrNo.Text
            .JobOrderId = 0
            .Buyer = cmbBuyer.SelectedItem.Text
            .BuyerID = cmbBuyer.SelectedValue
            .CreationDate = Date.Now
            .TaskNo = lblTaskNo.Text
            .Priority = 0 'lblProirty.Text
            .DateTimeStamp = txtCreationDate.Text
            .CreationTime = ""
            .Sample = 0
            .Pattern = 0
            .Dossier = 0
            .SizeSpecs = 0
            .ReadByGGTDept = "01/01/1900"
            .FinishTimeStamp = ""
            .Remarks = "N/A"
            .Bit = 0
            .DPRNDId = 0
            If ASSS = 1 Then
                .FabricCosumFstoreID = objFabricCons.GetID
            Else
                .FabricCosumMerchID = objFabricCons.GetID
            End If
            .Save()
        End With
    End Sub
    Sub NoGenerateOnLoad()
        Try
            Dim month As String = Voucherdate.Month
            Dim LastVoucherNo As String = objFabricCons.GetLastNoForTaskListEntry()
            Dim LastCode As String
            If LastVoucherNo = "" Then
                LastCode = "0001"
            Else
                LastCode = LastVoucherNo.Substring(4, 4)
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
                        LastCode = "" & Val(LastCode + 1)
                    Else
                        LastCode = "0" & Val(LastCode + 1)
                    End If
                ElseIf LastCode < 10000 Or LastCode = 1000 Then
                    If LastCode = 9999 Then
                        LastCode = Val(LastCode + 1)
                    Else
                        LastCode = "" & Val(LastCode + 1)
                    End If


                Else
                    LastCode = Val(LastCode + 1)
                End If
            End If
            VoucherNo = "TSK" & "-" & LastCode
            lblTaskNo.Text = VoucherNo
            lblProirty.Text = VoucherNo.Substring(4, 4)
        Catch ex As Exception

        End Try
    End Sub
End Class
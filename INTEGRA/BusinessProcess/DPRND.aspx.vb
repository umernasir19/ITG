Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.Xml
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Net
Imports System.Net.Mail
Public Class DPRND
    Inherits System.Web.UI.Page
    Dim ObjTblRND As New TblDPRND
    Dim lDPRNDID, userid As Long
    Dim ObjDPItemDatabase As New DPItemDatabase
    Dim dtAccess As DataTable
    Dim Dr As DataRow
    Dim dtStyleDetail As DataTable
    Dim ObjDPRNDStyleDetail As New DPRNDStyleDetail
    Dim ObjDPRNDAccessDetail As New DPRNDAccessDetail
    Dim ObjDPFabricIssue As New DPFabricIssue
    Dim ObjPatternDepartTaskListDtl As New PatternDepartTaskListDtl
    Dim objPatternDepartTaskListMst As New PatternDepartTaskListMstNew
    Dim TaskNo As String
    Dim Priority As Decimal
    Dim objFabricCons As New FabricConsump
    Dim VoucherNo As String
    Dim Voucherdate As Date = Date.Now
    Dim objStyle As New Style2
    Dim objPORecvMaster As New PORecvMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lDPRNDID = Request.QueryString("lDPRNDID")
        userid = Session("UserId")
        If Not Page.IsPostBack Then
            Session("FileNameP") = Nothing
            Session("ImageByteP") = Nothing
            Session("ImageByteTP") = Nothing
            Session("FileNameTP") = Nothing
            Session("dtAccess") = Nothing
            Session("dtStyleDetail") = Nothing
            BindItemDatabase()
            Dim DtCheckk As DataTable = objPORecvMaster.CheckDepartment(userid)
         If DtCheckk.Rows(0)("Department") = "G.G.T" Then
                ReadonlyAttributes()
                lblFabric.Visible = False
                Label6.Visible = False
                txtFabricPrice.Visible = False
                txtGarmentPrice.Visible = False
                BtnStyleDetail.Text = "Update Style Detail"
                dgAccess.Columns(6).Visible = False
                DgStyleDetail.Columns(7).Visible = False
                Label17.Visible = False
                txtStylePrice.Visible = False
                cmbUnit.Visible = True
                BindUnit()
            Else
                DgStyleDetail.Columns(11).Visible = False
                DgStyleDetail.Columns(12).Visible = False
                PanelFabric.Visible = True
                pnldd.Visible = True
                lblFabric.Visible = True
                Label6.Visible = True
                txtFabricPrice.Visible = True
                txtGarmentPrice.Visible = True
                Label17.Visible = True
                txtStylePrice.Visible = True
                cmbUnit.Visible = False
            End If
            txtCreationDatee.SelectedDate = Date.Now
            BindCustomer()
            If lDPRNDID > 0 Then
                btnSave.Text = "Update"
                Edit()
            Else
                btnSave.Text = "Save"
                txtDept.Text = "RND"
                txtPatern.Text = "N/A"
                PakistanTimezoneNew()
                NoGenerateOnLoad()
            End If
        End If
    End Sub
    Sub PakistanTimezone()
        Dim timeZoneInfo As TimeZoneInfo
        Dim dateTime As DateTime
        timeZoneInfo = timeZoneInfo.FindSystemTimeZoneById("Pakistan Standard Time")
        dateTime = timeZoneInfo.ConvertTime(dateTime.Now, timeZoneInfo)
        Dim time As String = dateTime.ToLongTimeString()
        txtCreationTime.Text = time
    End Sub
    Sub PakistanTimezoneNew()
        txtCreationTime.Text = DateTime.Now.ToString("HH:mm:ss")
    End Sub
    Sub ReadonlyAttributes()
        txtCreationDatee.Enabled = False
        cmbBuyer.Enabled = False
        ckhAllowToggt.Enabled = False
        txtStyle.ReadOnly = True
        txtDept.ReadOnly = True
        txtDalNoO.ReadOnly = True
        txtQty.ReadOnly = True
        txtSize.ReadOnly = True
        txtBuyerReferenceNo.ReadOnly = True
        txtPatern.ReadOnly = True
        txtWidthCuteable.ReadOnly = True
        txtWasshDtl.ReadOnly = True
        txtpocketLining.ReadOnly = True
        txtThreads.ReadOnly = True
        cmbACCESSORIES.Enabled = False
        txtConsPer.ReadOnly = True
        txtPrice.ReadOnly = True
        txtDescription.ReadOnly = True
        btnAddAccessories.ReadOnly = True
        dgAccess.Enabled = False
        FileUpload2.Enabled = False
        btnUpload.Enabled = False
        FileUploadTechPack.Enabled = False
        Button1.Enabled = False
        txtRemarks.Enabled = False


    End Sub
    Sub Edit()
        Dim dt As DataTable
        Dim dtacc As DataTable
        Dim dtStyle As DataTable
        dt = ObjTblRND.GetEditData(lDPRNDID)
        dtacc = ObjTblRND.GetEditAccStyle(lDPRNDID)
        dtStyle = ObjTblRND.GetEditStyleNew(lDPRNDID)
        If dt.Rows.Count > 0 Then
            txtCreationDatee.SelectedDate = dt.Rows(0)("CreatDate")
            cmbBuyer.SelectedValue = dt.Rows(0)("CustomerId")
            txtStyle.Text = dt.Rows(0)("Style")
            txtDept.Text = dt.Rows(0)("Dept")
            txtDalNoO.Text = dt.Rows(0)("DALNo")
            lblAllowToGgt.Text = dt.Rows(0)("GGTStatus")
            If dt.Rows(0)("CreationTime") = "" Then
                PakistanTimezone()
            Else
                txtCreationTime.Text = dt.Rows(0)("CreationTime")
            End If
            Dim AGGT As Boolean = dt.Rows(0)("AllowToGGT")
            If AGGT = True Then
                ckhAllowToggt.Checked = True
            ElseIf AGGT = False Then
                ckhAllowToggt.Checked = False
            End If
            Dim LOGT As Boolean = dt.Rows(0)("LockToGGT")
            If LOGT = True Then
                chklocktoggt.Checked = True
            ElseIf LOGT = False Then
                chklocktoggt.Checked = False
            End If
            Dim DS As Boolean = dt.Rows(0)("DigitalSignature")
            If DS = True Then
                chkDigitalSignature.Checked = True
            ElseIf DS = False Then
                chkDigitalSignature.Checked = False
            End If
            Dim dtFBData As DataTable = ObjTblRND.GetFBData(txtDalNoO.Text)
            Dim dtPORecvQty As DataTable = ObjTblRND.GetRecvQtyForSampleIssue(dtFBData.Rows(0)("FabricDBMstId"))
            If dtFBData.Rows.Count > 0 Then
                txtSupplierRef.Text = dtFBData.Rows(0)("SupplierArtNo")
                txtSupplierName.Text = dtFBData.Rows(0)("SupplierName")
                txtQuality.Text = dtFBData.Rows(0)("SupplierName")
                txtComposition.Text = dtFBData.Rows(0)("CompositionName")
                txtQuality.Text = dtFBData.Rows(0)("FabricQuality")
                txtColour.Text = dtFBData.Rows(0)("Color")
                txtWidth.Text = dtFBData.Rows(0)("FabricWidth")
                txtDye.Text = dtFBData.Rows(0)("DyeWash")
                txtFinish.Text = dtFBData.Rows(0)("FinishGSM")
                lblFabricMstId.Text = dtFBData.Rows(0)("FabricDBMstId")
                txtAvailFab.Text = Val(dtFBData.Rows(0)("OPQty")) + Val(dtFBData.Rows(0)("PurchaseQty")) - (Val(dtPORecvQty.Rows(0)("BalanceQty")))
            End If
            txtQty.Text = dt.Rows(0)("Quantity")
            txtSize.Text = dt.Rows(0)("Size")
            txtpocketLining.Text = dt.Rows(0)("Pocketlining")
            txtPatern.Text = dt.Rows(0)("Pattern")
            txtWasshDtl.Text = dt.Rows(0)("WashingDetail")
            txtThread.Text = dt.Rows(0)("Thread")
            txtWidthCuteable.Text = dt.Rows(0)("WidthCutable")
            txtRemarks.Text = dt.Rows(0)("Remarks")
            txtThreads.Text = dt.Rows(0)("Threads")
            txtFabricPrice.Text = dt.Rows(0)("FabricPrice")
            txtGarmentPrice.Text = dt.Rows(0)("GarmentPrice")
            txtBuyerReferenceNo.Text = dt.Rows(0)("BuyerReferenceNo")
            If dt.Rows(0)("FileName") = "" Then
                pictureNotAvialable()
            Else
                Session("FileNameDPRN") = dt.Rows(0)("FileName")
                Session("ImageByteP") = dt.Rows(0)("Image")
            End If
            If dt.Rows(0)("FileNameGPD") = "" Then
                pictureNotAvialablegdp()
            Else
                Session("FileNameGDP") = dt.Rows(0)("FileNameGPD")
                Session("ImageByteGDP") = dt.Rows(0)("ImageGDP")
            End If
            If dt.Rows(0)("FileNameTP") = "" Then
                pictureNotAvialablegTP()
            Else
                Session("FileNameTP") = dt.Rows(0)("FileNameTP")
                Session("ImageByteTP") = dt.Rows(0)("ImageTechPack")
            End If
            lnkFIlePicture.Visible = True
            btnShowGdpImage.Visible = True
            LinkButton1.Visible = True
            Button1.Visible = True
            lblFabricMstId.Text = dt.Rows(0)("FabricDBMstId")
            dtAccess = New DataTable
            With dtAccess
                .Columns.Add("DPRNDAccessDetailID", GetType(Long))
                .Columns.Add("DPItemDatabaseID", GetType(Long))
                .Columns.Add("DPRNDID", GetType(Long))
                .Columns.Add("ItemName", GetType(String))
                .Columns.Add("DESCRIPTION", GetType(String))
                .Columns.Add("CONSPER", GetType(Decimal))
                .Columns.Add("Price", GetType(Decimal))
            End With
            For x = 0 To dtacc.Rows.Count - 1
                Dr = dtAccess.NewRow()
                Dr = dtAccess.NewRow()
                Dr("DPRNDAccessDetailID") = dtacc.Rows(x)("DPRNDAccessDetailID")
                Dr("DPItemDatabaseID") = dtacc.Rows(x)("DPItemDatabaseID")
                Dr("DPRNDID") = dtacc.Rows(x)("DPRNDID")
                Dr("ItemName") = dtacc.Rows(x)("ItemName")
                Dr("DESCRIPTION") = dtacc.Rows(x)("DESCRIPTION")
                Dr("CONSPER") = dtacc.Rows(x)("CONSPER")
                Dr("Price") = dtacc.Rows(x)("Price")
                dtAccess.Rows.Add(Dr)
            Next
            Session("dtAccess") = dtAccess
            BindAccessGrid()
        End If
        dtStyleDetail = New DataTable
        With dtStyleDetail
            .Columns.Add("DPRNDStyleDetailID", GetType(Long))
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
            Dr = dtStyleDetail.NewRow()
            Dr("DPRNDStyleDetailID") = dtStyle.Rows(y)("DPRNDStyleDetailID")
            Dr("Description") = dtStyle.Rows(y)("Description")
            Dr("IsBodyFabric") = dtStyle.Rows(y)("IsBodyFabric")
            Dr("Size") = dtStyle.Rows(y)("Sizes")
            Dr("StyleWidth") = dtStyle.Rows(y)("StyleWidth")
            Dr("ShrinkageLength") = dtStyle.Rows(y)("ShrinkageLength")
            Dr("ShrinkageWidth") = dtStyle.Rows(y)("ShrinkageWidth")
            Dr("MarkerLengthWithSize") = dtStyle.Rows(y)("MarkerLengthWithSize")
            Dr("ConsumptionPerPcs") = dtStyle.Rows(y)("ConsumptionPerPcs")
            Dr("OtherDetail") = dtStyle.Rows(y)("OtherDetail")
            Dr("Price") = dtStyle.Rows(y)("Price")
            Dr("ConsumptionUnitid") = dtStyle.Rows(y)("ConsumptionUnitidd")
            Dr("Unit") = dtStyle.Rows(y)("Unit")
            dtStyleDetail.Rows.Add(Dr)
        Next
        Session("dtStyleDetail") = dtStyleDetail
        BindStyleDetailGrid()
    End Sub
    Sub BindCustomer()
        Dim dtsupplier As DataTable
        dtsupplier = ObjTblRND.GetCustomer
        cmbBuyer.DataSource = dtsupplier
        cmbBuyer.DataTextField = "CustomerName"
        cmbBuyer.DataValueField = "CustomerID"
        cmbBuyer.DataBind()
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            Try
                If txtCreationDatee.ValidationDate = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Date")
                ElseIf txtQty.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Qty")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    If lDPRNDID > 0 Then
                        Save()
                        SaveRNDDtlAccessDtl()
                        SaveRNDStyleDtl()
                        Response.Redirect("DPRNDView.aspx")
                    Else
                        Save()
                        SaveRNDDtlAccessDtl()
                        SaveRNDStyleDtl()
                        SaveTaskList()
                        Response.Redirect("DPRNDView.aspx")
                    End If
                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveTaskList()
        With objPatternDepartTaskListMst
            .PATTERNDEPARTMENTTASKLISTMstid = 0
            If Session("RoleId") = 46 And Session("Type") = "R.N.D" Then
                    .UserId = 270
            Else
                .UserId = userid
            End If
            .TypeID = 1
            .Style = txtStyle.Text
            .StyleID = 0
            .SRNO = ""
            .JobOrderId = 0
            .Buyer = cmbBuyer.SelectedItem.Text
            .BuyerID = cmbBuyer.SelectedValue
            .CreationDate = Date.Now
            .TaskNo = lblTaskNo.Text
            .Priority = 0 'lblProirty.Text
            .DateTimeStamp = txtCreationDatee.SelectedDate
            .CreationTime = txtCreationTime.Text
            .Sample = 0
            .Pattern = 0
            .Dossier = 0
            .SizeSpecs = 0
            .ReadByGGTDept = "01/01/1900"
            .FinishTimeStamp = ""
            .Remarks = "N/A"
            .Bit = 0
            .DPRNDId = ObjTblRND.GetID
            .FabricCosumFstoreID = 0
            .FabricCosumMerchID = 0
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
    Sub Save()
        With ObjTblRND
            If lDPRNDID > 0 Then
                .DPRNDID = lDPRNDID
            Else
                .DPRNDID = 0
            End If
            .CreatDate = txtCreationDatee.SelectedDate
            .CustomerId = cmbBuyer.SelectedValue
            .Buyer = cmbBuyer.SelectedItem.Text.ToUpper
            .Style = txtStyle.Text.ToUpper
            .ContactNo = "na"
            .Dept = txtDept.Text.ToUpper
            .DALNo = txtDalNoO.Text.ToUpper
            .Quantity = txtQty.Text
            .Size = txtSize.Text.ToUpper
            If txtpocketLining.Text = "" Then
                .Pocketlining = "N/A"
            Else
                .Pocketlining = txtpocketLining.Text.ToUpper
            End If
            If txtThreads.Text = "" Then
                .Threads = "N/A"
            Else
                .Threads = txtThreads.Text.ToUpper
            End If
            .Pattern = txtPatern.Text.ToUpper
            .WashingDetail = txtWasshDtl.Text.ToUpper
            .Thread = "N/A"
            .WidthCutable = txtWidthCuteable.Text.ToUpper
            .Remarks = txtRemarks.Text.ToUpper
            If txtFabricPrice.Text = "" Then
                .FabricPrice = 0
            Else
                .FabricPrice = txtFabricPrice.Text
            End If
            If txtGarmentPrice.Text = "" Then
                .GarmentPrice = 0
            Else
                .GarmentPrice = txtGarmentPrice.Text
            End If
            If Session("FileNameDPRN") = "" Then
                pictureNotAvialable()
                .FileName = Session("FileNameDPRN")
                .Image = Session("ImageByteP")
            Else
                .FileName = Session("FileNameDPRN")
                .Image = Session("ImageByteP")
            End If
            If Session("FileNameGDP") = "" Then
                pictureNotAvialablegdp()
                .FileNameGPD = Session("FileNameGDP")
                .ImageGDP = Session("ImageByteGDP")
            Else
                .FileNameGPD = Session("FileNameGDP")
                .ImageGDP = Session("ImageByteGDP")
            End If
            If Session("FileNameTP") = "" Then
                pictureNotAvialablegTP()
                .FileNameTP = Session("FileNameTP")
                .ImageTechPack = Session("ImageByteGDP")
            Else
                .FileNameTP = Session("FileNameTP")
                .ImageTechPack = Session("ImageByteTP")
            End If
            .FabricDBMstId = lblFabricMstId.Text
            .BuyerReferenceNo = txtBuyerReferenceNo.Text

            If ckhAllowToggt.Checked = True Then
                .AllowToGGT = 1
            Else
                .AllowToGGT = 0
            End If
            If chklocktoggt.Checked = True Then
                .LockToGGT = 1
            Else
                .LockToGGT = 0
            End If
            If lDPRNDID > 0 Then
                Dim DtCheckk As DataTable = objPORecvMaster.CheckDepartment(userid)
                If DtCheckk.Rows(0)("Department") = "G.G.T" Then
                    .GGTStatus = 1
                Else
                    .GGTStatus = lblAllowToGgt.Text
                End If
            Else
                .GGTStatus = 0
            End If
                .CreationTime = txtCreationTime.Text
                If userid = "238" Then
                    .ConsumptionDate = Date.Now
                Else
                    .ConsumptionDate = "01/01/1900"
                End If
                If chkDigitalSignature.Checked = True Then
                    .DigitalSignature = 1
                Else
                    .DigitalSignature = 0
                End If
                .SaveRND()
        End With
        Dim dt As DataTable = objStyle.GetRNDID()
        Dim id As Long = dt.Rows(0)("DPRNDID")
        Dim dtt As DataTable = objStyle.GetStyle(id)
        Dim Stylee As String = dtt.Rows(0)("Style")
        Dim UpdateStyle As String = Stylee.Replace("\", "/")
        objStyle.UpdateStyleOnRND(id, UpdateStyle)
    End Sub
    Sub SaveRNDDtlAccessDtl()
        Try
            Dim x As Integer
            For x = 0 To dgAccess.Items.Count - 1
                Dim item As GridDataItem = DirectCast(dgAccess.MasterTableView.Items(x), GridDataItem)
                With ObjDPRNDAccessDetail
                    .DPRNDAccessDetailID = item("DPRNDAccessDetailID").Text
                    .DPItemDatabaseID = item("DPItemDatabaseID").Text
                    If lDPRNDID > 0 Then
                        .DPRNDID = lDPRNDID
                    Else
                        .DPRNDID = ObjTblRND.GetID
                    End If
                    .ItemName = item("ItemName").Text.ToUpper
                    .DESCRIPTION = item("DESCRIPTION").Text.ToUpper
                    .CONSPER = item("CONSPER").Text
                    .Price = item("Price").Text
                    .SaveAcc()
                End With
            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveRNDStyleDtl()
        Try
            Dim x As Integer
            For x = 0 To DgStyleDetail.Items.Count - 1
                Dim item As GridDataItem = DirectCast(DgStyleDetail.MasterTableView.Items(x), GridDataItem)

                With ObjDPRNDStyleDetail
                    .DPRNDStyleDetailID = item("DPRNDStyleDetailID").Text

                    If lDPRNDID > 0 Then
                        .DPRNDID = lDPRNDID
                    Else
                        .DPRNDID = ObjTblRND.GetID
                    End If
                    .Description = item("Description").Text.ToUpper
                    .IsBodyFabric = item("IsBodyFabric").Text
                    .Sizes = item("Size").Text.ToUpper
                    .StyleWidth = item("StyleWidth").Text.ToUpper
                    .ShrinkageLength = item("ShrinkageLength").Text.ToUpper
                    .ShrinkageWidth = item("ShrinkageWidth").Text.ToUpper
                    .MarkerLengthWithSize = item("MarkerLengthWithSize").Text.ToUpper
                    .ConsumptionPerPcs = item("ConsumptionPerPcs").Text
                    .OtherDetail = item("OtherDetail").Text.ToUpper
                    If userid = "238" Then
                        .Price = 0
                    Else
                        .Price = item("Price").Text
                    End If


                    If userid = "238" Then
                        .ConsumptionUnitid = item("ConsumptionUnitid").Text.ToUpper
                    Else
                        .ConsumptionUnitid = 0
                    End If
                    .SaveStyleDtl()
                End With
            Next
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("DPRNDView.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub lnkFIlePicture_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkFIlePicture.Click
        Try
                      ScriptManager.RegisterClientScriptBlock(Me.UpPic, Me.UpPic.GetType(), "New ClientScript", "window.open('RNDPicturePopup.aspx', 'newwindow', 'left=12, top=60, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no');", True)
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnShowGdpImage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShowGdpImage.Click
        Try
            
            ScriptManager.RegisterClientScriptBlock(Me.upgdp, Me.upgdp.GetType(), "New ClientScript", "window.open('GDPPicturePopup.aspx', 'newwindow', 'left=12, top=60, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no');", True)
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtDalNoO_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtDalNoO.TextChanged
        Try
            Dim DtCheckExistingDalNo As DataTable = ObjTblRND.CheckExistingDalNo(txtDalNoO.Text)
            If DtCheckExistingDalNo.Rows.Count > 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                Dim dtFBData As DataTable = ObjTblRND.GetFBData(txtDalNoO.Text)
                Dim dtFBRecv As DataTable = ObjDPFabricIssue.GetFBRcvQty(txtDalNoO.Text)
                Dim dtFBIssue As DataTable = ObjDPFabricIssue.GetFBIssueQty(txtDalNoO.Text)
                Dim dtDPFBIssue As DataTable = ObjDPFabricIssue.GetDPFBIssueQty(txtDalNoO.Text)
                Dim FBRecv As Decimal = 0
                Dim FBIssue As Decimal = 0
                Dim DPFBIssue As Decimal = 0
                If dtFBRecv.Rows.Count > 0 Then
                    FBRecv = dtFBRecv.Rows(0)("ReceiveQty")
                End If
                If dtFBIssue.Rows.Count > 0 Then
                    FBIssue = dtFBIssue.Rows(0)("IssueQty")
                End If
                If dtDPFBIssue.Rows.Count > 0 Then
                    DPFBIssue = dtDPFBIssue.Rows(0)("IssueQty")
                End If
                If dtFBData.Rows.Count > 0 Then

                    txtSupplierRef.Text = dtFBData.Rows(0)("SupplierArtNo")
                    txtSupplierName.Text = dtFBData.Rows(0)("SupplierName")
                    txtQuality.Text = dtFBData.Rows(0)("SupplierName")
                    txtComposition.Text = dtFBData.Rows(0)("CompositionName")
                    txtQuality.Text = dtFBData.Rows(0)("FabricQuality")
                    txtColour.Text = dtFBData.Rows(0)("Color")
                    txtWidth.Text = dtFBData.Rows(0)("FabricWidth")
                    txtDye.Text = dtFBData.Rows(0)("DyeWash")
                    txtFinish.Text = dtFBData.Rows(0)("FinishGSM")
                    lblFabricMstId.Text = dtFBData.Rows(0)("FabricDBMstId")
                    txtAvailFab.Text = (Val(dtFBData.Rows(0)("OPQty")) + Val(dtFBData.Rows(0)("PurchaseQty")) + FBRecv - FBIssue - DPFBIssue)
                    txtWidthCuteable.Text = dtFBData.Rows(0)("FabricWidth")

                End If
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Dal No Not Exist")
                txtDalNoO.Text = ""
                txtDalNoO.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtStyle_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtStyle.TextChanged
        Try
            Dim DtCheckExistingStyle As DataTable = ObjTblRND.CheckExistingStyleForStyleDatabaseNew(txtStyle.Text)
            If DtCheckExistingStyle.Rows.Count > 0 Then
                Dim dt As DataTable = ObjTblRND.GetFrontImageFromStyleDatabaseNew(txtStyle.Text)
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                If dt.Rows.Count > 0 Then
                    Session("FileNameDPRN") = Nothing
                    Session("ImageByteP") = Nothing
                    txtBuyerReferenceNo.Text = dt.Rows(0)("BuyerReferenceNo")
                    cmbBuyer.SelectedValue = dt.Rows(0)("CustomerID")
                    cmbBuyer.Enabled = True
                    Dim FileNameFrontt As String = dt.Rows(0)("FileNameFront")
                    Dim FileNameFronttt As String = FileNameFrontt.Substring(0, 8)
                    If FileNameFronttt = "no-image" Then
                        lnkFIlePicture.Visible = False
                        btnUpload.Visible = True
                    Else
                        Dim FileName As String = dt.Rows(0)("FileNameFront")
                        Dim bytes As Byte() = dt.Rows(0)("ImageFront")
                        Session("FileNameDPRN") = FileName
                        Session("ImageByteP") = bytes
                        lnkFIlePicture.Visible = True
                        btnUpload.Visible = False
                    End If
                Else
                    cmbBuyer.Enabled = True
                End If
                Dim dtt As DataTable = ObjTblRND.GetBackImageFromStyleDatabaseNew(txtStyle.Text)
                If dtt.Rows.Count > 0 Then

                    Session("FileNameTP") = Nothing
                    Session("ImageByteTP") = Nothing
                    Dim FileNameBackk As String = dt.Rows(0)("FileNameBack")
                    Dim FileNameBackkk As String = FileNameBackk.Substring(0, 8)
                    If FileNameBackkk = "no-image" Then
                        LinkButton1.Visible = False
                        Button1.Visible = True
                    Else
                        Dim FileNamee As String = dtt.Rows(0)("FileNameBack")
                        Dim bytess As Byte() = dtt.Rows(0)("ImageBack")
                        Session("FileNameTP") = FileNamee
                        Session("ImageByteTP") = bytess
                        LinkButton1.Visible = True
                        Button1.Visible = False
                    End If
                End If
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Style Not Exist")
                txtStyle.Text = ""
                txtStyle.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpload.Click
        Try
            Session("FileNameDPRN") = Nothing
            Session("ImageByteP") = Nothing
            Dim fileExt As String = System.IO.Path.GetExtension(FileUpload2.FileName)
            If FileUpload2.FileName = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                pictureNotAvialable()
                lnkFIlePicture.Visible = True
            ElseIf fileExt = ".jpg" Or fileExt = ".pdf" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                Dim FileNameTP As String = ""
                Dim fs As System.IO.Stream = FileUpload2.PostedFile.InputStream
                Dim br As New System.IO.BinaryReader(fs)
                Dim bytesTP As Byte() = br.ReadBytes(CType(fs.Length, Integer))
                FileNameTP = FileUpload2.FileName
                Session("FileNameDPRN") = FileNameTP
                Session("ImageByteP") = bytesTP
                lnkFIlePicture.Visible = True
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Only jpg or Pdf file allow to upload")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnUploadGDP_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUploadGDP.Click
        Try
            Session("FileNameGDP") = Nothing
            Session("ImageByteGDP") = Nothing
            Dim fileExt As String = System.IO.Path.GetExtension(FileUpload1.FileName)
            If FileUpload1.FileName = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                pictureNotAvialablegdp()
                btnShowGdpImage.Visible = True
            ElseIf fileExt = ".jpg" Or fileExt = ".pdf" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                Dim FileNameTP As String = ""
                Dim fs As System.IO.Stream = FileUpload1.PostedFile.InputStream
                Dim br As New System.IO.BinaryReader(fs)
                Dim bytesTP As Byte() = br.ReadBytes(CType(fs.Length, Integer))
                FileNameTP = FileUpload1.FileName
                Session("FileNameGDP") = FileNameTP
                Session("ImageByteGDP") = bytesTP
                btnShowGdpImage.Visible = True
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Only jpg or Pdf file allow to upload")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub pictureNotAvialable()
        Dim path As String = Server.MapPath("../Images/" & "no-image.jpg")
        Session("ImageByteP") = GetFileContent(path)
        Session("FileNameDPRN") = "no-image.jpg"
    End Sub
    Sub pictureNotAvialablegdp()
        Dim path As String = Server.MapPath("../Images/" & "no-image.jpg")
        Session("ImageByteGDP") = GetFileContent(path)
        Session("FileNameGDP") = "no-image.jpg"
    End Sub
    Sub pictureNotAvialablegTP()
        Dim path As String = Server.MapPath("../Images/" & "no-image.jpg")
        Session("ImageByteTP") = GetFileContent(path)
        Session("FileNameTP") = "no-image.jpg"
    End Sub
    Private Function GetFileContent(ByVal imageFilePath As String) As Byte()
        Dim fileStream As Stream = New FileStream(imageFilePath, FileMode.Open)
        Dim fileContent As Byte() = New Byte(fileStream.Length - 1) {}
        fileStream.Read(fileContent, 0, CInt(fileStream.Length))
        fileStream.Close()
        Return fileContent
    End Function
    Protected Sub btnAddAccess_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAddAccess.Click
        Try
            cmbACCESSORIES.Visible = False
            txtThread.Visible = True
            btnAddAccess.Visible = False
            btnSaveAccess.Visible = True
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnSaveAccess_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSaveAccess.Click
        Try


            Dim dt As DataTable = ObjTblRND.CheckExistingRNDAccess(txtThread.Text)
            If dt.Rows.Count > 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Accessories Already Exist")

            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                If txtThread.Text = "" Then

                Else
                    With ObjDPItemDatabase
                        .DPItemDatabaseID = 0
                        .DPItemName = txtThread.Text.ToUpper
                        .Save()
                    End With

                End If
                BindItemDatabase()
                cmbACCESSORIES.Visible = True
                txtThread.Text = ""
                txtThread.Visible = False
                btnAddAccess.Visible = True
                btnSaveAccess.Visible = False

            End If

        Catch ex As Exception

        End Try
    End Sub
    Sub BindItemDatabase()
        Dim dtsupplier As DataTable
        dtsupplier = ObjTblRND.GetDPItemDatabase
        cmbACCESSORIES.DataSource = dtsupplier
        cmbACCESSORIES.DataTextField = "DPItemName"
        cmbACCESSORIES.DataValueField = "DPItemDatabaseID"
        cmbACCESSORIES.DataBind()

    End Sub
    Sub SaveSession()


        If (Not CType(Session("dtAccess"), DataTable) Is Nothing) Then
            dtAccess = Session("dtAccess")
        Else
            dtAccess = New DataTable
            With dtAccess
                .Columns.Add("DPRNDAccessDetailID", GetType(Long))
                .Columns.Add("DPItemDatabaseID", GetType(Long))
                .Columns.Add("DPRNDID", GetType(Long))
                .Columns.Add("ItemName", GetType(String))
                .Columns.Add("DESCRIPTION", GetType(String))
                .Columns.Add("CONSPER", GetType(Decimal))
                .Columns.Add("Price", GetType(Decimal))


            End With
        End If



        Dr = dtAccess.NewRow()
        Dr("DPRNDAccessDetailID") = 0
        Dr("DPItemDatabaseID") = cmbACCESSORIES.SelectedValue
        Dr("DPRNDID") = lDPRNDID
        Dr("ItemName") = cmbACCESSORIES.SelectedItem.Text

        If txtDescription.Text = "" Then
            Dr("DESCRIPTION") = "N/A"
        Else
            Dr("DESCRIPTION") = txtDescription.Text
        End If

        If txtConsPer.Text = "" Then
            Dr("CONSPER") = 0
        Else
            Dr("CONSPER") = txtConsPer.Text
        End If

        If txtPrice.Text = "" Then
            Dr("Price") = 0
        Else
            Dr("Price") = txtPrice.Text
        End If

        dtAccess.Rows.Add(Dr)

        Session("dtAccess") = dtAccess
        BindAccessGrid()

    End Sub
    Sub BindAccessGrid()

        dgAccess.DataSource = dtAccess
        dgAccess.DataBind()
    End Sub
    Protected Sub btnAddAccessories_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddAccessories.Click
        Try

            SaveSession()
 
        Catch ex As Exception

        End Try


    End Sub
    Protected Sub BtnStyleDetail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnStyleDetail.Click
        Try
            Dim checkcount As Decimal = 0
            Dim x As Integer
            Dim chkSelect As CheckBox
            For x = 0 To DgStyleDetail.Items.Count - 1
                Dim item As GridDataItem = DirectCast(DgStyleDetail.MasterTableView.Items(x), GridDataItem)
                chkSelect = CType(DgStyleDetail.Items(x).FindControl("chkSelect"), CheckBox)
                If chkSelect.Checked = True Then
                    checkcount = checkcount + 1
                End If
            Next
            If chkBodyFabric.Checked = True Then
                checkcount = checkcount + 1
            End If
            If DgStyleDetail.Items.Count >= 1 Then
                If checkcount > 1 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Only one Body fabric allow")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    SaveSessionStyleDetailGrid()
                    ClearControl()
                End If
            Else
             
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                SaveSessionStyleDetailGrid()
                ClearControl()

            End If




        Catch ex As Exception

        End Try


    End Sub
    Sub ClearControl()
        lblDPRNDStyleDetailID.Text = 0
        txtStyleDescription.Text = ""
        chkBodyFabric.Checked = False
        txtSizes.Text = ""
        txtStyleWidth.Text = ""
        txtShrink.Text = ""
        txtShrinkageWidth.Text = ""
        txtMarketLength.Text = ""
        txtStylePrice.Text = ""
        txtConsumption.Text = ""

    End Sub
    Protected Sub dgAccess_DeleteCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgAccess.DeleteCommand
        dtAccess = CType(Session("dtAccess"), DataTable)
        If (Not dtAccess Is Nothing) Then
            If (dtAccess.Rows.Count > 0) Then
                Dim DPRNDAccessDetailID As Integer = dtAccess.Rows(e.Item.ItemIndex)("DPRNDAccessDetailID")
                dtAccess.Rows.RemoveAt(e.Item.ItemIndex)
                ObjDPItemDatabase.Deletedetail(DPRNDAccessDetailID)
                BindAccessGrid()
            Else
            End If

        End If
    End Sub


    Sub SaveSessionStyleDetailGrid()


        If (Not CType(Session("dtStyleDetail"), DataTable) Is Nothing) Then
            dtStyleDetail = Session("dtStyleDetail")
        Else
            dtStyleDetail = New DataTable
            With dtStyleDetail
                .Columns.Add("DPRNDStyleDetailID", GetType(Long))
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
        End If



        Dr = dtStyleDetail.NewRow()
        Dr("DPRNDStyleDetailID") = lblDPRNDStyleDetailID.Text
        If txtStyleDescription.Text = "" Then
            Dr("Description") = " "
        Else
            Dr("Description") = txtStyleDescription.Text
        End If


        If chkBodyFabric.Checked = True Then
            Dr("IsBodyFabric") = 1
        Else
            Dr("IsBodyFabric") = 0
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


        If txtStylePrice.ValidationText = "" Then
            Dr("Price") = 0
        Else
            Dr("Price") = txtStylePrice.Text
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

        If userid = 238 Then
            Dr("ConsumptionUnitid") = cmbUnit.SelectedValue
            Dr("Unit") = cmbUnit.SelectedItem.Text
        Else
            Dr("ConsumptionUnitid") = 0
            Dr("Unit") = "N/A"

        End If



        dtStyleDetail.Rows.Add(Dr)
        Session("dtStyleDetail") = dtStyleDetail
        BindStyleDetailGrid()

    End Sub
    Sub BindUnit()
        Try
            Dim dtPONO As DataTable
            dtPONO = ObjTblRND.GetBindUnit()
            cmbUnit.DataSource = dtPONO
            cmbUnit.DataTextField = "Unit"
            cmbUnit.DataValueField = "ConsumptionUnitID"
            cmbUnit.DataBind()
            cmbUnit.Items.Insert(0, New RadComboBoxItem("Select", 0))
        Catch ex As Exception
        End Try
    End Sub

    Sub BindStyleDetailGrid()
        If dtStyleDetail.Rows.Count > 0 Then
            DgStyleDetail.DataSource = dtStyleDetail
            DgStyleDetail.DataBind()
            DgStyleDetail.Visible = True

            If userid = 238 Then
                DgStyleDetail.Columns(11).Visible = True
                DgStyleDetail.Columns(12).Visible = True
            Else
                DgStyleDetail.Columns(11).Visible = False
                DgStyleDetail.Columns(12).Visible = False
            End If
        Else
            DgStyleDetail.Visible = False
        End If

        Dim x As Integer
        Dim chkSelect As CheckBox
        For x = 0 To dtStyleDetail.Rows.Count - 1
            Dim item As GridDataItem = DirectCast(DgStyleDetail.MasterTableView.Items(x), GridDataItem)
            chkSelect = CType(DgStyleDetail.Items(x).FindControl("chkSelect"), CheckBox)
            Dim IsBodyFabric As String = item("IsBodyFabric").Text
            If IsBodyFabric = True Then
                chkSelect.Checked = True
                chkSelect.Enabled = False
            Else
                chkSelect.Checked = False
                chkSelect.Enabled = False
            End If
        Next
    End Sub

    Protected Sub DgStyleDetail_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles DgStyleDetail.ItemCommand
        Select Case e.CommandName
            Case "Edit"
                dtStyleDetail = CType(Session("dtStyleDetail"), DataTable)
                If (Not dtStyleDetail Is Nothing) Then
                    If (dtStyleDetail.Rows.Count > 0) Then
                        Dim item As GridDataItem = DirectCast(DgStyleDetail.MasterTableView.Items(e.Item.ItemIndex), GridDataItem)
                        Dim DPRNDStyleDetailID As Integer = item("DPRNDStyleDetailID").Text
                        SetDetailValuesByDataTable(e.Item.ItemIndex)
                        dtStyleDetail.Rows.RemoveAt(e.Item.ItemIndex)
                        BindStyleDetailGrid()

                    End If
                End If
            Case "Delete"
                dtStyleDetail = CType(Session("dtStyleDetail"), DataTable)
                If (Not dtStyleDetail Is Nothing) Then
                    If (dtStyleDetail.Rows.Count > 0) Then
                        Dim DPRNDStyleDetailID As Integer = dtStyleDetail.Rows(e.Item.ItemIndex)("DPRNDStyleDetailID")
                        dtStyleDetail.Rows.RemoveAt(e.Item.ItemIndex)
                        ObjDPItemDatabase.DeleteStyledetail(DPRNDStyleDetailID)
                        BindStyleDetailGrid()
                    Else
                    End If

                End If
        End Select
    End Sub
    Sub SetDetailValuesByDataTable(ByVal dtrowNo As Long)
        Try
            lblDPRNDStyleDetailID.Text = dtStyleDetail.Rows(dtrowNo)("DPRNDStyleDetailID")
            txtStyleDescription.Text = dtStyleDetail.Rows(dtrowNo)("Description")
            If dtStyleDetail.Rows(dtrowNo)("IsBodyFabric") = True Then
                chkBodyFabric.Checked = True
            Else
                chkBodyFabric.Checked = False
            End If

            txtSizes.Text = dtStyleDetail.Rows(dtrowNo)("Size")
            txtStyleWidth.Text = dtStyleDetail.Rows(dtrowNo)("StyleWidth")
            txtShrink.Text = dtStyleDetail.Rows(dtrowNo)("ShrinkageLength")
            txtShrinkageWidth.Text = dtStyleDetail.Rows(dtrowNo)("ShrinkageWidth")
            txtMarketLength.Text = dtStyleDetail.Rows(dtrowNo)("MarkerLengthWithSize")
            txtConsumption.Text = dtStyleDetail.Rows(dtrowNo)("ConsumptionPerPcs")
            txtStylePrice.Text = dtStyleDetail.Rows(dtrowNo)("Price")
            txtOtherDtl.Text = dtStyleDetail.Rows(dtrowNo)("OtherDetail")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkButton1.Click
        Try
            ScriptManager.RegisterClientScriptBlock(Me.UpPic, Me.UpPic.GetType(), "New ClientScript", "window.open('DPRNDTechPackImagePopup.aspx', 'newwindow', 'left=12, top=60, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no');", True)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Try
            Session("FileNameTP") = Nothing
            Session("ImageByteTP") = Nothing
            Dim fileExt As String = System.IO.Path.GetExtension(FileUploadTechPack.FileName)
            If FileUploadTechPack.FileName = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                pictureNotAvialable()
                lnkFIlePicture.Visible = True
            ElseIf fileExt = ".jpg" Or fileExt = ".pdf" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                Dim FileNameTP As String = ""
                Dim fs As System.IO.Stream = FileUploadTechPack.PostedFile.InputStream
                Dim br As New System.IO.BinaryReader(fs)
                Dim bytesTP As Byte() = br.ReadBytes(CType(fs.Length, Integer))

                FileNameTP = FileUploadTechPack.FileName
                Session("FileNameTP") = FileNameTP
                Session("ImageByteTP") = bytesTP
                LinkButton1.Visible = True
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Only jpg or Pdf file allow to upload")
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
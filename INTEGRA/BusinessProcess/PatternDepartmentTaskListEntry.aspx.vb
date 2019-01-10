Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Net
Imports System.Net.Mail
Public Class PatternDepartmentTaskListEntry
    Inherits System.Web.UI.Page
    Dim objDPFabricDbMst As New DPFabricDbMst
    Dim objTblDPRND As New TblDPRND

    Dim objDPPOMst As New DPPOMst
    Dim Userid, lPATTERNDEPARTMENTTASKLISTMstId, IDD As Long
    Dim objDataView As DataView
    Dim ObjPatternDepartTaskListDtl As New PatternDepartTaskListDtl
    Dim objPatternDepartTaskListMst As New PatternDepartTaskListMstNew
    Dim objFabricCons As New FabricConsump
    Dim Status As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Userid = Session("UserId")
        lPATTERNDEPARTMENTTASKLISTMstId = Request.QueryString("lPATTERNDEPARTMENTTASKLISTMstId")
        Status = Request.QueryString("Status")
        If Not Page.IsPostBack Then
            ObjPatternDepartTaskListDtl.DeleteDetailTableZeroIds(Userid)
            Session("FileName") = Nothing
            Session("ImageByte") = Nothing
            Session("FileNameTP") = Nothing
            Session("ImageByteTP") = Nothing
            BindType()

            If Session("RoleId") = 46 And Session("Type") = "R.N.D" Then
                pnlMian.Enabled = True
                pnlGGt.Enabled = False
            ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                pnlGGt.Enabled = False
                pnlMian.Enabled = True
            Else
                If Userid = 238 Then
                    pnlGGt.Enabled = True
                    pnlMian.Enabled = False
                ElseIf Userid = 241 Then
                    pnlGGt.Enabled = False
                    pnlMian.Enabled = True
                ElseIf Userid = 245 Or Userid = 256 Or Userid = 257 Or Userid = 258 Or Userid = 259 Or Userid = 260 Or Userid = 261 Or Userid = 262 Or Userid = 263 Or Userid = 268 Or Userid = 269 Then
                    pnlGGt.Enabled = False
                    pnlMian.Enabled = True
                ElseIf Userid = 237 Or Userid = 252 Or Userid = 253 Or Userid = 254 Or Userid = 255 Then
                    pnlMian.Enabled = True
                    pnlGGt.Enabled = False
                End If
            End If
            If lPATTERNDEPARTMENTTASKLISTMstId > 0 Then
                btnSave.Text = "Update"
                Edit()

            Else
                GetUserName()
                NoGenerateOnLoad()
                PakistanTimezone()
                btnSave.Text = "Save"


            End If

        End If
    End Sub
    Protected Sub chkFinishTimeStamp_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFinishTimeStamp.CheckedChanged
        Try
            PakistanTimezoneForGGT()
        Catch ex As Exception

        End Try
    End Sub
    '    protected void RadDateTimePicker1_SelectedDateChanged(object sender, SelectedDateChangedEventArgs e)
    '{
    '    Label1.Text = "Change from ";
    '    if (e.OldDate == null)
    '        Label1.Text += "nothing";
    '    else Label1.Text += e.OldDate.ToString();
    '    Label1.Text += " to ";
    '    if (e.NewDate == null)
    '        Label1.Text += "nothing";
    '    else Label1.Text += e.NewDate.ToString();
    '}       
    Sub Edit()
        Dim dt As DataTable
        dt = objFabricCons.GetEditDataForRNDEntryForTaskList(lPATTERNDEPARTMENTTASKLISTMstId)
        lblUserId.Text = dt.Rows(0)("UserId")
        txtUser.Text = dt.Rows(0)("UserName")
        lblTypeID.Text = dt.Rows(0)("TypeID")
        cmbType.SelectedValue = dt.Rows(0)("TypeID")
        lblStyleID.Text = dt.Rows(0)("StyleID")
        lblJobOrderId.Text = dt.Rows(0)("JobOrderId")
        txtTaskNo.Text = dt.Rows(0)("TaskNo")
        txtPriority.Text = dt.Rows(0)("Priority")
        txtStylee.Text = dt.Rows(0)("Style")
        txtSrnOo.Text = dt.Rows(0)("SRNO")
        TXTBUYERr.Text = dt.Rows(0)("Buyer")
        lblBuyerID.Text = dt.Rows(0)("BuyerID")
        txtCreationTime.Text = dt.Rows(0)("CreationTime")
        ' txtTimeStamp.SelectedDate = dt.Rows(0)("DateTimeStamp")
        Dim C1 As String = dt.Rows(0)("Sample")
        If C1 = True Then
            ckh1.Checked = True
        Else
            ckh1.Checked = False
        End If
        Dim C2 As String = dt.Rows(0)("Pattern")
        If C2 = True Then
            ckh2.Checked = True
        Else
            ckh2.Checked = False
        End If
        Dim C3 As String = dt.Rows(0)("Dossier")
        If C3 = True Then
            ckh3.Checked = True
        Else
            ckh3.Checked = False
        End If
        Dim C4 As String = dt.Rows(0)("SizeSpecs")
        If C4 = True Then
            ckh4.Checked = True
        Else
            ckh4.Checked = False
        End If

     
        Dim C5 As String = dt.Rows(0)("Printing")
        If C5 = True Then
            ckh5.Checked = True
        Else
            ckh5.Checked = False
        End If
        Dim C6 As String = dt.Rows(0)("Dyeing")
        If C6 = True Then
            ckh6.Checked = True
        Else
            ckh6.Checked = False
        End If
        Dim C7 As String = dt.Rows(0)("Embroidery")
        If C7 = True Then
            ckh7.Checked = True
        Else
            ckh7.Checked = False
        End If

      

        txtFinishTimeStamp.Text = dt.Rows(0)("FinishTimeStamp")
        txtRemarks.Text = dt.Rows(0)("Remarks")





        If dt.Rows(0)("ReadByGGTDept").ToString() = "01/01/1900 00:00:00" Then
            ' txtREADBYGGTDEPT.SelectedDate = Nothing
            txtREADBYGGTDEPT.SelectedDate = Date.Now
        Else
            txtREADBYGGTDEPT.SelectedDate = dt.Rows(0)("ReadByGGTDept")
        End If


        Dim dtt As DataTable = objPatternDepartTaskListMst.GetFileInfoTPNew(lPATTERNDEPARTMENTTASKLISTMstId)
        dgViewMaster.DataSource = dtt
        dgViewMaster.DataBind()


    End Sub
    Sub PakistanTimezone()
        Dim timeZoneInfo As TimeZoneInfo
        Dim dateTime As DateTime
        'Set the time zone information to US Mountain Standard Time 
        timeZoneInfo = timeZoneInfo.FindSystemTimeZoneById("Pakistan Standard Time")
        'Get date and time in US Mountain Standard Time 
        dateTime = timeZoneInfo.ConvertTime(dateTime.Now, timeZoneInfo)
        Dim time As String = dateTime.ToLongTimeString()
        txtCreationTime.Text = time   ' DateTime.Now.ToLongTimeString()
    End Sub
    Sub PakistanTimezoneForGGT()
        Dim timeZoneInfo As TimeZoneInfo
        Dim dateTime As DateTime
        'Set the time zone information to US Mountain Standard Time 
        timeZoneInfo = timeZoneInfo.FindSystemTimeZoneById("Pakistan Standard Time")
        'Get date and time in US Mountain Standard Time 
        dateTime = timeZoneInfo.ConvertTime(dateTime.Now, timeZoneInfo)
        Dim time As String = dateTime.ToLongTimeString()
        txtFinishTimeStamp.Text = time   ' DateTime.Now.ToLongTimeString()
    End Sub
    Protected Sub txtREADBYGGTDEPT_SelectedDateChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtREADBYGGTDEPT.SelectedDateChanged
        Try
            PakistanTimezoneForGGT()
        Catch ex As Exception

        End Try
    End Sub
    Sub GetUserName()
        Dim dt As DataTable = objFabricCons.GetUserName(Userid)
        If dt.Rows.Count > 0 Then
            txtUser.Text = dt.Rows(0)("UserName")
        End If
    End Sub
    Protected Sub txtStylee_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtStylee.TextChanged
        Try
            Dim dt As DataTable = objFabricCons.GetFromStyleDatabase(txtStylee.Text)
            If dt.Rows.Count > 0 Then
                lblStyleID.Text = dt.Rows(0)("DPStyleDatabaseID")
            End If
            lblStyleID.Text = 0
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub TXTBUYERr_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TXTBUYERr.TextChanged
        Try
            Dim dt As DataTable = objFabricCons.GetFromBuyerid(TXTBUYERr.Text)
            If dt.Rows.Count > 0 Then
                lblBuyerID.Text = dt.Rows(0)("CustomerID")
            End If
            lblBuyerID.Text = 0
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtSrnOo_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtSrnOo.TextChanged
        Try
            Dim dt As DataTable = objFabricCons.GetFromJobOrderid(txtSrnOo.Text)
            If dt.Rows.Count > 0 Then
                lblJobOrderId.Text = dt.Rows(0)("JoborderID")
            End If
            lblJobOrderId.Text = 0
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        Try

            Dim fileExt As String = System.IO.Path.GetExtension(FileUpload.FileName)
            If FileUpload.FileName = "" Then
                lblErrorMsgTechPack.Text = "No File"
            ElseIf fileExt = ".jpg" Or fileExt = ".JPG" Then
                SaveSRQTechPackDetail()
                lblErrorMsgTechPack.Text = ""
            ElseIf fileExt = ".pdf" Or fileExt = ".PDF" Then
                SaveSRQTechPackDetail()
                lblErrorMsgTechPack.Text = ""
            ElseIf fileExt = ".xls" Then
                SaveSRQTechPackDetail()
                lblErrorMsgTechPack.Text = ""
            ElseIf fileExt = ".xlsx" Then
                SaveSRQTechPackDetail()
                lblErrorMsgTechPack.Text = ""
            Else
                lblErrorMsgTechPack.Text = "Only pdf and Excel file allow to upload"
            End If

        Catch ex As Exception

        End Try
    End Sub
    Sub SaveSRQTechPackDetail()
        With ObjPatternDepartTaskListDtl

            .PATTERNDEPARTMENTTASKLISTDtlId = 0
            If lPATTERNDEPARTMENTTASKLISTMstId > 0 Then
                .PATTERNDEPARTMENTTASKLISTMstId = lPATTERNDEPARTMENTTASKLISTMstId
                IDD = lPATTERNDEPARTMENTTASKLISTMstId
            Else
                .PATTERNDEPARTMENTTASKLISTMstId = 0
                IDD = 0
            End If


            If Session("RoleId") = 46 And Session("Type") = "R.N.D" Then
                If lPATTERNDEPARTMENTTASKLISTMstId > 0 Then
                    .UserId = lblUserId.Text
                Else
                    .UserId = 270
                End If

            ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                If lPATTERNDEPARTMENTTASKLISTMstId > 0 Then
                    .UserId = lblUserId.Text
                Else
                    .UserId = 270
                End If
            Else
                If lPATTERNDEPARTMENTTASKLISTMstId > 0 Then
                    .UserId = lblUserId.Text
                Else
                    .UserId = Userid
                End If
            End If


            .FileNameTP = FileUpload.FileName
            .UploadPictureTP = SaveUploadPicture()
            .Save()
        End With
        BindGridImage()
    End Sub
    Sub BindGridImage()
        Dim dt As DataTable
        If lPATTERNDEPARTMENTTASKLISTMstId > 0 Then
            dt = objPatternDepartTaskListMst.GetFileInfoTPNewNew(IDD, lblUserId.Text)
        Else
            dt = objPatternDepartTaskListMst.GetFileInfoTPNewNew(IDD, Userid)
        End If
        dgViewMaster.DataSource = dt
        dgViewMaster.DataBind()
    End Sub
    Sub BindGridImageAfterDelete()
        Dim dt As DataTable
        If lPATTERNDEPARTMENTTASKLISTMstId > 0 Then
            dt = objPatternDepartTaskListMst.GetFileInfoTPNewNew(lPATTERNDEPARTMENTTASKLISTMstId, lblUserId.Text)
        Else
            dt = objPatternDepartTaskListMst.GetFileInfoTPNewNew(0, Userid)
        End If
        dgViewMaster.DataSource = dt
        dgViewMaster.DataBind()
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            If Session("RoleId") = 46 And Session("Type") = "R.N.D" Then
                Response.Redirect("PatternDepartmentTaskListViewForRND.aspx")

            ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                Response.Redirect("PatternDepartmentTaskListViewForFStore.aspx")
            Else
                If Status = "R" Or Userid = "237" Then
                    Response.Redirect("PatternDepartmentTaskListViewForRND.aspx")
                ElseIf Status = "R" Or Userid = "252" Then
                    Response.Redirect("PatternDepartmentTaskListViewForRND.aspx")
                ElseIf Status = "R" Or Userid = "253" Then
                    Response.Redirect("PatternDepartmentTaskListViewForRND.aspx")
                ElseIf Status = "R" Or Userid = "254" Then
                    Response.Redirect("PatternDepartmentTaskListViewForRND.aspx")
                ElseIf Status = "R" Or Userid = "255" Then
                    Response.Redirect("PatternDepartmentTaskListViewForRND.aspx")
                ElseIf Status = "F" Or Userid = "241" Then
                    Response.Redirect("PatternDepartmentTaskListViewForFStore.aspx")
                ElseIf Status = "M" Or Userid = "245" Then
                    Response.Redirect("PatternDepartmentTaskListViewForMerch.aspx")
                ElseIf Status = "M" Or Userid = "256" Then
                    Response.Redirect("PatternDepartmentTaskListViewForMerch.aspx")
                ElseIf Status = "M" Or Userid = "257" Then
                    Response.Redirect("PatternDepartmentTaskListViewForMerch.aspx")
                ElseIf Status = "M" Or Userid = "258" Then
                    Response.Redirect("PatternDepartmentTaskListViewForMerch.aspx")
                ElseIf Status = "M" Or Userid = "259" Then
                    Response.Redirect("PatternDepartmentTaskListViewForMerch.aspx")
                ElseIf Status = "M" Or Userid = "260" Then
                    Response.Redirect("PatternDepartmentTaskListViewForMerch.aspx")
                ElseIf Status = "M" Or Userid = "261" Then
                    Response.Redirect("PatternDepartmentTaskListViewForMerch.aspx")
                ElseIf Status = "M" Or Userid = "262" Then
                    Response.Redirect("PatternDepartmentTaskListViewForMerch.aspx")
                ElseIf Status = "M" Or Userid = "263" Then
                    Response.Redirect("PatternDepartmentTaskListViewForMerch.aspx")
                ElseIf Status = "M" Or Userid = "268" Then
                    Response.Redirect("PatternDepartmentTaskListViewForMerch.aspx")
                ElseIf Status = "M" Or Userid = "269" Then
                    Response.Redirect("PatternDepartmentTaskListViewForMerch.aspx")
                ElseIf Status = "G" Or Userid = "238" Then
                    Response.Redirect("PatternDepartmentTaskListEntry.aspx")
                End If
            End If

        Catch ex As Exception
        End Try
    End Sub
    Function SaveUploadPicture() As Object
        Try
            Dim imgByte As Byte() = Nothing
            If FileUpload.HasFile Then

                Dim File As HttpPostedFile = FileUpload.PostedFile
                imgByte = New Byte(File.ContentLength - 1) {}

                File.InputStream.Read(imgByte, 0, File.ContentLength)
            End If
            Return imgByte
        Catch ex As Exception
        End Try
    End Function
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            Try
              If cmbType.SelectedValue = 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Type")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    SaveMaster()
                    SaveDetail()
                    If Session("RoleId") = 46 And Session("Type") = "R.N.D" Then
                        Response.Redirect("PatternDepartmentTaskListViewForRND.aspx")
                    ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                        Response.Redirect("PatternDepartmentTaskListViewForFStore.aspx")
                    Else
                        If Status = "R" Or Userid = "237" Then
                            Response.Redirect("PatternDepartmentTaskListViewForRND.aspx")
                        ElseIf Status = "R" Or Userid = "252" Then
                            Response.Redirect("PatternDepartmentTaskListViewForRND.aspx")
                        ElseIf Status = "R" Or Userid = "253" Then
                            Response.Redirect("PatternDepartmentTaskListViewForRND.aspx")
                        ElseIf Status = "R" Or Userid = "254" Then
                            Response.Redirect("PatternDepartmentTaskListViewForRND.aspx")
                        ElseIf Status = "R" Or Userid = "255" Then
                            Response.Redirect("PatternDepartmentTaskListViewForRND.aspx")
                        ElseIf Status = "F" Or Userid = "241" Then
                            Response.Redirect("PatternDepartmentTaskListViewForFStore.aspx")
                        ElseIf Status = "M" Or Userid = "245" Then
                            Response.Redirect("PatternDepartmentTaskListViewForMerch.aspx")
                        ElseIf Status = "M" Or Userid = "256" Then
                            Response.Redirect("PatternDepartmentTaskListViewForMerch.aspx")
                        ElseIf Status = "M" Or Userid = "257" Then
                            Response.Redirect("PatternDepartmentTaskListViewForMerch.aspx")
                        ElseIf Status = "M" Or Userid = "258" Then
                            Response.Redirect("PatternDepartmentTaskListViewForMerch.aspx")
                        ElseIf Status = "M" Or Userid = "259" Then
                            Response.Redirect("PatternDepartmentTaskListViewForMerch.aspx")
                        ElseIf Status = "M" Or Userid = "260" Then
                            Response.Redirect("PatternDepartmentTaskListViewForMerch.aspx")
                        ElseIf Status = "M" Or Userid = "261" Then
                            Response.Redirect("PatternDepartmentTaskListViewForMerch.aspx")
                        ElseIf Status = "M" Or Userid = "262" Then
                            Response.Redirect("PatternDepartmentTaskListViewForMerch.aspx")
                        ElseIf Status = "M" Or Userid = "263" Then
                            Response.Redirect("PatternDepartmentTaskListViewForMerch.aspx")
                        ElseIf Status = "M" Or Userid = "268" Then
                            Response.Redirect("PatternDepartmentTaskListViewForMerch.aspx")
                        ElseIf Status = "M" Or Userid = "269" Then
                            Response.Redirect("PatternDepartmentTaskListViewForMerch.aspx")
                        ElseIf Status = "G" Or Userid = "238" Then
                            Response.Redirect("PatternDepartmentTaskListEntry.aspx")
                        End If
                    End If
                End If

            Catch ex As Exception

            End Try
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
            cmbType.Items.Insert(0, New RadComboBoxItem("Select", 0))
        Catch ex As Exception
        End Try
    End Sub
    Sub NoGenerateOnLoad()
        Try
            Dim VoucherNo As String
            Dim Voucherdate As Date = Date.Now
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
            txtTaskNo.Text = VoucherNo
            txtPriority.Text = VoucherNo.Substring(6, 2)

        Catch ex As Exception

        End Try
    End Sub
    Sub SaveMaster()
        With objPatternDepartTaskListMst
            If lPATTERNDEPARTMENTTASKLISTMstId > 0 Then
                .PATTERNDEPARTMENTTASKLISTMstid = lPATTERNDEPARTMENTTASKLISTMstId
            Else
                .PATTERNDEPARTMENTTASKLISTMstid = 0
            End If

            .CreationDate = Date.Now


            If Session("RoleId") = 46 And Session("Type") = "R.N.D" Then
                If lPATTERNDEPARTMENTTASKLISTMstId > 0 Then
                    .UserId = lblUserId.Text
                Else
                    .UserId = 270
                End If
            ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                If lPATTERNDEPARTMENTTASKLISTMstId > 0 Then
                    .UserId = lblUserId.Text
                Else
                    .UserId = 270
                End If
            Else
                If lPATTERNDEPARTMENTTASKLISTMstId > 0 Then
                    .UserId = lblUserId.Text
                Else
                    .UserId = Userid
                End If
            End If


            .TypeID = cmbType.SelectedValue
            .TaskNo = txtTaskNo.Text
            If lPATTERNDEPARTMENTTASKLISTMstId > 0 Then
                .Priority = txtPriority.Text
            Else
                .Priority = 0
            End If

            .Style = txtStylee.Text.ToUpper
            If lblStyleID.Text = "" Then
                .StyleID = 0
            Else
                .StyleID = lblStyleID.Text
            End If
            .SRNO = txtSrnOo.Text
            If lblJobOrderId.Text = "" Then
                .JobOrderId = 0
            Else
                .JobOrderId = lblJobOrderId.Text
            End If
            .Buyer = TXTBUYERr.Text.ToUpper
            If lblBuyerID.Text = "" Then
                .BuyerID = 0
            Else
                .BuyerID = lblBuyerID.Text
            End If
            .DateTimeStamp = Date.Now 'txtTimeStamp.SelectedDate
            .CreationTime = txtCreationTime.Text
            If ckh1.Checked = True Then
                .Sample = 1
            Else
                .Sample = 0
            End If
            If ckh2.Checked = True Then
                .Pattern = 1
            Else
                .Pattern = 0
            End If
            If ckh3.Checked = True Then
                .Dossier = 1
            Else
                .Dossier = 0
            End If
            If ckh4.Checked = True Then
                .SizeSpecs = 1
            Else
                .SizeSpecs = 0
            End If

            If ckh5.Checked = True Then
                .Printing = 1
            Else
                .Printing = 0
            End If
            If ckh6.Checked = True Then
                .Dyeing = 1
            Else
                .Dyeing = 0
            End If
            If ckh7.Checked = True Then
                .Embroidery = 1
            Else
                .Embroidery = 0
            End If

            If txtREADBYGGTDEPT.ValidationDate = "" Then
                .ReadByGGTDept = "01/01/1900"
            Else
                .ReadByGGTDept = txtREADBYGGTDEPT.SelectedDate
            End If
            .FinishTimeStamp = txtFinishTimeStamp.Text
            .Remarks = txtRemarks.Text
            .Bit = 1
            .DPRNDId = 0
            .FabricCosumFstoreID = 0
            .FabricCosumMerchID = 0
            .Save()
        End With
    End Sub
    Sub SaveDetail()

        Dim a As Long = 0
        Dim path2 As String = ""
        Dim spath As String = ""
        Dim FileName As String = ""

        If lPATTERNDEPARTMENTTASKLISTMstId > 0 Then
            a = lPATTERNDEPARTMENTTASKLISTMstId

        Else
            a = objPatternDepartTaskListMst.GetId
        End If

        'If dgViewMaster.Items.Count > 0 Then
        ObjPatternDepartTaskListDtl.updateTaskListDetail(a)
        ' Else
        '  With ObjPatternDepartTaskListDtl
        '.PATTERNDEPARTMENTTASKLISTDtlId = 0
        ' If lPATTERNDEPARTMENTTASKLISTMstId > 0 Then
        '.PATTERNDEPARTMENTTASKLISTMstId = lPATTERNDEPARTMENTTASKLISTMstId
        ' .UserId = lblUserId.Text
        ' Else
        ' .PATTERNDEPARTMENTTASKLISTMstId = objPatternDepartTaskListMst.GetId()
        ' .UserId = Userid
        ' End If
        ' path2 = Server.MapPath("../Images/" & "no-image.JPG")
        ' Session("FileNameTP") = "no-image.JPG"
        ' Session("ImageByteTP") = GetFileContent(path2)
        ' .UploadPictureTP = Session("ImageByteTP")
        ' .FileNameTP = Session("FileNameTP")
        ' .Save()
        ' End With
        ' End If
    End Sub
    Private Function GetFileContent(ByVal imageFilePath As String) As Byte()
        Dim fileStream As Stream = New FileStream(imageFilePath, FileMode.Open)
        Dim fileContent As Byte() = New Byte(fileStream.Length - 1) {}
        fileStream.Read(fileContent, 0, CInt(fileStream.Length))
        fileStream.Close()
        Return fileContent
    End Function

    Protected Sub dgViewMaster_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgViewMaster.ItemCommand
        Try
            Select Case e.CommandName

                Case Is = "DownloadFile"
                    Dim PATTERNDEPARTMENTTASKLISTMstid As Integer = dgViewMaster.Items(e.Item.ItemIndex).Cells(1).Text
                    Dim PATTERNDEPARTMENTTASKLISTDtlid As Integer = dgViewMaster.Items(e.Item.ItemIndex).Cells(0).Text
                    Response.Write("<script> window.open('TaskListImagePopup.aspx?PATTERNDEPARTMENTTASKLISTDtlid=" & PATTERNDEPARTMENTTASKLISTDtlid & "&PATTERNDEPARTMENTTASKLISTMstid=" & PATTERNDEPARTMENTTASKLISTMstid & "', 'newwindow', 'left=100, top=180, height=500, width=850, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")
                    ' ScriptManager.RegisterClientScriptBlock(Me.UpdatePanel11, Me.UpdatePanel11.GetType(), "New ClientScript", "window.open('SRQTechPackUploadShow.aspx?ID=" & ID & "&SRQMasterID=" & SRQMasterID & "', 'newwindow', 'left=12, top=60, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no');", True)
                Case Is = "Remove"
                    Dim PATTERNDEPARTMENTTASKLISTMstid As Integer = dgViewMaster.Items(e.Item.ItemIndex).Cells(1).Text
                    Dim PATTERNDEPARTMENTTASKLISTDtlid As Integer = dgViewMaster.Items(e.Item.ItemIndex).Cells(0).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    objFabricCons.DeleteTaslListDetail(PATTERNDEPARTMENTTASKLISTDtlid, PATTERNDEPARTMENTTASKLISTMstid)
                    BindGridImageAfterDelete()
            End Select
        Catch ex As Exception

        End Try
    End Sub
End Class
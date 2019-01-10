Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.Xml
Imports System.IO
Imports Telerik.Web.UI.Barcode
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Net
Imports System.Net.Mail
Imports Telerik.Web.UI.Upload

Public Class PurchaseOrderAddd
    Inherits System.Web.UI.Page
    Dim dtStyle As New DataTable
    Dim objSize As New Size
    Dim objColor As New Color
    Dim objVendor As New Vender
    Dim objCustomer As New Customer
    Dim objPurchaseMaster As New PurchaseOrder
    Dim objPurchaseDetail As New PurchaseOrderDetail
    Dim objPORelatedField As New PORelatedFields
    Dim dtPurchaseOrder As New DataTable
    Dim Dr As DataRow
    Dim lPOID As Long
    Public MarchandID As Long
    Public ShimpmentDate As String
    Dim GeneralCode As New GeneralCode
    Dim dtMarchand As DataTable
    Dim dtCheckDivistion As DataTable
    Dim objPurchaseReviseShip As New PurchaseOrderReviseShipment
    Dim Dt As New DataTable
    Dim objCurrency As New Currency
    Dim objPurchaseorderQRCode As New PurchaseorderQRCode

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lPOID = Request.QueryString("lPOID")
        MarchandID = Session("UserId")
        If Not Page.IsPostBack Then
            Session("dtPurchaseOrder") = Nothing
            lblPOType.Text = ""
            lblPOTypeHeading.Visible = False
            btnCalculate.Visible = False
            BindMarchant()
            BindCustomer()
            BindSupplier()
            BindProductPortfolio()
            BindProductGroup()
            BindProcessType(cmbProcessType)
            BindShipmentMode()
            BindShippingTerm()
            BindDeliveryTerm()
            BindPaymentTerm()
            BindCurrency()
            cmbCurrency.SelectedValue = 46
            BindLKZNumber()
            ChkTNA.Checked = True
            chkMGTPOCopy.Checked = True
            chkMerchantPOCopy.Checked = True
            chkQDPoCopy.Checked = True
            btnBookedExchangeRate.Visible = False
            lnkExchangeRate.Enabled = False
            btnPreview.Visible = False
            RadProgressArea1.ProgressIndicators = RadProgressArea1.ProgressIndicators And Not ProgressIndicators.SelectedFilesCount
            If lPOID > 0 Then
                btnCalculate.Visible = True
                SetValuesEditMod()
                cmbCustomer.Enabled = False
                cmbSupplier.Enabled = False
                txtShipmentdatee.Enabled = False
                btnPreview.Visible = True
                Dim Status As String = objPurchaseMaster.GetStatus(lPOID)
                If Status = "Close" Then
                    cmbStatus.Enabled = False
                Else
                    cmbStatus.Enabled = True
                End If
            End If

            RadProgressArea1.Localization.Uploaded = "Total Progress"
            RadProgressArea1.Localization.UploadedFiles = "Progress"
            RadProgressArea1.Localization.CurrentFileName = "Custom progress in action: "
        End If
    End Sub
    Private Sub BindProcessType(ByVal combo As RadComboBox)
        Dim itemsList As New ArrayList()
        itemsList.Add("Yarn Dyed")
        itemsList.Add("Solid Dyed")
        itemsList.Add("Printed")
        itemsList.Add("Dyed Over Print")
        itemsList.Add("Flat Bed")
        itemsList.Add("Others")
        combo.DataSource = itemsList
        combo.DataBind()
    End Sub
    Sub BindMarchant()
        Try
            Dim dtMarchandizer As DataTable = objPurchaseMaster.GetMarchandizer
            cmbMerchant.DataSource = dtMarchandizer
            cmbMerchant.DataTextField = "UserName"
            cmbMerchant.DataValueField = "UserId"
            cmbMerchant.DataBind()
            ' cmbMerchant.Items.Insert(0, "Select Merchandiser...")
        Catch ex As Exception

        End Try

    End Sub
    Sub BindCustomer()
        Try
            Dim dtCustomer As DataTable
            dtCustomer = objCustomer.GetBindCombo
            cmbCustomer.DataSource = dtCustomer
            cmbCustomer.DataTextField = "CustomerName"
            cmbCustomer.DataValueField = "CustomerID"
            cmbCustomer.DataBind()
            'Commission
            txtCommission.Text = objCustomer.GetCommission(cmbCustomer.SelectedValue)
        Catch ex As Exception

        End Try
    End Sub
    Sub BindSupplier()
        Try
            Dim dtSupplier As DataTable = objVendor.getDataforBindCombo
            With cmbSupplier
                .DataSource = dtSupplier
                .DataTextField = "VenderName"
                .DataValueField = "VenderLibraryID"
                .DataBind()
                '  .Items.Insert(0, "Select Merchandiser...")
            End With
        Catch ex As Exception
        End Try
    End Sub
    Sub BindProductPortfolio()
        Try
            Dim dtProductPortfolio As DataTable
            dtProductPortfolio = objPurchaseMaster.GetAllProductPortfolio
            cmbProductGroup.DataSource = dtProductPortfolio
            cmbProductGroup.DataTextField = "ProductPortfolio"
            cmbProductGroup.DataValueField = "ProductPortfolioID"
            cmbProductGroup.DataBind()
            ' cmbProductGroup.Items.Insert(0, New ListItem("Select...", "0"))
            Dim dtProductCategories As DataTable
            dtProductCategories = objPurchaseMaster.GetAllProductCategories(cmbProductGroup.SelectedValue)
            cmbProductCategroy.DataSource = dtProductCategories
            cmbProductCategroy.DataTextField = "ProductCategories"
            cmbProductCategroy.DataValueField = "ProductCategoriesID"
            cmbProductCategroy.DataBind()

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbProductGroup_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbProductGroup.SelectedIndexChanged
        Try
            If cmbProductGroup.SelectedValue = 0 Then
                cmbProductCategroy.Items.Clear()
                cmbProductGroup.BackColor = Drawing.Color.Red
            Else
                Dim dtProductCategories As DataTable
                dtProductCategories = objPurchaseMaster.GetAllProductCategories(cmbProductGroup.SelectedValue)
                cmbProductCategroy.DataSource = dtProductCategories
                cmbProductCategroy.DataTextField = "ProductCategories"
                cmbProductCategroy.DataValueField = "ProductCategoriesID"
                cmbProductCategroy.DataBind()
                ' cmbProductCategroy.Items.Insert(0, New ListItem("Select...", "0"))
                'cmbProductPortfolio.BackColor = Drawing.Color.White
            End If
            updProductCategroy.Update()
        Catch ex As Exception

        End Try
    End Sub
    Sub BindProductGroup()
        Try
            Dim dtProductGroup As DataTable
            dtProductGroup = objPurchaseMaster.GetAllProductType
            cmbDesign.DataSource = dtProductGroup
            cmbDesign.DataTextField = "ProductType"
            cmbDesign.DataValueField = "TypeID"
            cmbDesign.DataBind()
            '  cmbDesign.Items.Insert(0, New ListItem("Select...", "0"))
        Catch ex As Exception

        End Try
    End Sub
    Sub BindShipmentMode()
        Try
            Dim dtShipmentType As DataTable
            dtShipmentType = objPORelatedField.GetShipmentMode
            cmbShipmentMode.DataSource = dtShipmentType
            cmbShipmentMode.DataTextField = "Name"
            cmbShipmentMode.DataValueField = "ID"
            cmbShipmentMode.DataBind()
            '  cmbProductGroup.Items.Insert(0, New ListItem("Select...", "0"))
        Catch ex As Exception

        End Try
    End Sub
    Sub BindPaymentTerm()
        Try
            Dim dtPaymentTerm As DataTable
            dtPaymentTerm = objPORelatedField.GetPaymentTerm
            cmbPaymentTerms.DataSource = dtPaymentTerm
            cmbPaymentTerms.DataTextField = "Name"
            cmbPaymentTerms.DataValueField = "ID"
            cmbPaymentTerms.DataBind()
            '  cmbProductGroup.Items.Insert(0, New ListItem("Select...", "0"))
        Catch ex As Exception

        End Try
    End Sub
    Sub BindDeliveryTerm()
        Try
            Dim dtDeliveryTerm As DataTable
            dtDeliveryTerm = objPORelatedField.GetDeliveryTerm
            cmbDelivertyTerm.DataSource = dtDeliveryTerm
            cmbDelivertyTerm.DataTextField = "Name"
            cmbDelivertyTerm.DataValueField = "ID"
            cmbDelivertyTerm.DataBind()
            '  cmbProductGroup.Items.Insert(0, New ListItem("Select...", "0"))
        Catch ex As Exception

        End Try
    End Sub
    Sub BindShippingTerm()
        Try
            Dim dtShippingTerm As DataTable
            dtShippingTerm = objPORelatedField.GetShippmentTerm
            cmbShippingTerm.DataSource = dtShippingTerm
            cmbShippingTerm.DataTextField = "Name"
            cmbShippingTerm.DataValueField = "ID"
            cmbShippingTerm.DataBind()
            '  cmbProductGroup.Items.Insert(0, New ListItem("Select...", "0"))
        Catch ex As Exception

        End Try
    End Sub
    Sub BindCurrency()
        Try
            Dim dtCurrency As DataTable = objCurrency.Getalldata()
            cmbCurrency.DataSource = dtCurrency
            cmbCurrency.DataTextField = "CurrencyName"
            cmbCurrency.DataValueField = "CurrencyID"
            cmbCurrency.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Private Function itemsList() As Object
        Throw New NotImplementedException
    End Function
    Protected Sub btnAddMore_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddMore.Click
        Try
            ' Response.Write("<script> window.open('StylepopupNew.aspx?', 'newwindow', 'left=50, top=30, height=520, width=600, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")
            ScriptManager.RegisterClientScriptBlock(Me.upAddMore, Me.upAddMore.GetType(), "New ClientScript", "window.open('StylepopupNew.aspx?', 'newwindow', 'left=50, top=30, height=520, width=600, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no');", True)

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnShowData_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnShowData.Click
        Try
            FillGridByStyle()
            BindGrid()
            SetValuesintoGrid()
            CheckRepeatStyle()
            CheckBookedExchangeRate()
            Session("dtSelection") = Nothing
            btnCalculate.Visible = True
            updgPurchaseOrder.Update()
            upbtnCalculate.Update()
            upBookedExchange.Update()
            upLnkRate.Update()
        Catch ex As Exception

        End Try
    End Sub
    Sub FillGridByStyle()
        Dim bShouldAdd As Boolean = True
        Dim isEmployeeExist As Boolean = False
        If (Not CType(Session("dtPurchaseOrder"), DataTable) Is Nothing) Then
            dtPurchaseOrder = Session("dtPurchaseOrder")
        Else
            dtPurchaseOrder = New DataTable
            With dtPurchaseOrder
                .Columns.Add("PurchaseOrderDetailID", GetType(Long))
                .Columns.Add("Article", GetType(String))
                .Columns.Add("Size", GetType(String))
                .Columns.Add("Color", GetType(String))
                .Columns.Add("Quantity", GetType(String))
                .Columns.Add("Rate", GetType(String))
                .Columns.Add("Amount", GetType(String))
                .Columns.Add("StyleID", GetType(Long))
                .Columns.Add("Style", GetType(String))
                .Columns.Add("ArticleDescription", GetType(String))
                .Columns.Add("Remarks", GetType(String))
                .Columns.Add("StyleDetailID", GetType(Long))
            End With
        End If
        Dim x As Integer
        dtStyle = Session("dtSelection")
        If Not dtStyle Is Nothing Then
            For x = 0 To dtStyle.Rows.Count - 1
                Dr = dtPurchaseOrder.NewRow()
                Dr("PurchaseOrderDetailID") = dtStyle.Rows(x)("PurchaseOrderDetailID")
                Dr("Article") = dtStyle.Rows(x)("Article")
                Dr("Size") = dtStyle.Rows(x)("Size")
                Dr("Color") = dtStyle.Rows(x)("Colorway")
                Dr("Quantity") = ""
                Dr("Rate") = dtStyle.Rows(x)("ItemPrice")
                Dr("Amount") = ""
                Dr("StyleID") = dtStyle.Rows(x)("ID")
                Dr("Style") = dtStyle.Rows(x)("StyleNo")
                Dr("ArticleDescription") = dtStyle.Rows(x)("ArticleDescription")
                Dr("Remarks") = ""
                Dr("StyleDetailID") = dtStyle.Rows(x)("StyleDetailID")
                dtPurchaseOrder.Rows.Add(Dr)
            Next
            Session("dtPurchaseOrder") = dtPurchaseOrder
        End If
    End Sub
    Private Function BindGrid() As Boolean
        If (Not dtPurchaseOrder Is Nothing) Then
            If (dtPurchaseOrder.Rows.Count > 0) Then
                dgPurchaseOrder.DataSource = dtPurchaseOrder
                dgPurchaseOrder.DataBind()
                dgPurchaseOrder.Visible = True

                TryCast(dgPurchaseOrder.MasterTableView.GetColumn("PurchaseOrderDetailID"), GridBoundColumn).Display = False
                TryCast(dgPurchaseOrder.MasterTableView.GetColumn("StyleID"), GridBoundColumn).Display = False

                Return (True)
            End If
        End If
        Return (False)
    End Function
    Sub SetValuesintoGrid()
        Dim x As Integer
        Dim txtQty As RadNumericTextBox
        Dim txtrate As RadTextBox
        Dim txtAmt As RadTextBox

        If (Not CType(Session("dtPurchaseOrder"), DataTable) Is Nothing) Then
            dtPurchaseOrder = Session("dtPurchaseOrder")
            For x = 0 To dtPurchaseOrder.Rows.Count - 1
                txtQty = CType(dgPurchaseOrder.Items(x).FindControl("txtQuantity"), RadNumericTextBox)
                txtrate = CType(dgPurchaseOrder.Items(x).FindControl("txtRate"), RadTextBox)
                txtAmt = CType(dgPurchaseOrder.Items(x).FindControl("txtAmount"), RadTextBox)
                txtQty.Text = dtPurchaseOrder.Rows(x)("Quantity")
                txtrate.Text = dtPurchaseOrder.Rows(x)("Rate")
                txtAmt.Text = dtPurchaseOrder.Rows(x)("Amount")
            Next

        End If
    End Sub
    Sub BindLKZNumber()
        Try
            'Show LKZ Number.
            Dim objSupplierLKZ As New SupplierLKZNo
            Dim dtCheck As New DataTable
            dtCheck = objSupplierLKZ.CheckExistingOfLKZNumber(cmbSupplier.SelectedValue, cmbCustomer.SelectedValue)
            If dtCheck.Rows.Count > 0 Then
                txtLKZNo.Text = dtCheck.Rows(0)("LKZNumber")
                txtLKZNo.ToolTip = "This is LKZ number" + "[" + dtCheck.Rows(0)("LKZNumber") + "] of " + cmbSupplier.Text + " To " + cmbCustomer.Text
                updLKZNo.Update()
            Else
                txtLKZNo.Text = ""
                updLKZNo.Update()
            End If
            'End LKZ
        Catch ex As Exception

        End Try


    End Sub
    Protected Sub cmbCustomer_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbCustomer.SelectedIndexChanged
        Try
            BindLKZNumber()
            'Commission
            txtCommission.Text = objCustomer.GetCommission(cmbCustomer.SelectedValue)
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbSupplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbSupplier.SelectedIndexChanged
        Try
            BindLKZNumber()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            If lPOID > 0 Then
                If dgPurchaseOrder.Items.Count = 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("No Style Information Found.")
                ElseIf txtBookedExchangeRate.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("No Exchange Rate Found.")
                ElseIf txtBookedExchangeRate.Text = 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("No Exchange Rate Found.")
                Else
                    Save()
                End If
            Else
                CheckAlreadyExist()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub CheckAlreadyExist()
        'Check Detail is not Empty
        If dgPurchaseOrder.Items.Count = 0 Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("No Style Information Found.")
        ElseIf txtBookedExchangeRate.Text = "" Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("No Exchange Rate Found.")
        ElseIf txtBookedExchangeRate.Text = 0 Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("No Exchange Rate Found.")
        Else
            'Check Order Already Exist or not.
            Dim DtPO As New DataTable
            DtPO = objPurchaseMaster.GetRepeatPO(txtPONO.Text, cmbCustomer.SelectedValue, cmbSupplier.SelectedValue)
            If DtPO.Rows.Count > 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("This Purchaseorder Already Exist.")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                CheckRepeatStyle()
                Save()
            End If
        End If
    End Sub
    Sub CheckRepeatStyle()
        'Check if Style is already Used
        Try
            Dim dtStyle As New DataTable
            Dim x As Integer
            Dim styleNo As String
            ' For x = 0 To dgPurchaseOrder.RecordCount - 1
            styleNo = dgPurchaseOrder.Items(0).Cells(3).Text
            dtStyle = objPurchaseMaster.GetRepeatStyle(styleNo)
            ' Next
            If dtStyle.Rows.Count > 0 Then
                If dtStyle.Rows(0)("RepteadStyle") = 0 Then
                    lblPOType.Text = "I"
                    txtPORefNo.Text = dtStyle.Rows(0)("RepteadStyle")
                    txtPORefNo.Visible = False
                    lblPOTypeHeading.Visible = True
                Else
                    lblPOType.Text = "R"
                    txtPORefNo.Text = dtStyle.Rows(0)("RepteadStyle")
                    txtPORefNo.Visible = False
                    lblPOTypeHeading.Visible = True
                End If
            Else
                lblPOType.Text = "I"
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub Save()
        SetValues()
        If (Not Session("dtPurchaseOrder") Is Nothing) Then
            dtPurchaseOrder = Session("dtPurchaseOrder")
            '------- Save in PO Master Value
            GetPOMasterValues()
            '------- Save in PO Detail Value
            For Each Dr In dtPurchaseOrder.Rows
                GetPODetailValues(Dr)
            Next
            Const total As Integer = 100
            Dim progress As RadProgressContext = RadProgressContext.Current
            progress.Speed = "N/A"

            For i As Integer = 0 To total - 1
                progress.PrimaryTotal = 1
                progress.PrimaryValue = 1
                progress.PrimaryPercent = 100

                progress.SecondaryTotal = total
                progress.SecondaryValue = i
                progress.SecondaryPercent = (i * 100) / total
                progress.CurrentOperationText = "Step " + i.ToString()

                If Not Response.IsClientConnected Then
                    'Cancel button was clicked or the browser was closed, so stop processing
                    Exit For
                End If
                progress.TimeEstimated = (total - i) * 100
                'Stall the current thread for 0.1 seconds
                System.Threading.Thread.Sleep(100)
            Next
            'Save PDF in Folder
            SaveOriginalPurchaseorder()
            'Generate QR Codes
            GeneratQRCodeMGT()
            GeneratQRCodeMerchant()
            GeneratQRCodeQD()
            SaveQRCode()
        End If
        dgPurchaseOrder.Controls.Clear()
        Dim CurrentID As Long
        If lPOID = 0 Then
            CurrentID = objPurchaseMaster.GetPOId
            If cmbCustomer.SelectedValue = 46 Then
                GenrateTNAChartForCELIO(CurrentID)
            Else
                GenrateTNAChart(CurrentID)
            End If
        Else
            CurrentID = lPOID
            ''fOR UPDATE TNA
            If cmbCustomer.SelectedValue = 46 Then
                GenrateTNAChartForCELIO(CurrentID)
            Else
                GenrateTNAChart(CurrentID)
            End If
        End If
        '-----------------
        ' Response.Redirect("..\Reports/Report.aspx?ReportName=PO&POID=" & CurrentID & "")
        Session("dtSelection") = Nothing
        Session("dtPurchaseOrder") = Nothing
        Session("dtBookedExchangeRate") = Nothing
        If lPOID = 0 Then
            SendEmailMGT()
            SendEmailMerchant()
            SendEmailQD()
            SavePOTracking()
        End If
        Response.Redirect("MasterOrderForDataFeeder.aspx")

    End Sub
    Sub SaveQRCode()
        Try
            Dim CurrentID As Long
            If lPOID = 0 Then
                CurrentID = objPurchaseMaster.GetPOId
                With objPurchaseorderQRCode
                    .QRCodeID = 0
                    If lPOID = 0 Then
                        .POID = objPurchaseMaster.GetPOId
                    Else
                        .POID = lPOID
                    End If
                    .QRMGT = SaveImginByte(Server.MapPath("~/POQRCodes/" & CurrentID & "/MGT/QRCodeMGT.png"))
                    .QRMerchant = SaveImginByte(Server.MapPath("~/POQRCodes/" & CurrentID & "/Merchant/QRCodeMerchant.png"))
                    .QRQD = SaveImginByte(Server.MapPath("~/POQRCodes/" & CurrentID & "/QD/QRCodeQD.png"))
                    .CreationDate = Date.Now
                    .SavePurchaseorderQRCode()
                End With
            Else
                Dim dtCheck As DataTable
                dtCheck = objPurchaseorderQRCode.CheckExisting(lPOID)
                If dtCheck.Rows.Count > 0 Then
                Else
                    With objPurchaseorderQRCode
                        .QRCodeID = 0
                        If lPOID = 0 Then
                            .POID = objPurchaseMaster.GetPOId
                        Else
                            .POID = lPOID
                        End If
                        .QRMGT = SaveImginByte(Server.MapPath("~/POQRCodes/" & lPOID & "/MGT/QRCodeMGT.png"))
                        .QRMerchant = SaveImginByte(Server.MapPath("~/POQRCodes/" & lPOID & "/Merchant/QRCodeMerchant.png"))
                        .QRQD = SaveImginByte(Server.MapPath("~/POQRCodes/" & lPOID & "/QD/QRCodeQD.png"))
                        .CreationDate = Date.Now
                        .SavePurchaseorderQRCode()
                    End With
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Function SaveImginByte(ByVal imgPath) As Object
        Try
            Dim fileStream As New FileStream(imgPath, FileMode.Open, FileAccess.Read)
            Dim buffer As Byte() = New Byte(fileStream.Length - 1) {}
            fileStream.Read(buffer, 0, CInt(fileStream.Length))
            fileStream.Close()
            Return buffer
        Catch ex As Exception
        End Try
    End Function
    Sub SaveOriginalPurchaseorder()
        Try
            Dim CurrentID As Long
            If lPOID > 0 Then
                CurrentID = lPOID
            Else
                CurrentID = objPurchaseMaster.GetPOId
            End If
            If (Directory.Exists(Server.MapPath("~/OriginalPurchaseorderPDF/" & CurrentID & ""))) Then
                If FileUpload1.FileName = "" Then
                Else
                    FileUpload1.SaveAs(Server.MapPath("~/OriginalPurchaseorderPDF/" & CurrentID & "/" & FileUpload1.FileName))
                End If
            Else
                If FileUpload1.FileName = "" Then
                Else
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/OriginalPurchaseorderPDF/" & CurrentID & ""))
                    di.Create()
                    FileUpload1.SaveAs(Server.MapPath("~/OriginalPurchaseorderPDF/" & CurrentID & "/" & FileUpload1.FileName))
                End If
            End If

        Catch ex As Exception
        End Try
    End Sub
    Sub SetValues()
        Dim x As Integer
        Dim txtQty As RadNumericTextBox
        Dim txtAmt As RadTextBox
        Dim txtrate As RadTextBox
        If (Not CType(Session("dtPurchaseOrder"), DataTable) Is Nothing) Then
            dtPurchaseOrder = Session("dtPurchaseOrder")
            For x = 0 To dtPurchaseOrder.Rows.Count - 1
                If lPOID > 0 Then
                Else
                    dtPurchaseOrder.Rows(x)("PurchaseOrderDetailID") = 0
                End If
                txtQty = CType(dgPurchaseOrder.Items(x).FindControl("txtQuantity"), RadNumericTextBox)
                txtAmt = CType(dgPurchaseOrder.Items(x).FindControl("txtAmount"), RadTextBox)
                txtrate = CType(dgPurchaseOrder.Items(x).FindControl("txtRate"), RadTextBox)
                If txtQty.Text = "" Then
                    txtQty.Text = 0
                End If
                If txtAmt.Text = "" Then
                    txtAmt.Text = 0
                End If
                If txtrate.Text = "" Then
                    txtrate.Text = 0
                End If
                dtPurchaseOrder.Rows(x)("Quantity") = Val(txtQty.Text)
                dtPurchaseOrder.Rows(x)("Rate") = Val(txtrate.Text)
                dtPurchaseOrder.Rows(x)("Amount") = CDec(Val(txtAmt.Text))
            Next
        End If
    End Sub
    Sub GenrateTNAChartForCELIO(ByVal lPOID As Long)
        Dim Dtprocess As DataTable
        Dim dtuser As DataTable
        Dim ObjTNAChart As New TNAChart
        Dim ObjTNAChartHistory As New TNAChartHistory
        Dim MADDate As Date
        Dim TimeSpame, x, i As Integer
        Dim userid As Long
        '--------- Check Validation
        '---------- Save To Session
        'New Work Zakir
        Dim ObjUMUser As New User
        Dim dt As New DataTable
        If (Not CType(Session("dtMarchand"), DataTable) Is Nothing) Then
            dtuser = Session("dtMarchand")
            userid = Convert.ToInt64(dtuser.Rows(0)("UserId"))
            dt = ObjUMUser.getECPDivisonByID(Convert.ToInt64(cmbMerchant.SelectedValue))
            Dtprocess = objPurchaseMaster.GetScheduleCELIO(dtuser.Rows(0)("ECPDivistion"))
        End If
        dt = ObjUMUser.getECPDivisonByID(Convert.ToInt64(cmbMerchant.SelectedValue))
        Dtprocess = objPurchaseMaster.GetScheduleCELIO(dt.Rows(0)("ECPDivistion"))
        '----------- Get Detail From PO
        Dim DtPO As New DataTable
        DtPO = objPurchaseMaster.GetAllPO
        For i = 0 To DtPO.Rows.Count - 1
            MADDate = DtPO.Rows(i)("ShipmentDate")
            TimeSpame = DtPO.Rows(i)("TimeSpame")
            For x = 0 To Dtprocess.Rows.Count - 1
                With ObjTNAChart
                    .IdealDate = AddDateCELIO(Dtprocess.Rows(x)("SchedularTime"), MADDate)
                    .ActualDate = AddDateCELIO(Dtprocess.Rows(x)("SchedularTime"), MADDate)
                    .DateEstemated = AddDateCELIO(Dtprocess.Rows(x)("SchedularTime"), MADDate)
                    .POID = DtPO.Rows(i)("POID")
                    .QtyCompleted = 0
                    .Remarks = " "
                    .Status = "Created"
                    .ScheduleTime = Dtprocess.Rows(x)("SchedularTime")
                    .TNAProcessID = Dtprocess.Rows(x)("ProcessID")
                    .Selected = True
                    .SelectedStatus = "SELECTED"
                    .Parameter = 0
                    .ParameterUnit = ""
                    .TotalCapacity = 0
                    .CapacityUnit = ""
                    .Required = 0
                    .RequiredUnit = ""
                    .SaveTNAChart()
                End With
                '---------- Save into Chat History
                With ObjTNAChartHistory
                    .CreationDate = Date.Now
                    .TNAChartID = ObjTNAChart.GetId
                    .IdealDate = ObjTNAChart.IdealDate
                    .DateEstemated = ObjTNAChart.DateEstemated
                    .ActualDate = ObjTNAChart.ActualDate
                    .QtyCompleted = 0
                    .Remarks = " "
                    .Status = "Created"
                    .TNAProcessID = Dtprocess.Rows(x)("ProcessID")
                    .Parameter = 0
                    .ParameterUnit = ""
                    .TotalCapacity = 0
                    .CapacityUnit = ""
                    .Required = 0
                    .RequiredUnit = ""
                    .SaveTNAChartHistory()
                End With
            Next
        Next
    End Sub
    Sub GenrateTNAChart(ByVal lPOID As Long)
        Dim Dtprocess As DataTable
        Dim dtuser As DataTable
        Dim ObjTNAChart As New TNAChart
        Dim ObjTNAChartHistory As New TNAChartHistory
        Dim PLacementDate As Date
        Dim TimeSpame, x, i As Integer
        Dim userid As Long
        '--------- Check Validation
        '---------- Save To Session
        'New Work Zakir
        Dim ObjUMUser As New User
        Dim dt As New DataTable
        If (Not CType(Session("dtMarchand"), DataTable) Is Nothing) Then
            dtuser = Session("dtMarchand")
            userid = Convert.ToInt64(dtuser.Rows(0)("UserId"))
            dt = ObjUMUser.getECPDivisonByID(Convert.ToInt64(cmbMerchant.SelectedValue))
            Dtprocess = objPurchaseMaster.GetScheduleNew(dtuser.Rows(0)("ECPDivistion"))
        End If
        dt = ObjUMUser.getECPDivisonByID(Convert.ToInt64(cmbMerchant.SelectedValue))
        Dtprocess = objPurchaseMaster.GetScheduleNew(dt.Rows(0)("ECPDivistion"))
        '----------- Get Detail From PO
        Dim DtPO As New DataTable
        DtPO = objPurchaseMaster.GetAllPO
        For i = 0 To DtPO.Rows.Count - 1
            PLacementDate = DtPO.Rows(i)("PLacementDate")
            TimeSpame = DtPO.Rows(i)("TimeSpame")
            For x = 0 To Dtprocess.Rows.Count - 1
                With ObjTNAChart
                    .IdealDate = AddDate(TimeSpame, Dtprocess.Rows(x)("SchedularTime"), PLacementDate)
                    .ActualDate = AddDate(TimeSpame, Dtprocess.Rows(x)("SchedularTime"), PLacementDate)
                    .DateEstemated = AddDate(TimeSpame, Dtprocess.Rows(x)("SchedularTime"), PLacementDate)
                    .POID = DtPO.Rows(i)("POID")
                    .QtyCompleted = 0
                    .Remarks = " "
                    .Status = "Created"
                    .ScheduleTime = Dtprocess.Rows(x)("SchedularTime")
                    .TNAProcessID = Dtprocess.Rows(x)("ProcessID")
                    .Selected = True
                    .SelectedStatus = "SELECTED"
                    .Parameter = 0
                    .ParameterUnit = ""
                    .TotalCapacity = 0
                    .CapacityUnit = ""
                    .Required = 0
                    .RequiredUnit = ""
                    .SaveTNAChart()
                End With
                '---------- Save into Chat History
                With ObjTNAChartHistory
                    .CreationDate = Date.Now
                    .TNAChartID = ObjTNAChart.GetId
                    .IdealDate = ObjTNAChart.IdealDate
                    .DateEstemated = ObjTNAChart.DateEstemated
                    .ActualDate = ObjTNAChart.ActualDate
                    .QtyCompleted = 0
                    .Remarks = " "
                    .Status = "Created"
                    .TNAProcessID = Dtprocess.Rows(x)("ProcessID")
                    .Parameter = 0
                    .ParameterUnit = ""
                    .TotalCapacity = 0
                    .CapacityUnit = ""
                    .Required = 0
                    .RequiredUnit = ""
                    .SaveTNAChartHistory()
                End With
            Next
        Next
    End Sub
    Function AddDate(ByVal TotalDays As Double, ByVal Days As Double, ByVal DateAddin As Date) As Date
        Dim dt As Date
        Days = (TotalDays / 100) * Days
        dt = DateAddin.AddDays(Days)
        Return dt
    End Function
    Function AddDateCELIO(ByVal Days As Double, ByVal DateAddin As Date) As Date
        Dim dt As Date
        dt = DateAddin.AddDays(-Days)
        Return dt
    End Function
    Private Sub GetPOMasterValues()
        '-------------------------- Get Rate
        'Dim currencyCode As String = "USD"
        'Dim xmlDoc As New XmlDocument
        'Dim nsMgr As XmlNamespaceManager
        'Dim nodeCurrency As XmlNode
        'Dim nodetime As XmlNode
        'Dim nodeHrk As XmlNode
        Dim rate As Double = 0
        'Dim ExDate As Date
        Try
            'xmlDoc.Load("http://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml")
            'nsMgr = New XmlNamespaceManager(xmlDoc.NameTable)
            '' XmlNamespaceManager(XmlNamespaceManager = New XmlNamespaceManager(xmlDoc.NameTable))
            'nsMgr.AddNamespace("gesmes", "http://www.gesmes.org/xml/2002-08-01")
            'nsMgr.AddNamespace("def", "http://www.ecb.int/vocabulary/2002-08-01/eurofxref")
            'nodeCurrency = xmlDoc.SelectSingleNode("/gesmes:Envelope/def:Cube/def:Cube/def:Cube[@currency='" + currencyCode + "']", nsMgr)
            'nodetime = xmlDoc.SelectSingleNode("/gesmes:Envelope/def:Cube/def:Cube[@time]", nsMgr)

            'nodeHrk = xmlDoc.SelectSingleNode("/gesmes:Envelope/def:Cube/def:Cube/def:Cube[@currency='HRK']", nsMgr)
            '' rate = Convert.ToDouble(nodeCurrency.Attributes("rate").Value) / Convert.ToDouble(nodeHrk.Attributes("rate").Value)
            'rate = Convert.ToDouble(nodeCurrency.Attributes("rate").Value)
            'ExDate = Convert.ToDateTime(nodetime.Attributes("time").Value)
            Dim DtBookexchange As DataTable
            Dim startdatee As String = txtShipmentdatee.SelectedDate.Value.ToString("yyyy-MM-dd")
            DtBookexchange = objPurchaseMaster.GetPOForShipRateNewforBOOKED(startdatee, startdatee, cmbCurrency.SelectedItem.Text)
            Dim ExchangeRate As Decimal
            If DtBookexchange.Rows.Count > 0 Then
                ExchangeRate = DtBookexchange.Rows(0)("BookedExchangeRate")
            Else
                ExchangeRate = 0
            End If
            With objPurchaseMaster
                .POID = lPOID
                .PONO = txtPONO.Text
                If lPOID > 0 Then
                    .CreationDate = objPurchaseMaster.GetPOCreationDate(lPOID)
                    .ExchangeRate = objPurchaseMaster.GetExchangeRate(lPOID)
                    .ExchangeDate = objPurchaseMaster.GetExchangeDate(lPOID)
                Else
                    .CreationDate = Date.Now
                    .ExchangeRate = rate
                    'If rate = 0 Then
                    .ExchangeDate = Date.Now
                    'Else
                    '    .ExchangeDate = ExDate
                    'End If
                End If
                .LastUpdate = Date.Now
                .Status = cmbStatus.SelectedItem.Text
                If lblPOType.Text = "I" Then
                    .POtype = "New"
                Else
                    .POtype = "Repeat"
                End If
                .CustomerID = cmbCustomer.SelectedValue
                .SupplierID = cmbSupplier.SelectedValue
                .PlacementDate = txtPlacementdate.SelectedDate ' GeneralCode.GetDate(txtPlacementdate.SelectedDate)
                .ShipmentDate = txtShipmentdatee.SelectedDate ' GeneralCode.GetDate(txtShipmentdatee.SelectedDate)
                .Commission = txtCommission.Text
                .Tolerance = 0 'txtToleranceDelivery.Text
                .Toleranceindays = txtTolerance.Text
                .ProductGroup = cmbProductGroup.SelectedItem.Text
                .Season = txtSeason.Text
                .Quality = txtBlend.Text
                'GSM
                .Construction = txtGSM.Text
                .ShipmentMode = cmbShipmentMode.SelectedValue
                .PaymentMode = cmbShippingTerm.SelectedValue
                .PaymentType = cmbPaymentTerms.SelectedValue
                .EKNumber = txtEKNumber.Text
                .DeliveryType = cmbDelivertyTerm.SelectedValue
                .Currency = cmbCurrency.SelectedItem.Text
                .PORefNo = txtPORefNo.Text
                .Design = cmbDesign.SelectedItem.Text ''txtDesign.Text
                .TimeSpame = GetTimeSpame((txtShipmentdatee.SelectedDate), (txtPlacementdate.SelectedDate))
                .MarchandID = cmbMerchant.SelectedValue
                .Composition = cmbComposition.SelectedItem.Text
                .Destination = txtDestination.Text
                .ProcessType = cmbProcessType.SelectedItem.Text
                .ProductCategories = cmbProductCategroy.SelectedItem.Text
                .IsActive = True
                .ExchangeRate = ExchangeRate 'txtBookedExchangeRate.Text
                .SavePurchaseOrderSetup()

                If lPOID = 0 Then
                    SaveRevisedShipmentdateAuto()
                End If

            End With
        Catch ex As Exception
        End Try
        ''''''''''''''''''''''''''''''
    End Sub
    Function GetTimeSpame(ByVal DateFrom As Date, ByVal DateTo As Date)
        Dim tsTimeSpan As TimeSpan
        Dim iNumberOfDays As Integer
        tsTimeSpan = DateFrom.Subtract(DateTo)
        iNumberOfDays = tsTimeSpan.Days
        Return iNumberOfDays
    End Function
    Sub SaveRevisedShipmentdateAuto()
        Try
            Try
                With objPurchaseReviseShip
                    .POReviseShipmentID = 0
                    .POID = objPurchaseMaster.GetPOId
                    .CreationDate = Date.Now()
                    .ShipmentDate = GeneralCode.GetDate(txtShipmentdatee.SelectedDate)
                    .SavePurchaseOrderReviseShipment()
                End With
            Catch ex As Exception
            End Try
        Catch ex As Exception

        End Try
    End Sub
    Private Sub GetPODetailValues(ByVal dr As DataRow)
        With objPurchaseDetail
            .PODetailID = dr("PurchaseOrderDetailID")
            If lPOID = 0 Then
                .POID = objPurchaseMaster.GetPOId
            Else
                .POID = lPOID
            End If
            .Quantity = dr("Quantity")
            .Rate = dr("Rate")
            .StyleID = dr("StyleID")
            .Remarks = ""
            .StyleDetailID = dr("StyleDetailID")
            .SavePODetailSetup()
        End With
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Session("dtSelection") = Nothing
        Session("dtPurchaseOrder") = Nothing
        Session("dtBookedExchangeRate") = Nothing
        dgPurchaseOrder.Controls.Clear()
        Response.Redirect("MasterOrderForDataFeeder.aspx")
    End Sub
    Sub CheckBookedExchangeRate()
        Try
            Dim Shipmentdatee As String = txtShipmentdatee.SelectedDate.ToString()
            If Shipmentdatee = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Shipment Date Empty")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                Dim ObjBookedExchangeRate As New BookedExchangeRate
                Dim dtBookedRate As DataTable
                dtBookedRate = ObjBookedExchangeRate.ExistingOfBookedRateForPO(txtShipmentdatee.SelectedDate.Value.Month, txtShipmentdatee.SelectedDate.Value.Year)
                If dtBookedRate.Rows.Count > 0 Then
                    txtBookedExchangeRate.Text = dtBookedRate.Rows(0)("BookedExchangeRate")
                    btnBookedExchangeRate.Visible = False
                    lnkExchangeRate.Enabled = False
                    upLnkRate.Update()
                Else
                    txtBookedExchangeRate.Text = "0"
                    btnBookedExchangeRate.Visible = True
                    lnkExchangeRate.Enabled = True
                    upLnkRate.Update()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCalculate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCalculate.Click
        Try
            Calculate()
            updgPurchaseOrder.Update()
        Catch ex As Exception
        End Try
    End Sub
    Sub Calculate()
        Dim txtQty As RadNumericTextBox
        Dim txtAmt As RadTextBox
        Dim txtrate As RadTextBox
        Dim TotalAmt As Double = 0
        Dim TotalQty As Double = 0
        Dim x As Integer
        For x = 0 To dgPurchaseOrder.Items.Count - 1
            txtQty = CType(dgPurchaseOrder.Items(x).FindControl("TxtQuantity"), RadNumericTextBox)
            txtAmt = CType(dgPurchaseOrder.Items(x).FindControl("TxtAmount"), RadTextBox)
            txtrate = CType(dgPurchaseOrder.Items(x).FindControl("TxtRate"), RadTextBox)
            If txtQty.Text = "" Then
                txtQty.Text = 0
            End If
            If txtAmt.Text = "" Then
                txtAmt.Text = 0
            End If
            If txtrate.Text = "" Then
                txtrate.Text = 0
            End If
            TotalQty = TotalQty + Val(txtQty.Text)
            txtAmt.Text = (txtQty.Text) * txtrate.Text
            TotalAmt = TotalAmt + Val(txtAmt.Text)
            txtTotalAmount.Text = TotalAmt
            TxtTotalQty.Text = TotalQty
        Next
        uptxtTotalAmount.Update()
        upTxtTotalQty.Update()
    End Sub
    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPreview.Click
        Response.Redirect("PurchaseOrderPreview.aspx?lPOID=" & lPOID & "")
    End Sub
    Sub SetValuesEditMod()
        Dim TotalAmt As Double = 0
        Dim TotalQty As Double = 0
        Dim x As Integer
        Dim txtQty As RadNumericTextBox
        Dim txtAmt As RadTextBox
        Dim txtrate As RadTextBox
        Try
            Dt = objPurchaseMaster.GetPurchaseOrderByPOUsingStyleMaster(lPOID)
            txtPONO.Text = Dt.Rows(0)("PONO")
            cmbMerchant.SelectedValue = Dt.Rows(0)("MarchandID")
            ' cmbStatus.SelectedValue = Dt.Rows(0)("Status")
            If Dt.Rows(0)("POTYPE") = "Repeat" Then
                lblPOType.Text = "R"
            Else
                lblPOType.Text = "I"
            End If
            lblPOTypeHeading.Visible = True
            txtPlacementdate.SelectedDate = Dt.Rows(0)("PlacementDate")
            txtShipmentdatee.SelectedDate = Dt.Rows(0)("ShipmentDate")
            txtCommission.Text = Dt.Rows(0)("Commission")
            txtTolerance.Text = Dt.Rows(0)("Toleranceindays")
            ' txtToleranceDelivery.Text = Dt.Rows(0)("Tolerance")

            ' cmbProductGroup.SelectedValue = Dt.Rows(0)("ProductGroup")
            If String.IsNullOrEmpty(Dt.Rows(0)("ProductGroup").ToString()) = False Then
                'Now first get the ProductGroup ID
                Dim dtProductGroupID As New DataTable
                dtProductGroupID = objPurchaseMaster.GetProductPortfolioID(Dt.Rows(0)("ProductGroup"))
                If dtProductGroupID.Rows.Count > 0 Then
                    Dim ProductGroupID As Long = dtProductGroupID.Rows(0)("ProductPortfolioID")
                    cmbProductGroup.SelectedValue = ProductGroupID
                Else
                    cmbProductGroup.SelectedValue = 0
                End If
            Else
                cmbProductGroup.SelectedValue = 0
            End If
            Dim dtProductCategories As DataTable
            dtProductCategories = objPurchaseMaster.GetAllProductCategories(cmbProductGroup.SelectedValue)
            cmbProductCategroy.DataSource = dtProductCategories
            cmbProductCategroy.DataTextField = "ProductCategories"
            cmbProductCategroy.DataValueField = "ProductCategoriesID"
            cmbProductCategroy.DataBind()

            'Now first get the Product Categories ID
            Dim dtProductCategoriesID As New DataTable
            dtProductCategoriesID = objPurchaseMaster.GetProductCategoriesID(Dt.Rows(0)("ProductCategories"), cmbProductGroup.SelectedValue)
            If dtProductCategoriesID.Rows.Count > 0 Then
                Dim ProductCategoriesID As Long = dtProductCategoriesID.Rows(0)("ProductCategoriesID")
                cmbProductCategroy.SelectedValue = ProductCategoriesID
                updProductCategroy.Update()
            End If

            ' cmbProductCategroy.SelectedValue = Dt.Rows(0)("ProductCategories")
            cmbProcessType.SelectedValue = Dt.Rows(0)("ProcessType")
            '  cmbDesign.SelectedValue = Dt.Rows(0)("Design")
            If String.IsNullOrEmpty(Dt.Rows(0)("Design").ToString()) = False Then
                'Now first get the ProductType ID
                Dim dtProductTypeID As New DataTable
                dtProductTypeID = objPurchaseMaster.GetProductTypeID(Dt.Rows(0)("Design"))
                If dtProductTypeID.Rows.Count > 0 Then
                    Dim ProductTypeID As Long = dtProductTypeID.Rows(0)("TypeID")
                    cmbDesign.SelectedValue = ProductTypeID
                Else
                    cmbDesign.SelectedValue = 0
                End If
            Else
                cmbDesign.SelectedValue = 0
            End If
            txtSeason.Text = Dt.Rows(0)("Season")
            txtBlend.Text = Dt.Rows(0)("Quality")
            txtGSM.Text = Dt.Rows(0)("Construction")
            txtEKNumber.Text = Dt.Rows(0)("EKNumber")
            cmbCurrency.SelectedValue = Dt.Rows(0)("Currency")
            txtBookedExchangeRate.Text = Dt.Rows(0)("ExchangeRate")
            'Before bind Check id of Currency
            Dim DtCurrency As New DataTable
            DtCurrency = objCurrency.GetCurrency(Dt.Rows(0)("Currency"))
            cmbCurrency.SelectedValue = DtCurrency.Rows(0)("CurrencyID")
            'End check
            If String.IsNullOrEmpty(Dt.Rows(0)("PORefNo").ToString()) = False Then
                txtPORefNo.Text = Dt.Rows(0)("PORefNo")
            Else
                txtPORefNo.Text = ""
            End If
            ''For Composirion
            If Dt.Rows(0)("Composition").ToString() = "CMIA" Then
                cmbComposition.SelectedIndex = 0
            ElseIf Dt.Rows(0)("Composition").ToString() = "Oragnic" Then
                cmbComposition.SelectedIndex = 1
            ElseIf Dt.Rows(0)("Composition").ToString() = "100 % Cotton" Then
                cmbComposition.SelectedIndex = 2
            ElseIf Dt.Rows(0)("Composition").ToString() = "Cotton Polyester" Then
                cmbComposition.SelectedIndex = 3
            ElseIf Dt.Rows(0)("Composition").ToString() = "Polystic Cotton" Then
                cmbComposition.SelectedIndex = 4
            ElseIf Dt.Rows(0)("Composition").ToString() = "Tensil" Then
                cmbComposition.SelectedIndex = 5
            ElseIf Dt.Rows(0)("Composition").ToString() = "Bambu" Then
                cmbComposition.SelectedIndex = 6
            ElseIf Dt.Rows(0)("Composition").ToString() = "Micro Fibric" Then
                cmbComposition.SelectedIndex = 7
            ElseIf Dt.Rows(0)("Composition").ToString() = "Viscos-Cotton" Then
                cmbComposition.SelectedIndex = 8
            ElseIf Dt.Rows(0)("Composition").ToString() = "Viscos-Polyester" Then
                cmbComposition.SelectedIndex = 9
            ElseIf Dt.Rows(0)("Composition").ToString() = "Viscos-Elastine" Then
                cmbComposition.SelectedIndex = 10
            ElseIf Dt.Rows(0)("Composition").ToString() = "100 % Polyester" Then
                cmbComposition.SelectedIndex = 11
            ElseIf Dt.Rows(0)("Composition").ToString() = "Leather-Cow/Buffalo" Then
                cmbComposition.SelectedIndex = 12
            ElseIf Dt.Rows(0)("Composition").ToString() = "Leather-Sheep" Then
                cmbComposition.SelectedIndex = 13
            ElseIf Dt.Rows(0)("Composition").ToString() = "Others" Then
                cmbComposition.SelectedIndex = 14
            Else
                cmbComposition.SelectedIndex = 0
            End If
            If String.IsNullOrEmpty(Dt.Rows(0)("Destination").ToString()) = False Then
                txtDestination.Text = Dt.Rows(0)("Destination")
            Else
                txtDestination.Text = ""
            End If
            cmbCustomer.SelectedValue = Dt.Rows(0)("CustomerID")
            cmbSupplier.SelectedValue = Dt.Rows(0)("SupplierID")
            cmbDelivertyTerm.SelectedValue = Dt.Rows(0)("DeliveryType")
            cmbPaymentTerms.SelectedValue = Dt.Rows(0)("PaymentType")
            cmbShipmentMode.SelectedValue = Dt.Rows(0)("ShipmentMode")
            cmbShippingTerm.SelectedValue = Dt.Rows(0)("PaymentMode")
            If Dt.Rows(0)("Status") = "Booked" Then
                cmbStatus.SelectedValue = 0
            ElseIf Dt.Rows(0)("Status") = "Shipped" Then
                cmbStatus.SelectedValue = 1
            ElseIf Dt.Rows(0)("Status") = "Close" Then
                cmbStatus.SelectedValue = 2
            ElseIf Dt.Rows(0)("Status") = "Cancel" Then
                cmbStatus.SelectedValue = 3
            Else
                cmbStatus.SelectedValue = 0
            End If

            'Show LKZ Number.
            Dim objSupplierLKZ As New SupplierLKZNo
            Dim dtCheck As New DataTable
            dtCheck = objSupplierLKZ.CheckExistingOfLKZNumber(cmbSupplier.SelectedValue, cmbCustomer.SelectedValue)
            If dtCheck.Rows.Count > 0 Then
                txtLKZNo.Text = dtCheck.Rows(0)("LKZNumber")
                txtLKZNo.ToolTip = "This is LKZ number" + "[" + dtCheck.Rows(0)("LKZNumber") + "] of " + cmbSupplier.SelectedItem.Text + " To " + cmbCustomer.SelectedItem.Text
            Else
                txtLKZNo.Text = ""
                txtLKZNo.ToolTip = ""
            End If
            'End LKZ
            '-------------------- Detail Values
            dtPurchaseOrder = Nothing
            Session("dtPurchaseOrder") = Nothing
            dtPurchaseOrder = New DataTable
            With dtPurchaseOrder
                .Columns.Add("PurchaseOrderDetailID", GetType(Long))
                .Columns.Add("Article", GetType(String))
                .Columns.Add("Size", GetType(String))
                .Columns.Add("Color", GetType(String))
                .Columns.Add("Quantity", GetType(String))
                .Columns.Add("Rate", GetType(String))
                .Columns.Add("Amount", GetType(String))
                .Columns.Add("StyleID", GetType(Long))
                .Columns.Add("Style", GetType(String))
                .Columns.Add("ArticleDescription", GetType(String))
                .Columns.Add("Remarks", GetType(String))
                .Columns.Add("StyleDetailID", GetType(Long))
            End With
            For x = 0 To Dt.Rows.Count - 1
                Dr = dtPurchaseOrder.NewRow()
                Dr("PurchaseOrderDetailID") = Dt.Rows(x)("PODetailID")
                Dr("Quantity") = Dt.Rows(x)("Quantity")
                Dr("Rate") = Dt.Rows(x)("Rate")
                Dr("Amount") = Math.Round(CDec((Dt.Rows(x)("Quantity")) * (Dt.Rows(x)("Rate"))), 2)
                Dr("StyleID") = Dt.Rows(x)("StyleID")
                Dr("Remarks") = Dt.Rows(x)("Remarks")
                Dr("StyleDetailID") = Dt.Rows(x)("StyleDetailID")
                '-------------
                If String.IsNullOrEmpty(Dt.Rows(x)("Article").ToString()) = False Then
                    Dr("Article") = Dt.Rows(x)("Article")
                Else
                    Dr("Article") = ""
                End If
                If String.IsNullOrEmpty(Dt.Rows(x)("SizeRange").ToString()) = False Then
                    Dr("Size") = Dt.Rows(x)("SizeRange")
                Else
                    Dr("Size") = ""
                End If
                If String.IsNullOrEmpty(Dt.Rows(x)("Colorway").ToString()) = False Then
                    Dr("Color") = Dt.Rows(x)("Colorway")
                Else
                    Dr("Color") = ""
                End If
                If String.IsNullOrEmpty(Dt.Rows(x)("Rate").ToString()) = False Then
                    Dr("Rate") = Dt.Rows(x)("Rate")
                Else
                    Dr("Rate") = ""
                End If
                If String.IsNullOrEmpty(Dt.Rows(x)("StyleNo").ToString()) = False Then
                    Dr("Style") = Dt.Rows(x)("StyleNo")
                Else
                    Dr("Style") = ""
                End If
                If String.IsNullOrEmpty(Dt.Rows(x)("ArticleDescription").ToString()) = False Then
                    Dr("ArticleDescription") = Dt.Rows(x)("ArticleDescription")
                Else
                    Dr("ArticleDescription") = ""
                End If
                dtPurchaseOrder.Rows.Add(Dr)
            Next
            Session("dtPurchaseOrder") = dtPurchaseOrder
            BindGrid()
            For x = 0 To Dt.Rows.Count - 1
                txtQty = CType(dgPurchaseOrder.Items(x).FindControl("txtQuantity"), RadNumericTextBox)
                txtAmt = CType(dgPurchaseOrder.Items(x).FindControl("txtAmount"), RadTextBox)
                txtrate = CType(dgPurchaseOrder.Items(x).FindControl("txtRate"), RadTextBox)

                txtQty.Text = Dt.Rows(x)("Quantity")
                txtrate.Text = Dt.Rows(x)("Rate")
                txtAmt.Text = Math.Round(CDec((Dt.Rows(x)("Quantity")) * (Dt.Rows(x)("Rate"))), 2)
                TotalQty = Math.Round(TotalQty + CDec(Val(Dt.Rows(x)("Quantity"))), 2)
                TotalAmt = Math.Round(TotalAmt + CDec(Val(txtAmt.Text)), 2)
                txtTotalAmount.Text = TotalAmt
                TxtTotalQty.Text = TotalQty
            Next
            uptxtTotalAmount.Update()
            upTxtTotalQty.Update()
            'Bokked Rate
            CheckBookedExchangeRate()
        Catch ex As Exception
        End Try
    End Sub
    Sub GeneratQRCodeMGT()
        'MGT Start

        Dim CurrentID As Long
        If lPOID > 0 Then
            CurrentID = lPOID
            RadBarcode1.Text = "http://184.173.211.234/ECPB2B/BusinessProcess/QRCodeMGT.aspx?lPOID=" & CurrentID & ""
        Else
            CurrentID = objPurchaseMaster.GetPOId
            RadBarcode1.Text = "http://184.173.211.234/ECPB2B/BusinessProcess/QRCodeMGT.aspx?lPOID=" & CurrentID & ""
        End If
        If (Directory.Exists(Server.MapPath("~/POQRCodes/" & CurrentID & "/MGT"))) Then
        Else
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/POQRCodes/" & CurrentID & "/MGT"))
            di.Create()
            RadBarcode1.GetImage.Save(Server.MapPath("~/POQRCodes/" & CurrentID & "/MGT/QRCodeMGT.png"))
        End If

        ' Response.Write("<script> window.open('QRCodeMGT.aspx?lPOID=" & lPOID & "', 'newwindow', 'left=50, top=30, height=520, width=600, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")
        'MGT End
    End Sub
    Sub GeneratQRCodeMerchant()
        'Merchant Start

        Dim CurrentID As Long
        If lPOID > 0 Then
            CurrentID = lPOID
            RadBarcode1.Text = "http://184.173.211.234/ECPB2B/BusinessProcess/QRCodeMerchant.aspx?lPOID=" & CurrentID & ""
        Else
            CurrentID = objPurchaseMaster.GetPOId
            RadBarcode1.Text = "http://184.173.211.234/ECPB2B/BusinessProcess/QRCodeMerchant.aspx?lPOID=" & CurrentID & ""
        End If
        If (Directory.Exists(Server.MapPath("~/POQRCodes/" & CurrentID & "/Merchant"))) Then
        Else
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/POQRCodes/" & CurrentID & "/Merchant"))
            di.Create()
            RadBarcode1.GetImage.Save(Server.MapPath("~/POQRCodes/" & CurrentID & "/Merchant/QRCodeMerchant.png"))
        End If
        'Response.Write("<script> window.open('QRCodeMerchant.aspx?lPOID=" & lPOID & "', 'newwindow', 'left=50, top=30, height=520, width=600, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")
        'End Merchant

    End Sub
    Sub GeneratQRCodeQD()
        'Start QD

        Dim CurrentID As Long
        If lPOID > 0 Then
            CurrentID = lPOID
            RadBarcode1.Text = "http://184.173.211.234/ECPB2B/BusinessProcess/QRCodeQD.aspx?lPOID=" & CurrentID & ""
        Else
            CurrentID = objPurchaseMaster.GetPOId
            RadBarcode1.Text = "http://184.173.211.234/ECPB2B/BusinessProcess/QRCodeQD.aspx?lPOID=" & CurrentID & ""
        End If
        If (Directory.Exists(Server.MapPath("~/POQRCodes/" & CurrentID & "/QD"))) Then
        Else
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/POQRCodes/" & CurrentID & "/QD"))
            di.Create()
            RadBarcode1.GetImage.Save(Server.MapPath("~/POQRCodes/" & CurrentID & "/QD/QRCodeQD.png"))
        End If
        ' Response.Write("<script> window.open('QRCodeQD.aspx?lPOID=" & lPOID & "', 'newwindow', 'left=50, top=30, height=520, width=600, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")
        'End QD

    End Sub
    Protected Sub lnkExchangeRate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkExchangeRate.Click
        Try
            ' Response.Write("<script> window.open('BookedExchangePopup.aspx?', 'newwindow', 'left=100, top=160, height=420, width=500, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")
            ScriptManager.RegisterClientScriptBlock(Me.upLnkRate, Me.upLnkRate.GetType(), "New ClientScript", "window.open('BookedExchangePopup.aspx?', 'newwindow', 'left=100, top=160, height=420, width=500, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no');", True)
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnBookedExchangeRate_Click1(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBookedExchangeRate.Click
        Try
            If (Session("dtBookedExchangeRate")).ToString() = "" Then
                txtBookedExchangeRate.Text = 0
            ElseIf (Session("dtBookedExchangeRate")) = 0 Then
                txtBookedExchangeRate.Text = 0
            Else
                txtBookedExchangeRate.Text = (Session("dtBookedExchangeRate"))
            End If
            upBookedExchange.Update()
        Catch ex As Exception

        End Try
    End Sub
    Sub SendEmailMGT()
        Try
            Dim objUser As New User
            Dim dtEmail As DataTable
            Dim CurrentID As Long
            If lPOID > 0 Then
                CurrentID = lPOID
            Else
                CurrentID = objPurchaseMaster.GetPOId
            End If

            'For MGT
            Dim Report As New ReportDocument
            Dim Options As New ExportOptions
            Report.Load(Server.MapPath("..\Reports/QRMGT.rpt"))
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/SystemGeneratedPDF/" & CurrentID & "/MGT"))
            di.Create()

            Dim FileName As String = txtPONO.Text + "-" + cmbCustomer.SelectedItem.Text + "-" + cmbSupplier.SelectedItem.Text + "-MGTCopy"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/SystemGeneratedPDF/" & CurrentID & "/MGT/" & FileName & ".pdf"
            Report.SetParameterValue(0, CurrentID)
            Dim FileOption As New DiskFileDestinationOptions
            FileOption.DiskFileName = sTempFileName
            Options = Report.ExportOptions
            Options.ExportDestinationType = ExportDestinationType.DiskFile
            Options.ExportFormatType = ExportFormatType.PortableDocFormat
            Options.DestinationOptions = FileOption
            Options.ExportDestinationOptions = FileOption
            Report.SetDatabaseLogon("sa", "pwd")
            Report.Export()

            'Email

            Dim mail As MailMessage = New MailMessage()
            dtEmail = objUser.GetEmailAddress(77)
            mail.To.Add(dtEmail.Rows(0)("EmailAddress"))
            Dim dtCC As DataTable
            Dim x As Integer
            dtCC = objUser.GetEmailAddressCC()
            For x = 0 To dtCC.Rows.Count - 1
                mail.CC.Add(dtCC.Rows(x)("EmailAddress"))
                ' mail.CC.Add("ceo@itg.net.pk")
            Next
            mail.Bcc.Add("zahidsajjad@hotmail.com")
            mail.From = New MailAddress("noreply@eurocentrab2b.com")
            mail.Attachments.Add(New Attachment(Server.MapPath("~/SystemGeneratedPDF/" & CurrentID & "/MGT/" & FileName & ".pdf")))
            mail.Subject = "Order placement attachment: PO No. " & txtPONO.Text & "," & cmbCustomer.SelectedItem.Text & " | MGT copy"
            Dim Body As String = " " & _
                         "<br/>" & _
                         "Greetings:" & _
                           "<br/>" & _
                           "<br/>" & _
                         "Data feeder placed a purchase order at Euro Centra B2B. Enclosed please find copy of the purchase order." & _
                        "<br/>"
            Body = Body + " " & _
                         "Please note system also generates quick response code for the above order. QR Code will felicitate you " & _
                         "<br/>" & _
                          "to track order via your mobile phone. " & _
                          "<br/>" & _
                          "<br/>" & _
                          "Thanks" & _
                           "<br/>" & _
                        "Euro Centra B2B." & _
                           "<br/>" & _
                             "<br/>" & _
                         "Powered By: Integra ERP "
            mail.Body = Body
            mail.IsBodyHtml = True
            Dim smtp As SmtpClient = New SmtpClient()
            smtp.Port = 25
            smtp.Host = "mail.eurocentrab2b.com"
            smtp.Credentials = New System.Net.NetworkCredential("noreply@eurocentrab2b.com", "sajjad007")
            smtp.EnableSsl = False
            smtp.Send(mail)

            ' Dim bw As BackgroundWorker = New BackgroundWorker
            'Imports System.ComponentModel

            '' bw.WorkerReportsProgress = True
            ''bw.WorkerSupportsCancellation = True
            ''Thread iniatlize
            'Page.RegisterAsyncTask(New PageAsyncTask(New BeginEventHandler(AddressOf beginAsyncOperation), New EndEventHandler(AddressOf endAsyncOperation), New EndEventHandler(AddressOf timeoutAsyncOperation), New Object(), False))

            ''AddHandler bw.DoWork, AddressOf bw_DoWork
            ''AddHandler bw.ProgressChanged, AddressOf bw_ProgressChanged
            ''AddHandler bw.RunWorkerCompleted, AddressOf bw_RunWorkerCompleted
            ''If Not bw.IsBusy = True Then
            ''    bw.RunWorkerAsync()
            ''End If
        Catch ex As Exception

        End Try
    End Sub
    Sub SendEmailMerchant()
        Try
            Dim objUser As New User
            Dim dtEmail As DataTable
            Dim CurrentID As Long
            If lPOID > 0 Then
                CurrentID = lPOID
            Else
                CurrentID = objPurchaseMaster.GetPOId
            End If

            Dim Report As New ReportDocument
            Dim Options As New ExportOptions
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/SystemGeneratedPDF/" & CurrentID & "/Merchant"))
            di.Create()
            Report.Load(Server.MapPath("..\Reports/QRMerchant.rpt"))

            Dim FileName As String = txtPONO.Text + "-" + cmbCustomer.SelectedItem.Text + "-" + cmbSupplier.SelectedItem.Text + "-MerchantCopy"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/SystemGeneratedPDF/" & CurrentID & "/Merchant/" & FileName & ".pdf"
            Report.SetParameterValue(0, CurrentID)
            Dim FileOption As New DiskFileDestinationOptions
            FileOption.DiskFileName = sTempFileName
            Options = Report.ExportOptions
            Options.ExportDestinationType = ExportDestinationType.DiskFile
            Options.ExportFormatType = ExportFormatType.PortableDocFormat
            Options.DestinationOptions = FileOption
            Options.ExportDestinationOptions = FileOption
            Report.SetDatabaseLogon("sa", "pwd")
            Report.Export()

            'Email
            dtEmail = objUser.GetEmailAddress(cmbMerchant.SelectedValue)
            Dim mail As MailMessage = New MailMessage()
            mail.To.Add(dtEmail.Rows(0)("EmailAddress"))
            mail.Bcc.Add("zahidsajjad@hotmail.com")
            ' mail.CC.Add("ceo@itg.net.pk")
            mail.From = New MailAddress("noreply@eurocentrab2b.com")
            mail.Attachments.Add(New Attachment(Server.MapPath("~/SystemGeneratedPDF/" & CurrentID & "/Merchant/" & FileName & ".pdf")))
            mail.Subject = "Order placement attachment: PO No. " & txtPONO.Text & "," & cmbCustomer.SelectedItem.Text & "| TDG copy"
            Dim Body As String = " " & _
                         "<br/>" & _
                         "<Greetings:" & _
                           "<br/>" & _
                           "<br/>" & _
                         "Data feeder placed a purchase order at Euro Centra B2B. Enclosed please find copy of the purchase order. " & _
                        "<br/>"
            Body = Body + " " & _
                        "Please note system also generates quick response code for the above order. QR Code will felicitate you " & _
                         "<br/>" & _
                          "to update order status via your mobile phone. " & _
                          "<br/>" & _
                            "<br/>" & _
                         "Thanks" & _
                           "<br/>" & _
                          "Euro Centra B2B." & _
                           "<br/>" & _
                             "<br/>" & _
                         "Powered By: Integra ERP "
            mail.Body = Body
            mail.IsBodyHtml = True
            Dim smtp As SmtpClient = New SmtpClient()
            smtp.Port = 25
            smtp.Host = "mail.eurocentrab2b.com"
            smtp.Credentials = New System.Net.NetworkCredential("noreply@eurocentrab2b.com", "sajjad007")
            smtp.EnableSsl = False
            smtp.Send(mail)

        Catch ex As Exception

        End Try
    End Sub
    Sub SendEmailQD()
        Try
            Dim objUser As New User
            Dim dtEmail As DataTable
            Dim CurrentID As Long
            If lPOID > 0 Then
                CurrentID = lPOID
            Else
                CurrentID = objPurchaseMaster.GetPOId
            End If

            Dim Report As New ReportDocument
            Dim Options As New ExportOptions
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/SystemGeneratedPDF/" & CurrentID & "/QD"))
            di.Create()
            Report.Load(Server.MapPath("..\Reports/QRQD.rpt"))

            Dim FileName As String = txtPONO.Text + "-" + cmbCustomer.SelectedItem.Text + "-" + cmbSupplier.SelectedItem.Text + "-QDCopy"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/SystemGeneratedPDF/" & CurrentID & "/QD/" & FileName & ".pdf"
            Report.SetParameterValue(0, CurrentID)
            Dim FileOption As New DiskFileDestinationOptions
            FileOption.DiskFileName = sTempFileName
            Options = Report.ExportOptions
            Options.ExportDestinationType = ExportDestinationType.DiskFile
            Options.ExportFormatType = ExportFormatType.PortableDocFormat
            Options.DestinationOptions = FileOption
            Options.ExportDestinationOptions = FileOption
            Report.SetDatabaseLogon("sa", "pwd")
            Report.Export()

            'Email
            dtEmail = objUser.GetEmailAddress(22)
            Dim mail As MailMessage = New MailMessage()
            mail.To.Add(dtEmail.Rows(0)("EmailAddress"))
            mail.Bcc.Add("zahidsajjad@hotmail.com")
            mail.From = New MailAddress("noreply@eurocentrab2b.com")
            mail.Attachments.Add(New Attachment(Server.MapPath("~/SystemGeneratedPDF/" & CurrentID & "/QD/" & FileName & ".pdf")))
            mail.Subject = "Order placement attachment: PO No. " & txtPONO.Text & "," & cmbCustomer.SelectedItem.Text & "| QD copy"
            Dim Body As String = " " & _
                         "<br/>" & _
                         "Greetings:" & _
                           "<br/>" & _
                           "<br/>" & _
                         "Data feeder placed a purchase order at Euro Centra B2B. Enclosed please find copy of the purchase order. " & _
                        "<br/>"
            Body = Body + " " & _
                        "Please note system also generates quick response code for the above order. QR Code will felicitate you " & _
                         "<br/>" & _
                          "to update order status via your mobile phone. " & _
                          "<br/>" & _
                            "<br/>" & _
                          "Thanks" & _
                           "<br/>" & _
                          "Euro Centra B2B." & _
                           "<br/>" & _
                             "<br/>" & _
                         "Powered By: Integra ERP "
            mail.Body = Body
            mail.IsBodyHtml = True
            Dim smtp As SmtpClient = New SmtpClient()
            smtp.Port = 25
            smtp.Host = "mail.eurocentrab2b.com"
            smtp.Credentials = New System.Net.NetworkCredential("noreply@eurocentrab2b.com", "sajjad007")
            smtp.EnableSsl = False
            smtp.Send(mail)

        Catch ex As Exception

        End Try
    End Sub
    Sub SavePOTracking()
        Try
            Dim objPOtracking As New POTracking
            With objPOtracking
                .PoTrackingID = 0
                .CreationDate = Date.Now
                If lPOID = 0 Then
                    .POID = objPurchaseMaster.GetPOId
                End If
                .TrackingObject = "Order Placed"
                .SavePOTracking()
            End With
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub dgPurchaseOrder_DeleteCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgPurchaseOrder.DeleteCommand
        dtPurchaseOrder = CType(Session("dtPurchaseOrder"), DataTable)
        If (Not dtPurchaseOrder Is Nothing) Then
            If (dtPurchaseOrder.Rows.Count > 0) Then
                Dim PurchaseOrderDetailID As Integer = dtPurchaseOrder.Rows(e.Item.ItemIndex)("PurchaseOrderDetailID")
                dtPurchaseOrder.Rows.RemoveAt(e.Item.ItemIndex)
                objPurchaseDetail.DeletePurchaseOrderDetail(PurchaseOrderDetailID)
                BindGrid()

            Else

            End If
        End If
    End Sub
    Protected Sub cmbStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbStatus.SelectedIndexChanged
        Try
            If cmbStatus.SelectedValue = 2 Then
                cmbStatus.SelectedValue = 0
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
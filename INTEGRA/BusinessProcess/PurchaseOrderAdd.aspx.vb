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
Public Class PurchaseOrderAdd
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
    Dim lPOID, UserID As Long
    Public MarchandID As Long
    Public ShimpmentDate As String
    Dim GeneralCode As New GeneralCode
    Dim dtMarchand As DataTable
    Dim dtCheckDivistion As DataTable
    Dim objPurchaseReviseShip As New PurchaseOrderReviseShipment
    Dim Dt As New DataTable
    Dim objCurrency As New Currency
    Dim dtAdditional As New DataTable
    Dim objGeneralcode As New GeneralCode
    Dim Type As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lPOID = Request.QueryString("lPOID")
        UserID = Session("UserId")
        Type = Request.QueryString("Type")
        ' MarchandID = Session("UserId")
        If Not Page.IsPostBack Then
            Session("dtPurchaseOrder") = Nothing
            Session("dtSelection") = Nothing

            Session("dtBookedExchangeRate") = Nothing

            lblPOType.Text = ""
            lblPOTypeHeading.Visible = False
            btnCalculate.Visible = False
            BindMarchant()
            BindCustomer()
            BindSupplier()
            BindShipmentMode()
            BindPaymentTerm()
            BindCurrency()
            cmbCurrency.SelectedValue = 46
            BindLKZNumber()
            bindseason()
            ChkTNA.Checked = True
            btnBookedExchangeRate.Visible = False
            lnkExchangeRate.Enabled = False
            btnPreview.Visible = False
            If Type = "Copy" Then
                SetValuesCopyMod()
                btnPrint.Visible = False
            Else
                If lPOID > 0 Then
                    btnCalculate.Visible = True
                    SetValuesEditMod()
                    cmbCustomer.Enabled = False
                    cmbSupplier.Enabled = False
                    btnPreview.Visible = True

                    Dim Status As String = objPurchaseMaster.GetStatus(lPOID)
                    If Status = "Close" Then
                        cmbStatus.Enabled = False
                    Else
                        cmbStatus.Enabled = True
                    End If

                    btnPrint.Visible = True
                Else
                    btnPrint.Visible = False
                End If
            End If
        End If
    End Sub
    Sub bindseason()
        Dim dt As DataTable
        dt = objPurchaseMaster.GetSeason
        cmbseason.DataSource = dt
        cmbseason.DataTextField = "season"
        cmbseason.DataValueField = "SeasonID"
        cmbseason.DataBind()
    End Sub
    Sub BindMarchant()
        Try
            Dim dtMarchandizer As DataTable = objPurchaseMaster.GetMarchandizer
            cmbMerchant.DataSource = dtMarchandizer
            cmbMerchant.DataTextField = "UserName"
            cmbMerchant.DataValueField = "UserId"
            cmbMerchant.DataBind()
            cmbMerchant.SelectedValue = MarchandID
            cmbMerchant.Enabled = True
            UpdatePanel3.Update()

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

            Dim objStyleMaster As New StyleMaster
            cmbBuyingDept.DataSource = objStyleMaster.GetBuyingNo(cmbCustomer.SelectedValue)
            cmbBuyingDept.DataValueField = "departmentno"
            cmbBuyingDept.DataTextField = "departmentno"
            cmbBuyingDept.DataBind()
            UpdcmbBuyingDept.Update()
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

            End With
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
    Sub BindLKZNumber()
        Try
            'Show LKZ Number.
            Dim objSupplierLKZ As New SupplierLKZNo
            Dim dtCheck As New DataTable
            '   dtCheck = objSupplierLKZ.CheckExistingOfLKZNumber(cmbSupplier.SelectedValue, cmbCustomer.SelectedValue)
            dtCheck = objSupplierLKZ.CheckExistingOfSupplierCode(cmbSupplier.SelectedValue)
            If dtCheck.Rows.Count > 0 Then
                txtLKZNo.Text = dtCheck.Rows(0)("VenderCode")
                'txtLKZNo.ToolTip = "This is Supplier No" + "[" + dtCheck.Rows(0)("LKZNumber") + "] of " + cmbSupplier.SelectedItem.Text + " To " + cmbCustomer.SelectedItem.Text
                txtLKZNo.ToolTip = "This is Supplier Code"
                updLKZNo.Update()
            Else
                txtLKZNo.Text = ""
                updLKZNo.Update()
            End If
            'End LKZ
        Catch ex As Exception

        End Try


    End Sub
    Sub BindByeingDepartmet()
        Try
            Dim objStyleMaster As New StyleMaster
            cmbBuyingDept.DataSource = objStyleMaster.GetBuyingNoNew(cmbCustomer.SelectedValue)
            cmbBuyingDept.DataValueField = "departmentno"
            cmbBuyingDept.DataTextField = "departmentno"
            cmbBuyingDept.DataBind()
            UpdcmbBuyingDept.Update()
        Catch ex As Exception

        End Try


    End Sub
    Protected Sub cmbCustomer_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCustomer.SelectedIndexChanged
        Try
            '--it is a suplier code
            BindByeingDepartmet()

            'Commission
            txtCommission.Text = objCustomer.GetCommission(cmbCustomer.SelectedValue)
            UpdcmbBuyingDept.Update()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbSupplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSupplier.SelectedIndexChanged
        Try
            '--it is a suplier code
            BindLKZNumber()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnAddMore_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddMore.Click
        Try
            ' Response.Write("<script> window.open('StylepopupNew.aspx?', 'newwindow', 'left=50, top=30, height=520, width=600, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")
            ScriptManager.RegisterClientScriptBlock(Me.upAddMore, Me.upAddMore.GetType(), "New ClientScript", "window.open('StylepopupNew.aspx?', 'newwindow', 'left=50, top=30, height=520, width=600, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no');", True)

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnShowData_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnShowData.Click
        Try
            If txtShipmentDate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Shipment Date Empty.")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                FillGridByStyle()
                BindGrid1()
                '--Nizam Commited function
                ' BindGridAdditional()
                SetValuesintoGrid()
                CheckRepeatStyle()
                CheckBookedExchangeRate()
                Session("dtSelection") = Nothing
                btnCalculate.Visible = True
                updgPurchaseOrder.Update()
                '--Nizam Commited function
                '  UpdgAdditional.Update()
                upbtnCalculate.Update()
                upBookedExchange.Update()
                upLnkRate.Update()
            End If

        Catch ex As Exception

        End Try
    End Sub
    Sub FillGridByStyle()
        Dim iStyleID As String = ""
        Dim bShouldAdd As Boolean = True
        Dim isEmployeeExist As Boolean = False
        If (Not CType(Session("dtPurchaseOrder"), DataTable) Is Nothing) Then
            dtPurchaseOrder = Session("dtPurchaseOrder")
        Else
            dtPurchaseOrder = New DataTable
            With dtPurchaseOrder
                .Columns.Add("PurchaseOrderDetailID", GetType(Long))
                .Columns.Add("ColorRefNo", GetType(String))
                .Columns.Add("Size", GetType(String))
                .Columns.Add("Color", GetType(String))
                .Columns.Add("Quantity", GetType(String))
                .Columns.Add("Rate", GetType(String))
                .Columns.Add("Amount", GetType(String))
                .Columns.Add("StyleID", GetType(Long))
                .Columns.Add("Style", GetType(String))
                .Columns.Add("StyleDescription", GetType(String))
                .Columns.Add("Remarks", GetType(String))
                .Columns.Add("StyleDetailID", GetType(Long))
                .Columns.Add("DetailShipmentDate", GetType(String))
                .Columns.Add("DetailShipmentMode", GetType(String))

            End With
        End If
        Dim x As Integer
        dtStyle = Session("dtSelection")
        If Not dtStyle Is Nothing Then
            For x = 0 To dtStyle.Rows.Count - 1
                Dr = dtPurchaseOrder.NewRow()
                Dr("PurchaseOrderDetailID") = dtStyle.Rows(x)("PurchaseOrderDetailID")
                Dr("ColorRefNo") = dtStyle.Rows(x)("ColorRefNo")
                Dr("Size") = dtStyle.Rows(x)("Size")
                Dr("Color") = dtStyle.Rows(x)("Colorway")
                Dr("Quantity") = ""
                Dr("Rate") = dtStyle.Rows(x)("ItemPrice")
                Dr("Amount") = ""
                iStyleID = iStyleID + dtStyle.Rows(x)("ID").ToString() + " ,"
                Dr("StyleID") = dtStyle.Rows(x)("ID")
                Dr("Style") = dtStyle.Rows(x)("StyleNo")
                Dr("StyleDescription") = dtStyle.Rows(x)("StyleDescription")
                Dr("Remarks") = ""
                Dr("StyleDetailID") = dtStyle.Rows(x)("StyleDetailID")

                Dr("DetailShipmentDate") = objGeneralcode.GetDateByMonth(txtShipmentDate.Text)
                Dr("DetailShipmentMode") = cmbShipmentMode.SelectedValue

                dtPurchaseOrder.Rows.Add(Dr)
            Next
            Session("dtPurchaseOrder") = dtPurchaseOrder

            iStyleID = iStyleID.Substring(0, iStyleID.Length - 1)
            dtAdditional = objPurchaseMaster.GetStyleInfo(iStyleID)
            If dtAdditional.Rows.Count > 0 Then
                Session("dtAdditional") = dtAdditional
            End If

        End If
    End Sub
    Private Function BindGridAdditional() As Boolean
        If (Not dtAdditional Is Nothing) Then
            If (dtAdditional.Rows.Count > 0) Then
                dgAdditional.DataSource = dtAdditional
                dgAdditional.DataBind()
                dgAdditional.Visible = True

                Return (True)
            End If
        End If
        Return (False)
    End Function
    Private Function BindGrid() As Boolean
        If (Not dtPurchaseOrder Is Nothing) Then
            If (dtPurchaseOrder.Rows.Count > 0) Then
                dgPurchaseOrder.DataSource = dtPurchaseOrder
                dgPurchaseOrder.DataBind()
                dgPurchaseOrder.Visible = True
                Return (True)
            End If
        End If
        Return (False)
    End Function
    Private Function BindGrid1() As Boolean
        If (Not dtPurchaseOrder Is Nothing) Then
            If (dtPurchaseOrder.Rows.Count > 0) Then
                dgPurchaseOrder.DataSource = dtPurchaseOrder
                dgPurchaseOrder.DataBind()
                dgPurchaseOrder.Visible = True

                BindDetailShipmentMode()

                Dim x As Integer
                For x = 0 To dgPurchaseOrder.Items.Count - 1
                    Dim txtRemarks As TextBox = CType(dgPurchaseOrder.Items(x).FindControl("txtRemarks"), TextBox)
                    Dim txtDetailShipmentDate As TextBox = CType(dgPurchaseOrder.Items(x).FindControl("txtDetailShipmentDate"), TextBox)
                    Dim cmbDetailShipmentMode As DropDownList = CType(dgPurchaseOrder.Items(x).FindControl("cmbDetailShipmentMode"), DropDownList)
                    txtDetailShipmentDate.Text = dtPurchaseOrder.Rows(x)("DetailShipmentDate")
                    cmbDetailShipmentMode.SelectedValue = dtPurchaseOrder.Rows(x)("DetailShipmentMode")
                    txtRemarks.Text = dtPurchaseOrder.Rows(x)("Remarks")
                Next

                Return (True)
            End If
        End If
        Return (False)
    End Function
    Sub BindDetailShipmentMode()
        Try
            Dim dtShipmentType As DataTable
            dtShipmentType = objPORelatedField.GetShipmentMode
            Dim x As Integer
            For x = 0 To dgPurchaseOrder.Items.Count - 1
                Dim cmbDetailShipmentMode As DropDownList = CType(dgPurchaseOrder.Items(x).FindControl("cmbDetailShipmentMode"), DropDownList)

                cmbDetailShipmentMode.DataSource = dtShipmentType
                cmbDetailShipmentMode.DataTextField = "Name"
                cmbDetailShipmentMode.DataValueField = "ID"
                cmbDetailShipmentMode.DataBind()
            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub SetValuesintoGrid()
        Dim x As Integer
        Dim txtQty As TextBox
        Dim txtrate As TextBox
        Dim txtAmt As TextBox

        If (Not CType(Session("dtPurchaseOrder"), DataTable) Is Nothing) Then
            dtPurchaseOrder = Session("dtPurchaseOrder")
            For x = 0 To dtPurchaseOrder.Rows.Count - 1
                txtQty = CType(dgPurchaseOrder.Items(x).FindControl("txtQuantity"), TextBox)
                txtrate = CType(dgPurchaseOrder.Items(x).FindControl("txtRate"), TextBox)
                txtAmt = CType(dgPurchaseOrder.Items(x).FindControl("txtAmount"), TextBox)
                txtQty.Text = dtPurchaseOrder.Rows(x)("Quantity")
                txtrate.Text = dtPurchaseOrder.Rows(x)("Rate")
                txtAmt.Text = dtPurchaseOrder.Rows(x)("Amount")
            Next

        End If
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

                ElseIf Val(TxtTotalQty.Text) <> Val(txtEnteredQty.Text) Then   ' check system qty and enter qty is equal
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("System Qty and Entered Qty not equal.")
                Else
                    If Type = "Copy" Then
                        CheckAlreadyExist()
                    Else
                        Save()
                    End If

                End If

            Else
                If Val(TxtTotalQty.Text) <> Val(txtEnteredQty.Text) Then   ' check system qty and enter qty is equal
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("System Qty and Entered Qty not equal.")
                Else
                    CheckAlreadyExist()
                End If
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
            styleNo = dgPurchaseOrder.Items(0).Cells(2).Text
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

            GetPODetailValues()

            'Save PDF in Folder
            SaveOriginalPurchaseorder()

        End If
        dgPurchaseOrder.Controls.Clear()
        Dim CurrentID As Long
        'If lPOID = 0 Then
        '    CurrentID = objPurchaseMaster.GetPOId
        '    GenrateTNAChart(CurrentID)
        'Else
        '    CurrentID = lPOID
        'End If
        If lPOID = 0 Or Type = "Copy" Then
            CurrentID = objPurchaseMaster.GetPOId
            GenrateTNAChart(CurrentID)
        Else
            Dim dtcheckTNA As DataTable = objPurchaseMaster.CheckTNA(lPOID)
            If dtcheckTNA.Rows.Count > 0 Then
            Else
                CurrentID = lPOID
                GenrateTNAChart(CurrentID)
            End If
        End If
        '-----------------
        Session("dtSelection") = Nothing
        Session("dtPurchaseOrder") = Nothing
        Session("dtBookedExchangeRate") = Nothing

        Response.Redirect("MasterOrderForDataFeeder.aspx")

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
                If Type = "Copy" Then
                    CurrentID = objPurchaseMaster.GetPOId
                Else
                    CurrentID = lPOID
                End If

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
        Dim txtQty As TextBox
        Dim txtAmt As TextBox
        Dim txtrate As TextBox
        If (Not CType(Session("dtPurchaseOrder"), DataTable) Is Nothing) Then
            dtPurchaseOrder = Session("dtPurchaseOrder")
            For x = 0 To dtPurchaseOrder.Rows.Count - 1
                If lPOID > 0 Then
                ElseIf Type = "Copy" Then

                Else
                    dtPurchaseOrder.Rows(x)("PurchaseOrderDetailID") = 0
                End If
                txtQty = CType(dgPurchaseOrder.Items(x).FindControl("txtQuantity"), TextBox)
                txtAmt = CType(dgPurchaseOrder.Items(x).FindControl("txtAmount"), TextBox)
                txtrate = CType(dgPurchaseOrder.Items(x).FindControl("txtRate"), TextBox)
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
    Sub GenerateCelioCP(ByVal lPOID As Long)
        Try
            Dim objCPChart As New CPChart
            Dim objCPChartHistory As New CPChartHistory
            Dim objPurchaseOrder As New PurchaseOrder
            Dim dt As DataTable = objPurchaseOrder.GetAllPOForCP(lPOID)
            Dim x As Integer
            Dim a As Integer
            For x = 0 To dt.Rows.Count - 1
                Dim dtt As DataTable = objCPChart.GetProcessFirstTime()
                For a = 0 To dtt.Rows.Count - 1
                    With objCPChart
                        .CPChartID = 0
                        .POID = dt.Rows(x)("POID")
                        .CreationDate = Date.Now()
                        .CPProcessID = dtt.Rows(a)("CPProcessID")
                        .Quantity = 0
                        .TargetSubmission = ""
                        .IstSubmission = ""
                        .DHLorFEDEX = ""
                        .FeedBackReceived = ""
                        .RevisedTarget = ""
                        .RevisedSubmission = ""
                        .DHLorFEDEX1 = ""
                        .FeedBackReceived1 = ""
                        .Remarks = ""
                        .SaveCPChart()
                    End With

                    With objCPChartHistory
                        .CPChartHistoryID = 0
                        .CreationDate = Date.Now()
                        .CPChartID = objCPChart.GetId()
                        .CPProcessID = dtt.Rows(a)("CPProcessID")
                        .Quantity = 0
                        .TargetSubmission = ""
                        .IstSubmission = ""
                        .DHLorFEDEX = ""
                        .FeedBackReceived = ""
                        .RevisedTarget = ""
                        .RevisedSubmission = ""
                        .DHLorFEDEX1 = ""
                        .FeedBackReceived1 = ""
                        .Remarks = ""
                        .SaveCPChartHistory()
                    End With
                Next
            Next
        Catch ex As Exception

        End Try
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
        Dim dtproductinfo As DataTable
        '--------- Check Validation
        '---------- Save To Session
        'New Work Zakir
        Dim styleid As Long = dgPurchaseOrder.Items(0).Cells(1).Text

        dtproductinfo = objPurchaseMaster.GetProductInfo(styleid)
        Dim ProductPortfolioID As Long = dtproductinfo.Rows(0)("ProductPortfolioID")
        If ProductPortfolioID = 2 Or ProductPortfolioID = 3 Or ProductPortfolioID = 1 Then
            Dim ObjUMUser As New User
            Dim dt As New DataTable
            If (Not CType(Session("dtMarchand"), DataTable) Is Nothing) Then
                dtuser = Session("dtMarchand")
                userid = Convert.ToInt64(dtuser.Rows(0)("UserId"))
                dt = ObjUMUser.getECPDivisonByID(Convert.ToInt64(cmbMerchant.SelectedValue))
                Dtprocess = objPurchaseMaster.GetScheduleNew(dtuser.Rows(0)("ECPDivistion"))
            End If
            dt = ObjUMUser.getECPDivisonByID(Convert.ToInt64(cmbMerchant.SelectedValue))
            ' Dtprocess = objPurchaseMaster.GetScheduleNew(dt.Rows(0)("ECPDivistion"))
            If ProductPortfolioID = 2 Then
                Dtprocess = objPurchaseMaster.GetScheduleNewwithWoven(dt.Rows(0)("ECPDivistion"), 1)
            ElseIf ProductPortfolioID = 3 Then
                Dtprocess = objPurchaseMaster.GetScheduleNewwithKnits(dt.Rows(0)("ECPDivistion"), 1)
            ElseIf ProductPortfolioID = 1 Then
                Dtprocess = objPurchaseMaster.GetScheduleNewwithHomeTextile(dt.Rows(0)("ECPDivistion"), 1)
            End If


            '----------- Get Detail From PO
            Dim DtPO As New DataTable
            'DtPO = objPurchaseMaster.GetAllPO
            DtPO = objPurchaseMaster.Getforedit(lPOID)
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
                        .Color = ""
                        .SaveTNAChartHistory()
                    End With
                Next
            Next
        End If
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
        Dim currencyCode As String = "USD"
        Dim xmlDoc As New XmlDocument
        Dim nsMgr As XmlNamespaceManager
        Dim nodeCurrency As XmlNode
        Dim nodetime As XmlNode
        Dim nodeHrk As XmlNode
        Dim rate As Double = 0
        Dim ExDate As Date
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

            'Dim DtBookexchange As DataTable
            'Dim datee As Date = txtShipmentDate.Text
            'txtShipmentDatee.SelectedDate = datee
            'Dim startdatee As String = txtShipmentDatee.SelectedDate.Value.ToString("yyyy-MM-dd")
            'DtBookexchange = objPurchaseMaster.GetPOForShipRateNewforBOOKED(startdatee, startdatee, cmbCurrency.SelectedItem.Text)
            'Dim ExchangeRate As Decimal
            'If DtBookexchange.Rows.Count > 0 Then
            '    ExchangeRate = DtBookexchange.Rows(0)("BookedExchangeRate")
            'Else
            '    ExchangeRate = 0
            'End If

            With objPurchaseMaster
                If Type = "Copy" Then
                    .POID = 0
                Else
                    .POID = lPOID
                End If
                .PONO = txtPONO.Text
                If lPOID > 0 Then
                    If Type = "Copy" Then
                        .CreationDate = Date.Now
                        .ExchangeRate = rate
                        If rate = 0 Then
                            .ExchangeDate = Date.Now
                        Else
                            .ExchangeDate = ExDate
                        End If
                    Else
                        .CreationDate = objPurchaseMaster.GetPOCreationDate(lPOID)
                        .ExchangeRate = objPurchaseMaster.GetExchangeRate(lPOID)
                        .ExchangeDate = objPurchaseMaster.GetExchangeDate(lPOID)
                    End If
                Else
                    .CreationDate = Date.Now
                    .ExchangeRate = rate
                    If rate = 0 Then
                        .ExchangeDate = Date.Now
                    Else
                        .ExchangeDate = ExDate
                    End If
                End If
                .LastUpdate = Date.Now

                If lPOID > 0 Then
                    If Type = "Copy" Then
                        .Status = cmbStatus.SelectedItem.Text
                    Else
                        Dim Status As String = objPurchaseMaster.GetStatus(lPOID)
                        If Status = "Close" Then
                            .Status = "Close"
                        Else
                            .Status = cmbStatus.SelectedItem.Text
                        End If
                    End If
                Else
                    .Status = cmbStatus.SelectedItem.Text
                End If

                .Status = cmbStatus.SelectedItem.Text
                If lblPOType.Text = "I" Then
                    .POtype = "New"
                ElseIf lblPOType.Text = "R" Then
                    .POtype = "Repeat"
                End If
                .CustomerID = cmbCustomer.SelectedValue
                .SupplierID = cmbSupplier.SelectedValue
                .PlacementDate = GeneralCode.GetDate(txtPlacementDate.Text)
                .ShipmentDate = GeneralCode.GetDate(txtShipmentDate.Text)
                .Commission = txtCommission.Text
                .Tolerance = 0
                .Toleranceindays = txtTolerance.Text
                .ProductGroup = ""
                .Season = cmbseason.SelectedItem.Text 'txtSeason.Text
                .Quality = ""
                'GSM
                .Construction = ""
                .ShipmentMode = cmbShipmentMode.SelectedValue
                .PaymentMode = 0
                .PaymentType = cmbPaymentTerms.SelectedValue
                .EKNumber = cmbBuyingDept.SelectedItem.Text ' txtEKNumber.Text
                .DeliveryType = 0
                .Currency = cmbCurrency.SelectedItem.Text
                .PORefNo = txtPORefNo.Text
                .Design = ""
                .TimeSpame = GetTimeSpame(GeneralCode.GetDate(txtShipmentDate.Text), GeneralCode.GetDate(txtPlacementDate.Text))
                .MarchandID = cmbMerchant.SelectedValue '
                .Composition = ""
                .Destination = txtDestination.Text
                .ProcessType = ""
                .ProductCategories = ""
                .IsActive = True
                .ExchangeRate = txtBookedExchangeRate.Text 'ExchangeRate '
                .InqDate = GeneralCode.GetDate(InqDate.Text)
                .Stage = cmbStage.SelectedItem.Text
                .UserID = CLng(Session("UserID"))
                .POComplaintType = txtComplaintType.Text
                .SavePurchaseOrderSetup()
                If lPOID = 0 Or Type = "Copy" Then
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
                    .ShipmentDate = GeneralCode.GetDate(txtShipmentDate.Text)
                    .SavePurchaseOrderReviseShipment()
                End With
            Catch ex As Exception
            End Try
        Catch ex As Exception

        End Try
    End Sub
    Private Sub GetPODetailValues()
        For x = 0 To dgPurchaseOrder.Items.Count - 1
            Dim txtQuantity As TextBox = CType(dgPurchaseOrder.Items(x).FindControl("txtQuantity"), TextBox)
            Dim txtRate As TextBox = CType(dgPurchaseOrder.Items(x).FindControl("txtRate"), TextBox)

            Dim txtRemarks As TextBox = CType(dgPurchaseOrder.Items(x).FindControl("txtRemarks"), TextBox)
            Dim txtDetailShipmentDate As TextBox = CType(dgPurchaseOrder.Items(x).FindControl("txtDetailShipmentDate"), TextBox)
            Dim cmbDetailShipmentMode As DropDownList = CType(dgPurchaseOrder.Items(x).FindControl("cmbDetailShipmentMode"), DropDownList)


            With objPurchaseDetail
                .PODetailID = dgPurchaseOrder.Items(x).Cells(0).Text
                If lPOID = 0 Or Type = "Copy" Then
                    .POID = objPurchaseMaster.GetPOId
                Else
                    .POID = lPOID
                End If
                .Quantity = Val(txtQuantity.Text)
                .Rate = Val(txtRate.Text)
                .StyleID = dgPurchaseOrder.Items(x).Cells(1).Text
                .Remarks = txtRemarks.Text
                .StyleDetailID = dgPurchaseOrder.Items(x).Cells(2).Text

                .DetailShipmentDate = objGeneralcode.GetDateN(txtDetailShipmentDate.Text)
                .DetailShipmentMode = cmbDetailShipmentMode.SelectedValue
                .SavePODetailSetup()
            End With
        Next

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
            Dim Shipmentdatee As String = txtShipmentDate.Text.ToString()
            Dim shipdate As Date = txtShipmentDate.Text
            Dim year As String = shipdate.Year
            Dim Month As String = shipdate.Month

            'If Shipmentdatee = "" Then
            '    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Shipment Date Empty")
            'Else
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
            Dim ObjBookedExchangeRate As New BookedExchangeRate
            Dim dtBookedRate As DataTable
            'dtBookedRate = ObjBookedExchangeRate.ExistingOfBookedRateForPOO(txtShipmentDate.Text)
            dtBookedRate = ObjBookedExchangeRate.ExistingOfBookedRateForPOONew(year, Month)

            If dtBookedRate.Rows.Count > 0 Then
                txtBookedExchangeRate.Text = dtBookedRate.Rows(0)("BookedExchangeRate")
                btnBookedExchangeRate.Visible = False
                lnkExchangeRate.Enabled = False
                upLnkRate.Update()
            Else
                txtBookedExchangeRate.Text = "1.33"
                btnBookedExchangeRate.Visible = True
                lnkExchangeRate.Enabled = True
                upLnkRate.Update()
            End If
            If txtBookedExchangeRate.Text = "" Then
                txtBookedExchangeRate.Text = "1.33"
                btnBookedExchangeRate.Visible = True
                lnkExchangeRate.Enabled = True
                upLnkRate.Update()
            End If
            'End If
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
        dtPurchaseOrder = Session("dtPurchaseOrder")
        Dim txtQty As TextBox
        Dim txtAmt As TextBox
        Dim txtrate As TextBox
        Dim TotalAmt As Double = 0
        Dim TotalQty As Double = 0

        Dim x As Integer
        For x = 0 To dgPurchaseOrder.Items.Count - 1
            Dim txtDetailShipmentDate As TextBox = CType(dgPurchaseOrder.Items(x).FindControl("txtDetailShipmentDate"), TextBox)
            txtQty = CType(dgPurchaseOrder.Items(x).FindControl("TxtQuantity"), TextBox)
            txtAmt = CType(dgPurchaseOrder.Items(x).FindControl("TxtAmount"), TextBox)
            txtrate = CType(dgPurchaseOrder.Items(x).FindControl("TxtRate"), TextBox)
            txtDetailShipmentDate.Text = dtPurchaseOrder.Rows(x)("DetailShipmentDate")
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
            txtAmt.Text = ((txtQty.Text) * txtrate.Text).ToString("F2")
            TotalAmt = TotalAmt + Convert.ToDecimal(txtAmt.Text)
            txtTotalAmount.Text = TotalAmt.ToString("F2")
            TxtTotalQty.Text = TotalQty
        Next
        uptxtTotalAmount.Update()
        upTxtTotalQty.Update()
    End Sub
    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPreview.Click
        Response.Redirect("PurchaseOrderPreview.aspx?lPOID=" & lPOID & "")
    End Sub
    Sub SetValuesCopyMod()
        Dim iStyleID As String = ""
        Dim TotalAmt As Double = 0
        Dim TotalQty As Double = 0
        Dim x As Integer
        Dim txtQty As TextBox
        Dim txtAmt As TextBox
        Dim txtrate As TextBox
        Try
            Dt = objPurchaseMaster.GetPurchaseOrderByPOUsingStyleMaster(lPOID)
            txtPONO.Text = Dt.Rows(0)("PONO")
            cmbMerchant.SelectedValue = Dt.Rows(0)("MarchandID")
            If Dt.Rows(0)("POTYPE") = "Repeat" Then
                lblPOType.Text = "R"
            Else
                lblPOType.Text = "I"
            End If
            lblPOTypeHeading.Visible = True
            txtPlacementDate.Text = Dt.Rows(0)("PlacementDate")
            txtShipmentDate.Text = Dt.Rows(0)("ShipmentDate")
            txtCommission.Text = Dt.Rows(0)("Commission")
            txtTolerance.Text = Dt.Rows(0)("Toleranceindays")
            txtComplaintType.Text = Dt.Rows(0)("POComplaintType")

            cmbCustomer.SelectedValue = Dt.Rows(0)("CustomerID")
            'txtSeason.Text = Dt.Rows(0)("Season")
            cmbseason.SelectedItem.Text = Dt.Rows(0)("Season")
            Dim objStyleMaster As New StyleMaster
            cmbBuyingDept.DataSource = objStyleMaster.GetBuyingNo(cmbCustomer.SelectedValue)
            cmbBuyingDept.DataValueField = "departmentno"
            cmbBuyingDept.DataTextField = "departmentno"
            cmbBuyingDept.DataBind()
            cmbBuyingDept.Items.Insert(0, New ListItem("Select", "0"))
            txtEKNumber.Text = Dt.Rows(0)("EKNumber")
            cmbBuyingDept.SelectedItem.Text = Dt.Rows(0)("EKNumber")

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

            If String.IsNullOrEmpty(Dt.Rows(0)("Destination").ToString()) = False Then
                txtDestination.Text = Dt.Rows(0)("Destination")
            Else
                txtDestination.Text = ""
            End If

            cmbSupplier.SelectedValue = Dt.Rows(0)("SupplierID")

            cmbPaymentTerms.SelectedValue = Dt.Rows(0)("PaymentType")
            cmbShipmentMode.SelectedValue = Dt.Rows(0)("ShipmentMode")

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

            InqDate.Text = Dt.Rows(0)("InqDate")
            cmbStage.SelectedItem.Text = Dt.Rows(0)("Stage")

            'Show LKZ Number.
            Dim objSupplierLKZ As New SupplierLKZNo
            Dim dtCheck As New DataTable
            '   dtCheck = objSupplierLKZ.CheckExistingOfLKZNumber(cmbSupplier.SelectedValue, cmbCustomer.SelectedValue)
            dtCheck = objSupplierLKZ.CheckExistingOfSupplierCode(cmbSupplier.SelectedValue)
            If dtCheck.Rows.Count > 0 Then
                txtLKZNo.Text = dtCheck.Rows(0)("VenderCode")
                'txtLKZNo.ToolTip = "This is Supplier No" + "[" + dtCheck.Rows(0)("LKZNumber") + "] of " + cmbSupplier.SelectedItem.Text + " To " + cmbCustomer.SelectedItem.Text
                txtLKZNo.ToolTip = "This is Supplier Code"
                updLKZNo.Update()
            Else
                txtLKZNo.Text = ""
                updLKZNo.Update()
            End If
            'End LKZ
            '-------------------- Detail Values
            'dtPurchaseOrder = Nothing
            'Session("dtPurchaseOrder") = Nothing
            'dtPurchaseOrder = New DataTable
            'With dtPurchaseOrder
            '    .Columns.Add("PurchaseOrderDetailID", GetType(Long))
            '    .Columns.Add("ColorRefNo", GetType(String))
            '    .Columns.Add("Size", GetType(String))
            '    .Columns.Add("Color", GetType(String))
            '    .Columns.Add("Quantity", GetType(String))
            '    .Columns.Add("Rate", GetType(String))
            '    .Columns.Add("Amount", GetType(String))
            '    .Columns.Add("StyleID", GetType(Long))
            '    .Columns.Add("Style", GetType(String))
            '    .Columns.Add("StyleDescription", GetType(String))
            '    .Columns.Add("Remarks", GetType(String))
            '    .Columns.Add("StyleDetailID", GetType(Long))
            '    .Columns.Add("DetailShipmentDate", GetType(String))
            '    .Columns.Add("DetailShipmentMode", GetType(String))
            'End With
            'For x = 0 To Dt.Rows.Count - 1
            '    Dr = dtPurchaseOrder.NewRow()
            '    Dr("PurchaseOrderDetailID") = Dt.Rows(x)("PODetailID")
            '    Dr("Quantity") = Dt.Rows(x)("Quantity")
            '    Dr("Rate") = Dt.Rows(x)("Rate")
            '    Dr("Amount") = Math.Round(CDec((Dt.Rows(x)("Quantity")) * (Dt.Rows(x)("Rate"))), 2)
            '    Dr("StyleID") = Dt.Rows(x)("StyleID")
            '    iStyleID = iStyleID + Dt.Rows(x)("StyleID").ToString() + " ,"
            '    Dr("Remarks") = Dt.Rows(x)("Remarks")
            '    Dr("StyleDetailID") = Dt.Rows(x)("StyleDetailID")
            '    '-------------
            '    If String.IsNullOrEmpty(Dt.Rows(x)("ColorRefNo").ToString()) = False Then
            '        Dr("ColorRefNo") = Dt.Rows(x)("ColorRefNo")
            '    Else
            '        Dr("ColorRefNo") = ""
            '    End If
            '    If String.IsNullOrEmpty(Dt.Rows(x)("Sizes").ToString()) = False Then
            '        Dr("Size") = Dt.Rows(x)("Sizes")
            '    Else
            '        Dr("Size") = ""
            '    End If
            '    If String.IsNullOrEmpty(Dt.Rows(x)("Colorway").ToString()) = False Then
            '        Dr("Color") = Dt.Rows(x)("Colorway")
            '    Else
            '        Dr("Color") = ""
            '    End If
            '    If String.IsNullOrEmpty(Dt.Rows(x)("Rate").ToString()) = False Then
            '        Dr("Rate") = Dt.Rows(x)("Rate")
            '    Else
            '        Dr("Rate") = ""
            '    End If
            '    If String.IsNullOrEmpty(Dt.Rows(x)("StyleNo").ToString()) = False Then
            '        Dr("Style") = Dt.Rows(x)("StyleNo")
            '    Else
            '        Dr("Style") = ""
            '    End If
            '    If String.IsNullOrEmpty(Dt.Rows(x)("StyleDescription").ToString()) = False Then
            '        Dr("StyleDescription") = Dt.Rows(x)("StyleDescription")
            '    Else
            '        Dr("StyleDescription") = ""
            '    End If

            '    Dr("DetailShipmentDate") = Dt.Rows(x)("DetailShipmentDatee")
            '    Dr("DetailShipmentMode") = Dt.Rows(x)("DetailShipmentMode")

            '    dtPurchaseOrder.Rows.Add(Dr)
            'Next
            'Session("dtPurchaseOrder") = dtPurchaseOrder
            'BindGrid1()
            'iStyleID = iStyleID.Substring(0, iStyleID.Length - 1)
            'dtAdditional = objPurchaseMaster.GetStyleInfo(iStyleID)
            'If dtAdditional.Rows.Count > 0 Then
            '    Session("dtAdditional") = dtAdditional
            'End If
            '' BindGridAdditional()
            'For x = 0 To Dt.Rows.Count - 1
            '    txtQty = CType(dgPurchaseOrder.Items(x).FindControl("txtQuantity"), TextBox)
            '    txtAmt = CType(dgPurchaseOrder.Items(x).FindControl("txtAmount"), TextBox)
            '    txtrate = CType(dgPurchaseOrder.Items(x).FindControl("txtRate"), TextBox)

            '    txtQty.Text = Dt.Rows(x)("Quantity")
            '    txtrate.Text = Dt.Rows(x)("Rate")
            '    txtAmt.Text = Math.Round(CDec((Dt.Rows(x)("Quantity")) * (Dt.Rows(x)("Rate"))), 2)
            '    TotalQty = Math.Round(TotalQty + CDec(Val(Dt.Rows(x)("Quantity"))), 2)
            '    TotalAmt = Math.Round(TotalAmt + CDec(Val(txtAmt.Text)), 2)
            '    txtTotalAmount.Text = TotalAmt
            '    TxtTotalQty.Text = TotalQty
            'Next

            'txtEnteredQty.Text = TotalQty

            'uptxtTotalAmount.Update()
            'upTxtTotalQty.Update()
            ''Bokked Rate
            ''CheckBookedExchangeRate()
        Catch ex As Exception

        End Try
    End Sub
    Sub SetValuesEditMod()
        Dim iStyleID As String = ""
        Dim TotalAmt As Double = 0
        Dim TotalQty As Double = 0
        Dim x As Integer
        Dim txtQty As TextBox
        Dim txtAmt As TextBox
        Dim txtrate As TextBox
        Try
            Dt = objPurchaseMaster.GetPurchaseOrderByPOUsingStyleMaster(lPOID)
            txtPONO.Text = Dt.Rows(0)("PONO")
            cmbMerchant.SelectedValue = Dt.Rows(0)("MarchandID")
            If Dt.Rows(0)("POTYPE") = "Repeat" Then
                lblPOType.Text = "R"
            Else
                lblPOType.Text = "I"
            End If
            lblPOTypeHeading.Visible = True
            txtPlacementDate.Text = Dt.Rows(0)("PlacementDate")
            txtShipmentDate.Text = Dt.Rows(0)("ShipmentDate")
            txtCommission.Text = Dt.Rows(0)("Commission")
            txtTolerance.Text = Dt.Rows(0)("Toleranceindays")
            txtComplaintType.Text = Dt.Rows(0)("POComplaintType")

            cmbCustomer.SelectedValue = Dt.Rows(0)("CustomerID")
            'txtSeason.Text = Dt.Rows(0)("Season")
            cmbseason.SelectedItem.Text = Dt.Rows(0)("Season")
            Dim objStyleMaster As New StyleMaster
            cmbBuyingDept.DataSource = objStyleMaster.GetBuyingNo(cmbCustomer.SelectedValue)
            cmbBuyingDept.DataValueField = "departmentno"
            cmbBuyingDept.DataTextField = "departmentno"
            cmbBuyingDept.DataBind()
            cmbBuyingDept.Items.Insert(0, New ListItem("Select", "0"))
            txtEKNumber.Text = Dt.Rows(0)("EKNumber")
            cmbBuyingDept.SelectedItem.Text = Dt.Rows(0)("EKNumber")

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

            If String.IsNullOrEmpty(Dt.Rows(0)("Destination").ToString()) = False Then
                txtDestination.Text = Dt.Rows(0)("Destination")
            Else
                txtDestination.Text = ""
            End If

            cmbSupplier.SelectedValue = Dt.Rows(0)("SupplierID")

            cmbPaymentTerms.SelectedValue = Dt.Rows(0)("PaymentType")
            cmbShipmentMode.SelectedValue = Dt.Rows(0)("ShipmentMode")

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

            InqDate.Text = Dt.Rows(0)("InqDate")
            cmbStage.SelectedItem.Text = Dt.Rows(0)("Stage")

            'Show LKZ Number.
            Dim objSupplierLKZ As New SupplierLKZNo
            Dim dtCheck As New DataTable
            '   dtCheck = objSupplierLKZ.CheckExistingOfLKZNumber(cmbSupplier.SelectedValue, cmbCustomer.SelectedValue)
            dtCheck = objSupplierLKZ.CheckExistingOfSupplierCode(cmbSupplier.SelectedValue)
            If dtCheck.Rows.Count > 0 Then
                txtLKZNo.Text = dtCheck.Rows(0)("VenderCode")
                'txtLKZNo.ToolTip = "This is Supplier No" + "[" + dtCheck.Rows(0)("LKZNumber") + "] of " + cmbSupplier.SelectedItem.Text + " To " + cmbCustomer.SelectedItem.Text
                txtLKZNo.ToolTip = "This is Supplier Code"
                updLKZNo.Update()
            Else
                txtLKZNo.Text = ""
                updLKZNo.Update()
            End If
            'End LKZ
            '-------------------- Detail Values
            dtPurchaseOrder = Nothing
            Session("dtPurchaseOrder") = Nothing
            dtPurchaseOrder = New DataTable
            With dtPurchaseOrder
                .Columns.Add("PurchaseOrderDetailID", GetType(Long))
                .Columns.Add("ColorRefNo", GetType(String))
                .Columns.Add("Size", GetType(String))
                .Columns.Add("Color", GetType(String))
                .Columns.Add("Quantity", GetType(String))
                .Columns.Add("Rate", GetType(String))
                .Columns.Add("Amount", GetType(String))
                .Columns.Add("StyleID", GetType(Long))
                .Columns.Add("Style", GetType(String))
                .Columns.Add("StyleDescription", GetType(String))
                .Columns.Add("Remarks", GetType(String))
                .Columns.Add("StyleDetailID", GetType(Long))
                .Columns.Add("DetailShipmentDate", GetType(String))
                .Columns.Add("DetailShipmentMode", GetType(String))
            End With
            For x = 0 To Dt.Rows.Count - 1
                Dr = dtPurchaseOrder.NewRow()
                Dr("PurchaseOrderDetailID") = Dt.Rows(x)("PODetailID")
                Dr("Quantity") = Dt.Rows(x)("Quantity")
                Dr("Rate") = Dt.Rows(x)("Rate")
                Dr("Amount") = Math.Round(CDec((Dt.Rows(x)("Quantity")) * (Dt.Rows(x)("Rate"))), 2)
                Dr("StyleID") = Dt.Rows(x)("StyleID")
                iStyleID = iStyleID + Dt.Rows(x)("StyleID").ToString() + " ,"
                Dr("Remarks") = Dt.Rows(x)("Remarks")
                Dr("StyleDetailID") = Dt.Rows(x)("StyleDetailID")
                '-------------
                If String.IsNullOrEmpty(Dt.Rows(x)("ColorRefNo").ToString()) = False Then
                    Dr("ColorRefNo") = Dt.Rows(x)("ColorRefNo")
                Else
                    Dr("ColorRefNo") = ""
                End If
                If String.IsNullOrEmpty(Dt.Rows(x)("Sizes").ToString()) = False Then
                    Dr("Size") = Dt.Rows(x)("Sizes")
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
                If String.IsNullOrEmpty(Dt.Rows(x)("StyleDescription").ToString()) = False Then
                    Dr("StyleDescription") = Dt.Rows(x)("StyleDescription")
                Else
                    Dr("StyleDescription") = ""
                End If

                Dr("DetailShipmentDate") = Dt.Rows(x)("DetailShipmentDatee")
                Dr("DetailShipmentMode") = Dt.Rows(x)("DetailShipmentMode")

                dtPurchaseOrder.Rows.Add(Dr)
            Next
            Session("dtPurchaseOrder") = dtPurchaseOrder
            BindGrid1()
            iStyleID = iStyleID.Substring(0, iStyleID.Length - 1)
            dtAdditional = objPurchaseMaster.GetStyleInfo(iStyleID)
            If dtAdditional.Rows.Count > 0 Then
                Session("dtAdditional") = dtAdditional
            End If
            ' BindGridAdditional()
            For x = 0 To Dt.Rows.Count - 1
                txtQty = CType(dgPurchaseOrder.Items(x).FindControl("txtQuantity"), TextBox)
                txtAmt = CType(dgPurchaseOrder.Items(x).FindControl("txtAmount"), TextBox)
                txtrate = CType(dgPurchaseOrder.Items(x).FindControl("txtRate"), TextBox)

                txtQty.Text = Dt.Rows(x)("Quantity")
                txtrate.Text = Dt.Rows(x)("Rate")
                txtAmt.Text = Math.Round(CDec((Dt.Rows(x)("Quantity")) * (Dt.Rows(x)("Rate"))), 2).ToString("F2")
                TotalQty = Math.Round(TotalQty + CDec(Val(Dt.Rows(x)("Quantity"))), 2)
                TotalAmt = Math.Round(TotalAmt + CDec(Convert.ToDecimal(txtAmt.Text)), 2)
                txtTotalAmount.Text = TotalAmt.ToString("F2")
                TxtTotalQty.Text = TotalQty
            Next

            txtEnteredQty.Text = TotalQty

            uptxtTotalAmount.Update()
            upTxtTotalQty.Update()
            'Bokked Rate
            'CheckBookedExchangeRate()
        Catch ex As Exception

        End Try
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
    Protected Sub dgPurchaseOrder_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgPurchaseOrder.ItemCommand
        Select Case e.CommandName
            Case Is = "Remove"
                dtPurchaseOrder = CType(Session("dtPurchaseOrder"), DataTable)
                If (Not dtPurchaseOrder Is Nothing) Then
                    If (dtPurchaseOrder.Rows.Count > 0) Then
                        Dim lPurchaseOrderDetailID As Integer = dtPurchaseOrder.Rows(e.Item.ItemIndex)("PurchaseOrderDetailID")
                        dtPurchaseOrder.Rows.RemoveAt(e.Item.ItemIndex)
                        objPurchaseDetail.DeleteDetailById(lPurchaseOrderDetailID)
                        BindGrid()
                        SetValuesintoGrid()
                        Calculate()
                        If dtPurchaseOrder.Rows.Count = 0 Then
                            dgPurchaseOrder.Visible = False
                        End If
                    Else
                        dgPurchaseOrder.Visible = False
                    End If
                End If
            Case Is = "Calculate"
                Calculate()
        End Select
    End Sub
    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPrint.Click
        Try
            'Delete All PDF files from Folder
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            'End Delete
            Dim Report As New ReportDocument
            Dim Options As New ExportOptions
            Report.Load(Server.MapPath("..\Reports/POPrint.rpt"))
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = txtPONO.Text + "-" + cmbCustomer.SelectedItem.Text + "-" + cmbSupplier.SelectedItem.Text
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
            Report.SetParameterValue(0, lPOID)
            Dim FileOption As New DiskFileDestinationOptions
            FileOption.DiskFileName = sTempFileName
            Options = Report.ExportOptions
            Options.ExportDestinationType = ExportDestinationType.DiskFile
            Options.ExportFormatType = ExportFormatType.PortableDocFormat
            Options.DestinationOptions = FileOption
            Options.ExportDestinationOptions = FileOption
            Report.SetDatabaseLogon("sa", "pwd")
            Report.Export()

            If (Directory.Exists(Server.MapPath("~/TempPDF"))) Then
                Dim strFileSize As String = ""
                Dim dii As New IO.DirectoryInfo(Server.MapPath("~/TempPDF"))
                Dim aryFi As IO.FileInfo() = dii.GetFiles(FileName & ".pdf")
                Dim fi As IO.FileInfo
                For Each fi In aryFi
                    Response.ClearHeaders()
                    Response.ClearContent()
                    Response.ContentType = "application/octet-stream"
                    Response.Charset = "UTF-8"
                    Response.AddHeader("content-disposition", "attachment; filename=" & fi.Name)
                    Response.WriteFile(Server.MapPath("~/TempPDF/" & fi.Name & ""))
                    Response.End()
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
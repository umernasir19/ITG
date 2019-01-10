Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports Telerik.Web.UI.Barcode
Imports System.Net
Imports System.Net.Mail
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class CommercialInvoices
    Inherits System.Web.UI.Page
    Dim dtSelectionPOPUP As New DataTable
    Dim lCommercialInvoiceID As Long
    Dim lPOID As String
    Dim lPODetailID As String
    Dim objCommercial As New Commercial
    Dim objCommercialDetail As New CommercialDetail
    Dim objColor As New Color
    Dim objDataTable As DataTable
    Dim Dr As DataRow
    Dim Dt As New DataTable
    Dim dtCommercial As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lPOID = Request.QueryString("lPOID")
        lPODetailID = Request.QueryString("lPODetailID")
        lCommercialInvoiceID = Request.QueryString("lCommercialInvoiceID")
        If Not Page.IsPostBack Then
            txtCurrency.Visible = False
            If lPOID = "" Then
                ONEdit()
                btnSave.Text = "Update"
            Else
                SetValuesEditMod()
            End If
        End If
    End Sub
    Sub ONEdit()
        Dim TotalAmt As Double = 0
        Dim TotalQty As Double = 0
        Dim x As Integer
        Dim txtQty As RadNumericTextBox
        Dim txtAmt As RadTextBox
        Dim txtrate As RadTextBox
        Dim txtUOM As RadTextBox
        Try
            Dt = objCommercial.GetValeForEdit(lCommercialInvoiceID)
            Dim Currency As String = Dt.Rows(0)("Currency")
            If Currency = "Dollar" Then
                lblCurrency.Text = "$"
            Else
                lblCurrency.Text = "€"
            End If
            txtCurrency.Text = Dt.Rows(0)("Currency")
            txtInvoiceNo.Text = Dt.Rows(0)("InvoiceNo")
            txtInvoiceDate.SelectedDate = Dt.Rows(0)("InvoiceDate")
            txtButyingDept.Text = Dt.Rows(0)("BuyingDept")
            txtBLAWBNo.Text = Dt.Rows(0)("BillNo")
            txtMAWB.Text = Dt.Rows(0)("Mode")
            txtForwarder.Text = Dt.Rows(0)("Forwarder")
            txtContainerSize.Text = Dt.Rows(0)("ContainerSize")
            txtConsolidation.Text = Dt.Rows(0)("Consolidation")
            txtContainerNo.Text = Dt.Rows(0)("ContainerNo")
            txtCargoDate.SelectedDate = Dt.Rows(0)("ShipmentDate")
            txtETA.SelectedDate = Dt.Rows(0)("ETA")
            txtETD.SelectedDate = Dt.Rows(0)("ETD")
            txtCarrierName.Text = Dt.Rows(0)("CarrierName")
            txtVoyageFlight.Text = Dt.Rows(0)("VoyageFlight")
            txtPODPOA.Text = Dt.Rows(0)("Remarks")
            txtComments.Text = Dt.Rows(0)("Comments")
            txtShippingMode.Text = Dt.Rows(0)("Terms")
            txtCustomer.Text = Dt.Rows(0)("CustomerName")
            txtButyingDept.Text = Dt.Rows(0)("BuyingDept")
            txtShippingTerm.Text = Dt.Rows(0)("ItemDescription")
            '-------------------- Detail Values
            dtCommercial = Nothing
            Session("dtCommercial") = Nothing
            dtCommercial = New DataTable
            With dtCommercial
                .Columns.Add("CommercialInvoiceDetailID", GetType(Long))
                .Columns.Add("POID", GetType(Long))
                .Columns.Add("PODetailID", GetType(Long))
                .Columns.Add("Article", GetType(String))
                .Columns.Add("Size", GetType(String))
                .Columns.Add("PONO", GetType(String))
                .Columns.Add("Color", GetType(String))
                .Columns.Add("Quantity", GetType(String))
                .Columns.Add("Rate", GetType(String))
                .Columns.Add("Value", GetType(String))
                .Columns.Add("StyleID", GetType(Long))
                .Columns.Add("Style", GetType(String))
                .Columns.Add("Remarks", GetType(String))
                .Columns.Add("InsertTextQTY", GetType(String))
                .Columns.Add("UOM", GetType(String))
            End With
            For x = 0 To Dt.Rows.Count - 1
                Dr = dtCommercial.NewRow()
                Dr("CommercialInvoiceDetailID") = Dt.Rows(x)("CommercialInvoiceDetailID")
                Dr("POID") = Dt.Rows(x)("POID")
                Dr("PODetailID") = Dt.Rows(x)("PODetailID")
                Dr("Quantity") = Dt.Rows(x)("Quantity")
                Dr("Rate") = Dt.Rows(x)("Rate")
                Dr("Value") = Math.Round(CDec((Dt.Rows(x)("Quantity")) * (Dt.Rows(x)("Rate"))), 2)
                Dr("StyleID") = Dt.Rows(x)("StyleID")
                Dr("Remarks") = Dt.Rows(x)("Remarks")

                '-------------
                If String.IsNullOrEmpty(Dt.Rows(x)("Article").ToString()) = False Then
                    Dr("Article") = Dt.Rows(x)("Article")
                Else
                    Dr("Article") = ""
                End If
                If String.IsNullOrEmpty(Dt.Rows(x)("PONO").ToString()) = False Then
                    Dr("PONO") = Dt.Rows(x)("PONO")
                Else
                    Dr("PONO") = ""
                End If
                If String.IsNullOrEmpty(Dt.Rows(x)("Size").ToString()) = False Then
                    Dr("Size") = Dt.Rows(x)("Size")
                Else
                    Dr("Size") = ""
                End If
                If String.IsNullOrEmpty(Dt.Rows(x)("Color").ToString()) = False Then
                    Dr("Color") = Dt.Rows(x)("Color")
                Else
                    Dr("Color") = ""
                End If
                If String.IsNullOrEmpty(Dt.Rows(x)("Rate").ToString()) = False Then
                    Dr("Rate") = Dt.Rows(x)("Rate")
                Else
                    Dr("Rate") = ""
                End If
                If String.IsNullOrEmpty(Dt.Rows(x)("Style").ToString()) = False Then
                    Dr("Style") = Dt.Rows(x)("Style")
                Else
                    Dr("Style") = ""
                End If

                dtCommercial.Rows.Add(Dr)
            Next
            Session("dtCommercial") = dtCommercial
            BindGrid()
            For x = 0 To Dt.Rows.Count - 1
                txtQty = CType(dgPurchaseOrder.Items(x).FindControl("txtQuantity"), RadNumericTextBox)
                txtAmt = CType(dgPurchaseOrder.Items(x).FindControl("txtAmount"), RadTextBox)
                txtrate = CType(dgPurchaseOrder.Items(x).FindControl("txtRate"), RadTextBox)
                txtUOM = CType(dgPurchaseOrder.Items(x).FindControl("txtUOM"), RadTextBox)
                txtQty.Text = Dt.Rows(x)("InsertTextQTY")
                txtrate.Text = Dt.Rows(x)("Rate")
                txtUOM.Text = Dt.Rows(x)("UOM")
                txtAmt.Text = Math.Round(CDec((Dt.Rows(x)("InsertTextQTY")) * (Dt.Rows(x)("Rate"))), 2)
                TotalQty = Math.Round(TotalQty + CDec(Val(Dt.Rows(x)("InsertTextQTY"))), 2)
                TotalAmt = Math.Round(TotalAmt + CDec(Val(txtAmt.Text)), 2)
                txtTotalAmount.Text = TotalAmt
                txttotalQTY.Text = TotalQty
            Next
            Calculate()
        Catch ex As Exception
        End Try
    End Sub
    Sub SetValuesEditMod()
        Dim TotalAmt As Double = 0
        Dim TotalQty As Double = 0
        Dim x As Integer
        Dim txtQty As RadNumericTextBox
        Dim txtAmt As RadTextBox
        Dim txtrate As RadTextBox
        Try
            Dt = objCommercial.GetPurchaseOrderByPOUsingStyleMaster(lPOID, lPODetailID)
            Dim Currency As String = Dt.Rows(0)("Currency")
            If Currency = "Dollar" Then
                lblCurrency.Text = "$"
            Else
                lblCurrency.Text = "€"
            End If
            txtCurrency.Text = Dt.Rows(0)("Currency")
            txtCurrency.Text = Dt.Rows(0)("Currency")
            txtShippingMode.Text = Dt.Rows(0)("ShipmentModeName")
            txtCustomer.Text = Dt.Rows(0)("CustomerName")
            txtButyingDept.Text = Dt.Rows(0)("BuyingDept")
            txtShippingTerm.Text = Dt.Rows(0)("PaymentModeName")

            '-------------------- Detail Values
            dtCommercial = Nothing
            Session("dtCommercial") = Nothing
            dtCommercial = New DataTable
            With dtCommercial
                .Columns.Add("CommercialInvoiceDetailID", GetType(Long))
                .Columns.Add("POID", GetType(Long))
                .Columns.Add("PODetailID", GetType(Long))
                .Columns.Add("Article", GetType(String))
                .Columns.Add("Size", GetType(String))
                .Columns.Add("PONO", GetType(String))
                .Columns.Add("Color", GetType(String))
                .Columns.Add("Quantity", GetType(String))
                .Columns.Add("Rate", GetType(String))
                .Columns.Add("Value", GetType(String))
                .Columns.Add("Style", GetType(String))
                .Columns.Add("UOM", GetType(String))
            End With
            For x = 0 To Dt.Rows.Count - 1
                Dr = dtCommercial.NewRow()
                Dr("CommercialInvoiceDetailID") = Dt.Rows(x)("CommercialInvoiceDetailID")
                Dr("POID") = Dt.Rows(x)("POID")
                Dr("PODetailID") = Dt.Rows(x)("PODetailID")
                Dr("Quantity") = Dt.Rows(x)("Quantity")
                Dr("Rate") = Dt.Rows(x)("Rate")
                Dr("Value") = Math.Round(CDec((Dt.Rows(x)("Quantity")) * (Dt.Rows(x)("Rate"))), 2)
                '-------------
                If String.IsNullOrEmpty(Dt.Rows(x)("Article").ToString()) = False Then
                    Dr("Article") = Dt.Rows(x)("Article")
                Else
                    Dr("Article") = ""
                End If
                If String.IsNullOrEmpty(Dt.Rows(x)("PONO").ToString()) = False Then
                    Dr("PONO") = Dt.Rows(x)("PONO")
                Else
                    Dr("PONO") = ""
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
                dtCommercial.Rows.Add(Dr)
            Next
            Session("dtCommercial") = dtCommercial
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
                txttotalQTY.Text = TotalQty
            Next
            Calculate()
        Catch ex As Exception
        End Try
    End Sub
    Private Function BindGrid() As Boolean
        If (Not dtCommercial Is Nothing) Then
            If (dtCommercial.Rows.Count > 0) Then
                dgPurchaseOrder.DataSource = dtCommercial
                dgPurchaseOrder.DataBind()
                dgPurchaseOrder.Visible = True
                Return (True)
            End If
        End If
        Return (False)
    End Function
    Protected Sub btnCalculate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCalculate.Click
        Calculate()
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
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            Calculate()
            '----Check Invoice No Duplicate
            Dim DtInvoice As New DataTable
            DtInvoice = objCommercial.InvoiceExist(txtInvoiceNo.Text)
            If lCommercialInvoiceID > 0 Then
                SetValues()
                '---------Detail
                SetDetailValues()
                SendMail()
                Session("dtCommercial") = Nothing
                Response.Redirect("CommercialInvoiceView.aspx")
            Else
                If DtInvoice.Rows.Count > 0 Then
                    lblInvoiceMSG.Text = "Invoice Already Exist."
                    lblInvoiceMSG.Visible = True
                Else
                    '------------ Master
                    If txtInvoiceNo.Text = "" Then
                        lblInvoiceMSG.Visible = True
                        lblInvoiceMSG.Text = "Invoice No Required."
                    ElseIf txtInvoiceDate.SelectedDate.ToString() = Nothing Then
                        lblInvoiceMSG.Visible = True
                        lblInvoiceMSG.Text = "Invoice Date Required."
                    ElseIf txtBLAWBNo.Text = "" Then
                        lblInvoiceMSG.Visible = True
                        lblInvoiceMSG.Text = "BL/AWB No. Required."
                    ElseIf txtCargoDate.SelectedDate.ToString() = Nothing Then
                        lblInvoiceMSG.Visible = True
                        lblInvoiceMSG.Text = "Shipment Date Required."
                    ElseIf txtETA.SelectedDate.ToString() = Nothing Then
                        lblInvoiceMSG.Visible = True
                        lblInvoiceMSG.Text = "ETA Required."
                    ElseIf txtETD.SelectedDate.ToString() = Nothing Then
                        lblInvoiceMSG.Visible = True
                        lblInvoiceMSG.Text = "ETD Required."
                    Else
                        SetValues()
                        '---------Detail
                        SetDetailValues()
                        SendMail()
                        Session("dtCommercial") = Nothing
                        Response.Redirect("CommercialInvoiceView.aspx")
                    End If

                End If
            End If

        Catch ex As Exception
        End Try
    End Sub
    Sub SendMail()
        Try
            Dim objUser As New User
            Dim dtEmail As DataTable
            Dim Report As New ReportDocument
            Dim Options As New ExportOptions
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Report.Load(Server.MapPath("..\Reports/CommercialInvoice.rpt"))

            Dim FileName As String = "Commercial Invoice " + txtETD.SelectedDate.Value.ToString("dd-MM-yyyy")
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
            If lCommercialInvoiceID > 0 Then
                Report.SetParameterValue(0, lCommercialInvoiceID)
            Else
                Report.SetParameterValue(0, objCommercial.GetId)
            End If
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
            dtEmail = objUser.GetEmailAddress(24)
            mail.To.Add(dtEmail.Rows(0)("EmailAddress"))
            Dim dtCC As DataTable
            Dim x As Integer
            dtCC = objUser.GetEmailAddressCommericalInvoice()
            For x = 0 To dtCC.Rows.Count - 1
                mail.CC.Add(dtCC.Rows(x)("EmailAddress"))
                ' mail.CC.Add("ceo@itg.net.pk")
            Next
            mail.Bcc.Add("zahidsajjad@hotmail.com")
            mail.From = New MailAddress("noreply@eurocentrab2b.com")
            mail.Attachments.Add(New Attachment(Server.MapPath("~/TempPDF/" & FileName & ".pdf")))
            mail.Subject = "Commerical invoice for logistic dept."
            Dim Body As String = " " & _
                         "<br/>" & _
                         "Greetings:" & _
                           "<br/>" & _
                           "<br/>" & _
                         "Attach please find Commercial invoice" & _
                        "<br/>"
            Body = Body + " " & _
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
    Sub SetValues()
        With objCommercial
            If lCommercialInvoiceID > 0 Then
                .CommercialInvoiceID = lCommercialInvoiceID
            Else
                .CommercialInvoiceID = 0
            End If
            .CreationDate = Date.Now
            .InvoiceNo = txtInvoiceNo.Text
            .InvoiceDate = txtInvoiceDate.SelectedDate 'GeneralCode.GetDate(txtInvoiceDate.SelectedDate)
            .InvoiceValue = txtTotalAmount.Text
            .Terms = txtShippingMode.Text
            .ItemDescription = txtShippingTerm.Text
            .Mode = txtMAWB.Text
            .CarrierName = txtCarrierName.Text
            .VoyageFlight = txtVoyageFlight.Text
            .BillNo = txtBLAWBNo.Text
            .ShipmentDate = txtCargoDate.SelectedDate 'GeneralCode.GetDate(txtCargoDate.Text)
            .ContainerNo = txtContainerNo.Text
            .Remarks = txtPODPOA.Text
            .IsActive = False
            .ETD = txtETD.SelectedDate 'GeneralCode.GetDate(txtETD.Text)
            .ETA = txtETA.SelectedDate 'GeneralCode.GetDate(txtETA.Text)
            Dim Currency As String = lblCurrency.Text
            If Currency = "$" Then
                .Currency = "Dollar"
            Else
                .Currency = "Euro"
            End If
            txtCurrency.Text = Currency
            .Forwarder = txtForwarder.Text
            .Consolidation = txtConsolidation.Text
            .ContainerSize = txtContainerSize.Text
            .Comments = txtComments.Text
            .SaveCommercialInvoice()
        End With
    End Sub
    Sub SetDetailValues()
        Dim CargoID As Long = objCommercial.GetId
        Dim dt As New DataTable
        dt = Session("dtCommercial")
        Dim txtQty As RadNumericTextBox
        Dim txtUOM As RadTextBox
        Dim txtAmt As RadTextBox
        Dim txtrate As RadTextBox
        Dim TotalAmt As Double = 0
        Dim TotalQty As Double = 0
        Dim x As Integer

        For x = 0 To dgPurchaseOrder.Items.Count - 1
            Dim item As GridDataItem = DirectCast(dgPurchaseOrder.MasterTableView.Items(x), GridDataItem)
            txtQty = CType(dgPurchaseOrder.Items(x).FindControl("TxtQuantity"), RadNumericTextBox)
            txtAmt = CType(dgPurchaseOrder.Items(x).FindControl("TxtAmount"), RadTextBox)
            txtrate = CType(dgPurchaseOrder.Items(x).FindControl("TxtRate"), RadTextBox)
            txtUOM = CType(dgPurchaseOrder.Items(x).FindControl("txtUOM"), RadTextBox)
            With objCommercialDetail
                If lCommercialInvoiceID > 0 Then
                    .CommercialInvoiceID = lCommercialInvoiceID
                Else
                    .CommercialInvoiceID = objCommercial.GetId
                End If
                .CommercialInvoiceDetailID = item("CommercialInvoiceDetailID").Text
                .POID = item("POID").Text
                .Quantity = txtQty.Text
                .PODetailID = item("PODetailID").Text
                .UOM = txtUOM.Text
                .Rate = txtrate.Text
                .SaveCommercialInvoiceDetail()
            End With
        Next
    End Sub
    Protected Sub txtETD_SelectedDateChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles txtETD.SelectedDateChanged
        If txtShippingMode.Text = "Sea" Then
            txtETA.SelectedDate = txtETD.SelectedDate.Value.AddDays(28)
            txtETA.Enabled = False
        ElseIf txtShippingMode.Text = "Air" Then
            txtETA.SelectedDate = txtETD.SelectedDate.Value.AddDays(7)
            txtETA.Enabled = False
        End If
    End Sub
    Protected Sub btnShowData_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnShowData.Click
        Try
            FillGridByStyle()
            BindGrid()
            SetValuesintoGrid()
            Session("dtSelection") = Nothing
            Calculate()
            updgPurchaseOrder.Update()
            upbtnCalculate.Update()
        Catch ex As Exception
        End Try
    End Sub
    Sub FillGridByStyle()
        Dim bShouldAdd As Boolean = True
        Dim isEmployeeExist As Boolean = False
        If (Not CType(Session("dtCommercial"), DataTable) Is Nothing) Then
            dtCommercial = Session("dtCommercial")
        Else
            dtCommercial = New DataTable
            With dtCommercial
                .Columns.Add("CommercialInvoiceDetailID", GetType(Long))
                .Columns.Add("POID", GetType(Long))
                .Columns.Add("PODetailID", GetType(Long))
                .Columns.Add("Article", GetType(String))
                .Columns.Add("Size", GetType(String))
                .Columns.Add("PONO", GetType(String))
                .Columns.Add("Color", GetType(String))
                .Columns.Add("Quantity", GetType(String))
                .Columns.Add("Rate", GetType(String))
                .Columns.Add("Value", GetType(String))
                .Columns.Add("Style", GetType(String))
                .Columns.Add("UOM", GetType(String))
            End With
        End If
        Dim x As Integer
        dtSelectionPOPUP = Session("dtSelection")
        If Not dtSelectionPOPUP Is Nothing Then
            For x = 0 To dtSelectionPOPUP.Rows.Count - 1
                Dr = dtCommercial.NewRow()
                Dr("CommercialInvoiceDetailID") = dtSelectionPOPUP.Rows(x)("CommercialInvoiceDetailID")
                Dr("POID") = dtSelectionPOPUP.Rows(x)("POID")
                Dr("PODetailID") = dtSelectionPOPUP.Rows(x)("PODetailID")
                Dr("Style") = dtSelectionPOPUP.Rows(x)("StyleNo")
                Dr("PONO") = dtSelectionPOPUP.Rows(x)("PONO")
                Dr("Article") = dtSelectionPOPUP.Rows(x)("Article")
                Dr("Size") = dtSelectionPOPUP.Rows(x)("Size")
                Dr("Color") = dtSelectionPOPUP.Rows(x)("Color")
                Dr("Quantity") = dtSelectionPOPUP.Rows(x)("Quantity")
                Dr("Rate") = dtSelectionPOPUP.Rows(x)("Rate")
                Dr("Value") = dtSelectionPOPUP.Rows(x)("Value")
                Dr("UOM") = ""
                dtCommercial.Rows.Add(Dr)
            Next
            Session("dtCommercial") = dtCommercial
        End If
        Session.Remove("dtSelection")
    End Sub
    Sub SetValuesintoGrid()
        Dim x As Integer
        Dim txtQty As RadNumericTextBox
        Dim txtrate As RadTextBox
        Dim txtAmt As RadTextBox
        Dim txtUOM As RadTextBox
        If (Not CType(Session("dtCommercial"), DataTable) Is Nothing) Then
            dtCommercial = Session("dtCommercial")
            For x = 0 To dtCommercial.Rows.Count - 1
                Dim item As GridDataItem = DirectCast(dgPurchaseOrder.MasterTableView.Items(x), GridDataItem)
                txtQty = CType(dgPurchaseOrder.Items(x).FindControl("txtQuantity"), RadNumericTextBox)
                txtAmt = CType(dgPurchaseOrder.Items(x).FindControl("TxtAmount"), RadTextBox)
                txtrate = CType(dgPurchaseOrder.Items(x).FindControl("txtRate"), RadTextBox)
                txtUOM = CType(dgPurchaseOrder.Items(x).FindControl("txtUOM"), RadTextBox)

                txtQty.Text = dtCommercial.Rows(x)("Quantity")
                txtrate.Text = dtCommercial.Rows(x)("Rate")
                txtAmt.Text = dtCommercial.Rows(x)("Value")
            Next

        End If
    End Sub
    Protected Sub btnAddMore_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddMore.Click
        Try
            ' Response.Write("<script> window.open('CommercialInvoicesPopup.aspx?Currency=" & txtCurrency.Text & "&Customername=" & txtCustomer.Text & "&Eknumber=" & txtButyingDept.Text & "&ShipmentMode=" & txtShippingMode.Text & "&ShipmentTerm=" & txtShippingTerm.Text & "', 'newwindow', 'left=12, top=30, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")
            ScriptManager.RegisterClientScriptBlock(Me.upAddMore, Me.upAddMore.GetType(), "New ClientScript", "window.open('CommercialInvoicesPopup.aspx?Currency=" & txtCurrency.Text & "&Customername=" & txtCustomer.Text & "&Eknumber=" & txtButyingDept.Text & "&ShipmentMode=" & txtShippingMode.Text & "&ShipmentTerm=" & txtShippingTerm.Text & "', 'newwindow', 'left=12, top=30, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no');", True)
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Response.Redirect("MasterOrderForSupplier.aspx")
    End Sub
 
End Class
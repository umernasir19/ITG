Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports System.Net
Imports System.Net.Mail

Public Class PORevisedShipment
    Inherits System.Web.UI.Page
    Dim objPurchaseMaster As New PurchaseOrder
    Dim lPOID As Long
    Dim dtPurchaseOrder As New DataTable
    Dim Dr As DataRow
    Dim Dt As New DataTable
    Dim objCurrency As New Currency
    Dim objPurchaseReviseShip As New PurchaseOrderReviseShipment
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("IPOID") = Nothing
        lPOID = Request.QueryString("lPOID")
        If Not Page.IsPostBack Then
            SetValuesEditMod()
            SHowRevesedShipDates()
        End If
    End Sub
    Sub SetValuesEditMod()
        Dim TotalAmt As Double = 0
        Dim TotalQty As Double = 0
        Dim x As Integer
        Try
            Dt = objPurchaseMaster.GetPurchaseOrderByPOUsingStyleMasterView(lPOID)
            lblPONO.Text = Dt.Rows(0)("PONO")
            lblMerchant.Text = Dt.Rows(0)("Username")
            lblMerchantDesignation.Text = Dt.Rows(0)("Designation")
            lblECPDivision.Text = Dt.Rows(0)("ECPDivistion")

            lblOrderType.Text = Dt.Rows(0)("POTYPE") + "(" + Dt.Rows(0)("PORefNo") + ")"
            lblPlacementDate.Text = Dt.Rows(0)("PlacementDatee")
            lblDeliveryDate.Text = Dt.Rows(0)("ShipmentDatee")
            lblShipmentDate.Text = Dt.Rows(0)("ShipmentDatee")
            '  txtTolerance.Text = Dt.Rows(0)("Toleranceindays")
            lblTolerance.Text = "+/-" + Dt.Rows(0)("Toleranceindays") + "%"
            lblLeadTimeMargin.Text = Dt.Rows(0)("TimeSpame").ToString() + "Days"
            lblProductPortfolio.Text = Dt.Rows(0)("ProductGroup")
            lblProductCategories.Text = Dt.Rows(0)("ProductCategories")
            lblSeason.Text = Dt.Rows(0)("Season")
            lblDeliveryMode.Text = Dt.Rows(0)("ShipmentModeName")
            lblShippingTerms.Text = Dt.Rows(0)("PaymentModeName")
            lblPreferredPaymentTerms.Text = Dt.Rows(0)("PaymentTypeName")
            lblDeliveryMode.Text = Dt.Rows(0)("DeliveryTypeName")
            lblTransactionshouldbein.Text = Dt.Rows(0)("Currency")
            lblDestination.Text = Dt.Rows(0)("Destination")
            'lblBriefOrderDescription.Text = "Pending"
           
            lblEknumber.Text = Dt.Rows(0)("Eknumber") + "(Buying Department No.)"
            lblCustomer.Text = Dt.Rows(0)("CustomerName")
            ' lblSupplier.Text = Dt.Rows(0)("VenderName")
            ' lblSupplierDesignation.Text = Dt.Rows(0)("VenderName")
            If String.IsNullOrEmpty(Dt.Rows(0)("ShortName").ToString()) = False Then
                lblShortname.Text = Dt.Rows(0)("ShortName")
            Else
                lblShortname.Text = ""
            End If
            'Show LKZ Number.
            Dim objSupplierLKZ As New SupplierLKZNo
            Dim dtCheck As New DataTable
            dtCheck = objSupplierLKZ.CheckExistingOfLKZNumber(Dt.Rows(0)("SupplierID"), Dt.Rows(0)("CustomerID"))
            If dtCheck.Rows.Count > 0 Then
                lblLKZNo.Text = dtCheck.Rows(0)("LKZNumber") + "(LKZ No)"
                lblLKZNo.ToolTip = "This is LKZ number" + "[" + dtCheck.Rows(0)("LKZNumber") + "] of " + lblSupplier.Text + " To " + lblCustomer.Text
            Else
                lblLKZNo.Text = ""
                lblLKZNo.ToolTip = ""
                lblLKZNo.Visible = True
            End If
            Dim dtSupplierContactPerson As New DataTable
            dtSupplierContactPerson = objSupplierLKZ.CheckContactPerson(Dt.Rows(0)("SupplierID"))
            If dtSupplierContactPerson.Rows.Count > 0 Then
                lblSupplier.Text = "Mr. " + dtSupplierContactPerson.Rows(0)("PersonName")
                lblSupplierDesignation.Text = dtSupplierContactPerson.Rows(0)("Designation")
            Else
                lblSupplier.Text = ""
                lblSupplierDesignation.Text = ""
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
            Dim TAmount As Decimal = 0
            For x = 0 To dtPurchaseOrder.Rows.Count - 1
                TotalQty = Math.Round(TotalQty + CDec(Val(dtPurchaseOrder.Rows(x)("Quantity"))), 0)
                TAmount = Math.Round(TAmount + CDec(Val(dtPurchaseOrder.Rows(x)("Amount"))), 2)
                lblTotalAmount.Text = TAmount
                lblTotalQty.Text = TotalQty
            Next
            If Dt.Rows(0)("Currency") = "Dollar" Then
                lblTotalAmount.Text = "$ " + lblTotalAmount.Text
            ElseIf Dt.Rows(0)("Currency") = "Euro" Then
                lblTotalAmount.Text = "€ " + lblTotalAmount.Text
            Else
                lblTotalAmount.Text = lblTotalAmount.Text + " " + Dt.Rows(0)("Currency")
            End If
        Catch ex As Exception
        End Try
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
    Protected Sub btnUpdateRevisedShipmentDate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdateRevisedShipmentDate.Click
        Try
            SavePOReviseShipment()
        Catch ex As Exception

        End Try
    End Sub
    Sub SavePOReviseShipment()
        Try
            Dim Dtt As New DataTable
            Dim RevisedShipment As String = txtRevisedShipment.SelectedDate.Value.Year.ToString() + "-" + txtRevisedShipment.SelectedDate.Value.Month.ToString() + "-" + txtRevisedShipment.SelectedDate.Value.Day.ToString()
            Dtt = objPurchaseReviseShip.GetPOForEcistingShipmetDatee(lPOID, RevisedShipment)
            If Dtt.Rows.Count > 0 Then
                lblMMsg.Text = "   Not Save."
            Else
                With objPurchaseReviseShip
                    .POReviseShipmentID = 0
                    .POID = lPOID
                    .CreationDate = Date.Now()
                    .ShipmentDate = txtRevisedShipment.SelectedDate
                    .SavePurchaseOrderReviseShipment()
                End With
                lblMMsg.Text = "   Saved."
                SetValuesEditMod()
                SHowRevesedShipDates()
                SendEmail()
                SavePOTracking()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub ShowRevesedShipDates()
        Try
            Dim dtRevesedShipDates As New DataTable
            Dim x As Integer
            Dim Counter As Integer = 1
            Dim Message As String = ""
            dtRevesedShipDates = objPurchaseReviseShip.CheckExisting(lPOID)
            If dtRevesedShipDates.Rows.Count = 1 Then
                lblRevsedShipmentDate.Visible = True
                For x = 0 To dtRevesedShipDates.Rows.Count - 1
                    txtRevisedShipment.SelectedDate = dtRevesedShipDates.Rows(x)("ShipmentDate")
                Next
            ElseIf dtRevesedShipDates.Rows.Count > 1 Then
                lblRevsedShipmentDate.Visible = True
                lblRevsedShipmentDate.Text = "Shipment Date Revised."
                For x = 0 To dtRevesedShipDates.Rows.Count - 1
                    Message = Message + "Shipment Date :" + Counter.ToString() + " = " + dtRevesedShipDates.Rows(x)("ShipmentDate") + vbCrLf
                    Counter = Counter + 1
                Next
                lblRevsedShipmentDate.ToolTip = Message
                txtRevisedShipment.SelectedDate = dtRevesedShipDates.Rows(dtRevesedShipDates.Rows.Count - 1)("ShipmentDate")
            Else
                lblRevsedShipmentDate.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub SendEmail()
        Try
            'Email
            Dim objUser As New User
            Dim dtEmail As DataTable
            dtEmail = objUser.GetEmailAddress(77)
            Dim mail As MailMessage = New MailMessage()
            mail.To.Add(dtEmail.Rows(0)("EmailAddress"))
            Dim dtCC As DataTable
            Dim x As Integer
            dtCC = objUser.EmailAddressCCForRevisedShipmentt()
            For x = 0 To dtCC.Rows.Count - 1
                mail.CC.Add(dtCC.Rows(x)("EmailAddress"))
            Next
            Dim dtPOInfo As DataTable
            dtPOInfo = objUser.EmailAddressCCForRevisedShipmentMerchant(lPOID)
            mail.CC.Add(dtPOInfo.Rows(0)("EmailAddress"))
            mail.Bcc.Add("zahidsajjad@hotmail.com")
            mail.From = New MailAddress("noreply@eurocentrab2b.com")
            mail.Subject = "Shipment Date Revised Notification: PO No. " & dtPOInfo.Rows(0)("PONO") & ", " & dtPOInfo.Rows(0)("Customername") & ""
            Dim dtRevisdDate As DataTable = objPurchaseReviseShip.CheckRevisedShipDate(lPOID)
            Dim Body As String = " " & _
                         "<br/>" & _
                         "Greetings:" & _
                           "<br/>" & _
                           "<br/>" & _
                         "Merchandiser has revised shipment of following order:"
            Body = Body + " " & _
                         "<br/>" & _
                         "PO. No:" & dtPOInfo.Rows(0)("PONO") & "" & _
                         "<br/>" & _
                          "Customer: " & dtPOInfo.Rows(0)("Customername") & "" & _
                         "<br/>" & _
                          "Supplier: " & dtPOInfo.Rows(0)("Vendername") & "" & _
                         "<br/>" & _
                         "Original shipment date: " & dtPOInfo.Rows(0)("ShipmentDatee") & "" & _
                         "<br/>" & _
                          "Lead time margin: " & dtPOInfo.Rows(0)("timespame") & "Days" & _
                         "<br/>" & _
                          "<br/>" & _
                          "<b> Revised: " & dtRevisdDate.Rows(0)("ShipmentDate") & "</b>" & _
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

            '"<b> Revised: " & txtRevisedShipment.SelectedDate.Value.ToString("dd-MM-yyyy") & "</b>" & _

        Catch ex As Exception

        End Try
    End Sub
    Sub SavePOTracking()
        Try
            Dim objPOtracking As New POTracking
            With objPOtracking
                .PoTrackingID = 0
                .CreationDate = Date.Now
                .POID = lPOID
                .TrackingObject = "Revised Shipment Date"
                .SavePOTracking()
            End With
        Catch ex As Exception
        End Try
    End Sub

End Class
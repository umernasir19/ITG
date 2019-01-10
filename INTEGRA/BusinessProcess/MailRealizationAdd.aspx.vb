Imports Integra.EuroCentra
Imports System.Data
Imports Telerik.Web.UI.Upload
Imports System.Xml
Imports Telerik.Web.UI
Imports System.Data.DataTable
Imports System.IO
Imports Telerik.Web.UI.Barcode
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Net
Imports System.Net.Mail
Public Class MailRealizationAdd
    Inherits System.Web.UI.Page
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim lCargoID As Long
    Dim objShip As New ShipmentMode
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lCargoID = Request.QueryString("CargoID")
        If Not Page.IsPostBack Then
            Dim dt As DataTable = objShip.Getdata(lCargoID)
            If dt.Rows.Count > 0 Then
                txtBuyer.Text = dt.Rows(0)("BuyerName")
                txtInvoice.Text = dt.Rows(0)("InvoiceNo")
                txtInvAmt.Text = dt.Rows(0)("InvoiceAmount")
                If dt.Rows(0)("ExchangeRate") = 0 Then

                    txtPkr.Text = dt.Rows(0)("InvoiceAmount")
                    txtExchange.Text = dt.Rows(0)("ExchangeRate")
                Else
                    txtExchange.Text = dt.Rows(0)("ExchangeRate")
                    txtPkr.Text = Math.Round(dt.Rows(0)("InvoiceAmount") * Convert.ToDecimal(dt.Rows(0)("ExchangeRate")), 0)
                End If

                txtLc.Text = dt.Rows(0)("LCNO")
                txtBank.Text = dt.Rows(0)("BankCode")
                txtRemarkss.Text = dt.Rows(0)("Remarks")
                lblbuy.Text = dt.Rows(0)("BuyerName")
                lbli.Text = dt.Rows(0)("InvoiceNo")
                lblInvAmt.Text = dt.Rows(0)("InvoiceAmount")
                lblEx.Text = dt.Rows(0)("ExchangeRate")
                lblPkr.Text = dt.Rows(0)("InvoiceAmount")
                lblLc.Text = dt.Rows(0)("LCNO")
                lblBank.Text = dt.Rows(0)("BankCode")
                lblRemarks.Text = dt.Rows(0)("Remarks")
            End If
        End If
    End Sub
    Protected Sub btnSendEmail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSendEmail.Click
        Try
            If txtToEmail.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Enter TO.")
            Else
                AutoMailSending()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub AutoMailSending()
        Try
           
            Dim sb As New StringBuilder()
            Dim sw As New StringWriter(sb)
            Dim hw As New HtmlTextWriter(sw)
            ' dgemail.RenderControl(hw)
            Dim mail As MailMessage = New MailMessage()
            mail.To.Add(txtToEmail.Text)
            'mail.CC.Add("abbas.badami@tfapparels.com")
            'mail.CC.Add("tariq.janoo@tfapparels.com")
            'mail.Bcc.Add("nizam149@gmail.com")
            'mail.Bcc.Add("salahuddin@itg.net.pk")

            'mail.To.Add("nizam@itg.net.pk")
            ' mail.CC.Add("nizam149@gmail.com")
            'mail.CC.Add("salman@itg.net.pk")
            'mail.Bcc.Add("naveed2146@gmail.com")


            'mail.Bcc.Add("yasiransari2288@gmail.com")
            mail.From = New MailAddress("ERP.noreply@gmail.com")
            mail.Subject = "MAIL REALIZATION"
            Dim Body As String = " " & _
                         "<br/>"
            Body = Body + sb.ToString()
            Body = Body + " </table> <br/>" & _
                         "<br/>" & _
                          "<b> <font size=6> <font color=green> MAIL REALIZATION</font></font> </b><br/>" & _
                          "<b> <font size=5> BUYER :        <font color=darkBlue>" & lblbuy.Text & " </font></font></b><br/>" & _
                          "<b> <font size=5> INVOICE NO. :  <font color=darkBlue>" & lbli.Text & " </font></font></b><br/>" & _
                          "<b> <font size=5> INVOICE AMOUNT:<font color=darkBlue>" & lblInvAmt.Text & "</font></font></b><br/>" & _
                          "<b> <font size=5> EXCHANGE RATE :<font color=darkBlue>" & lblEx.Text & " </font></font></b><br/>" & _
                          "<b> <font size=5> PKR :          <font color=darkBlue>" & lblPkr.Text & " </font></font></b><br/>" & _
                          "<b> <font size=5> LC NO.:        <font color=darkBlue>" & lblLc.Text & "</font></font></b><br/>" & _
                          "<b> <font size=5> BANK :         <font color=darkBlue>" & lblBank.Text & " </font></font></b><br/>" & _
                          "<b> <font size=5> REMARKS :      <font color=darkBlue>" & lblRemarks.Text & " </font></font></b><br/>" & _
            " " & _
                          "<br/>" & _
                         "<b>   </b>" & _
                           "<br/>" & _
                            "<br/>" & _
                           "<font color=""red"">  " & _
                            "<br/>" & _
                            " </font>" & _
                              "<br/>" & _
                                "<br/>" & _
                         "Thanks" & _
                           "<br/>" & _
                        "DAL ERP" & _
                         "<br/>" & _
                          "<br/>" & _
                          "Powered By:" & _
                           "<br/>" & _
                           "Integra ERP System (www.itg.net.pk)" & _
                             "<br/>" & _
                        "************* This is System generated email and does not required reply *******************"
            mail.Body = Body
            mail.IsBodyHtml = True
            Dim smtp As SmtpClient = New SmtpClient()
            smtp.Port = 587
            smtp.Host = "smtp.gmail.com"
            'smtp.Credentials = New System.Net.NetworkCredential("no-reply@naeementerprise.com", "Erp@1995")
            smtp.Credentials = New System.Net.NetworkCredential("erpnoreplyy@gmail.com", "naeem1234")           'smtp.Host = "webmail.naztextilemills.com"
            'smtp.Credentials = New System.Net.NetworkCredential("Naz-online-system@naztextilemills.com", "N@z123")
            ' smtp.UseDefaultCredentials = False
            smtp.EnableSsl = True
            smtp.Send(mail)

        Catch ex As Exception
        End Try
    End Sub
End Class
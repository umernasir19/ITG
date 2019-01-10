Imports System.Data
Imports Integra.EuroCentra
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class DebitNoteModule
    Inherits System.Web.UI.Page
    Dim objCargo As New Cargo
    Dim objDebitNote As New DebitNote
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            PageHeader("Debit Note Module")
            BindMonth()
            BindYear()
            BindCustomer()
            Panel1.Visible = True
            Panel2.Visible = False
        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub BindMonth()
        Dim dtMonth As DataTable
        dtMonth = objCargo.GetCargoMonthNames
        cmbMonth.DataSource = dtMonth
        cmbMonth.DataTextField = "MonthName"
        cmbMonth.DataValueField = "MonthNo"
        cmbMonth.DataBind()
    End Sub
    Sub BindYear()
        Dim dtYear As DataTable
        dtYear = objCargo.GetCargoYearNames
        cmbYear.DataSource = dtYear
        cmbYear.DataTextField = "YearName"
        cmbYear.DataValueField = "YearNo"
        cmbYear.DataBind()
    End Sub
    Sub BindCustomer()
        Dim dtCustomer As DataTable
        dtCustomer = objCargo.GetCargoCustomers
        cmbCustomer.DataSource = dtCustomer
        cmbCustomer.DataTextField = "CustomerName"
        cmbCustomer.DataValueField = "CustomerID"
        cmbCustomer.DataBind()
    End Sub
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            'Check Existing
            Dim dtCheck As DataTable
            dtCheck = objDebitNote.CheckExistingDebitNot(cmbCustomer.SelectedValue, cmbMonth.SelectedValue, cmbYear.SelectedValue, cmbCurrency.SelectedItem.Text)
            If dtCheck.Rows.Count > 0 Then
                lblMsg.Text = "Already Debit Note Created"
                Panel1.Visible = True
                Panel2.Visible = False
            Else
                Panel1.Visible = False
                Panel2.Visible = True
                'lblCustomerName.Text = cmbCustomer.SelectedItem.Text
                txtCustomerNamePart.Text = cmbCustomer.SelectedItem.Text
                If cmbCurrency.SelectedItem.Text = "Dollar" Then
                    lblCurrencyName.Text = "USD"
                Else
                    lblCurrencyName.Text = "EUR"
                End If
                txtDNDate.SelectedDate = Date.Now.Date
                'For customerNo
                Dim dtCustomerNo As DataTable
                dtCustomerNo = objDebitNote.GetCustomerNo(cmbCustomer.SelectedValue)
                If dtCustomerNo.Rows.Count > 0 Then
                    If String.IsNullOrEmpty(dtCustomerNo.Rows(0)("CustomerNo").ToString()) = False Then
                        txtCustomerNo.Text = dtCustomerNo.Rows(0)("CustomerNo")
                        txtaddressLine1.Text = dtCustomerNo.Rows(0)("Address1")
                        txtaddressLine2.Text = dtCustomerNo.Rows(0)("Address2")
                        txtaddressLine3.Text = dtCustomerNo.Rows(0)("Country")

                    Else
                        txtCustomerNo.Text = 0
                    End If
                Else
                    txtCustomerNo.Text = 0
                End If
                'end Customer No
                Dim x As Integer
                Dim dtData As DataTable
                Dim TotalValue As Decimal = 0
                Dim TotalCommissionValue As Decimal = 0
                dtData = objDebitNote.GetAllData(cmbCustomer.SelectedValue, cmbMonth.SelectedValue, cmbYear.SelectedValue, cmbCurrency.SelectedItem.Text)
                If dtData.Rows.Count > 0 Then
                    For x = 0 To dtData.Rows.Count - 1
                        TotalValue = TotalValue + dtData.Rows(x)("Value")
                    Next
                    TotalCommissionValue = (TotalValue * dtData.Rows(0)("Commission")) / 100
                    txtTotalValue.Text = Strings.Format(CDbl(TotalCommissionValue), "##,##0.00")
                    txtTotalValueHide.Text = Strings.Format(CDbl(TotalCommissionValue), "####0.00")
                    txtDescription.Text = dtData.Rows(0)("Commission").ToString() + "% Commission on Turnover of " + cmbMonth.SelectedItem.Text + ", " + cmbYear.SelectedItem.Text + " (Pak)"

                    txtSay.Text = AmtInWord(txtTotalValueHide.Text)
                Else
                    'Msg
                    txtTotalValue.Text = 0
                    txtTotalValueHide.Text = 0
                    txtDescription.Text = "NO"
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            With objDebitNote
                .DebitNoteID = 0
                .CreationDate = Date.Now
                .DNNo = txtDNNo.Text
                .DNDate = txtDNDate.SelectedDate
                .ImportDept = txtImportDept.Text
                .AddressLine1 = txtaddressLine1.Text
                .AddressLine2 = txtaddressLine2.Text
                .AddressLine3 = txtaddressLine3.Text
                .Attn = txtAttn.Text
                .Description = txtDescription.Text
                .TotalValue = txtTotalValueHide.Text
                .Customerid = cmbCustomer.SelectedValue
                .CustomerNamePart = txtCustomerNamePart.Text
                .CommissionMonth = cmbMonth.SelectedValue
                .CommissionYear = cmbYear.SelectedItem.Text
                .Currency = cmbCurrency.SelectedItem.Text
                .Say = txtSay.Text
                .SaveDebitNote()
            End With

            'Export PDf
            Dim Report As New ReportDocument
            Dim Options As New ExportOptions

            If (Directory.Exists(Server.MapPath("~/PDFReports/" & cmbYear.SelectedItem.Text & "/" & cmbMonth.SelectedItem.Text & ""))) Then
                Report.Load(Server.MapPath("..\Reports/rptDebitNote.rpt"))
                Dim FileName As String = "DN-" + cmbCustomer.SelectedItem.Text + "-" + cmbMonth.SelectedItem.Text + "-" + cmbCurrency.SelectedItem.Text + ""
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/PDFReports/" & cmbYear.SelectedItem.Text & "/" & cmbMonth.SelectedItem.Text & "/" & FileName & ".pdf"
                Report.SetParameterValue(0, objDebitNote.GetId)
                Dim FileOption As New DiskFileDestinationOptions
                FileOption.DiskFileName = sTempFileName
                Options = Report.ExportOptions
                Options.ExportDestinationType = ExportDestinationType.DiskFile
                Options.ExportFormatType = ExportFormatType.PortableDocFormat
                Options.DestinationOptions = FileOption
                Options.ExportDestinationOptions = FileOption
                Report.SetDatabaseLogon("sa", "pwd")
                Report.Export()
            Else
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/PDFReports/" & cmbYear.SelectedItem.Text & "/" & cmbMonth.SelectedItem.Text & ""))
                di.Create()
                Report.Load(Server.MapPath("..\Reports/rptDebitNote.rpt"))
                Dim FileName As String = "DN-" + cmbCustomer.SelectedItem.Text + "-" + cmbMonth.SelectedItem.Text + "-" + cmbCurrency.SelectedItem.Text + ""
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/PDFReports/" & cmbYear.SelectedItem.Text & "/" & cmbMonth.SelectedItem.Text & "/" & FileName & ".pdf"
                Report.SetParameterValue(0, objDebitNote.GetId)
                Dim FileOption As New DiskFileDestinationOptions
                FileOption.DiskFileName = sTempFileName
                Options = Report.ExportOptions
                Options.ExportDestinationType = ExportDestinationType.DiskFile
                Options.ExportFormatType = ExportFormatType.PortableDocFormat
                Options.DestinationOptions = FileOption
                Options.ExportDestinationOptions = FileOption
                Report.SetDatabaseLogon("sa", "pwd")
                Report.Export()
            End If
            Response.Redirect("DebitNoteView.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("DebitNoteView.aspx")
    End Sub
    Function AmtInWord(ByVal Num As Decimal) As String
        'I have created this function for converting amount in indian rupees (INR). 
        'You can manipulate as you wish like decimal setting, Doller (any currency) Prefix.
        Dim strNum As String
        Dim strNumDec As String
        Dim StrWord As String
        Dim CurrenctString As String = ""
        strNum = Num
        If lblCurrencyName.Text = "USD" Then
            CurrenctString = "U.S.Dollars "
        Else
            CurrenctString = "Euro "
        End If
        If InStr(1, strNum, ".") <> 0 Then
            strNumDec = Mid(strNum, InStr(1, strNum, ".") + 1)

            If Len(strNumDec) = 1 Then
                strNumDec = strNumDec + "0"
            End If
            If Len(strNumDec) > 2 Then
                strNumDec = Mid(strNumDec, 1, 2)
            End If
            strNum = Mid(strNum, 1, InStr(1, strNum, ".") - 1)
            StrWord = IIf(CDbl(strNum) = 1, " Say " + CurrenctString, " Say " + CurrenctString) + NumToWord(CDbl(strNum)) + IIf(CDbl(strNumDec) > 0, " and Cent" + cWord3(CDbl(strNumDec)), "")
        Else
            StrWord = IIf(CDbl(strNum) = 1, " Say " + CurrenctString, " Say " + CurrenctString) + NumToWord(CDbl(strNum))
        End If
        AmtInWord = StrWord & " Only"
        Return AmtInWord
    End Function
    Function NumToWord(ByVal Num As Decimal) As String
        'I divided this function in two part.
        '1. Three or less digit number.
        '2. more than three digit number.
        Dim strNum As String
        Dim StrWord As String
        strNum = Num
        If Len(strNum) <= 3 Then
            StrWord = cWord3(CDbl(strNum))
        Else
            StrWord = cWordG3(CDbl(Mid(strNum, 1, Len(strNum) - 3))) + " " + cWord3(CDbl(Mid(strNum, Len(strNum) - 2)))
        End If
        NumToWord = StrWord
    End Function
    Function cWordG3(ByVal Num As Decimal) As String
        '2. more than three digit number.
        Dim strNum As String = ""
        Dim StrWord As String = ""
        Dim readNum As String = ""
        strNum = Num
        If Len(strNum) Mod 2 <> 0 Then
            readNum = CDbl(Mid(strNum, 1, 1))
            If readNum <> "0" Then
                StrWord = retWord(readNum)
                readNum = CDbl("1" + strReplicate("0", Len(strNum) - 1) + "000")
                StrWord = StrWord + " " + retWord(readNum)
            End If
            strNum = Mid(strNum, 2)
        End If
        While Not Len(strNum) = 0
            readNum = CDbl(Mid(strNum, 1, 2))
            If readNum <> "0" Then
                StrWord = StrWord + " " + cWord3(readNum)
                readNum = CDbl("1" + strReplicate("0", Len(strNum) - 2) + "000")
                StrWord = StrWord + " " + retWord(readNum)
            End If
            strNum = Mid(strNum, 3)
        End While
        cWordG3 = StrWord
        Return cWordG3
    End Function
    Function cWord3(ByVal Num As Decimal) As String
        '1. Three or less digit number.
        Dim strNum As String = ""
        Dim StrWord As String = ""
        Dim readNum As String = ""
        If Num < 0 Then Num = Num * -1
        strNum = Num

        If Len(strNum) = 3 Then
            readNum = CDbl(Mid(strNum, 1, 1))
            StrWord = retWord(readNum) + " Hundred"
            strNum = Mid(strNum, 2, Len(strNum))
        End If
        If Len(strNum) <= 2 Then
            If CDbl(strNum) >= 0 And CDbl(strNum) <= 20 Then
                StrWord = StrWord + " " + retWord(CDbl(strNum))
            Else
                StrWord = StrWord + " " + retWord(CDbl(Mid(strNum, 1, 1) + "0")) + " " + retWord(CDbl(Mid(strNum, 2, 1)))
            End If
        End If
        strNum = CStr(Num)
        cWord3 = StrWord
        Return cWord3
    End Function
    Function retWord(ByVal Num As Decimal) As String
        'This two dimensional array store the primary word convertion of number.
        retWord = ""
        Dim ArrWordList(,) As Object = {{0, ""}, {1, "One"}, {2, "Two"}, {3, "Three"}, {4, "Four"}, _
                                        {5, "Five"}, {6, "Six"}, {7, "Seven"}, {8, "Eight"}, {9, "Nine"}, _
                                        {10, "Ten"}, {11, "Eleven"}, {12, "Twelve"}, {13, "Thirteen"}, {14, "Fourteen"}, _
                                        {15, "Fifteen"}, {16, "Sixteen"}, {17, "Seventeen"}, {18, "Eighteen"}, {19, "Nineteen"}, _
                                        {20, "Twenty"}, {30, "Thirty"}, {40, "Forty"}, {50, "Fifty"}, {60, "Sixty"}, _
                                        {70, "Seventy"}, {80, "Eighty"}, {90, "Ninety"}, {100, "Hundred"}, {1000, "Thousand"}, _
                                        {100000, "Lakh"}, {10000000, "Crore"}}

        Dim i As Integer
        For i = 0 To UBound(ArrWordList)
            If Num = ArrWordList(i, 0) Then
                retWord = ArrWordList(i, 1)
                Exit For
            End If
        Next
        Return retWord
    End Function
    Function strReplicate(ByVal str As String, ByVal intD As Integer) As String
        'This fucntion padded "0" after the number to evaluate hundred, thousand and on....
        'using this function you can replicate any Charactor with given string.
        Dim i As Integer
        strReplicate = ""
        For i = 1 To intD
            strReplicate = strReplicate + str
        Next
        Return strReplicate
    End Function

End Class
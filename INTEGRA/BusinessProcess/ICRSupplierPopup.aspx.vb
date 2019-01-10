Imports System.Data
Imports Integra.EuroCentra
Imports System.Net
Imports System.Net.Mail
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Public Class ICRSupplierPopup
    Inherits System.Web.UI.Page
    Dim objPurchaseOrder As New PurchaseOrder
    Dim lblTotalPO As Label
    Dim dr As DataRow
    Dim DtCurrentDate As New DataTable
    Dim objICR As New ICR
    Dim IPOID As Long
    Dim lPODetailID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Expires = 0
        Dim objDataView As DataView
        IPOID = Request.QueryString("lPOID")
        lPODetailID = Request.QueryString("lPODetailID")
        If Not Page.IsPostBack Then
            Try
                If IPOID > 0 Then
                    objDataView = LoadData(IPOID)
                    Session("objDataView") = objDataView
                    BindGrid()
                Else
                    objDataView = LoadData(IPOID)
                    Session("objDataView") = objDataView
                    BindGrid()
                End If
            Catch objUDException As UDException
            End Try
        End If
    End Sub
    ' Procedure that Binds the Grid
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            Dim strSortExpression As String
            objDataView = Session("objDataView")
            If objDataView.Count > 0 Then
                dgPurchaseOrder.Visible = True
                strSortExpression = dgPurchaseOrder.SortExpression
                If strSortExpression <> "" Then
                    objDataView.Sort = strSortExpression
                    If Not dgPurchaseOrder.IsSortedAscending Then
                        objDataView.Sort += " DESC"
                    End If
                End If
                dgPurchaseOrder.RecordCount = objDataView.Count
                dgPurchaseOrder.DataSource = objDataView
                dgPurchaseOrder.DataBind()

                Dim x As Integer
                Dim cmbCATINSP As DropDownList
                Dim txtSuppling As TextBox
                For x = 0 To dgPurchaseOrder.RecordCount - 1
                    cmbCATINSP = CType(dgPurchaseOrder.Items(x).FindControl("cmbCATINSP"), DropDownList)
                    txtSuppling = CType(dgPurchaseOrder.Items(x).FindControl("txtSuppling"), TextBox)
                    ' BindcmbCATINSP()
                    With cmbCATINSP
                        .Items.Clear()
                        .Items.Insert(0, "In Line")
                        .Items.Insert(1, "Final")
                        .Items.Insert(2, "Rework")
                    End With
                    'when come from supplier main page  hilght selected row
                    If Convert.ToInt32(dgPurchaseOrder.Items(x).Cells(1).Text) = lPODetailID Then
                        dgPurchaseOrder.Items(x).BackColor = Drawing.Color.LightSkyBlue
                    End If
                    'end
                Next
            Else
                dgPurchaseOrder.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData(ByVal IPOID As Long) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objPurchaseOrder.TemproryFUNForICR(IPOID)
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    'PageChanged (NOT private otherwise unaccessible from the page)
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs)
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgPurchaseOrder.ItemDataBound
        'BindGrid()
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim DateProposed As String = txtDateProposed.SelectedDate.ToString()
            If DateProposed = "" Then
                lblMSG.Text = "Date Proposed Empty"
            ElseIf txtPreperedby.Text = "" Then
                lblMSG.Text = "Prepered by empty"
            ElseIf txtEmail.Text = "" Then
                lblMSG.Text = "Email empty"
            Else
                Dim x As Integer
                Dim chkICR As CheckBox ' get the update check box status
                Dim cmbCATINSP As DropDownList
                Dim txtSuppling As TextBox
                For x = 0 To dgPurchaseOrder.Items.Count - 1
                    chkICR = CType(dgPurchaseOrder.Items(x).FindControl("chkICR"), CheckBox)
                    If chkICR.Checked = True Then
                        Dim cmbWIPProcess As DropDownList = CType(dgPurchaseOrder.Items(x).FindControl("cmbWIPProcess"), DropDownList)
                        cmbCATINSP = CType(dgPurchaseOrder.Items(x).FindControl("cmbCATINSP"), DropDownList)
                        txtSuppling = CType(dgPurchaseOrder.Items(x).FindControl("txtSuppling"), TextBox)
                        Dim IPOID As Integer = dgPurchaseOrder.Items(x).Cells(0).Text
                        Dim IPODetailID As Integer = dgPurchaseOrder.Items(x).Cells(1).Text
                        With objICR
                            .ICRId = 0
                            .POID = IPOID
                            .POdetailID = IPODetailID
                            .Suppling = txtSuppling.Text
                            .DateProposed = txtDateProposed.SelectedDate
                            .ContactPerson = txtPreperedby.Text
                            .Email = txtEmail.Text
                            .CATINSP = cmbCATINSP.SelectedValue
                            .CreationDate = Date.Now
                            .SaveICR()
                            'After Save Make False Checkbox                       
                            chkICR.Checked = False
                        End With
                        lblMSG.Visible = True
                        lblMSG.Text = "Your ICR Save Successfully"
                    Else
                        'Make False Checkbox 
                        chkICR.Checked = False
                        'Not save
                    End If
                Next
                SavePOTracking()
                SendEmail()
            End If
        Catch ex As Exception
        End Try
        Session("dtWIPSelection") = Nothing
        '  Response.Redirect("SupplierMainPage.aspx")
    End Sub
    Sub SavePOTracking()
        Try
            Dim objPOtracking As New POTracking
            With objPOtracking
                .PoTrackingID = 0
                .CreationDate = Date.Now
                .POID = IPOID
                .TrackingObject = "ICR issued by supplier"
                .SavePOTracking()
            End With
        Catch ex As Exception
        End Try
    End Sub
    Sub SendEmail()
        Try
            Dim Report As New ReportDocument
            Dim Options As New ExportOptions
            Report.Load(Server.MapPath("..\Reports/InspectionCallRequest.rpt"))
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()

            Dim FileName As String = "ICR_" + txtDateProposed.SelectedDate.Value.ToString("dd-MM-yyyy")
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
            Report.SetParameterValue(0, IPOID)
            Report.SetParameterValue(1, IPOID)

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
            Dim objUser As New User
            Dim dtEmail As DataTable
            dtEmail = objUser.GetEmailAddress(22)
            Dim mail As MailMessage = New MailMessage()
            mail.To.Add(dtEmail.Rows(0)("EmailAddress"))
            Dim dtCC As DataTable
            Dim x As Integer
            dtCC = objUser.EmailAddressCCForICR()
            For x = 0 To dtCC.Rows.Count - 1
                mail.CC.Add(dtCC.Rows(x)("EmailAddress"))
            Next
            Dim dtPOInfo As DataTable
            dtPOInfo = objPurchaseOrder.TemproryFUNForICR(IPOID)
            mail.Bcc.Add(txtEmail.Text)
            mail.Bcc.Add("zahidsajjad@hotmail.com")
            mail.Attachments.Add(New Attachment(Server.MapPath("~/TempPDF/" & FileName & ".pdf")))
            mail.From = New MailAddress("noreply@eurocentrab2b.com")
            mail.Subject = "Inspection Call Request: PO No. " & dtPOInfo.Rows(0)("PONO") & ", " & dtPOInfo.Rows(0)("Customername") & ""
            Dim Body As String = " " & _
                         "<br/>" & _
                         "Greetings:" & _
                           "<br/>" & _
                           "<br/>" & _
                         "Supplier issue inspecion call request (ICR) of following order:"
            Body = Body + " " & _
                         "<br/>" & _
                         "PO. No:" & dtPOInfo.Rows(0)("PONO") & "" & _
                         "<br/>" & _
                          "Customer: " & dtPOInfo.Rows(0)("Customername") & "" & _
                         "<br/>" & _
                          "Supplier: " & dtPOInfo.Rows(0)("Vendername") & "" & _
                         "<br/>" & _
                         "Shipment date: " & dtPOInfo.Rows(0)("ShipmentDate") & "" & _
                         "<br/>" & _
                          "<br/>" & _
                          "<b> ICR Prepered by " & txtPreperedby.Text & " and Proposed Date " & txtDateProposed.SelectedDate & " </b>" & _
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
 
End Class

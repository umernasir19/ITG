Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Net
Imports System.Net.Mail
Imports System.Xml
Public Class Production
    Inherits System.Web.UI.Page
    Dim objtbleProductionMaster As New tbleProductionMaster
    Dim objtbleProductionDetails As New tbleProductionDetails
    Dim objJobOrder As New JobOrderdatabase
    Dim objSub_Style As New Style_SubStyle
    Dim dtproduction As New DataTable
    Dim lJobOrderId As Long
    Dim roleid As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lJobOrderId = Request.QueryString("JobOrderID")
        If Not Page.IsPostBack Then
            roleid = Session("RoleId")
            BindJoborder()
            ddljoborder.SelectedValue = lJobOrderId
            'If roleid = 19 Then
            '    BindProduction1()

            'ElseIf roleid = 15 Then
            '    BindProductionSTBR()
            'ElseIf roleid = 20 Then
            '    BindProductionCUTTING()
            'ElseIf roleid = 16 Then
            '    BindProductionWashing()
            'Else
            BindProduction()
        End If
        'End If

    End Sub
    Sub BindProductionWashing()
        Dim dt As DataTable
        dt = objtbleProductionMaster.BindProductionWashing()
        ddlproduction.DataSource = dt
        ddlproduction.DataTextField = "ProductionType"
        ddlproduction.DataValueField = "ProductionTypeID"
        ddlproduction.DataBind()
        ddlproduction.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Sub BindProduction()
        Dim dt As DataTable
        dt = objtbleProductionMaster.BindProduction()
        ddlproduction.DataSource = dt
        ddlproduction.DataTextField = "ProductionType"
        ddlproduction.DataValueField = "ProductionTypeID"
        ddlproduction.DataBind()
        ddlproduction.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Sub BindProductionCUTTING()
        Dim dt As DataTable
        dt = objtbleProductionMaster.BindProductionCutting()
        ddlproduction.DataSource = dt
        ddlproduction.DataTextField = "ProductionType"
        ddlproduction.DataValueField = "ProductionTypeID"
        ddlproduction.DataBind()
        ddlproduction.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Sub BindProductionSTBR()
        Dim dt As DataTable
        dt = objtbleProductionMaster.BindProductionSTBR()
        ddlproduction.DataSource = dt
        ddlproduction.DataTextField = "ProductionType"
        ddlproduction.DataValueField = "ProductionTypeID"
        ddlproduction.DataBind()
        ddlproduction.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Sub BindProduction1()
        Dim dt As DataTable
        dt = objtbleProductionMaster.BindProduction1()
        ddlproduction.DataSource = dt
        ddlproduction.DataTextField = "ProductionType"
        ddlproduction.DataValueField = "ProductionTypeID"
        ddlproduction.DataBind()
        ddlproduction.Items.Insert(0, New ListItem("Select", "0"))
    End Sub


    Sub BindJoborder()
        Dim dt As DataTable
        dt = objtbleProductionMaster.BindJobprder()
        ddljoborder.DataSource = dt
        ddljoborder.DataTextField = "JobOrderNo"
        ddljoborder.DataValueField = "JobOrderID"
        ddljoborder.DataBind()
        ddljoborder.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Sub bindGrid()
        Dim dt As New DataTable
        dt = objJobOrder.BindGridForDigitalNew(ddljoborder.SelectedValue, ddlproduction.SelectedValue)
        If ddlproduction.SelectedItem.Text = "Packing" Then

            dgView.DataSource = dt
            dgView.DataBind()
            dgView.Columns(9).Visible = True
            Dim x As Integer
            For x = 0 To dgView.Items.Count - 1
                Dim txtPercent As TextBox = CType(dgView.Items(x).FindControl("txtPercent"), TextBox)
                Dim txtQTYwithPer As TextBox = CType(dgView.Items(x).FindControl("txtQTYwithPer"), TextBox)
                Dim lnkRemove As ImageButton = CType(dgView.Items(x).FindControl("lnkRemove"), ImageButton)
                Dim txtRejection As TextBox = CType(dgView.Items(x).FindControl("txtRejection"), TextBox)

                Dim percent As Decimal

                If String.IsNullOrEmpty(dt.Rows(x)("QtyPerNew").ToString()) = False Then
                    percent = dt.Rows(x)("QtyPerNew")
                Else
                    percent = 0
                End If


                Dim TotalQty As Decimal

                If String.IsNullOrEmpty(dt.Rows(x)("TotalQtyNew").ToString()) = False Then
                    TotalQty = dt.Rows(x)("TotalQtyNew")
                Else
                    TotalQty = 0
                End If


                txtPercent.Text = percent
                txtQTYwithPer.Text = TotalQty
                txtRejection.Text = TotalQty - Val(dt.Rows(x)("ProductedTodayIndivisiual"))
                If percent > 0 Then
                    txtPercent.ReadOnly = True
                    lnkRemove.Enabled = False
                Else
                    txtPercent.ReadOnly = False
                    lnkRemove.Enabled = True
                End If



            Next
        Else


            dgView.DataSource = dt
            dgView.DataBind()
            dgView.Columns(9).Visible = False
            Dim x As Integer
            For x = 0 To dgView.Items.Count - 1
                Dim txtPercent As TextBox = CType(dgView.Items(x).FindControl("txtPercent"), TextBox)
                Dim txtQTYwithPer As TextBox = CType(dgView.Items(x).FindControl("txtQTYwithPer"), TextBox)
                Dim lnkRemove As ImageButton = CType(dgView.Items(x).FindControl("lnkRemove"), ImageButton)
                Dim txtRejection As TextBox = CType(dgView.Items(x).FindControl("txtRejection"), TextBox)
                Dim percent As Decimal

                If String.IsNullOrEmpty(dt.Rows(x)("QtyPerNew").ToString()) = False Then
                    percent = dt.Rows(x)("QtyPerNew")
                Else
                    percent = 0
                End If


                Dim TotalQty As Decimal

                If String.IsNullOrEmpty(dt.Rows(x)("TotalQtyNew").ToString()) = False Then
                    TotalQty = dt.Rows(x)("TotalQtyNew")
                Else
                    TotalQty = 0
                End If


                txtPercent.Text = percent
                txtQTYwithPer.Text = TotalQty
                txtRejection.Text = TotalQty - Val(dt.Rows(x)("ProductedTodayIndivisiual"))
                If percent > 0 Then
                    txtPercent.ReadOnly = True
                    lnkRemove.Enabled = False
                Else
                    txtPercent.ReadOnly = False
                    lnkRemove.Enabled = True
                End If



            Next
        End If
    End Sub
    Protected Sub ddljoborder_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddljoborder.SelectedIndexChanged
        If ddlproduction.SelectedValue = 0 Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please select Production")
        ElseIf ddljoborder.SelectedValue = 0 Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please select Job  Order")
        Else
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
            bindGrid()
        End If
    End Sub
    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Try
            If ddlproduction.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please select Production")
            ElseIf ddljoborder.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please select Job Order")
            ElseIf txtdDate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please select Date")
            Else
                With objtbleProductionMaster
                    .ProductionMasterID = 0
                    .JobOrderID = ddljoborder.SelectedValue
                    .ProductionDate = txtdDate.Text
                    .ProductionTypeID = ddlproduction.SelectedValue
                    .Saveproduction()
                End With

                ''for  detail save
                Dim x As Integer
                For x = 0 To dgView.Items.Count - 1

                    Dim lProductionDetailID As Long = 0
                    Dim lProductionMasterID As Long = objtbleProductionMaster.GetId()
                    Dim lProductionTypeID As Long = ddlproduction.SelectedValue
                    Dim lJobOrderDetailID As Long = dgView.Items(x).Cells(0).Text
                    Dim PreviousProduced As Decimal = dgView.Items(x).Cells(8).Text
                    Dim txtProduced As TextBox = CType(dgView.Items(x).FindControl("txtProduced"), TextBox)
                    Dim ChkStatus As CheckBox = CType(dgView.Items(x).FindControl("ChkStatus"), CheckBox)

                    Dim Qty As Decimal = dgView.Items(x).Cells(5).Text
                    Dim txtPercent As TextBox = CType(dgView.Items(x).FindControl("txtPercent"), TextBox)
                    Dim txtQTYwithPer As TextBox = CType(dgView.Items(x).FindControl("txtQTYwithPer"), TextBox)
                    Dim lnkRemove As ImageButton = CType(dgView.Items(x).FindControl("lnkRemove"), ImageButton)
                    Dim A = PreviousProduced
                    Dim B As Decimal
                    Dim percent As Decimal
                    Dim TotalQty As Decimal
                    If txtPercent.Text = "" Then
                        percent = 0
                    Else
                        percent = Val(txtPercent.Text)
                    End If
                    If txtQTYwithPer.Text = "" Then
                        TotalQty = 0
                    Else
                        TotalQty = Val(txtQTYwithPer.Text)
                    End If
                    If txtProduced.Text = "" Then
                        B = 0
                    Else
                        B = Convert.ToDecimal(txtProduced.Text)
                    End If

                    Dim C As Decimal
                    C = A + B

                    If ChkStatus.Checked = True Then

                        If txtProduced.Text = "" Then
                            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Date Empty.")
                        Else
                            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                            With objtbleProductionDetails
                                .ProductionDetailID = lProductionDetailID
                                .ProductionMasterID = lProductionMasterID
                                .ProductionTypeID = lProductionTypeID
                                .JobOrderDetailID = lJobOrderDetailID
                                .ProductedToday = B
                                .PreviousProduced = C
                                .TotalProduced = C
                                .Remarks = "N/A"
                                .Selected = ChkStatus.Checked
                                .Style_SubStyleID = 0
                                ChkStatus.Enabled = False
                                txtPercent.ReadOnly = True
                                lnkRemove.Enabled = False
                                ChkStatus.Checked = False
                                .MinimizeQty = 0
                                .Saveproduction()
                                objSub_Style.UpdateQty(lJobOrderDetailID, percent, TotalQty)
                            End With
                        End If
                    End If
                    objSub_Style.UpdateQty(lJobOrderDetailID, percent, TotalQty)
                Next
            End If
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Record Has Been Saved")
            bindGrid()
            'BindmailGrid()
            ' mail()
        Catch ex As Exception
        End Try

        Try

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub dgView_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgView.SortCommand
        bindGrid()
    End Sub
    Protected Sub dgView_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgView.PageIndexChanged
        bindGrid()
    End Sub
    Protected Sub dgView_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgView.ItemCommand
        Try
            Select Case e.CommandName
                Case Is = "Calculation"
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                    Dim txtPercent As TextBox = DirectCast(dgView.Items(e.Item.ItemIndex).FindControl("txtPercent"), TextBox)
                    Dim txtQTYwithPer As TextBox = DirectCast(dgView.Items(e.Item.ItemIndex).FindControl("txtQTYwithPer"), TextBox)
                    Dim Qty As Decimal = dgView.Items(e.Item.ItemIndex).Cells(5).Text
                    If txtPercent.Text = "" Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please fill Percent")
                    Else
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                        Dim perQty As Decimal = (Val(txtPercent.Text) * Qty / 100)
                        Dim TotalQty As Decimal = perQty + Qty
                        txtQTYwithPer.Text = TotalQty
                    End If
                Case Is = "CalculationMinimize"
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                    Dim txtMinimizeQty As TextBox = DirectCast(dgView.Items(e.Item.ItemIndex).FindControl("txtMinimizeQty"), TextBox)
                    Dim JoborderId As Long = ddljoborder.SelectedValue
                    Dim ProductionTypeId As Long = ddlproduction.SelectedValue
                    Dim PreviousProduced As Decimal = dgView.Items(e.Item.ItemIndex).Cells(8).Text
                    Dim lJobOrderDetailID As Long = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    If txtMinimizeQty.Text = "" Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please fill Minimize")
                    Else
                        If PreviousProduced > 0 Then
                            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                            Dim ProductionDetailDt As DataTable = objtbleProductionDetails.getdataforMinimize(lJobOrderDetailID, ProductionTypeId)
                            Dim ProductionDetailId As Long = ProductionDetailDt.Rows.Item(0)("ProductionDetailId")
                            Dim MinimizeQty As Decimal = ProductionDetailDt.Rows.Item(0)("MinimizeQty")
                            Dim totalMinimizeQty As Decimal
                            totalMinimizeQty = MinimizeQty + Val(txtMinimizeQty.Text)
                            objtbleProductionDetails.UpdateMinimizeQty(ProductionDetailId, totalMinimizeQty)
                            bindGrid()
                        Else
                            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Can not be Minimize")
                        End If


                    End If
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub ddlproduction_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlproduction.SelectedIndexChanged
        Try
            If ddlproduction.SelectedValue > 0 Then
                PageHeader(ddlproduction.SelectedItem.Text)

            Else
                PageHeader("")
            End If

            If ddlproduction.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please select Production")
            ElseIf ddljoborder.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please select Job  Order")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                bindGrid()
            End If

        Catch ex As Exception

        End Try
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub


    'Sub mail()
    '    Try
    '        'Dim dtQA As DataTable = objTNAChart.QAInfo()
    '        'Dim i As Integer
    '        'For i = 0 To dtQA.Rows.Count - 1
    '        Dim dt As DataTable = objJobOrder.BindGrid(ddljoborder.SelectedValue, ddlproduction.SelectedValue)
    '        If dt.Rows.Count > 0 Then
    '            dgmail.DataSource = dt
    '            dgmail.DataBind()

    '            dgmail.HeaderStyle.BackColor = Drawing.Color.LightBlue
    '            dgmail.GridLines = CType(System.Enum.Parse(GetType(GridLines), 3, True), GridLines)
    '            dgmail.HeaderStyle.Font.Name = "verdana"
    '            dgmail.ForeColor = Drawing.Color.Black

    '            dgmail.Font.Name = "verdana"

    '            Dim sb As New StringBuilder()
    '            Dim sw As New StringWriter(sb)
    '            Dim hw As New HtmlTextWriter(sw)
    '            dgmail.RenderControl(hw)

    '            'Email
    '            Dim mail As MailMessage = New MailMessage()
    '            'mail.To.Add("zakir@itg.net.pk")
    '            ''WHEN YOU WILL PUBLISH PLZ UNCOMMENT THE FOLLOWING EMAIL
    '            '  mail.To.Add("naveed.zia@naztextilemills.com")
    '            ' mail.To.Add("muhammad.salman90@live.com")
    '            ' mail.To.Add("mbhcaprian@gmail.com")
    '            'mail.CC.Add("cutting@naztextilemills.com")
    '            ' mail.CC.Add("fabric@naztextilemills.com")
    '            ' mail.CC.Add("finishing@naztextilemills.com")
    '            ' mail.CC.Add("Kamran.ahmed@naztextiemills.com")
    '            ' mail.CC.Add("washing@naztextilemills.com")
    '            ' mail.CC.Add("asif.muhammad@naztextilemills.com")
    '            ' mail.CC.Add("production@naztextilemills.com")
    '            ' mail.CC.Add("purchase@naztextilemills.com")
    '            ' mail.CC.Add("s.siddiqui@naztextilemills.com")
    '            ' mail.CC.Add("nizam149@gmail.com")
    '            ' mail.Bcc.Add("muhammad.salman90@live.com")
    '            ' mail.Bcc.Add("mbhcaprian@gmail.com")
    '            mail.From = New MailAddress("Naz-online-system@naztextilemills.com")

    '            mail.Subject = "Production(JobOrder vise)"
    '            'Dim x As Integer
    '            Dim Body As String = " " & _
    '                         "<br/>" & _
    '                         "<b> Dear , </b>" & _
    '                           "<br/>" & _
    '                           "<br/>" & _
    '                         "Following are the Detail Of #" & ddlproduction.SelectedItem.Text & "</b>." & _
    '                        "<br/>" & _
    '                        "<br/>"
    '            Body = Body + sb.ToString()
    '            Body = Body + " </table> <br/>" & _
    '                         "<br/>" & _
    '                         " " & _
    '                         "<br/>" & _
    '                          "<br/>" & _
    '                         "<b>   </b>" & _
    '                           "<br/>" & _
    '                            "<br/>" & _
    '                           "<font color=""red"">  " & _
    '                            "<br/>" & _
    '                            " </font>" & _
    '                              "<br/>" & _
    '                                "<br/>" & _
    '                         "Thanks" & _
    '                           "<br/>" & _
    '                        "NTL" & _
    '                         "<br/>" & _
    '                          "<br/>" & _
    '                          "Powered By:" & _
    '                           "<br/>" & _
    '                           "Integra ERP System" & _
    '                             "<br/>" & _
    '                              "<br/>" & _
    '                         "************* This is System generated email and does not required reply *******************"
    '            mail.Body = Body
    '            mail.IsBodyHtml = True
    '            Dim smtp As SmtpClient = New SmtpClient()
    '            smtp.Port = 25
    '            smtp.Host = "webmail.naztextilemills.com"
    '            smtp.Credentials = New System.Net.NetworkCredential("Naz-online-system@naztextilemills.com", "N@z123")
    '            smtp.EnableSsl = False
    '            smtp.Send(mail)
    '        End If
    '    Catch ex As Exception
    '        lblmsgemail.Text = ex.ToString
    '    End Try
    'End Sub
    'Sub BindmailGrid()
    '    Dim dt As DataTable = objJobOrder.BindGrid(ddljoborder.SelectedValue, ddlproduction.SelectedValue)

    '    If dt.Rows.Count > 0 Then
    '        Dgmail.DataSource = dt
    '        Dgmail.DataBind()
    '        Dgmail.Visible = True

    '    End If
    'End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("JobOrderDatabaseView.aspx")
        Catch ex As Exception

        End Try
    End Sub
End Class
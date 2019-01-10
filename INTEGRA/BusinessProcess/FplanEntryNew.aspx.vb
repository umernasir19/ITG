Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Public Class FplanEntryNew
    Inherits System.Web.UI.Page
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim ObjFPlanMst As New FPlanMst
    Dim ObjFPlanDtl As New FPlanDtl
    Dim JobOrderID As Long
    Dim jOBdT, dtDetail, dtFPlan As DataTable
    Dim FPlanDt As DataTable
    Dim dr As DataRow


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        JobOrderID = Request.QueryString("JobOrderID")
        If Not Page.IsPostBack Then

            lblJobOrderId.Text = JobOrderID
            Session("dtDetail") = Nothing
            Session("dtFPlan") = Nothing
            FillMasterdate()
            FPlanDt = ObjFPlanMst.GetFPLANdetail(JobOrderID)
            Dim x As Integer
            Dim Pieaceqty As Decimal = 0
            Dim ReqMeter2 As Decimal = 0
            If FPlanDt.Rows.Count > 0 Then
                Session("dtFPlan") = FPlanDt
                lblFPlanMst.Text = FPlanDt.Rows(0)("FPlanMstID")
                txtTotalFabric.Text = FPlanDt.Rows(0)("TotalFabric")
                txtConsumption.Text = FPlanDt.Rows(0)("Cons")
                txtPrecentage.Text = FPlanDt.Rows(0)("Percent")
                txtConsumptionQty.Text = Val(txtConsumption.Text) * Val(txtQty.Text)
                BindGridFPlan()
                btnsave.Visible = False
                BindcmbFabric()
                BindcmbStyle()
                For x = 0 To dgFPlan.Items.Count - 1
                    Dim cmbFabric As DropDownList = CType(dgFPlan.Items(x).FindControl("cmbFabric"), DropDownList)
                    Dim cmbStyle As DropDownList = CType(dgFPlan.Items(x).FindControl("cmbStyle"), DropDownList)
                    Dim txtWidth As TextBox = CType(dgFPlan.Items(x).FindControl("txtWidth"), TextBox)
                    Dim txtReqMeter As TextBox = CType(dgFPlan.Items(x).FindControl("txtReqMeter"), TextBox)
                    ' Dim txtInHouse As TextBox = CType(dgFPlan.Items(x).FindControl("txtInHouse"), TextBox)
                    'Dim txtIssueQty As TextBox = CType(dgFPlan.Items(x).FindControl("txtIssueQty"), TextBox)
                    'Dim txtStockQty As TextBox = CType(dgFPlan.Items(x).FindControl("txtStockQty"), TextBox)
                    ' Dim txtBalanceQty As TextBox = CType(dgFPlan.Items(x).FindControl("txtBalanceQty"), TextBox)
                    Dim txtPieceQtyy As TextBox = CType(dgFPlan.Items(x).FindControl("txtPieceQtyy"), TextBox)
                    Dim lblIMSItemID As Label = CType(dgFPlan.Items(x).FindControl("lblIMSItemID"), Label)
                    'txtInHouse.ReadOnly = True
                    'txtInHouse.Enabled = False
                    cmbFabric.SelectedValue = FPlanDt.Rows(x)("FabricDatabaseID")
                    cmbStyle.SelectedValue = FPlanDt.Rows(x)("Style")
                    txtWidth.Text = FPlanDt.Rows(x)("Width")
                    txtReqMeter.Text = FPlanDt.Rows(x)("ReqMeter")
                    'txtInHouse.Text = FPlanDt.Rows(x)("InhandQty")
                    ' txtBalanceQty.Text = FPlanDt.Rows(x)("BalanceQty")
                    ' txtIssueQty.Text = FPlanDt.Rows(x)("IssueQty")
                    ' txtStockQty.Text = FPlanDt.Rows(x)("StockQty")
                    txtPieceQtyy.Text = FPlanDt.Rows(x)("PieceQty")
                    lblIMSItemID.Text = FPlanDt.Rows(x)("IMSItemID")
                    Pieaceqty = Pieaceqty + Val(txtPieceQtyy.Text)
                    ReqMeter2 = ReqMeter2 + Val(txtReqMeter.Text)
                    lblPieaceQty.Text = Pieaceqty
                    lblReqMeter.Text = ReqMeter2
                Next

                SaveButton.Visible = True
                lblGrandTotal.Visible = True
                btnAddmore.Visible = True

            End If

            BindFibricCode()


        End If

    End Sub
    Sub FillMasterdate()
        jOBdT = ObjFPlanMst.GetJobOrderData(JobOrderID)

        txtJobOrder.Text = jOBdT.Rows(0)("SRNo")
        txtBrand.Text = jOBdT.Rows(0)("Brand")
        txtBuyer.Text = jOBdT.Rows(0)("CustomerName")
        txtContent.Text = jOBdT.Rows(0)("Content")
        txtItem.Text = jOBdT.Rows(0)("ItemName")
        txtSeason.Text = jOBdT.Rows(0)("SeasonName")
        txtQty.Text = jOBdT.Rows(0)("Qty")
        txtRecvDate.Text = jOBdT.Rows(0)("ReceivedDate")
        txtShipDate.Text = jOBdT.Rows(0)("ShipmentDate")


    End Sub
    Sub BindFibricCode()
        Dim dt As DataTable
        dt = ObjFPlanMst.GetFabricCode()
        ddlFabricCode.DataSource = dt
        ddlFabricCode.DataTextField = "FabricCode"
        ddlFabricCode.DataValueField = "FabricDatabaseID"
        ddlFabricCode.DataBind()
        ddlFabricCode.Items.Insert(0, New ListItem("Select Fabric Code", "0"))
    End Sub
    Sub BindcmbStyle()
        Dim x As Integer = 0
        For x = 0 To dgFPlan.Items.Count - 1
            Dim cmbstyle As DropDownList = CType(dgFPlan.Items(x).FindControl("cmbstyle"), DropDownList)
            Dim Dt As DataTable
            Dt = ObjFPlanMst.GetStyle(JobOrderID)
            If cmbstyle IsNot Nothing Then
                cmbstyle.DataSource = Dt
                cmbstyle.DataTextField = "Style"
                ' cmbstyle.DataValueField = "FabricDatabaseID" '    "ProductDatabaseID"
                cmbstyle.DataBind()
                cmbstyle.DataSource = Dt
                cmbstyle.Items.Insert(0, New ListItem("Select", "0"))
            End If
        Next
    End Sub

    Sub BindcmbFabric()
        Dim x As Integer = 0
        For x = 0 To dgFPlan.Items.Count - 1
            Dim cmbFabric As DropDownList = CType(dgFPlan.Items(x).FindControl("cmbFabric"), DropDownList)
            Dim Dt As DataTable
            Dt = ObjFPlanMst.GetFabricCode()
            If cmbFabric IsNot Nothing Then
                cmbFabric.DataSource = Dt
                cmbFabric.DataTextField = "Fabric"
                cmbFabric.DataValueField = "FabricDatabaseID" '    "ProductDatabaseID"
                cmbFabric.DataBind()
                cmbFabric.DataSource = Dt
                cmbFabric.Items.Insert(0, New ListItem("Select..", "0"))
            End If
        Next
    End Sub
    Sub SaveSession()
        If (Not CType(Session("dtDetail"), DataTable) Is Nothing) Then
            dtDetail = Session("dtDetail")
        Else
            dtDetail = New DataTable
            With dtDetail
                .Columns.Add("FPlanDtlID", GetType(Long))
                .Columns.Add("FabricdataBaseId", GetType(Long))
                .Columns.Add("Fabric", GetType(String))
                .Columns.Add("Weave", GetType(String))
                .Columns.Add("GSM", GetType(String))
                .Columns.Add("Width", GetType(String))
                .Columns.Add("Composition", GetType(String))
                .Columns.Add("ReqMeter", GetType(String))
                .Columns.Add("ReqDatee", GetType(String))
            End With
        End If

        Dim dt As DataTable = ObjFPlanMst.GetFabricData(ddlFabricCode.SelectedValue)

        dr = dtDetail.NewRow()
        dr("FPlanDtlID") = 0
        dr("FabricdataBaseId") = ddlFabricCode.SelectedValue
        dr("FabricCode") = ddlFabricCode.SelectedItem.Text
        dr("Weave") = dt.Rows(0)("FabricWeave")
        dr("GSM") = dt.Rows(0)("GSM")
        dr("Width") = dt.Rows(0)("Width")
        dr("Composition") = dt.Rows(0)("Composition")
        dr("ReqMeter") = txtTotalFabric.Text
        dr("ReqDatee") = txtReqDate.Text

        dtDetail.Rows.Add(dr)
        Session("dtDetail") = dtDetail
        BindGrid()

    End Sub
    Sub SaveSessionFirst()
        If (Not CType(Session("dtFPlan"), DataTable) Is Nothing) Then
            dtFPlan = Session("dtFPlan")
        Else
            dtFPlan = New DataTable
            With dtFPlan
                .Columns.Add("FPlanDtlID", GetType(Long))
                '.Columns.Add("RowNumber", GetType(String))
                '.Columns.Add("FabricdataBaseId", GetType(Long))
                .Columns.Add("FabricDatabaseID", GetType(String))
                '.Columns.Add("Weave", GetType(String))
                '.Columns.Add("GSM", GetType(String))

                .Columns.Add("Width", GetType(String))
                '.Columns.Add("Composition", GetType(String))
                .Columns.Add("Consumption", GetType(String))
                .Columns.Add("ReqMeter", GetType(String))
                .Columns.Add("ReqDatee", GetType(String))
                '.Columns.Add("OpeningBal", GetType(String))
                '.Columns.Add("InHandQty", GetType(String))
                '.Columns.Add("BalanceQty", GetType(String))
                '.Columns.Add("IssueQty", GetType(String))
                '.Columns.Add("StockQty", GetType(String))

                .Columns.Add("PieceQty", GetType(String))
                .Columns.Add("IMSItemID", GetType(String))
                .Columns.Add("ReqStatus", GetType(String))
                .Columns.Add("Style", GetType(String))


            End With
        End If

        'Dim dt As DataTable = ObjFPlanMst.GetFabricData(ddlFabricCode.SelectedValue)

        dr = dtFPlan.NewRow()
        dr("FPlanDtlID") = 0
        'dr("RowNumber") = 1
        ' dr("FabricdataBaseId") = String.Empty
        dr("FabricDatabaseID") = String.Empty
        ' dr("Weave") = dt.Rows(0)("FabricWeave")
        'dr("GSM") = dt.Rows(0)("GSM")
        dr("Width") = String.Empty ' dt.Rows(0)("Width")
        'dr("Composition") = dt.Rows(0)("Composition")
        dr("Consumption") = txtConsumption.Text
        dr("ReqMeter") = String.Empty 'txtTotalFabric.Text
        dr("ReqDatee") = txtReqDate.Text
        'dr("OpeningBal") = txtTotalFabric.Text

        'dr("InHandQty") = String.Empty
        'dr("BalanceQty") = String.Empty
        'dr("IssueQty") = String.Empty
        'dr("StockQty") = String.Empty
        '  dr("Dept") = String.Empty
        dr("PieceQty") = String.Empty
        dr("IMSItemID") = String.Empty
        dr("ReqStatus") = 0
        dr("Style") = String.Empty
        dtFPlan.Rows.Add(dr)
        Session("dtFPlan") = dtFPlan
        BindGridFPlan()

        BindcmbFabric()
        BindcmbStyle()
        'Dim x As Integer
        'For x = 0 To dtFPlan.Rows.Count - 1
        '    Dim txtPieceQtyy As TextBox = CType(dgFPlan.Items(x).FindControl("txtPieceQtyy"), TextBox)
        '    txtPieceQtyy.Text = dtFPlan.Rows(x)("PieceQty")
        'Next


    End Sub
    Private Sub BindGrid()
        dtDetail = Session("dtDetail")
        Dim objDataview As New DataView(dtDetail)
        dgFPlanView.RecordCount = objDataview.Count
        dgFPlanView.DataSource = objDataview
        dgFPlanView.DataBind()
    End Sub
    Private Sub BindGridFPlan()
        dtFPlan = Session("dtFPlan")
        Dim objDataview As New DataView(dtFPlan)
        dgFPlan.RecordCount = objDataview.Count
        dgFPlan.DataSource = objDataview
        dgFPlan.DataBind()


        Dim x As Integer
        For x = 0 To dtFPlan.Rows.Count - 1
            Dim BtnPDF As ImageButton = CType(dgFPlan.Items(x).FindControl("lnkPDF"), ImageButton)
            Dim FPalnDtlId As Long = dgFPlan.Items(x).Cells(0).Text
            Dim dt As New DataTable
            dt = ObjFPlanDtl.GetDataForEnablePDF(FPalnDtlId)
            If dt.Rows.Count > 0 Then
                BtnPDF.Enabled = True
                BtnPDF.ToolTip = "Click to Download Fabric Purchase Order PDF"
                BtnPDF.ImageUrl = "~/Images/pdf_icon_small.gif"
            Else
                BtnPDF.Enabled = False
                BtnPDF.ToolTip = "Not Available"
                BtnPDF.ImageUrl = "~/Images/pdf_icon_NotAv.gif"
            End If

        Next

    End Sub

    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Try
            Dim reqdate As Date = txtReqDate.Text
            Dim Shipdate As Date = txtShipDate.Text
            If txtTotalFabric.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Req Meter")
                'ElseIf ddlFabricCode.SelectedValue = 0 Then
                'DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Fabric Code ")
            ElseIf txtReqDate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Req. Date ")
            ElseIf reqdate > Shipdate Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Required Date is Greater than Ship Date ")
                'ElseIf txtPieceQty.Text = "" Then
                'DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Piece Qty. Empty")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                ' SaveSession()
                SaveSessionFirst()
                clear()
                SaveButton.Visible = True
                btnsave.Visible = False
                lblGrandTotal.Visible = True
                btnAddmore.Visible = True
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub clear()
        'txtTotalFabric.Text = ""
        txtReqDate.Text = ""
        txtPieceQty.Text = ""

    End Sub
    Protected Sub dgFPlanView_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgFPlanView.ItemCommand
        Try
            Select Case e.CommandName
                Case "Edit"
                    ' Dim lblCreatedByID As Label = CType(dgView.Items(e.Item.ItemIndex).FindControl("lblCreatedByID"), Label)
                    'If CLng(Session("Userid")) = Convert.ToInt32(lblCreatedByID.Text) Then
                    'Dim tblBankMstID As Long = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    'DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    'Response.Redirect("BankVoucherEntry.aspx?ltblBankMstID=" & tblBankMstID & "")
                    '' Else
                    ' DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Edit Permitted By Only Created Person")
                    ' End If

                Case "Remove"


                    Dim tblFPlanDtlID As Long = dgFPlanView.Items(e.Item.ItemIndex).Cells(0).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    dtDetail = CType(Session("dtDetail"), DataTable)
                    If (Not dtDetail Is Nothing) Then
                        If (dtDetail.Rows.Count > 0) Then
                            Dim ltblBankDtlID As Integer = dgFPlanView.Items(e.Item.ItemIndex).Cells(0).Text
                            dtDetail.Rows.RemoveAt(e.Item.ItemIndex)
                            ObjFPlanMst.DeleteDetail(ltblBankDtlID)
                            BindGrid()
                        End If
                    End If

                    'objtblBankMst.DeletetblBankDtl(tblBankMstID)
                    'Dim objDataView As DataView
                    'objDataView = LoadData()
                    'Session("objDataView") = objDataView
                    'BindGrid()
                    ' DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Delete Successfully")
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub dgFPlan_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgFPlan.ItemCommand
        Try
            Select Case e.CommandName
                Case "Edit"
                    ' Dim lblCreatedByID As Label = CType(dgView.Items(e.Item.ItemIndex).FindControl("lblCreatedByID"), Label)
                    'If CLng(Session("Userid")) = Convert.ToInt32(lblCreatedByID.Text) Then
                    'Dim tblBankMstID As Long = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    'DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    'Response.Redirect("BankVoucherEntry.aspx?ltblBankMstID=" & tblBankMstID & "")
                    '' Else
                    ' DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Edit Permitted By Only Created Person")
                    ' End If

                Case "Remove"


                    Dim tblFPlanDtlID As Long = dgFPlanView.Items(e.Item.ItemIndex).Cells(0).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    dtDetail = CType(Session("dtDetail"), DataTable)
                    If (Not dtDetail Is Nothing) Then
                        If (dtDetail.Rows.Count > 0) Then
                            Dim ltblBankDtlID As Integer = dgFPlanView.Items(e.Item.ItemIndex).Cells(0).Text
                            dtDetail.Rows.RemoveAt(e.Item.ItemIndex)
                            ObjFPlanMst.DeleteDetail(ltblBankDtlID)
                            BindGrid()
                        End If
                    End If

                    'objtblBankMst.DeletetblBankDtl(tblBankMstID)
                    'Dim objDataView As DataView
                    'objDataView = LoadData()
                    'Session("objDataView") = objDataView
                    'BindGrid()
                    ' DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Delete Successfully")

                Case "Calculate"
                    inhandcalculate()
                Case "CalculateStock"

                    Stockcalculate()
                Case "Issue"
                    Dim cmbFabric As DropDownList = CType(dgFPlan.Items(e.Item.ItemIndex).FindControl("cmbFabric"), DropDownList)
                    Dim txtPieceQtyy As TextBox = CType(dgFPlan.Items(e.Item.ItemIndex).FindControl("txtPieceQtyy"), TextBox)
                    Dim txtReqMeter As TextBox = CType(dgFPlan.Items(e.Item.ItemIndex).FindControl("txtReqMeter"), TextBox)
                    Dim lblIMSItemID As Label = CType(dgFPlan.Items(e.Item.ItemIndex).FindControl("lblIMSItemID"), Label)
                    Dim FabricdataBaseId As Long = cmbFabric.SelectedValue
                    Dim IMSItemID As Long = lblIMSItemID.Text
                    Dim JobOrderId As Long = lblJobOrderId.Text
                    Session("Con") = dgFPlan.Items(e.Item.ItemIndex).Cells(4).Text
                    Session("PieceQty") = txtPieceQtyy.Text
                    Session("Balance") = txtReqMeter.Text
                    'Response.Write("<script> window.open('FPlanEntryPopup.aspx?lFabricdataBaseId='" & FabricdataBaseId & "'&lJobOrderId='" & JobOrderId & "'', 'newwindow', 'left=450, top=300, height=220, width=450, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")
                    Response.Write("<script> window.open('FPlanEntryPopup.aspx?lFabricdataBaseId=" & FabricdataBaseId & "&lJobOrderId=" & JobOrderId & "&lIMSItemID=" & IMSItemID & "', 'newwindow', 'left=450, top=300, height=500, width=900, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")

                Case "Requisition"
                    Dim lblIMSItemID As Label = CType(dgFPlan.Items(e.Item.ItemIndex).FindControl("lblIMSItemID"), Label)
                    Dim JobOrderId As Long = lblJobOrderId.Text
                    Dim IMSItemID As String = lblIMSItemID.Text
                    Response.Write("<script> window.open('ReqPopup.aspx?JobOrderID=" & JobOrderId & "&IMSItemID=" & IMSItemID & "', 'newwindow', 'left=100, top=180, height=200, width=720, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")



                Case "PDF"



                    Dim FPlanDtlID As Long = dgFPlan.Items(e.Item.ItemIndex).Cells(0).Text
                    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                        System.IO.File.Delete(Uploadedfiles)
                    Next

                    '  Report.Load(Server.MapPath("~/Reports/RequisitionPurchaseOrderReport.rpt"))

                    Report.Load(Server.MapPath("~/Reports/RequisitionPurchaseOrderReport2.rpt"))
                    Report.Refresh()
                    Report.SetParameterValue(0, FPlanDtlID)

                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim FileName As String = "RequisitionPurchaseOrderReport"
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"

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

            End Select
        Catch ex As Exception
        End Try
    End Sub
    Sub inhandcalculate()
        Dim AhandQty As Decimal = 0
        Dim BalnceQty As Decimal = 0
        Dim OpeningBal As Decimal = 0
        Dim x As Integer
        For x = 0 To dgFPlan.Items.Count - 1
            Dim txtInHouse As TextBox = CType(dgFPlan.Items(x).FindControl("txtInHouse"), TextBox)
            Dim txtBalanceQty As TextBox = CType(dgFPlan.Items(x).FindControl("txtBalanceQty"), TextBox)
            Dim imgcalculate As ImageButton = CType(dgFPlan.Items(x).FindControl("imgcalculate"), ImageButton)
            OpeningBal = dgFPlan.Items(x).Cells(8).Text
            AhandQty = Val(txtInHouse.Text)
            If AhandQty > OpeningBal Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Inhand Qty is Greater")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                BalnceQty = OpeningBal - AhandQty
                txtBalanceQty.Text = BalnceQty
            End If

        Next
    End Sub
    Sub Stockcalculate()
        Dim inhandQty As Decimal = 0
        Dim StockQty As Decimal = 0
        Dim issueQty As Decimal = 0

        Dim x As Integer
        For x = 0 To dgFPlan.Items.Count - 1
            Dim txtInHouse As TextBox = CType(dgFPlan.Items(x).FindControl("txtInHouse"), TextBox)
            Dim txtIssueQty As TextBox = CType(dgFPlan.Items(x).FindControl("txtIssueQty"), TextBox)
            Dim txtStockQty As TextBox = CType(dgFPlan.Items(x).FindControl("txtStockQty"), TextBox)

            inhandQty = Val(txtInHouse.Text)
            issueQty = Val(txtIssueQty.Text)
            If issueQty > inhandQty Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Issue Qty is Greater")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                issueQty = inhandQty - issueQty
                txtStockQty.Text = issueQty
            End If

        Next
    End Sub
    Protected Sub SaveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        Try
            savedata()
            Response.Redirect("Fabric.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Sub savedata()
        With ObjFPlanMst
            If lblFPlanMst.Text = "" Then
                .FPlanMstID = 0
            Else
                .FPlanMstID = lblFPlanMst.Text
            End If
            .JobOrderId = lblJobOrderId.Text
            .JobOrderNo = txtJobOrder.Text
            .RecvDate = txtRecvDate.Text
            .ShipDate = txtShipDate.Text
            .Season = txtSeason.Text
            .Buyer = txtBuyer.Text
            .Brand = txtBrand.Text
            .Item = txtItem.Text
            .Content = txtContent.Text
            .Quantity = txtQty.Text
            .TotalFabric = txtTotalFabric.Text
            .Cons = txtConsumption.Text
            .Percent = txtPrecentage.Text
            .SaveFPlanMst()
        End With

        Dim x As Integer
        For x = 0 To dgFPlan.Items.Count - 1
            Dim cmbFabric As DropDownList = CType(dgFPlan.Items(x).FindControl("cmbFabric"), DropDownList)
            Dim cmbStyle As DropDownList = CType(dgFPlan.Items(x).FindControl("cmbStyle"), DropDownList)
            Dim txtWidth As TextBox = CType(dgFPlan.Items(x).FindControl("txtWidth"), TextBox)
            'Dim txtInHouse As TextBox = CType(dgFPlan.Items(x).FindControl("txtInHouse"), TextBox)
            'Dim txtIssueQty As TextBox = CType(dgFPlan.Items(x).FindControl("txtIssueQty"), TextBox)
            'Dim txtStockQty As TextBox = CType(dgFPlan.Items(x).FindControl("txtStockQty"), TextBox)
            'Dim txtBalanceQty As TextBox = CType(dgFPlan.Items(x).FindControl("txtBalanceQty"), TextBox)
            Dim lblIMSItemID As Label = CType(dgFPlan.Items(x).FindControl("lblIMSItemID"), Label)
            Dim txtPieceQtyy As TextBox = CType(dgFPlan.Items(x).FindControl("txtPieceQtyy"), TextBox)
            Dim txtReqMeter As TextBox = CType(dgFPlan.Items(x).FindControl("txtReqMeter"), TextBox)

            With ObjFPlanDtl
                .FPlanDtlID = dgFPlan.Items(x).Cells(0).Text
                If lblFPlanMst.Text = "" Then
                    .FPlanMstID = ObjFPlanMst.GetID
                Else
                    .FPlanMstID = lblFPlanMst.Text
                End If
                .FabricdataBaseId = cmbFabric.SelectedValue
                .Width = txtWidth.Text
                .Consumption = dgFPlan.Items(x).Cells(4).Text
                If txtReqMeter.Text = "" Then
                    .ReqMeter = 0 'dgFPlan.Items(x).Cells(4).Text
                Else
                    .ReqMeter = txtReqMeter.Text  'dgFPlan.Items(x).Cells(4).Text
                End If

                .ReqDate = dgFPlan.Items(x).Cells(7).Text
                If txtPieceQtyy.Text = "" Then
                    .PieceQty = 0  'dgFPlan.Items(x).Cells(15).Text
                Else
                    .PieceQty = txtPieceQtyy.Text 'dgFPlan.Items(x).Cells(15).Text
                End If
                .IMSItemID = lblIMSItemID.Text
                .ReqStatus = dgFPlan.Items(x).Cells(10).Text
                '.PieceQty = dgFPlan.Items(x).Cells(9).Text
                .Style = cmbStyle.SelectedItem.Text
                .SaveFPlanDtl()
            End With
        Next

    End Sub

    'Protected Sub txtReqDate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtReqDate.TextChanged
    '    Try
    '        Dim reqdate As Date = txtReqDate.Text
    '        Dim Shipdate As Date = txtShipDate.Text
    '        If reqdate <= Shipdate Then
    '            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
    '        Else
    '            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Required Date is Greater than Ship Date ")
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Protected Sub txtConsumption_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtConsumption.TextChanged
        Try
            If Val(txtPrecentage.Text) > 0 Then

                Dim value As Decimal = 0
                Dim tvalue As Decimal = 0

                value = Val(txtConsumption.Text) * Val(txtQty.Text)
                tvalue = (value * Val(txtPrecentage.Text)) / 100
                txtTotalFabric.Text = value + tvalue
            Else
                txtConsumptionQty.Text = Val(txtConsumption.Text) * Val(txtQty.Text)
                txtTotalFabric.Text = ""
            End If
            'Dim value As Decimal = 0
            'Dim tvalue As Decimal = 0

            ' value = (txtConsumption.Text) * Val(txtQty.Text)
            'tvalue = (value * 3) / 100
            'txtTotalFabric.Text = value + tvalue
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnAddmore_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddmore.Click
        Try

            Dim x As Integer
            'For x = 0 To dgFPlan.Items.Count - 1
            '    Dim txtInHouse As TextBox = CType(dgFPlan.Items(x).FindControl("txtInHouse"), TextBox)
            '    Dim imgcalculate As ImageButton = CType(dgFPlan.Items(x).FindControl("imgcalculate"), ImageButton)

            '    imgcalculate.Enabled = False
            '    txtInHouse.ReadOnly = True
            '    txtInHouse.Enabled = False

            'Next
            'Dim balance As Decimal
            For x = 0 To dgFPlan.Items.Count - 1
                '  Dim txtBalanceQty As TextBox = CType(dgFPlan.Items(dgFPlan.Items.Count - 1).FindControl("txtBalanceQty"), TextBox)
                Dim cmbFabric As DropDownList = CType(dgFPlan.Items(dgFPlan.Items.Count - 1).FindControl("cmbFabric"), DropDownList)
                Dim cmbstyle As DropDownList = CType(dgFPlan.Items(dgFPlan.Items.Count - 1).FindControl("cmbstyle"), DropDownList)
                If cmbFabric.SelectedValue = 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Fabric")
                ElseIf cmbstyle.SelectedItem.Text = "Select" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Style")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    If Val(lblReqMeter.Text) < Val(txtTotalFabric.Text) Then

                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                        AddNewRowToGrid()
                    Else
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Quantity Full")
                    End If
                End If
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub AddNewRowToGrid()
        Dim rowIndex As Integer = 0

        If Session("dtFPlan") IsNot Nothing Then
            Dim dtFPlan As DataTable = DirectCast(Session("dtFPlan"), DataTable)
            Dim dr As DataRow = Nothing
            If dtFPlan.Rows.Count > 0 Then
                For i As Integer = 1 To dtFPlan.Rows.Count
                    'extract the TextBox values
                    Dim cmbFabric As DropDownList = CType(dgFPlan.Items(rowIndex).FindControl("cmbFabric"), DropDownList)
                    Dim cmbStyle As DropDownList = CType(dgFPlan.Items(rowIndex).FindControl("cmbStyle"), DropDownList)
                    Dim txtWidth As TextBox = CType(dgFPlan.Items(rowIndex).FindControl("txtWidth"), TextBox)
                    'Dim txtInHouse As TextBox = CType(dgFPlan.Items(rowIndex).FindControl("txtInHouse"), TextBox)
                    ' Dim txtBalanceQty As TextBox = CType(dgFPlan.Items(rowIndex).FindControl("txtBalanceQty"), TextBox)
                    'Dim txtIssueQty As TextBox = CType(dgFPlan.Items(rowIndex).FindControl("txtIssueQty"), TextBox)
                    Dim txtReqMeter As TextBox = CType(dgFPlan.Items(rowIndex).FindControl("txtReqMeter"), TextBox)

                    Dim txtPieceQtyy As TextBox = CType(dgFPlan.Items(rowIndex).FindControl("txtPieceQtyy"), TextBox)
                    Dim lblIMSItemID As Label = CType(dgFPlan.Items(rowIndex).FindControl("lblIMSItemID"), Label)
                    Dim FPlanDtlID As String = dgFPlan.Items(rowIndex).Cells(0).Text

                    'Dim FabricdataBaseId As String = dgFPlan.Items(rowIndex).Cells(1).Text
                    'Dim FabricCode As String = dgFPlan.Items(rowIndex).Cells(2).Text
                    'Dim Weave As String = dgFPlan.Items(rowIndex).Cells(3).Text
                    'Dim GSM As String = dgFPlan.Items(rowIndex).Cells(4).Text
                    'Dim Width As String = dgFPlan.Items(rowIndex).Cells(5).Text
                    ' Dim Composition As String = dgFPlan.Items(rowIndex).Cells(6).Text
                    Dim Consumption As String = dgFPlan.Items(rowIndex).Cells(4).Text
                    'Dim ReqMeter As String = dgFPlan.Items(rowIndex).Cells(4).Text
                    'Dim PieceQty As String = dgFPlan.Items(rowIndex).Cells(9).Text
                    Dim ReqDatee As String = dgFPlan.Items(rowIndex).Cells(7).Text
                    Dim ReqStatus As String = dgFPlan.Items(rowIndex).Cells(10).Text
                    dr = dtFPlan.NewRow()
                    dr("FPlanDtlID") = FPlanDtlID
                    'dr("RowNumber") = i + 1
                    'dr("FabricdataBaseId") = FabricdataBaseId
                    'dr("FabricCode") = FabricCode
                    'dr("Weave") = Weave
                    'dr("GSM") = GSM
                    'dr("Width") = Width
                    'dr("Composition") = Composition
                    dr("Consumption") = Consumption
                    'dr("ReqMeter") = ReqMeter
                    'dr("PieceQty") = PieceQty
                    dr("ReqDatee") = ReqDatee
                    dr("ReqStatus") = ReqStatus

                    ' dr("OpeningBal") = txtBalanceQty.Text
                    dtFPlan.Rows(i - 1)("Width") = txtWidth.Text
                    dtFPlan.Rows(i - 1)("FabricDatabaseID") = cmbFabric.SelectedValue
                    dtFPlan.Rows(i - 1)("ReqMeter") = txtReqMeter.Text

                    dtFPlan.Rows(i - 1)("PieceQty") = txtPieceQtyy.Text
                    dtFPlan.Rows(i - 1)("IMSItemID") = lblIMSItemID.Text
                    dtFPlan.Rows(i - 1)("Style") = cmbStyle.SelectedItem.Text
                    'dtFPlan.Rows(i - 1)("InHandQty") = txtInHouse.Text
                    'dtFPlan.Rows(i - 1)("BalanceQty") = txtBalanceQty.Text
                    'dtFPlan.Rows(i - 1)("IssueQty") = txtIssueQty.Text
                    'dtFPlan.Rows(i - 1)("StockQty") = txtStockQty.Text
                    rowIndex += 1
                Next

                dtFPlan.Rows.Add(dr)
                dtFPlan.Rows(rowIndex)("FPlanDtlID") = 0
                Session("dtFPlan") = dtFPlan

                dgFPlan.DataSource = dtFPlan
                dgFPlan.DataBind()
            End If
        Else
            Response.Write("ViewState is null")
        End If

        'Set Previous Data on Postbacks
        SetPreviousData()
    End Sub
    Private Sub SetPreviousData()
        BindcmbFabric()
        BindcmbStyle()
        Dim rowIndex As Integer = 0
        If Session("dtFPlan") IsNot Nothing Then
            Dim dtFPlan As DataTable = DirectCast(Session("dtFPlan"), DataTable)
            If dtFPlan.Rows.Count > 0 Then
                For i As Integer = 0 To dtFPlan.Rows.Count - 1
                    Dim cmbFabric As DropDownList = CType(dgFPlan.Items(rowIndex).FindControl("cmbFabric"), DropDownList)
                    Dim txtWidth As TextBox = CType(dgFPlan.Items(rowIndex).FindControl("txtWidth"), TextBox)
                    'Dim txtInHouse As TextBox = CType(dgFPlan.Items(rowIndex).FindControl("txtInHouse"), TextBox)
                    'Dim txtBalanceQty As TextBox = CType(dgFPlan.Items(rowIndex).FindControl("txtBalanceQty"), TextBox)
                    'Dim txtIssueQty As TextBox = CType(dgFPlan.Items(rowIndex).FindControl("txtIssueQty"), TextBox)
                    'Dim txtStockQty As TextBox = CType(dgFPlan.Items(rowIndex).FindControl("txtStockQty"), TextBox)

                    Dim txtPieceQtyy As TextBox = CType(dgFPlan.Items(rowIndex).FindControl("txtPieceQtyy"), TextBox)
                    Dim txtReqMeter As TextBox = CType(dgFPlan.Items(rowIndex).FindControl("txtReqMeter"), TextBox)
                    Dim lblIMSItemID As Label = CType(dgFPlan.Items(rowIndex).FindControl("lblIMSItemID"), Label)
                    Dim cmbStyle As DropDownList = CType(dgFPlan.Items(rowIndex).FindControl("cmbStyle"), DropDownList)
                    Dim FPlanDtlID As String = dgFPlan.Items(rowIndex).Cells(0).Text
                    ' Dim FabricdataBaseId As String = dgFPlan.Items(rowIndex).Cells(1).Text
                    'Dim FabricCode As String = dgFPlan.Items(rowIndex).Cells(2).Text
                    'Dim Weave As String = dgFPlan.Items(rowIndex).Cells(3).Text
                    ' Dim GSM As String = dgFPlan.Items(rowIndex).Cells(4).Text
                    'Dim Width As String = dgFPlan.Items(rowIndex).Cells(5).Text
                    ' Dim Composition As String = dgFPlan.Items(rowIndex).Cells(6).Text
                    Dim Consumption As String = dgFPlan.Items(rowIndex).Cells(4).Text
                    'Dim ReqMeter As String = dgFPlan.Items(rowIndex).Cells(8).Text
                    'Dim PieceQty As String = dgFPlan.Items(rowIndex).Cells(9).Text
                    Dim ReqDatee As String = dgFPlan.Items(rowIndex).Cells(7).Text
                    Dim ReqStatus As String = dgFPlan.Items(rowIndex).Cells(10).Text
                    cmbFabric.SelectedValue = dtFPlan.Rows(i)("FabricDatabaseID").ToString()
                    txtWidth.Text = dtFPlan.Rows(i)("Width").ToString()
                    ' txtInHouse.Text = dtFPlan.Rows(i)("InHandQty").ToString()
                    'txtBalanceQty.Text = dtFPlan.Rows(i)("BalanceQty").ToString()
                    'txtIssueQty.Text = dtFPlan.Rows(i)("IssueQty").ToString()
                    'txtStockQty.Text = dtFPlan.Rows(i)("StockQty").ToString()
                    txtReqMeter.Text = dtFPlan.Rows(i)("ReqMeter").ToString()

                    txtPieceQtyy.Text = dtFPlan.Rows(i)("PieceQty").ToString()
                    lblIMSItemID.Text = dtFPlan.Rows(i)("IMSItemID").ToString()
                    cmbStyle.SelectedItem.Text = dtFPlan.Rows(i)("Style")

                    rowIndex += 1
                Next

            End If
        End If
    End Sub



    Protected Sub cmbFabric_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim x As Integer = 0
        For x = 0 To dgFPlan.Items.Count - 1
            Dim cmbFabric As DropDownList = CType(dgFPlan.Items(x).FindControl("cmbFabric"), DropDownList)
            Dim Dt As DataTable
            Dt = ObjFPlanMst.GetFabricData(cmbFabric.SelectedValue)
            'Dt = ObjFPlanMst.GetSizee(cmbProduct.SelectedValue)
            Dim txtWidth As TextBox = CType(dgFPlan.Items(x).FindControl("txtWidth"), TextBox)
            Dim lblIMSItemID As Label = CType(dgFPlan.Items(x).FindControl("lblIMSItemID"), Label)

            ' Dim lblFabricdataBaseId As Label = CType(dgFPlan.Items(x).FindControl("lblFabricdataBaseId"), Label)
            If txtWidth IsNot Nothing Then
                txtWidth.Text = Dt.Rows(0)("Width")
                lblIMSItemID.Text = Dt.Rows(0)("IMSItemID")
                'lblFabricdataBaseId.Text = Dt.Rows(0)("FabricdataBaseId")
                'cmbSize.DataSource = Dt
                'cmbSize.DataTextField = "SizeDirection"
                'cmbSize.DataValueField = "ProductDatabaseDetailID"
                'cmbSize.DataSource = Dt
                'cmbSize.DataBind()
                'cmbSize.Items.Insert(0, New ListItem("Select", "0"))
            End If

            'Dim dtt As DataTable = DirectCast(Session("CurrentTable"), DataTable)
            'If dtt.Rows.Count > 0 Then
            '    If cmbProduct.SelectedValue = dtt.Rows(x)("Column2").ToString() Then
            '        cmbSize.SelectedValue = dtt.Rows(x)("Column5").ToString()
            '    Else

            '    End If
            'Else
            'End If
            'If cmbProduct.SelectedValue <> 0 And cmbSize.SelectedValue = "" Then
            '    If cmbSize IsNot Nothing Then
            '        cmbSize.DataSource = Dt
            '        cmbSize.DataTextField = "Sizee"
            '        cmbSize.DataValueField = "ProductDatabaseDetailID"
            '        cmbSize.DataBind()
            '        cmbSize.DataSource = Dt
            '        cmbSize.Items.Insert(0, New ListItem("Select Size..", "0"))
            '    End If
            'End If
        Next
    End Sub

    Protected Sub txtPieceQtyy_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim x As Integer = 0
            Dim Pieaceqty As Decimal = 0
            Dim ReqMeter2 As Decimal = 0
            Dim tvalue As Decimal = 0
            Dim value As Decimal = 0
            For x = 0 To dgFPlan.Items.Count - 1

                Dim PieceQtyy As Decimal = 0
                Dim ReqMeter As Decimal = 0
                Dim txtPieceQtyy As TextBox = CType(dgFPlan.Items(x).FindControl("txtPieceQtyy"), TextBox)
                Dim txtReqMeter As TextBox = CType(dgFPlan.Items(x).FindControl("txtReqMeter"), TextBox)
                If lblPieaceQty.Text = "" Then
                    'lblPieaceQty.Text = 0
                    If Val(Pieaceqty) + Val(txtPieceQtyy.Text) > Val(txtQty.Text) Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Pieace Qty Is Greater")

                    Else
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                        PieceQtyy = txtPieceQtyy.Text
                        value = PieceQtyy * Val(dgFPlan.Items(x).Cells(4).Text)
                        tvalue = (value * Val(txtPrecentage.Text)) / 100
                        ReqMeter = value + tvalue 'PieceQtyy * Val(dgFPlan.Items(x).Cells(3).Text)
                        txtReqMeter.Text = ReqMeter 'Val(txtPieceQtyy.Text) * Val(dgFPlan.Items(x).Cells(7).Text)
                        Pieaceqty = Pieaceqty + Val(txtPieceQtyy.Text)
                        ReqMeter2 = ReqMeter2 + Val(txtReqMeter.Text)
                        lblPieaceQty.Text = Pieaceqty
                        lblReqMeter.Text = ReqMeter2
                    End If

                Else

                    If Val(Pieaceqty) + Val(txtPieceQtyy.Text) > Val(txtQty.Text) Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Pieace Qty Is Greater")

                    Else
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                        PieceQtyy = txtPieceQtyy.Text
                        value = PieceQtyy * Val(dgFPlan.Items(x).Cells(4).Text)
                        tvalue = (value * Val(txtPrecentage.Text)) / 100
                        ReqMeter = value + tvalue 'PieceQtyy * Val(dgFPlan.Items(x).Cells(3).Text)
                        txtReqMeter.Text = ReqMeter 'Val(txtPieceQtyy.Text) * Val(dgFPlan.Items(x).Cells(7).Text)
                        Pieaceqty = Pieaceqty + Val(txtPieceQtyy.Text)
                        ReqMeter2 = ReqMeter2 + Val(txtReqMeter.Text)
                        lblPieaceQty.Text = Pieaceqty
                        lblReqMeter.Text = ReqMeter2
                    End If

                End If

            Next


            'Dim a As Integer
            'For a = 0 To dgFPlan.Items.Count - 1
            '    Dim txtPieceQtyy As TextBox = CType(dgFPlan.Items(a).FindControl("txtPieceQtyy"), TextBox)
            '    Dim txtReqMeter As TextBox = CType(dgFPlan.Items(a).FindControl("txtReqMeter"), TextBox)

            'Next


        Catch ex As Exception

        End Try
    End Sub

    Protected Sub txtPrecentage_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPrecentage.TextChanged
        Try
            Dim value As Decimal = 0
            Dim tvalue As Decimal = 0

            value = Val(txtConsumption.Text) * Val(txtQty.Text)
            tvalue = (value * Val(txtPrecentage.Text)) / 100
            txtTotalFabric.Text = value + tvalue

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub LinkFabricPopup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkFabricPopup.Click
        Try
            Response.Write("<script> window.open('FabricDataBasePopup.aspx', 'newwindow', 'left=100, top=180, height=300, width=850, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnShow_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnShow.Click
        Try
            BindcmbFabric()
            Dim dtFPlan As DataTable = DirectCast(Session("dtFPlan"), DataTable)
            If dtFPlan.Rows.Count > 0 Then
                For i As Integer = 0 To dtFPlan.Rows.Count - 1
                    Dim cmbFabric As DropDownList = CType(dgFPlan.Items(i).FindControl("cmbFabric"), DropDownList)
                    cmbFabric.SelectedValue = dtFPlan.Rows(i)("FabricDatabaseID").ToString()
                Next
            End If


        Catch ex As Exception

        End Try
    End Sub
End Class

Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Public Class AccPlanEntryNewSF
    Inherits System.Web.UI.Page
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim ObjAccessPlanMst As New AccessoriesePlanMst
    Dim ObjAccessPlanDtl As New AccessoriesePlanDtl
    Dim JobOrderID As Long
    Dim jOBdT, dtDetail, dtFPlan As DataTable
    Dim AccessPlanDt As DataTable
    Dim dr As DataRow
    Dim ObjFPlanDtl As New FPlanDtl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        JobOrderID = Request.QueryString("JobOrderID")
        If Not Page.IsPostBack Then

            lblJobOrderId.Text = JobOrderID
            Session("dtDetail") = Nothing
            Session("dtFPlan") = Nothing
            Dim x As Integer
            Dim Pieaceqty As Decimal = 0
            AccessPlanDt = ObjAccessPlanMst.GetAccessPLANdetail(JobOrderID)
            If AccessPlanDt.Rows.Count > 0 Then
                Session("dtFPlan") = AccessPlanDt
                lblAccessPlanMst.Text = AccessPlanDt.Rows(0)("AccessoriesePlanMstID")
                'Session("FileName") = AccessPlanDt.Rows(0)("FileName")
                Session("UploadPicture") = AccessPlanDt.Rows(0)("UploadPicture")
                BindGridFPlan()
                btnsave.Visible = False
                BindcmbAccosseries()
                BindUOM2()
                BindcmbStyle()
                For x = 0 To dgACPlan.Items.Count - 1

                    Dim cmbAccosires As DropDownList = CType(dgACPlan.Items(x).FindControl("cmbAccosires"), DropDownList)
                    Dim cmbStyle As DropDownList = CType(dgACPlan.Items(x).FindControl("cmbStyle"), DropDownList)
                    Dim ddlUOM2 As DropDownList = CType(dgACPlan.Items(x).FindControl("ddlUOM2"), DropDownList)
                    Dim txtPercentage As TextBox = CType(dgACPlan.Items(x).FindControl("txtPercentage"), TextBox)
                    Dim txtPerPcsAvg As TextBox = CType(dgACPlan.Items(x).FindControl("txtPerPcsAvg"), TextBox)
                    Dim txtQuantity As TextBox = CType(dgACPlan.Items(x).FindControl("txtQuantity"), TextBox)
                    Dim txtRemarks As TextBox = CType(dgACPlan.Items(x).FindControl("txtRemarks"), TextBox)
                    Dim txtColorName As TextBox = CType(dgACPlan.Items(x).FindControl("txtColorName"), TextBox)
                    Dim txtAccessoriesName As TextBox = CType(dgACPlan.Items(x).FindControl("txtAccessoriesName"), TextBox)
                    Dim Image2 As Image = CType(dgACPlan.Items(x).FindControl("Image2"), Image)
                    txtColorName.Text = AccessPlanDt.Rows(x)("ColorName")

                    txtAccessoriesName.Text = AccessPlanDt.Rows(x)("AccessoriesName")
                    cmbAccosires.SelectedValue = AccessPlanDt.Rows(x)("AccessoriesID")
                    Dim FName As String = ""
                    Dim DtacsImage = ObjAccessPlanMst.GetAccessorieseDatabyclass(cmbAccosires.SelectedValue)
                    Dim bytes As Byte() = DtacsImage.Rows(0)("UploadPicture")
                    Dim base64String As String = Convert.ToBase64String(bytes, 0, bytes.Length)
                    Image2.ImageUrl = "data:image/png;base64," & base64String
                    Image2.Visible = True
                    Session("ImageByte") = bytes
                    txtPercentage.Text = AccessPlanDt.Rows(x)("Percentage")
                    ddlUOM2.SelectedValue = AccessPlanDt.Rows(x)("UOMID")
                    txtPerPcsAvg.Text = AccessPlanDt.Rows(x)("PerPcsAvg")
                    txtQuantity.Text = AccessPlanDt.Rows(x)("Qty")
                    cmbStyle.SelectedItem.Text = AccessPlanDt.Rows(x)("Style")
                    txtRemarks.Text = AccessPlanDt.Rows(x)("Remarks")
                    Pieaceqty = Pieaceqty + Val(txtQuantity.Text)
                    lblPieaceQty.Text = Pieaceqty

                Next
                SaveButton.Visible = True
                lblGrandTotal.Visible = True
                btnAddmore.Visible = True

            End If
            BindAccessorieseCode()
            FillMasterdate()

        End If

    End Sub
    Sub FillMasterdate()
        jOBdT = ObjAccessPlanMst.GetJobOrderData(JobOrderID)

        txtJobOrder.Text = jOBdT.Rows(0)("SRNo")
        txtBrand.Text = jOBdT.Rows(0)("Brand")
        txtBuyer.Text = jOBdT.Rows(0)("CustomerName")
        txtContent.Text = jOBdT.Rows(0)("Content")
        txtItem.Text = jOBdT.Rows(0)("ItemName")
        txtSeason.Text = jOBdT.Rows(0)("SeasonName")
        txtQty.Text = jOBdT.Rows(0)("Qty")
        txtRecvDate.Text = jOBdT.Rows(0)("ReceivedDate")
        txtShipDate.Text = jOBdT.Rows(0)("ShipmentDate")
        Dim shipdate As Date = txtShipDate.Text
        Dim ReqDate As Date = shipdate.AddDays(-20)

        'txtReqDate.Text = ReqDate

    End Sub
    Sub BindUOM2()
        Dim x As Integer = 0
        For x = 0 To dgACPlan.Items.Count - 1
            Dim ddlUOM2 As DropDownList = CType(dgACPlan.Items(x).FindControl("ddlUOM2"), DropDownList)
            Dim dt As DataTable
            dt = ObjAccessPlanMst.GetUOM()
            ddlUOM2.DataSource = dt
            ddlUOM2.DataTextField = "UOMName"
            ddlUOM2.DataValueField = "UOMID"
            ddlUOM2.DataBind()
            ddlUOM2.Items.Insert(0, New ListItem("Select UOM", "0"))
        Next
    End Sub
    Sub BindcmbStyle()
        Dim x As Integer = 0
        For x = 0 To dgACPlan.Items.Count - 1
            Dim cmbstyle As DropDownList = CType(dgACPlan.Items(x).FindControl("cmbstyle"), DropDownList)
            Dim Dt As DataTable
            Dt = ObjAccessPlanMst.GetStyle(JobOrderID)
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
    Sub BindAccessorieseCode()
        Dim dt As DataTable
        dt = ObjAccessPlanMst.GetAccessorieseCode()
        ddlAccessorieseCode.DataSource = dt
        ddlAccessorieseCode.DataTextField = "AccessoriesCode"
        ddlAccessorieseCode.DataValueField = "AccessoriesID"
        ddlAccessorieseCode.DataBind()
        ddlAccessorieseCode.Items.Insert(0, New ListItem("Select Accessories Code", "0"))
    End Sub
    Sub BindcmbAccosseries()
        Dim x As Integer = 0
        For x = 0 To dgACPlan.Items.Count - 1
            Dim cmbAccosires As DropDownList = CType(dgACPlan.Items(x).FindControl("cmbAccosires"), DropDownList)
            Dim Dt As DataTable
            Dt = ObjAccessPlanMst.GetAccessory()
            If cmbAccosires IsNot Nothing Then
                cmbAccosires.DataSource = Dt
                cmbAccosires.DataTextField = "Accessories"
                cmbAccosires.DataValueField = "AccessoriesID" '    "ProductDatabaseID"
                cmbAccosires.DataBind()
                cmbAccosires.DataSource = Dt
                cmbAccosires.Items.Insert(0, New ListItem("Select..", "0"))
            End If
        Next
    End Sub
    Sub SaveSessionFirst()
        If (Not CType(Session("dtFPlan"), DataTable) Is Nothing) Then
            dtFPlan = Session("dtFPlan")
        Else
            dtFPlan = New DataTable
            With dtFPlan
                .Columns.Add("AccessoriesePlanDtlID", GetType(Long))
                .Columns.Add("AccessoriesID", GetType(String))
                .Columns.Add("AccessoriesName", GetType(String))
                .Columns.Add("ColorName", GetType(String))
                .Columns.Add("Style", GetType(String))
                .Columns.Add("UploadPicture", GetType(String))
                .Columns.Add("Percentage", GetType(String))
                .Columns.Add("PerPcsAvg", GetType(String))
                .Columns.Add("Qty", GetType(String))
                .Columns.Add("Remarks", GetType(String))
                .Columns.Add("UOMID", GetType(String))
                .Columns.Add("AccReqStatus", GetType(String))

            End With
        End If

        Dim dt As DataTable = ObjAccessPlanMst.GetAccessorieseData(ddlAccessorieseCode.SelectedValue)
        dr = dtFPlan.NewRow()
        dr("AccessoriesePlanDtlID") = 0
        dr("AccessoriesID") = String.Empty
        dr("AccessoriesName") = String.Empty
        dr("ColorName") = String.Empty
        dr("Style") = String.Empty
        dr("UploadPicture") = String.Empty
        dr("Percentage") = String.Empty
        dr("PerPcsAvg") = String.Empty
        dr("Qty") = String.Empty
        dr("Remarks") = String.Empty
        dr("UOMID") = String.Empty
        dr("AccReqStatus") = 0
        dtFPlan.Rows.Add(dr)
        Session("dtFPlan") = dtFPlan
        BindGridFPlan()
        BindcmbAccosseries()
        BindUOM2()
        BindcmbStyle()
    End Sub
    Private Sub BindGridFPlan()
        dtFPlan = Session("dtFPlan")
        Dim objDataview As New DataView(dtFPlan)
        dgACPlan.RecordCount = objDataview.Count
        dgACPlan.DataSource = objDataview
        dgACPlan.DataBind()
    End Sub
    Protected Sub dgACPlan_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgACPlan.ItemCommand
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


                    Dim tblFPlanDtlID As Long = dgACPlan.Items(e.Item.ItemIndex).Cells(0).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    dtDetail = CType(Session("dtDetail"), DataTable)
                    If (Not dtDetail Is Nothing) Then
                        If (dtDetail.Rows.Count > 0) Then
                            Dim ltblBankDtlID As Integer = dgACPlan.Items(e.Item.ItemIndex).Cells(0).Text
                            dtDetail.Rows.RemoveAt(e.Item.ItemIndex)
                            'ObjFPlanMst.DeleteDetail(ltblBankDtlID)
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
                    Dim cmbAccosires As DropDownList = CType(dgACPlan.Items(e.Item.ItemIndex).FindControl("cmbAccosires"), DropDownList)
                    'Dim txtPieceQtyy As TextBox = CType(dgACPlan.Items(e.Item.ItemIndex).FindControl("txtPieceQtyy"), TextBox)
                    Dim txtReqQTY As TextBox = CType(dgACPlan.Items(e.Item.ItemIndex).FindControl("txtReqQTY"), TextBox)
                    Dim lblIMSItemID As Label = CType(dgACPlan.Items(e.Item.ItemIndex).FindControl("lblIMSItemID"), Label)
                    Dim AccosiresdataBaseId As Long = cmbAccosires.SelectedValue
                    Dim JobOrderId As Long = lblJobOrderId.Text
                    Dim IMSItemID As Long = lblIMSItemID.Text
                    Session("Accosires") = cmbAccosires.SelectedItem.Text 'dgFPlan.Items(e.Item.ItemIndex).Cells(3).Text
                    'Session("PieceQty") = txtPieceQtyy.Text
                    Session("Balance") = txtReqQTY.Text


                    ' Response.Write("<script> window.open('APlanEntryPopup.aspx?lAccosiresdataBaseId='" & AccosiresdataBaseId & "'&lJobOrderId='" & JobOrderId & "', 'newwindow', 'left=450, top=300, height=500, width=900, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")
                    Response.Write("<script> window.open('APlanEntryPopup.aspx?lAccosiresdataBaseId=" & AccosiresdataBaseId & "&lJobOrderId=" & JobOrderId & "&lIMSItemID=" & IMSItemID & "', 'newwindow', 'left=450, top=300, height=500, width=900, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")
                    ' Response.Write("<script> window.open('APlanPOPUNew.aspx', 'newwindow', 'left=450, top=300, height=500, width=900, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")


                Case "PDF"



                    Dim AccessoriesePlanDtlID As Long = dgACPlan.Items(e.Item.ItemIndex).Cells(0).Text
                    For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                        System.IO.File.Delete(Uploadedfiles)
                    Next

                    Report.Load(Server.MapPath("~/Reports/RequisitionReportJobOrderAcc.rpt"))
                    Report.Refresh()
                    Report.SetParameterValue(0, AccessoriesePlanDtlID)

                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim FileName As String = "RequisitionReportJobOrderAcc"
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
        For x = 0 To dgACPlan.Items.Count - 1
            Dim txtInHouse As TextBox = CType(dgACPlan.Items(x).FindControl("txtInHouse"), TextBox)
            Dim txtBalanceQty As TextBox = CType(dgACPlan.Items(x).FindControl("txtBalanceQty"), TextBox)
            Dim imgcalculate As ImageButton = CType(dgACPlan.Items(x).FindControl("imgcalculate"), ImageButton)
            OpeningBal = dgACPlan.Items(x).Cells(12).Text
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
        For x = 0 To dgACPlan.Items.Count - 1
            Dim txtInHouse As TextBox = CType(dgACPlan.Items(x).FindControl("txtInHouse"), TextBox)
            Dim txtIssueQty As TextBox = CType(dgACPlan.Items(x).FindControl("txtIssueQty"), TextBox)
            Dim txtStockQty As TextBox = CType(dgACPlan.Items(x).FindControl("txtStockQty"), TextBox)

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

    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Try
            'Dim reqdate As Date = txtReqDate.Text
            Dim Shipdate As Date = txtShipDate.Text
            ' If txtTotalReqQty.Text = "" Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Req Meter")
            ' ElseIf ddlAccessorieseCode.SelectedValue = 0 Then
            'DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Fabric Code ")
            ' ElseIf ddlUOM.SelectedValue = 0 Then
            ' DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select UOM ")
            '' If txtReqDate.Text = "" Then
            'DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Req. Date ")
            'ElseIf reqdate > Shipdate Then
            'DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Required Date is Greater than Ship Date ")
            'Else
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
            SaveSessionFirst()
            clear()
            SaveButton.Visible = True
            btnsave.Visible = False
            lblGrandTotal.Visible = True
            btnAddmore.Visible = True
            'End If
        Catch ex As Exception

        End Try
    End Sub
    Sub clear()
        txtTotalReqQty.Text = ""


    End Sub
    Protected Sub SaveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        Try
            Dim ddlUOM2 As DropDownList = CType(dgACPlan.Items(dgACPlan.Items.Count - 1).FindControl("ddlUOM2"), DropDownList)
            Dim cmbAccosires As DropDownList = CType(dgACPlan.Items(dgACPlan.Items.Count - 1).FindControl("cmbAccosires"), DropDownList)
            Dim cmbStyle As DropDownList = CType(dgACPlan.Items(dgACPlan.Items.Count - 1).FindControl("cmbStyle"), DropDownList)
            Dim txtPercentage As TextBox = CType(dgACPlan.Items(dgACPlan.Items.Count - 1).FindControl("txtPercentage"), TextBox)
            Dim txtPerPcsAvg As TextBox = CType(dgACPlan.Items(dgACPlan.Items.Count - 1).FindControl("txtPerPcsAvg"), TextBox)

            If cmbStyle.SelectedItem.Text = "Select" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Style")
            ElseIf txtPercentage.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("% Empty")
            ElseIf txtPerPcsAvg.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Per Pcs Avg Empty")
            ElseIf ddlUOM2.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select UOM")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                savedata()
                Response.Redirect("Fabric.aspx")
            End If



        Catch ex As Exception

        End Try
    End Sub
    Sub savedata()
        With ObjAccessPlanMst
            If lblAccessPlanMst.Text = "" Then
                .AccessoriesePlanMstID = 0
            Else
                .AccessoriesePlanMstID = lblAccessPlanMst.Text
            End If
            .JobOrderId = lblJobOrderId.Text
            .JobOrderNo = txtJobOrder.Text
            .RecvDate = txtRecvDate.Text
            .ShipDate = txtShipDate.Text
            .Season = txtSeason.Text
            .Buyer = txtBuyer.Text
            .Brand = txtBrand.Text
            .Content = txtContent.Text
            .Quantity = txtQty.Text
            .SaveAccessoriesePlanMst()
        End With

        Dim x As Integer
        For x = 0 To dgACPlan.Items.Count - 1
            Dim cmbAccosires As DropDownList = CType(dgACPlan.Items(x).FindControl("cmbAccosires"), DropDownList)
            Dim cmbStyle As DropDownList = CType(dgACPlan.Items(x).FindControl("cmbStyle"), DropDownList)
            Dim ddlUOM2 As DropDownList = CType(dgACPlan.Items(x).FindControl("ddlUOM2"), DropDownList)
            Dim txtPercentage As TextBox = CType(dgACPlan.Items(x).FindControl("txtPercentage"), TextBox)
            Dim txtPerPcsAvg As TextBox = CType(dgACPlan.Items(x).FindControl("txtPerPcsAvg"), TextBox)
            Dim txtQuantity As TextBox = CType(dgACPlan.Items(x).FindControl("txtQuantity"), TextBox)
            Dim txtRemarks As TextBox = CType(dgACPlan.Items(x).FindControl("txtRemarks"), TextBox)
            With ObjAccessPlanDtl
                .AccessoriesePlanDtlID = dgACPlan.Items(x).Cells(0).Text
                If lblAccessPlanMst.Text = "" Then
                    .AccessoriesePlanMstID = ObjAccessPlanMst.GetID
                Else
                    .AccessoriesePlanMstID = lblAccessPlanMst.Text
                End If
                .AccessoriesID = cmbAccosires.SelectedValue
                .Style = cmbStyle.SelectedItem.Text
                .Percentage = Val(txtPercentage.Text)
                .PerPcsAvg = Val(txtPerPcsAvg.Text)
                .Qty = Val(txtQuantity.Text)
                .Remarks = txtRemarks.Text
                .UOMID = ddlUOM2.SelectedValue
                .AccReqStatus = dgACPlan.Items(x).Cells(11).Text
                .SaveAccessoriesePlanDtl()
            End With
        Next

    End Sub

    Protected Sub btnAddmore_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddmore.Click
        Try

            Dim x As Integer
            'For x = 0 To dgACPlan.Items.Count - 1
            '    Dim txtInHouse As TextBox = CType(dgACPlan.Items(x).FindControl("txtInHouse"), TextBox)
            '    Dim imgcalculate As ImageButton = CType(dgACPlan.Items(x).FindControl("imgcalculate"), ImageButton)

            '    imgcalculate.Enabled = False
            '    txtInHouse.ReadOnly = True
            '    txtInHouse.Enabled = False

            'Next
            Dim balance As Decimal
            '   For x = 0 To dgACPlan.Items.Count - 1
            'Dim txtBalanceQty As TextBox = CType(dgACPlan.Items(dgACPlan.Items.Count - 1).FindControl("txtBalanceQty"), TextBox)
            Dim cmbAccosires As DropDownList = CType(dgACPlan.Items(dgACPlan.Items.Count - 1).FindControl("cmbAccosires"), DropDownList)
            Dim cmbStyle As DropDownList = CType(dgACPlan.Items(dgACPlan.Items.Count - 1).FindControl("cmbStyle"), DropDownList)
            Dim txtPercentage As TextBox = CType(dgACPlan.Items(dgACPlan.Items.Count - 1).FindControl("txtPercentage"), TextBox)
            Dim txtPerPcsAvg As TextBox = CType(dgACPlan.Items(dgACPlan.Items.Count - 1).FindControl("txtPerPcsAvg"), TextBox)
            Dim ddlUOM2 As DropDownList = CType(dgACPlan.Items(dgACPlan.Items.Count - 1).FindControl("ddlUOM2"), DropDownList)
            ' balance = txtBalanceQty.Text
            'If balance > 0 Then
            If cmbAccosires.SelectedValue > 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")

                ' If Val(lblPieaceQty.Text) < Val(txtQty.Text) Then
                '   DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                If cmbStyle.SelectedItem.Text = "Select" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Style")
                ElseIf txtPercentage.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("% Empty")
                ElseIf txtPerPcsAvg.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Per Pcs Avg Empty")
                ElseIf ddlUOM2.SelectedValue = 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select UOM")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                    AddNewRowToGrid()
                End If


                '  Else
                '     DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Quantity Full")
                '   End If

            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Select Accessories")
            End If

            'Else
            'DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Can Not Be More Add  Balance Qty Is Zero")
            'End If
            ' Next

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
                    Dim cmbAccosires As DropDownList = CType(dgACPlan.Items(rowIndex).FindControl("cmbAccosires"), DropDownList)
                    Dim cmbStyle As DropDownList = CType(dgACPlan.Items(rowIndex).FindControl("cmbStyle"), DropDownList)
                    Dim Image2 As Image = CType(dgACPlan.Items(rowIndex).FindControl("Image2"), Image)
                    Dim txtAccessoriesName As TextBox = CType(dgACPlan.Items(rowIndex).FindControl("txtAccessoriesName"), TextBox)
                    Dim txtColorName As TextBox = CType(dgACPlan.Items(rowIndex).FindControl("txtColorName"), TextBox)
                    Dim txtPercentage As TextBox = CType(dgACPlan.Items(rowIndex).FindControl("txtPercentage"), TextBox)
                    Dim txtPerPcsAvg As TextBox = CType(dgACPlan.Items(rowIndex).FindControl("txtPerPcsAvg"), TextBox)
                    Dim txtQuantity As TextBox = CType(dgACPlan.Items(rowIndex).FindControl("txtQuantity"), TextBox)
                    Dim txtRemarks As TextBox = CType(dgACPlan.Items(rowIndex).FindControl("txtRemarks"), TextBox)
                    Dim ddlUOM2 As DropDownList = CType(dgACPlan.Items(rowIndex).FindControl("ddlUOM2"), DropDownList)
                    Dim AccessoriesePlanDtlID As String = dgACPlan.Items(rowIndex).Cells(0).Text
                    Dim AccReqStatus As String = dgACPlan.Items(rowIndex).Cells(11).Text
                    dr = dtFPlan.NewRow()
                    dr("AccessoriesePlanDtlID") = AccessoriesePlanDtlID
                    dr("AccReqStatus") = AccReqStatus
                    dtFPlan.Rows(i - 1)("AccessoriesID") = cmbAccosires.SelectedValue
                    dtFPlan.Rows(i - 1)("AccessoriesName") = txtAccessoriesName.Text
                    dtFPlan.Rows(i - 1)("ColorName") = txtColorName.Text
                    dtFPlan.Rows(i - 1)("Style") = cmbStyle.SelectedItem.Text
                    dtFPlan.Rows(i - 1)("UploadPicture") = Session("ImageByte") 'Image2.ImageUrl
                    dtFPlan.Rows(i - 1)("Percentage") = txtPercentage.Text
                    dtFPlan.Rows(i - 1)("PerPcsAvg") = txtPerPcsAvg.Text
                    dtFPlan.Rows(i - 1)("Qty") = txtQuantity.Text
                    dtFPlan.Rows(i - 1)("Remarks") = txtRemarks.Text
                    dtFPlan.Rows(i - 1)("Style") = cmbStyle.SelectedItem.Text
                    dtFPlan.Rows(i - 1)("UOMID") = ddlUOM2.SelectedValue
                    rowIndex += 1
                Next

                dtFPlan.Rows.Add(dr)
                dtFPlan.Rows(rowIndex)("AccessoriesePlanDtlID") = 0
                Session("dtFPlan") = dtFPlan

                dgACPlan.DataSource = dtFPlan
                dgACPlan.DataBind()
            End If
        Else
            Response.Write("ViewState is null")
        End If

        'Set Previous Data on Postbacks
        SetPreviousData()
    End Sub
    Private Sub SetPreviousData()
        BindcmbAccosseries()
        BindUOM2()
        BindcmbStyle()
        Dim rowIndex As Integer = 0
        If Session("dtFPlan") IsNot Nothing Then
            Dim dtFPlan As DataTable = DirectCast(Session("dtFPlan"), DataTable)
            If dtFPlan.Rows.Count > 0 Then
                For i As Integer = 0 To dtFPlan.Rows.Count - 1
                    Dim cmbAccosires As DropDownList = CType(dgACPlan.Items(rowIndex).FindControl("cmbAccosires"), DropDownList)
                    Dim cmbStyle As DropDownList = CType(dgACPlan.Items(rowIndex).FindControl("cmbStyle"), DropDownList)
                    Dim Image2 As Image = CType(dgACPlan.Items(rowIndex).FindControl("Image2"), Image)
                    Dim txtAccessoriesName As TextBox = CType(dgACPlan.Items(rowIndex).FindControl("txtAccessoriesName"), TextBox)
                    Dim txtColorName As TextBox = CType(dgACPlan.Items(rowIndex).FindControl("txtColorName"), TextBox)
                    Dim txtPercentage As TextBox = CType(dgACPlan.Items(rowIndex).FindControl("txtPercentage"), TextBox)
                    Dim txtPerPcsAvg As TextBox = CType(dgACPlan.Items(rowIndex).FindControl("txtPerPcsAvg"), TextBox)
                    Dim txtQuantity As TextBox = CType(dgACPlan.Items(rowIndex).FindControl("txtQuantity"), TextBox)
                    Dim txtRemarks As TextBox = CType(dgACPlan.Items(rowIndex).FindControl("txtRemarks"), TextBox)
                    Dim ddlUOM2 As DropDownList = CType(dgACPlan.Items(rowIndex).FindControl("ddlUOM2"), DropDownList)
                    Dim AccessoriesePlanDtlID As String = dgACPlan.Items(rowIndex).Cells(0).Text
                    Dim AccReqStatus As String = dgACPlan.Items(rowIndex).Cells(11).Text
                    cmbAccosires.SelectedValue = dtFPlan.Rows(i)("AccessoriesID").ToString()
                    txtAccessoriesName.Text = dtFPlan.Rows(i)("AccessoriesName").ToString()
                    txtColorName.Text = dtFPlan.Rows(i)("ColorName").ToString()
                    '----Use for image 
                    Dim FName As String = ""
                    Dim DtacsImage = ObjAccessPlanMst.GetAccessorieseDatabyclass(cmbAccosires.SelectedValue)
                    Dim bytes As Byte() = DtacsImage.Rows(0)("UploadPicture")
                    Dim base64String As String = Convert.ToBase64String(bytes, 0, bytes.Length)
                    Image2.ImageUrl = "data:image/png;base64," & base64String
                    Image2.Visible = True
                    Session("ImageByte") = bytes
                    '---End
                    txtPercentage.Text = dtFPlan.Rows(i)("Percentage").ToString()
                    txtPerPcsAvg.Text = dtFPlan.Rows(i)("PerPcsAvg").ToString()
                    'txtPercentage.Text = dtFPlan.Rows(i)("Percentage").ToString()
                    'txtQty.Text = dtFPlan.Rows(i)("Qty").ToString()
                    txtQuantity.Text = dtFPlan.Rows(i)("Qty").ToString()
                    txtRemarks.Text = dtFPlan.Rows(i)("Remarks").ToString()
                    ddlUOM2.SelectedValue = dtFPlan.Rows(i)("UOMID").ToString()
                    cmbStyle.SelectedItem.Text = dtFPlan.Rows(i)("Style")
                    rowIndex += 1
                Next

            End If
        End If
    End Sub
    Protected Sub cmbAccosires_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim x As Integer = 0
        For x = 0 To dgACPlan.Items.Count - 1
            Dim cmbAccosires As DropDownList = CType(dgACPlan.Items(x).FindControl("cmbAccosires"), DropDownList)
            Dim Dt As DataTable
            Dt = ObjAccessPlanMst.GetAccessorieseDatabyclass(cmbAccosires.SelectedValue)
            Dim Image2 As Image = CType(dgACPlan.Items(x).FindControl("Image2"), Image)
            Dim txtColorName As TextBox = CType(dgACPlan.Items(x).FindControl("txtColorName"), TextBox)
            Dim txtAccessoriesName As TextBox = CType(dgACPlan.Items(x).FindControl("txtAccessoriesName"), TextBox)

            If Image2 IsNot Nothing Then
                '----Use for image 
                Dim FName As String = ""
                Dim bytes As Byte() = Dt.Rows(0)("UploadPicture")
                Dim base64String As String = Convert.ToBase64String(bytes, 0, bytes.Length)
                Image2.ImageUrl = "data:image/png;base64," & base64String
                Image2.Visible = True
                FName = Dt.Rows(0)("FileName")
                Session("FileName") = FName
                Session("ImageByte") = bytes
                '---End
                txtAccessoriesName.Text = Dt.Rows(0)("AccessoriesName")
                txtColorName.Text = Dt.Rows(0)("ColorName")
            End If
        Next
    End Sub






    Protected Sub LinkAccessoriesePopup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkAccessoriesePopup.Click
        Try
            Response.Write("<script> window.open('AccessoriesDataBasePopup.aspx', 'newwindow', 'left=100, top=180, height=350, width=850, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnShow_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnShow.Click
        Try
            BindcmbAccosseries()
            Dim dtFPlan As DataTable = DirectCast(Session("dtFPlan"), DataTable)
            If dtFPlan.Rows.Count > 0 Then
                For i As Integer = 0 To dtFPlan.Rows.Count - 1
                    Dim cmbAccosires As DropDownList = CType(dgACPlan.Items(i).FindControl("cmbAccosires"), DropDownList)
                    cmbAccosires.SelectedValue = dtFPlan.Rows(i)("AccessoriesID").ToString()

                Next
            End If


        Catch ex As Exception

        End Try
    End Sub

    Protected Sub txtPercentage_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim x As Integer
            Dim qty As Decimal = 0
            For x = 0 To dgACPlan.Items.Count - 1
                Dim txtPerPcsAvg As TextBox = CType(dgACPlan.Items(x).FindControl("txtPerPcsAvg"), TextBox)
                Dim txtPercentage As TextBox = CType(dgACPlan.Items(x).FindControl("txtPercentage"), TextBox)
                Dim txtQuantity As TextBox = CType(dgACPlan.Items(x).FindControl("txtQuantity"), TextBox)

                If txtPerPcsAvg.Text = "" Then
                Else
                    txtQuantity.Text = (Val(txtPercentage.Text) * Val(txtQty.Text) / 100) * Val(txtPerPcsAvg.Text)
                    qty = qty + (txtQuantity.Text)
                    lblPieaceQty.Text = qty
                End If
            Next


        Catch ex As Exception

        End Try
    End Sub

    Protected Sub txtPerPcsAvg_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim x As Integer
            Dim qty As Decimal = 0
            For x = 0 To dgACPlan.Items.Count - 1
                Dim txtPerPcsAvg As TextBox = CType(dgACPlan.Items(x).FindControl("txtPerPcsAvg"), TextBox)
                Dim txtPercentage As TextBox = CType(dgACPlan.Items(x).FindControl("txtPercentage"), TextBox)
                Dim txtQuantity As TextBox = CType(dgACPlan.Items(x).FindControl("txtQuantity"), TextBox)

                If txtPercentage.Text = "" Then
                Else
                    txtQuantity.Text = (Val(txtPercentage.Text) * Val(txtQty.Text) / 100) * Val(txtPerPcsAvg.Text)
                    qty = qty + (txtQuantity.Text)
                    lblPieaceQty.Text = qty
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
End Class




Imports System.Data
Imports Integra.classes
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Drawing.Color
Imports System.Drawing.KnownColor
Imports System.Web
Imports System.Reflection
Imports System.Drawing
Imports System
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports BarcodeLib.Barcode
Imports System.Drawing.Text
Imports System.Drawing.Imaging
Public Class StyleAssortmentEntry
    Inherits System.Web.UI.Page
    Dim objStyleAssortmentBarCodeDetail As New StyleAssortmentBarCodeDetail
    Dim objGeneralCode As New GeneralCode
    Dim objStyleAssortmentMaster As New StyleAssortmentMaster
    Dim objStyleAssortmentDetail As New StyleAssortmentDetail
    Dim dtWashingDatabase As New DataTable
    Dim dr As DataRow
    Dim lJobOrderID, lJoborderDetailid, lStyleAssortmentMasterID As Long
    Dim UserId As Long
    Dim DtStyleAssortmentDetail As New DataTable
    Dim dtGrid As New DataTable
    Dim Styles As String
    Dim RoleID As Long
    Dim objStyleAccessoriesList As New StyleAccessoriesList
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lJobOrderID = Request.QueryString("JobOrderID")
        lJoborderDetailid = Request.QueryString("JoborderDetailid")
        lStyleAssortmentMasterID = Request.QueryString("StyleAssortmentMasterID")
        Styles = Request.QueryString("Styles")
        UserId = Session("UserId")
        RoleID = Session("RoleId")
        If Not IsPostBack Then
            Session("dtGrid") = Nothing
            BindGender()
            BindBreakup()
            GetMasterData()
            getExtraQty()
            If lStyleAssortmentMasterID > 0 Then
                GetForEdit()
                btnDeleteAssortment.Visible = True
                btnsave.Text = "Update"
                btnsave.Visible = True
                dgStyleAssortment.Columns(9).Visible = True
                If RoleID = 42 Then
                    dgStyleAssortment.Columns(10).Visible = True
                Else
                    dgStyleAssortment.Columns(10).Visible = False
                End If
            Else
                dgStyleAssortment.Columns(9).Visible = True
                btnsave.Text = "Save"
            End If
        End If
        PageHeader("Style Assortment")
    End Sub
    Sub GetMasterData()
        Dim dtMasterData As New DataTable
        Try
            dtMasterData = objStyleAssortmentMaster.GetData(lJobOrderID, lJoborderDetailid)
            txtStyle.Text = dtMasterData.Rows(0)("Style")
            txtJobNo.Text = dtMasterData.Rows(0)("PONo") '("SRNo")
            txtSeason.Text = dtMasterData.Rows(0)("SeasonName")
            txtCustomer.Text = dtMasterData.Rows(0)("CustomerName")
            txtBrand.Text = dtMasterData.Rows(0)("Brand")
            txtCustPo.Text = dtMasterData.Rows(0)("CustomerOrder")
            txtItem.Text = dtMasterData.Rows(0)("ItemDesc")
            txtGSM.Text = dtMasterData.Rows(0)("GSM")
            txtContent.Text = dtMasterData.Rows(0)("Content")
            txtPrice.Text = dtMasterData.Rows(0)("UnitPrice")
            txtQuantity.Text = dtMasterData.Rows(0)("Quantity")
            txtCustColor.Text = dtMasterData.Rows(0)("Colorr")
            Dim username As String = objStyleAssortmentMaster.GetUserInfo(UserId)
            txtMarchand.Text = username
            txtCreationDate.Text = Date.Today
        Catch ex As Exception
        End Try
    End Sub
    Sub GetForEdit()
        Dim dt As New DataTable
        dt = objStyleAssortmentMaster.GetForEdit(lStyleAssortmentMasterID)
        If dt.Rows.Count > 0 Then
            txtCreationDate.Text = dt.Rows(0)("CreationDate")
            cmbGender.SelectedValue = dt.Rows(0)("GenderID")
            chkLabDipapprovalbycustomer.Checked = dt.Rows(0)("LabDipapprovalbycustomer")
            chkEmbelishmentReq.Checked = dt.Rows(0)("EmbelishmentReq")
            lblUserId.Text = dt.Rows(0)("UserId")
            getExtraQty()
            BindSizeRange()
            cmbSizeRange.SelectedValue = dt.Rows(0)("SizeRangeID")
            If dt.Rows(0)("BreakUp") = "Ratio" Then
                cmbBreak.SelectedIndex = 1
            ElseIf dt.Rows(0)("BreakUp") = "Assorted/Solid" Then
                cmbBreak.SelectedIndex = 2
            ElseIf dt.Rows(0)("BreakUp") = "Both" Then
                cmbBreak.SelectedIndex = 3
            Else
                cmbBreak.SelectedIndex = 0
            End If
            Session("dtGrid") = dt
            BindGrid()
        End If
    End Sub
    Sub getExtraQty()
        Dim dt As DataTable = objStyleAssortmentMaster.GetQty(txtCustomer.Text)
        txtExtaQty.Text = dt.Rows(0)("ExtraQty")
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub BindGender()
        Try
            Dim dt As DataTable
            dt = objStyleAssortmentMaster.BindGender2()
            cmbGender.DataSource = dt
            cmbGender.DataTextField = "SizeGroup"
            cmbGender.DataValueField = "SizeRangeId"
            cmbGender.DataBind()
            cmbGender.Items.Insert(0, "Select")
        Catch ex As Exception
        End Try
    End Sub
    Sub BindSizeRange()
        Try
            Dim dt As DataTable
            dt = objStyleAssortmentMaster.BindSizeRange2(cmbGender.SelectedValue)
            cmbSizeRange.DataSource = dt
            cmbSizeRange.DataTextField = "SizeRange"
            cmbSizeRange.DataValueField = "SizeRangeID"
            cmbSizeRange.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Sub BindBreakup()
        Try
            cmbBreak.Items.Insert(0, "Select")
            cmbBreak.Items.Insert(1, "Ratio")
            cmbBreak.Items.Insert(2, "Assorted/Solid")
            cmbBreak.Items.Insert(3, "Both")
        Catch ex As Exception
        End Try
    End Sub
    Sub SaveMaster()
        Try
            With objStyleAssortmentMaster
                If lStyleAssortmentMasterID > 0 Then
                    .StyleAssortmentMasterID = lStyleAssortmentMasterID
                Else
                    .StyleAssortmentMasterID = 0
                End If
                .JobOrderID = lJobOrderID
                .JoborderDetailid = lJoborderDetailid
                If Session("RoleId") = 46 And Session("Type") = "Merchandising" Then
                    If lStyleAssortmentMasterID > 0 Then
                        .UserID = lblUserId.Text
                    Else
                        .UserID = 270
                    End If
                Else
                    If lStyleAssortmentMasterID > 0 Then
                        .UserID = lblUserId.Text
                    Else
                        .UserID = UserId
                    End If
                End If
                If chkLabDipapprovalbycustomer.Checked = True Then
                    .LabDipapprovalbycustomer = True
                Else
                    .LabDipapprovalbycustomer = False
                End If
                .CreationDate = objGeneralCode.GetDate(txtCreationDate.Text)
                If chkEmbelishmentReq.Checked = True Then
                    .EmbelishmentReq = True
                Else
                    .EmbelishmentReq = False
                End If
                If txtExtaQty.Text = "" Then
                    .ExtraQty = 0
                Else
                    .ExtraQty = txtExtaQty.Text
                End If
                .SaveStyleAssortmentMaster()
            End With
            objStyleAccessoriesList.UpdateExtraQtyInCustomer(txtCustomer.Text, txtExtaQty.Text)
        Catch ex As Exception
        End Try
    End Sub
    Sub saveDetail()
        Dim x As Integer
        Try
            For x = 0 To dgStyleAssortment.Items.Count - 1
                Dim txtRatio As TextBox = CType(dgStyleAssortment.Items.Item(x).FindControl("txtRatio"), TextBox)
                Dim txtQty As TextBox = CType(dgStyleAssortment.Items.Item(x).FindControl("txtQty"), TextBox)
                Dim cmbUnit As DropDownList = CType(dgStyleAssortment.Items.Item(x).FindControl("cmbUnit"), DropDownList)
                Dim txtAssortQty As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtAssortQty"), TextBox)
                Dim txtExtra As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtExtra"), TextBox)
                Dim txtLineno As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtLineno"), TextBox)
                With objStyleAssortmentDetail
                    If lStyleAssortmentMasterID > 0 Then
                        .StyleAssortmentMasterID = lStyleAssortmentMasterID
                    Else
                        .StyleAssortmentMasterID = objStyleAssortmentMaster.GetID
                    End If
                    .StyleAssortmentDetailID = dgStyleAssortment.Items(x).Cells(0).Text
                    .GenderID = cmbGender.SelectedValue
                    .SizeRangeID = dgStyleAssortment.Items(x).Cells(1).Text
                    .SizeDatabaseID = dgStyleAssortment.Items(x).Cells(2).Text
                    .Breakup = cmbBreak.SelectedItem.Text
                    .Size = dgStyleAssortment.Items(x).Cells(3).Text
                    .Ratio = txtRatio.Text
                    .Unit = cmbUnit.SelectedItem.Text
                    If txtQty.Text = "" Then
                        .Qty = 0
                    Else
                        .Qty = txtQty.Text
                    End If
                    If txtAssortQty.Text = "" Then
                        .Asortqty = 0
                    Else
                        .Asortqty = txtAssortQty.Text
                    End If
                    .ExtraQty = txtExtra.Text
                    .DownloadBit = False
                    If txtLineno.Text = "" Then
                        .LineNumber = ""
                    Else
                        .LineNumber = txtLineno.Text
                    End If
                    .SaveStyleAssortmentDetail()
                End With
            Next
        Catch ex As Exception
        End Try
    End Sub
    Sub SaveAuto()
        Try
            Dim dtStyle As DataTable = objStyleAssortmentMaster.GetDataAuto(lJobOrderID, lJoborderDetailid, Styles)
            Dim x As Integer = 0
            For x = 0 To dtStyle.Rows.Count - 1
                txtQuantity.Text = dtStyle.Rows(x)("Quantity")
                With objStyleAssortmentMaster
                    .StyleAssortmentMasterID = 0
                    .JobOrderID = dtStyle.Rows(x)("JobOrderID")
                    .JoborderDetailid = dtStyle.Rows(x)("JobOrderDetailID")
                    .UserID = UserId
                    If chkLabDipapprovalbycustomer.Checked = True Then
                        .LabDipapprovalbycustomer = True
                    Else
                        .LabDipapprovalbycustomer = False
                    End If
                    .CreationDate = objGeneralCode.GetDate(txtCreationDate.Text)
                    If chkEmbelishmentReq.Checked = True Then
                        .EmbelishmentReq = True
                    Else
                        .EmbelishmentReq = False
                    End If
                    If txtExtaQty.Text = "" Then
                        .ExtraQty = 0
                    Else
                        .ExtraQty = txtExtaQty.Text
                    End If
                    .SaveStyleAssortmentMaster()
                End With
                Dim c As Integer = 0
                Dim totalRatio As Decimal = 0
                For c = 0 To dgStyleAssortment.Items.Count - 1
                    Dim txtRatio As TextBox = CType(dgStyleAssortment.Items(c).FindControl("txtRatio"), TextBox)
                    If cmbBreak.SelectedIndex = 1 Then
                        totalRatio = totalRatio + Val(txtRatio.Text)
                    Else
                    End If
                Next
                Dim i As Integer = 0
                For i = 0 To dgStyleAssortment.Items.Count - 1
                    Dim txtRatio As TextBox = CType(dgStyleAssortment.Items(i).FindControl("txtRatio"), TextBox)
                    Dim txtQty As TextBox = CType(dgStyleAssortment.Items(i).FindControl("txtQty"), TextBox)
                    Dim txtAssortQty As TextBox = CType(dgStyleAssortment.Items(i).FindControl("txtAssortQty"), TextBox)
                    Dim cmbUnit As DropDownList = CType(dgStyleAssortment.Items(i).FindControl("cmbUnit"), DropDownList)
                    With objStyleAssortmentDetail
                        .StyleAssortmentMasterID = objStyleAssortmentMaster.GetID
                        .StyleAssortmentDetailID = dgStyleAssortment.Items(i).Cells(0).Text
                        .GenderID = cmbGender.SelectedValue
                        .SizeRangeID = dgStyleAssortment.Items(i).Cells(1).Text
                        .SizeDatabaseID = dgStyleAssortment.Items(i).Cells(2).Text
                        .Breakup = cmbBreak.SelectedItem.Text
                        .Size = dgStyleAssortment.Items(i).Cells(3).Text
                        .Ratio = txtRatio.Text
                        .Unit = cmbUnit.SelectedItem.Text
                        If txtQty.Text = "" Then
                            .Qty = 0
                        Else
                            If cmbBreak.SelectedIndex = 1 Then
                                Dim UnitRate As Decimal = Val(txtQuantity.Text) / totalRatio
                                txtQty.Text = Math.Round(Val(txtRatio.Text) * UnitRate, 2)
                                .Qty = Val(txtQty.Text)
                            Else
                                .Qty = Val(txtQty.Text)
                            End If
                        End If
                        If txtAssortQty.Text = "" Then
                            .Asortqty = 0
                        Else
                            .Asortqty = txtAssortQty.Text
                        End If
                        .SaveStyleAssortmentDetail()
                    End With
                Next
            Next
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If RoleID = 42 Then
            Response.Redirect("..\ProductionScaning/StyleAssortmentBarCodeView.aspx")
        Else
            Response.Redirect("StyleAssortmentView.aspx")
        End If
    End Sub
    Protected Sub dgStyleAssortment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgStyleAssortment.SelectedIndexChanged
    End Sub
    Protected Sub dgStyleAssortment_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgStyleAssortment.SortCommand
    End Sub
    Protected Sub txtExtaQty_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtExtaQty.TextChanged
        Try
            BindGrid()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BindGrid()
        Dim x As Integer
        Try
            Dim objDatatable As DataTable
            If lStyleAssortmentMasterID > 0 Then
                objDatatable = Session("dtGrid")
            Else
                objDatatable = objStyleAssortmentMaster.GetGridSizeDataData(cmbSizeRange.SelectedValue)
                Session("dtGrid") = objDatatable
            End If
            If objDatatable.Rows.Count > 0 Then
                dgStyleAssortment.Visible = True
                dgStyleAssortment.RecordCount = objDatatable.Rows.Count
                dgStyleAssortment.DataSource = objDatatable
                dgStyleAssortment.DataBind()
                btnsave.Visible = True
                If cmbBreak.SelectedItem.Text = "Ratio" Then
                    dgStyleAssortment.Columns(7).Visible = False
                    dgStyleAssortment.Columns(6).Visible = True
                ElseIf cmbBreak.SelectedItem.Text = "Assorted/Solid" Then
                    dgStyleAssortment.Columns(6).Visible = False
                    dgStyleAssortment.Columns(7).Visible = True
                Else
                    dgStyleAssortment.Columns(6).Visible = True
                    dgStyleAssortment.Columns(7).Visible = True
                End If
            Else
                dgStyleAssortment.Visible = False
            End If
            Dim totalRatio As Decimal = 0
            Dim UnitRate As Decimal = 0
            Dim TotalAssort As Decimal = 0
            Dim TotalQty As Decimal = 0
            For x = 0 To dgStyleAssortment.Items.Count - 1
                Dim txtQty As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtQty"), TextBox)
                Dim txtRatio As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtRatio"), TextBox)
                Dim cmbUnit As DropDownList = CType(dgStyleAssortment.Items(x).FindControl("cmbUnit"), DropDownList)
                Dim txtAssortQty As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtAssortQty"), TextBox)
                Dim txtBalanceQty As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtBalanceQty"), TextBox)
                Dim txtExtra As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtExtra"), TextBox)
                Dim txtLineno As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtLineno"), TextBox)
                Dim lblTotalAssort As Label = CType(dgStyleAssortment.Items(x).FindControl("lblTotalAssort"), Label)
                Dim lblTotalQty As Label = CType(dgStyleAssortment.Items(x).FindControl("lblTotalQty"), Label)
                txtExtra.Text = txtExtaQty.Text
                If cmbBreak.SelectedIndex = 2 Then
                    txtRatio.Text = "--"
                    txtRatio.Enabled = False
                ElseIf cmbBreak.SelectedIndex = 3 Then
                    txtRatio.Text = objDatatable.Rows(x)("Ratio")
                Else
                    txtRatio.Text = objDatatable.Rows(x)("Ratio")
                End If
                If cmbBreak.SelectedIndex = 1 Then
                    totalRatio = totalRatio + Val(txtRatio.Text)
                    UnitRate = Val(txtQuantity.Text / totalRatio)
                ElseIf cmbBreak.SelectedIndex = 3 Then
                    totalRatio = totalRatio + Val(txtRatio.Text)
                    UnitRate = Val(txtRatioQty.Text / totalRatio)
                Else
                End If
                Dim dtUnit As New DataTable
                dtUnit = objStyleAssortmentMaster.GetUOMData(lJobOrderID, lJoborderDetailid)
                cmbUnit.DataSource = dtUnit
                cmbUnit.DataTextField = "Symbol"
                cmbUnit.DataValueField = "UOMID"
                cmbUnit.DataBind()
                cmbUnit.Enabled = False
                txtLineno.Text = objDatatable.Rows(x)("LineNumber")
            Next
            Dim BalanceRound As Decimal = 0
            x = 0
            For x = 0 To dgStyleAssortment.Items.Count - 1
                Dim txtQty As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtQty"), TextBox)
                Dim txtRatio As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtRatio"), TextBox)
                Dim txtAssortQty As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtAssortQty"), TextBox)
                Dim txtBalanceQty As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtBalanceQty"), TextBox)
                Dim txtExtra As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtExtra"), TextBox)
                Dim txtLineno As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtLineno"), TextBox)
                If cmbBreak.SelectedIndex = 1 Then
                    txtQty.Text = Math.Round(Val(txtRatio.Text) * UnitRate, 2)
                    txtAssortQty.Text = 0
                    txtAssortQty.ReadOnly = True
                    txtBalanceQty.ReadOnly = True
                    Dim AssortQty As Decimal = 0
                    Dim Balance As Decimal
                    Dim Qtyy As Decimal = ((Val(txtQty.Text) + Val(AssortQty)) * Val(txtExtaQty.Text)) / 100
                    txtExtra.Text = Qtyy
                    Balance = Math.Round(Val(txtQty.Text) + Val(txtAssortQty.Text) + Val(txtExtra.Text), 2)
                    txtBalanceQty.Text = Math.Round(Balance)
                    txtLineno.Text = objDatatable.Rows(x)("LineNumber")
                    If txtAssortQty.Text = "" Then
                        TotalAssort = TotalAssort + 0
                    Else
                        TotalAssort = TotalAssort + Val(txtAssortQty.Text)
                    End If
                    If txtBalanceQty.Text = "" Then
                        TotalQty = TotalQty + 0
                    Else
                        TotalQty = TotalQty + Val(txtBalanceQty.Text)
                    End If
                ElseIf cmbBreak.SelectedIndex = 2 Then
                    txtQty.Text = 0
                    txtQty.ReadOnly = True
                    txtBalanceQty.ReadOnly = True
                    txtAssortQty.Text = objDatatable.Rows(x)("Asortqty")
                    Dim Balance As Decimal
                    Dim RatioQty As Decimal = 0
                    Dim Qtyy As Decimal = ((Val(txtQty.Text) + Val(txtAssortQty.Text)) * Val(txtExtaQty.Text)) / 100
                    txtExtra.Text = Qtyy
                    Balance = Math.Round(Val(txtQty.Text) + Val(txtAssortQty.Text) + Val(txtExtra.Text), 2)
                    txtBalanceQty.Text = Math.Round(Balance)
                    txtLineno.Text = objDatatable.Rows(x)("LineNumber")
                    If txtAssortQty.Text = "" Then
                        TotalAssort = TotalAssort + 0
                    Else
                        TotalAssort = TotalAssort + Val(txtAssortQty.Text)
                    End If
                    If txtBalanceQty.Text = "" Then
                        TotalQty = TotalQty + 0
                    Else
                        TotalQty = TotalQty + Val(txtBalanceQty.Text)
                    End If
                ElseIf cmbBreak.SelectedIndex = 3 Then
                    txtQty.Text = Math.Round(Val(txtRatio.Text) * UnitRate, 2)
                    txtBalanceQty.ReadOnly = True
                    txtAssortQty.Text = objDatatable.Rows(x)("Asortqty")
                    Dim Balance As Decimal
                    Dim Qtyy As Decimal = ((Val(txtQty.Text) + Val(txtAssortQty.Text)) * Val(txtExtaQty.Text)) / 100
                    txtExtra.Text = Qtyy
                    Balance = Math.Round(Val(txtQty.Text) + Val(txtAssortQty.Text) + Val(txtExtra.Text), 2)
                    txtBalanceQty.Text = Math.Round(Balance)
                    txtLineno.Text = objDatatable.Rows(x)("LineNumber")
                    If txtAssortQty.Text = "" Then
                        TotalAssort = TotalAssort + 0
                    Else
                        TotalAssort = TotalAssort + Val(txtAssortQty.Text)
                    End If
                    If txtBalanceQty.Text = "" Then
                        TotalQty = TotalQty + 0
                    Else
                        TotalQty = TotalQty + Val(txtBalanceQty.Text)
                    End If
                End If
            Next
            lblTotalAssort.Text = TotalAssort
            lblTotalQty.Text = TotalQty
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BindGridAfterAllSizeDelete()
        Dim x As Integer
        Try
            Dim objDatatable As DataTable
            objDatatable = Session("dtGrid")
            If IsNothing(objDatatable) Then
                objDatatable = objStyleAssortmentMaster.GetGridSizeDataData(cmbSizeRange.SelectedValue)
            Else
            End If
            If objDatatable.Rows.Count > 0 Then
                dgStyleAssortment.Visible = True
                dgStyleAssortment.RecordCount = objDatatable.Rows.Count
                dgStyleAssortment.DataSource = objDatatable
                dgStyleAssortment.DataBind()
                btnsave.Visible = True
                If cmbBreak.SelectedItem.Text = "Ratio" Then
                    dgStyleAssortment.Columns(7).Visible = False
                    dgStyleAssortment.Columns(6).Visible = True
                ElseIf cmbBreak.SelectedItem.Text = "Assorted/Solid" Then
                    dgStyleAssortment.Columns(6).Visible = False
                    dgStyleAssortment.Columns(7).Visible = True
                Else
                    dgStyleAssortment.Columns(6).Visible = True
                    dgStyleAssortment.Columns(7).Visible = True
                End If
            Else
                dgStyleAssortment.Visible = False
            End If
            Dim totalRatio As Decimal = 0
            Dim UnitRate As Decimal = 0
            For x = 0 To dgStyleAssortment.Items.Count - 1
                Dim txtQty As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtQty"), TextBox)
                Dim txtRatio As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtRatio"), TextBox)
                Dim cmbUnit As DropDownList = CType(dgStyleAssortment.Items(x).FindControl("cmbUnit"), DropDownList)
                Dim txtAssortQty As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtAssortQty"), TextBox)
                Dim txtBalanceQty As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtBalanceQty"), TextBox)
                Dim txtExtra As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtExtra"), TextBox)
                txtExtra.Text = txtExtaQty.Text
                If cmbBreak.SelectedIndex = 2 Then
                    txtRatio.Text = "--"
                    txtRatio.Enabled = False
                ElseIf cmbBreak.SelectedIndex = 3 Then
                    txtRatio.Text = objDatatable.Rows(x)("Ratio")
                Else
                    txtRatio.Text = objDatatable.Rows(x)("Ratio")
                End If
                If cmbBreak.SelectedIndex = 1 Then
                    totalRatio = totalRatio + Val(txtRatio.Text)
                    UnitRate = Val(txtQuantity.Text / totalRatio)

                ElseIf cmbBreak.SelectedIndex = 3 Then
                    totalRatio = totalRatio + Val(txtRatio.Text)
                    UnitRate = Val(txtRatioQty.Text / totalRatio)
                Else
                End If
                Dim dtUnit As New DataTable
                dtUnit = objStyleAssortmentMaster.GetUOMData(lJobOrderID, lJoborderDetailid)
                cmbUnit.DataSource = dtUnit
                cmbUnit.DataTextField = "Symbol"
                cmbUnit.DataValueField = "UOMID"
                cmbUnit.DataBind()
                cmbUnit.Enabled = False
            Next
            Dim BalanceRound As Decimal = 0
            x = 0
            For x = 0 To dgStyleAssortment.Items.Count - 1
                Dim txtQty As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtQty"), TextBox)
                Dim txtRatio As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtRatio"), TextBox)
                Dim txtAssortQty As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtAssortQty"), TextBox)
                Dim txtBalanceQty As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtBalanceQty"), TextBox)
                Dim txtExtra As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtExtra"), TextBox)
                If cmbBreak.SelectedIndex = 1 Then
                    txtQty.Text = Math.Round(Val(txtRatio.Text) * UnitRate, 2)
                    txtAssortQty.Text = 0
                    txtAssortQty.ReadOnly = True
                    txtBalanceQty.ReadOnly = True
                    Dim AssortQty As Decimal = 0
                    Dim Balance As Decimal
                    Dim Qtyy As Decimal = ((Val(txtQty.Text) + Val(AssortQty)) * Val(txtExtaQty.Text)) / 100
                    txtExtra.Text = Qtyy
                    Balance = Math.Round(Val(txtQty.Text) + Val(txtAssortQty.Text) + Val(txtExtra.Text), 2)
                    txtBalanceQty.Text = Math.Round(Balance)
                ElseIf cmbBreak.SelectedIndex = 2 Then
                    txtQty.Text = 0
                    txtQty.ReadOnly = True
                    txtBalanceQty.ReadOnly = True
                    txtAssortQty.Text = objDatatable.Rows(x)("Asortqty")
                    Dim Balance As Decimal
                    Dim RatioQty As Decimal = 0
                    Dim Qtyy As Decimal = ((Val(txtQty.Text) + Val(txtAssortQty.Text)) * Val(txtExtaQty.Text)) / 100
                    txtExtra.Text = Qtyy
                    Balance = Math.Round(Val(txtQty.Text) + Val(txtAssortQty.Text) + Val(txtExtra.Text), 2)
                    txtBalanceQty.Text = Math.Round(Balance)
                ElseIf cmbBreak.SelectedIndex = 3 Then
                    txtQty.Text = Math.Round(Val(txtRatio.Text) * UnitRate, 2)
                    txtBalanceQty.ReadOnly = True
                    txtAssortQty.Text = objDatatable.Rows(x)("Asortqty")
                    Dim Balance As Decimal
                    Dim Qtyy As Decimal = ((Val(txtQty.Text) + Val(txtAssortQty.Text)) * Val(txtExtaQty.Text)) / 100
                    txtExtra.Text = Qtyy
                    Balance = Math.Round(Val(txtQty.Text) + Val(txtAssortQty.Text) + Val(txtExtra.Text), 2)
                    txtBalanceQty.Text = Math.Round(Balance)
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
    Sub ClearControls()
        Try
            cmbGender.SelectedValue = 0
            cmbSizeRange.SelectedIndex = 0
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbGender_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbGender.SelectedIndexChanged
        Try
            dgStyleAssortment.Visible = False
            BindSizeRange()
            cmbGender.SelectedValue = 0
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbBreak_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBreak.SelectedIndexChanged
        Try
            If cmbGender.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Gender.")
            ElseIf cmbSizeRange.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Size Range.")
            ElseIf cmbBreak.SelectedIndex = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Breakup.")
            Else
                If cmbBreak.SelectedItem.Text = "Ratio" And txtExtaQty.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Extra Qty.")
                    cmbBreak.SelectedIndex = 0
                ElseIf cmbBreak.SelectedItem.Text = "Assorted/Solid" And txtExtaQty.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Extra Qty.")
                    cmbBreak.SelectedIndex = 0
                ElseIf cmbBreak.SelectedItem.Text = "Both" And txtExtaQty.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Extra Qty.")
                    cmbBreak.SelectedIndex = 0
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    If cmbBreak.SelectedIndex = 3 Then
                        pnlAssort.Visible = True
                        dgStyleAssortment.Visible = False
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                    Else
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                        dgStyleAssortment.Visible = True
                        Dim DTCheck As DataTable = Session("dtGrid")
                        If IsNothing(DTCheck) And btnDeleteAssortment.Visible = True Then
                            BindGridAfterAllSizeDelete()
                        Else
                            BindGrid()
                        End If
                        ClearControls()
                        pnlAssort.Visible = False
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Try
            If lStyleAssortmentMasterID = 0 Then
                Dim x As Integer = 0
                Dim TotalQty As Decimal = 0
                For x = 0 To dgStyleAssortment.Items.Count - 1
                    Dim txtQty As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtQty"), TextBox)
                    Dim txtAssortQty As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtAssortQty"), TextBox)
                    Dim AssortQty As Decimal = 0
                    If txtAssortQty.Text = "" Then
                        AssortQty = 0
                    Else
                        AssortQty = txtAssortQty.Text
                    End If
                    TotalQty = TotalQty + Val(txtQty.Text) + Val(AssortQty)
                Next
                If TotalQty > Val(txtQuantity.Text) Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Not allow to save, Qty is wrong. System Calculated Qty is: " + TotalQty.ToString())
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                    SaveMaster()
                    saveDetail()
                    If lStyleAssortmentMasterID > 0 Then
                    Else
                    End If
                    Response.Redirect("StyleAssortmentView.aspx")
                End If
            Else
                SaveMaster()
                saveDetailOnEdit()
                If RoleID = 42 Then
                    SaveBarCodeDetailNewOnEditForDigital()
                    Response.Redirect("..\ProductionScaning/StyleAssortmentBarCodeView.aspx")
                Else
                    Response.Redirect("StyleAssortmentView.aspx")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtRatio_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim UnitRate As Decimal = 0
            Dim c As Integer = 0
            Dim totalRatio As Decimal = 0
            Dim x As Integer = 0
            If cmbBreak.SelectedIndex = 1 Then
                For c = 0 To dgStyleAssortment.Items.Count - 1
                    Dim txtRatio As TextBox = CType(dgStyleAssortment.Items(c).FindControl("txtRatio"), TextBox)
                    totalRatio = totalRatio + Val(txtRatio.Text)
                Next
                UnitRate = Val(txtQuantity.Text / totalRatio)
                For x = 0 To dgStyleAssortment.Items.Count - 1
                    Dim txtQty As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtQty"), TextBox)
                    Dim txtRatio As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtRatio"), TextBox)
                    Dim txtAssortQty As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtAssortQty"), TextBox)
                    Dim txtBalanceQty As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtBalanceQty"), TextBox)
                    Dim txtExtra As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtExtra"), TextBox)
                    txtQty.Text = Math.Round(Val(txtRatio.Text) * UnitRate, 2)
                    Dim Balance As Decimal
                    Dim Qtyy As Decimal = ((Val(txtQty.Text) + Val(txtAssortQty.Text)) * Val(txtExtaQty.Text)) / 100
                    txtExtra.Text = Qtyy
                    Balance = Val(txtQty.Text) + Val(txtAssortQty.Text) + Val(txtExtra.Text)
                    txtBalanceQty.Text = Math.Round(Balance)
                Next
            ElseIf cmbBreak.SelectedIndex = 3 Then
                For c = 0 To dgStyleAssortment.Items.Count - 1
                    Dim txtRatio As TextBox = CType(dgStyleAssortment.Items(c).FindControl("txtRatio"), TextBox)
                    totalRatio = totalRatio + Val(txtRatio.Text)
                Next
                UnitRate = Val(txtRatioQty.Text / totalRatio)
                For x = 0 To dgStyleAssortment.Items.Count - 1
                    Dim txtQty As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtQty"), TextBox)
                    Dim txtRatio As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtRatio"), TextBox)
                    Dim txtAssortQty As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtAssortQty"), TextBox)
                    Dim txtBalanceQty As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtBalanceQty"), TextBox)
                    Dim txtExtra As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtExtra"), TextBox)
                    txtQty.Text = Math.Round(Val(txtRatio.Text) * UnitRate, 2)
                    Dim Qtyy As Decimal = ((Val(txtQty.Text) + Val(txtAssortQty.Text)) * Val(txtExtaQty.Text)) / 100
                    txtExtra.Text = Qtyy
                    txtBalanceQty.Text = Math.Round(Val(txtQty.Text) + Val(txtAssortQty.Text) + Val(txtExtra.Text), 2)
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtAssortQty_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim TotalAssort As Decimal = 0
        Dim TotalQty As Decimal = 0
        Dim x As Integer = 0
        Try
            For x = 0 To dgStyleAssortment.Items.Count - 1
                Dim txtQty As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtQty"), TextBox)
                Dim txtRatio As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtRatio"), TextBox)
                Dim txtAssortQty As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtAssortQty"), TextBox)
                Dim txtBalanceQty As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtBalanceQty"), TextBox)
                Dim txtExtra As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtExtra"), TextBox)
                Dim Qtyy As Decimal = ((Val(txtQty.Text) + Val(txtAssortQty.Text)) * Val(txtExtaQty.Text)) / 100
                txtExtra.Text = Qtyy
                txtBalanceQty.Text = Val(txtQty.Text) + Val(txtAssortQty.Text) + Val(txtExtra.Text)
                If txtAssortQty.Text = "" Then
                    TotalAssort = TotalAssort + 0
                Else
                    TotalAssort = TotalAssort + Val(txtAssortQty.Text)
                End If
                If txtBalanceQty.Text = "" Then
                    TotalQty = TotalQty + 0
                Else
                    TotalQty = TotalQty + Val(txtBalanceQty.Text)
                End If
            Next
            lblTotalAssort.Text = TotalAssort
            lblTotalQty.Text = TotalQty
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtRatioQty_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRatioQty.TextChanged
        Try
            txtAssortedQty.Text = Val(txtQuantity.Text) - Val(txtRatioQty.Text)
            BindGrid()
            dgStyleAssortment.Visible = True
            ClearControls()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbSizeRange_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSizeRange.SelectedIndexChanged
        Try
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
            Session("dtGrid") = Nothing
            cmbBreak.SelectedIndex = 0
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub LinkAddGender_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkAddGender.Click
        Try
            Response.Write("<script> window.open('AddGenderPopup.aspx', 'newwindow', 'left=100, top=180, height=500, width=850, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnGenderShow_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnGenderShow.Click
        BindGender()
    End Sub
    Protected Sub dgStyleAssortment_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgStyleAssortment.ItemCommand
        Try
            Select Case e.CommandName
                Case Is = "Remove"
                    Dim StyleAssortmentDetailID As Integer = dgStyleAssortment.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim dt As DataTable = objStyleAssortmentMaster.CheckStyleAssortmentDetailIDForCutting(lStyleAssortmentMasterID, StyleAssortmentDetailID)
                    Dim dtt As DataTable = objStyleAssortmentMaster.CheckStyleAssortmentDetailIDForChecklist(lStyleAssortmentMasterID, StyleAssortmentDetailID)
                    If dt.Rows.Count > 0 Or dtt.Rows.Count > 0 Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Can Not Be Deleted")
                    Else
                        objStyleAssortmentMaster.DeleteStyleAssortmentDetail(StyleAssortmentDetailID)
                        Dim dtsession As New DataTable
                        dtsession = Session("dtGrid")
                        dtsession.Rows.RemoveAt(e.Item.ItemIndex)
                        Session("dtGrid") = dtsession
                        BindGridForEdit()
                    End If
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BindGridForEdit()
        Dim x As Integer
        Try
            Dim objDatatable As DataTable
            objDatatable = Session("dtGrid")
            If objDatatable.Rows.Count > 0 Then
                dgStyleAssortment.Visible = True
                dgStyleAssortment.RecordCount = objDatatable.Rows.Count
                dgStyleAssortment.DataSource = objDatatable
                dgStyleAssortment.DataBind()
                btnsave.Visible = True
                If cmbBreak.SelectedItem.Text = "Ratio" Then
                    dgStyleAssortment.Columns(7).Visible = False
                    dgStyleAssortment.Columns(6).Visible = True
                ElseIf cmbBreak.SelectedItem.Text = "Assorted/Solid" Then
                    dgStyleAssortment.Columns(6).Visible = False
                    dgStyleAssortment.Columns(7).Visible = True
                Else
                    dgStyleAssortment.Columns(6).Visible = True
                    dgStyleAssortment.Columns(7).Visible = True
                End If
            Else
                dgStyleAssortment.Visible = False
            End If
            Dim totalRatio As Decimal = 0
            Dim UnitRate As Decimal = 0
            For x = 0 To dgStyleAssortment.Items.Count - 1
                Dim txtQty As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtQty"), TextBox)
                Dim txtRatio As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtRatio"), TextBox)
                Dim cmbUnit As DropDownList = CType(dgStyleAssortment.Items(x).FindControl("cmbUnit"), DropDownList)
                Dim txtAssortQty As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtAssortQty"), TextBox)
                Dim txtBalanceQty As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtBalanceQty"), TextBox)
                Dim txtExtra As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtExtra"), TextBox)
                txtExtra.Text = txtExtaQty.Text
                If cmbBreak.SelectedIndex = 2 Then
                    txtRatio.Text = "--"
                    txtRatio.Enabled = False
                ElseIf cmbBreak.SelectedIndex = 3 Then
                    txtRatio.Text = objDatatable.Rows(x)("Ratio")
                Else
                    txtRatio.Text = objDatatable.Rows(x)("Ratio")
                End If
                If lStyleAssortmentMasterID > 0 Then
                    txtQty.Text = objDatatable.Rows(x)("Qty")
                    If cmbBreak.SelectedIndex = 1 Then
                        totalRatio = totalRatio + Val(txtRatio.Text)
                        UnitRate = Val(txtQuantity.Text / totalRatio)

                    ElseIf cmbBreak.SelectedIndex = 3 Then
                        totalRatio = totalRatio + Val(txtRatio.Text)
                        UnitRate = Val(txtRatioQty.Text / totalRatio)
                    Else
                    End If
                Else
                    If cmbBreak.SelectedIndex = 1 Then
                        totalRatio = totalRatio + Val(txtRatio.Text)
                        UnitRate = Val(txtQuantity.Text / totalRatio)

                    ElseIf cmbBreak.SelectedIndex = 3 Then
                        totalRatio = totalRatio + Val(txtRatio.Text)
                        UnitRate = Val(txtRatioQty.Text / totalRatio)

                    End If
                End If
                Dim dtUnit As New DataTable
                dtUnit = objStyleAssortmentMaster.GetUOMData(lJobOrderID, lJoborderDetailid)
                cmbUnit.DataSource = dtUnit
                cmbUnit.DataTextField = "Symbol"
                cmbUnit.DataValueField = "UOMID"
                cmbUnit.DataBind()
                cmbUnit.Enabled = False
            Next
            Dim BalanceRound As Decimal = 0
            x = 0
            For x = 0 To dgStyleAssortment.Items.Count - 1
                Dim txtQty As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtQty"), TextBox)
                Dim txtRatio As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtRatio"), TextBox)
                Dim txtAssortQty As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtAssortQty"), TextBox)
                Dim txtBalanceQty As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtBalanceQty"), TextBox)
                Dim txtExtra As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtExtra"), TextBox)
                If lStyleAssortmentMasterID > 0 Then
                    txtQty.Text = Math.Round(Val(txtRatio.Text) * UnitRate, 2)
                    BalanceRound = Val(txtQty.Text) + Val(txtAssortQty.Text) + txtExtra.Text
                    txtBalanceQty.Text = Math.Round(BalanceRound)
                    If cmbBreak.SelectedIndex = 1 Then
                        txtQty.Text = Math.Round(Val(txtRatio.Text) * UnitRate, 2)
                        txtAssortQty.Text = 0
                        txtAssortQty.ReadOnly = True
                        txtBalanceQty.ReadOnly = True
                        Dim AssortQty As Decimal = 0
                        Dim Balance As Decimal
                        Dim Qtyy As Decimal = ((Val(txtQty.Text) + Val(AssortQty)) * Val(txtExtaQty.Text)) / 100
                        txtExtra.Text = Math.Round(Qtyy, 2)
                        Balance = Math.Round(Val(txtQty.Text) + Val(txtAssortQty.Text) + Val(txtExtra.Text), 2)
                        txtBalanceQty.Text = Math.Round(Balance)
                    ElseIf cmbBreak.SelectedIndex = 2 Then
                        txtQty.Text = 0
                        txtQty.ReadOnly = True
                        txtBalanceQty.ReadOnly = True
                        txtAssortQty.Text = objDatatable.Rows(x)("Asortqty")
                        Dim Balance As Decimal
                        Dim RatioQty As Decimal = 0
                        Dim Qtyy As Decimal = ((Val(txtQty.Text) + Val(txtAssortQty.Text)) * Val(txtExtaQty.Text)) / 100
                        txtExtra.Text = Qtyy
                        Balance = Math.Round(Val(txtQty.Text) + Val(txtAssortQty.Text) + Val(txtExtra.Text), 2)
                        txtBalanceQty.Text = Math.Round(Balance)
                    ElseIf cmbBreak.SelectedIndex = 3 Then
                        txtQty.Text = Math.Round(Val(txtRatio.Text) * UnitRate, 2)
                        txtBalanceQty.ReadOnly = True
                        txtAssortQty.Text = objDatatable.Rows(x)("Asortqty")
                        Dim Balance As Decimal
                        Dim Qtyy As Decimal = ((Val(txtQty.Text) + Val(txtAssortQty.Text)) * Val(txtExtaQty.Text)) / 100
                        txtExtra.Text = Qtyy
                        Balance = Math.Round(Val(txtQty.Text) + Val(txtAssortQty.Text) + Val(txtExtra.Text), 2)
                        txtBalanceQty.Text = Math.Round(Balance)
                    End If
                Else
                    txtQty.Text = Math.Round(Val(txtRatio.Text) * UnitRate, 2)
                    BalanceRound = Val(txtQty.Text) + Val(txtAssortQty.Text) + txtExtra.Text
                    txtBalanceQty.Text = Math.Round(BalanceRound)
                    If cmbBreak.SelectedIndex = 1 Then
                        txtQty.Text = Math.Round(Val(txtRatio.Text) * UnitRate, 2)
                        txtAssortQty.Text = 0
                        txtAssortQty.ReadOnly = True
                        txtBalanceQty.ReadOnly = True
                        Dim AssortQty As Decimal = 0
                        Dim Balance As Decimal
                        Dim Qtyy As Decimal = ((Val(txtQty.Text) + Val(AssortQty)) * Val(txtExtaQty.Text)) / 100
                        txtExtra.Text = Math.Round(Qtyy, 2)
                        Balance = Math.Round(Val(txtQty.Text) + Val(txtAssortQty.Text) + Val(txtExtra.Text), 2)
                        txtBalanceQty.Text = Math.Round(Balance)
                    ElseIf cmbBreak.SelectedIndex = 2 Then
                        txtQty.Text = 0
                        txtQty.ReadOnly = True
                        txtBalanceQty.ReadOnly = True
                        Dim Balance As Decimal
                        Dim RatioQty As Decimal = 0
                        Dim Qtyy As Decimal = ((Val(txtQty.Text) + Val(RatioQty)) * Val(txtExtaQty.Text)) / 100
                        txtExtra.Text = Qtyy
                        Balance = Math.Round(Val(txtQty.Text) + Val(txtAssortQty.Text) + Val(txtExtra.Text), 2)
                        txtBalanceQty.Text = Math.Round(Balance)
                    ElseIf cmbBreak.SelectedIndex = 3 Then
                        txtQty.Text = Math.Round(Val(txtRatio.Text) * UnitRate, 2)
                        txtBalanceQty.ReadOnly = True
                        Dim Balance As Decimal
                        Dim Qtyy As Decimal = ((Val(txtQty.Text) + Val(txtAssortQty.Text)) * Val(txtExtaQty.Text)) / 100
                        txtExtra.Text = Qtyy
                        Balance = Math.Round(Val(txtQty.Text) + Val(txtAssortQty.Text) + Val(txtExtra.Text), 2)
                        txtBalanceQty.Text = Math.Round(Balance)
                    End If
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
    Sub DeleteAllAssorment()
        Dim dt As DataTable = objStyleAssortmentMaster.CheckStyleAssortmentDetailIDForCuttingAllCase(lStyleAssortmentMasterID)
        Dim dtt As DataTable = objStyleAssortmentMaster.CheckStyleAssortmentDetailIDForChecklistAllCase(lStyleAssortmentMasterID)
        If dt.Rows.Count > 0 Or dtt.Rows.Count > 0 Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Can Not Be Deleted")
        Else
            objStyleAssortmentMaster.DeleteStyleAssortmentDetailAllCase(lStyleAssortmentMasterID)
            Dim dtsession As New DataTable
            Session("dtGrid") = Nothing
            dgStyleAssortment.Visible = False
            cmbGender.SelectedIndex = 0
            cmbBreak.SelectedIndex = 0
        End If
    End Sub
    Protected Sub btnDeleteAssortment_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDeleteAssortment.Click
        DeleteAllAssorment()
    End Sub
    Sub saveDetailOnEdit()
        Dim x As Integer
        Try
            For x = 0 To dgStyleAssortment.Items.Count - 1
                Dim dtbrk As New DataTable
                dtbrk = objStyleAssortmentMaster.GetBRKup(lStyleAssortmentMasterID)
                Dim txtRatio As TextBox = CType(dgStyleAssortment.Items.Item(x).FindControl("txtRatio"), TextBox)
                Dim txtQty As TextBox = CType(dgStyleAssortment.Items.Item(x).FindControl("txtQty"), TextBox)
                Dim cmbUnit As DropDownList = CType(dgStyleAssortment.Items.Item(x).FindControl("cmbUnit"), DropDownList)
                Dim txtAssortQty As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtAssortQty"), TextBox)
                Dim txtExtra As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtExtra"), TextBox)
                Dim txtLineno As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtLineno"), TextBox)
                With objStyleAssortmentDetail
                    .StyleAssortmentMasterID = lStyleAssortmentMasterID
                    .StyleAssortmentDetailID = dgStyleAssortment.Items(x).Cells(0).Text
                    .GenderID = cmbGender.SelectedValue
                    .SizeRangeID = dgStyleAssortment.Items(x).Cells(1).Text
                    .SizeDatabaseID = dgStyleAssortment.Items(x).Cells(2).Text
                    .Breakup = cmbBreak.SelectedItem.Text
                    .Size = dgStyleAssortment.Items(x).Cells(3).Text
                    .Ratio = txtRatio.Text
                    .Unit = cmbUnit.SelectedItem.Text
                    If txtQty.Text = "" Then 't
                        .Qty = 0 't
                    Else
                        .Qty = txtQty.Text 't
                    End If
                    If txtAssortQty.Text = "" Then
                        .Asortqty = 0
                    Else
                        .Asortqty = txtAssortQty.Text
                    End If
                    .ExtraQty = txtExtra.Text
                    .DownloadBit = False
                    If txtLineno.Text = "" Then
                        .LineNumber = ""
                    Else
                        .LineNumber = txtLineno.Text
                    End If
                    .SaveStyleAssortmentDetail()
                End With
            Next
        Catch ex As Exception
        End Try
    End Sub
    Sub SaveBarCodeDetailForEdit()
        Try
            Dim dtcompletedate As New DataTable
            dtcompletedate = objStyleAssortmentBarCodeDetail.GetCompleteDataOnEditNew(lStyleAssortmentMasterID, lJobOrderID, lJoborderDetailid)
            Dim Size As String = ""
            Dim SizeQTY As Decimal = 0
            Dim Breakup As String = ""
            Dim x As Integer
            Dim SizeRangeID As Long = 0
            Dim SizeDatabaseID As Long = 0
            Dim StyleAssortmentDetailID As Long = 0
            For x = 0 To dtcompletedate.Rows.Count - 1
                Dim txtExtra As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtExtra"), TextBox)
                Breakup = dtcompletedate.Rows(x)("Breakup")
                Size = dtcompletedate.Rows(x)("Size")
                SizeRangeID = dtcompletedate.Rows(x)("SizeRangeID")
                SizeDatabaseID = dtcompletedate.Rows(x)("SizeDatabaseID")
                StyleAssortmentDetailID = dtcompletedate.Rows(x)("StyleAssortmentDetailID")
                If Breakup = "Assorted/Solid" Then
                    SizeQTY = dtcompletedate.Rows(x)("Asortqtyy")
                Else
                    SizeQTY = dtcompletedate.Rows(x)("QTYy")
                End If
                Dim dtt As New DataTable
                dtt = objStyleAssortmentBarCodeDetail.GetEditData(lStyleAssortmentMasterID, lJobOrderID, lJoborderDetailid, Size)
                Dim totalCount As Integer
                Dim Increment As Integer
                If dtt.Rows.Count > 0 Then
                    Increment = dtt.Rows(0)("BarCodeCount")
                Else
                    Increment = 0
                End If
                Dim LineNo As String = ""
                LineNo = dtcompletedate.Rows(x)("LineNumber")
                Dim y As Integer
                For y = 0 To totalCount - 1
                    Increment = Increment + 1
                    With objStyleAssortmentBarCodeDetail
                        .StyleAssortmentBarCodeDetailID = 0
                        .JobOrderID = lJobOrderID
                        .JoborderDetailid = lJoborderDetailid
                        .Merchandiser = txtMarchand.Text
                        .Customer = txtCustomer.Text
                        .JobNo = txtJobNo.Text
                        .Style = txtStyle.Text
                        .Item = txtItem.Text
                        .Brand = txtBrand.Text
                        Dim barcodedata As String
                       barcodedata = (lJoborderDetailid.ToString) + (SizeDatabaseID.ToString) + (Increment.ToString)
                        .BarCodeCount = Increment
                        .CreationDate = Date.Now
                        .Code = barcodedata
                        .StyleAssortmentMasterID = lStyleAssortmentMasterID
                        .SizeRangeID = SizeRangeID
                        .SizeDatabaseID = SizeDatabaseID
                        .Size = Size
                        .TotalOrderQty = txtQuantity.Text
                        .TotalSizeQty = Val(SizeQTY)
                        .Stitching = False
                        .Washing = False
                        .Finishing = False
                        .Packing = False
                        .Extra = txtExtra.Text
                        .LineNumber = LineNo
                        .StyleAssortmentDetailID = StyleAssortmentDetailID
                        .SaveStyleAssortmentBarCodeDetail()
                    End With
                Next
            Next
        Catch ex As Exception
        End Try
    End Sub
    Sub SaveBarCodeDetail()
        Try
            Dim dtcompletedate As DataTable
            Dim currentid As Long
            currentid = objStyleAssortmentMaster.GetID
            dtcompletedate = objStyleAssortmentBarCodeDetail.GetCompleteData(currentid, lJobOrderID, lJoborderDetailid)
            Dim Size As String = ""
            Dim SizeQTY As Decimal = 0
            Dim Breakup As String = ""
            Dim x As Integer
            Dim SizeRangeID As Long = 0
            Dim SizeDatabaseID As Long = 0
            Dim StyleAssortmentDetailID As Long = 0
            For x = 0 To dtcompletedate.Rows.Count - 1
                Breakup = dtcompletedate.Rows(x)("Breakup")
                Size = dtcompletedate.Rows(x)("Size")
                SizeRangeID = dtcompletedate.Rows(x)("SizeRangeID")
                SizeDatabaseID = dtcompletedate.Rows(x)("SizeDatabaseID")
                StyleAssortmentDetailID = dtcompletedate.Rows(x)("StyleAssortmentDetailID")
                If Breakup = "Assorted/Solid" Then
                    SizeQTY = dtcompletedate.Rows(x)("Asortqtyy")
                Else
                    SizeQTY = dtcompletedate.Rows(x)("QTYy")
                End If
                Dim LineNo As String = ""
                LineNo = dtcompletedate.Rows(x)("LineNumber")
                Dim totalCount As Integer
                Dim Increment As Integer = 0
                totalCount = SizeQTY
                Dim y As Integer
                For y = 0 To totalCount - 1
                    Increment = Increment + 1
                    With objStyleAssortmentBarCodeDetail
                        .StyleAssortmentBarCodeDetailID = 0
                        .JobOrderID = lJobOrderID
                        .JoborderDetailid = lJoborderDetailid
                        .Merchandiser = txtMarchand.Text
                        .Customer = txtCustomer.Text
                        .JobNo = txtJobNo.Text
                        .Style = txtStyle.Text
                        .Item = txtItem.Text
                        .Brand = txtBrand.Text
                        Dim barcodedata As String
                             barcodedata = (lJoborderDetailid.ToString) + (SizeDatabaseID.ToString) + (Increment.ToString)
                        Dim barcode As BarcodeLib.Barcode.Linear = New BarcodeLib.Barcode.Linear()
                        barcode.Type = BarcodeLib.Barcode.BarcodeType.CODE128
                        barcode.Data = barcodedata '"TFA-JO-00034PJTU50456P421"
                        barcode.LeftMargin = 0
                        barcode.RightMargin = 0
                        barcode.TopMargin = 0
                        barcode.BottomMargin = 0
                        barcode.Resolution = 72
                        barcode.Rotate = RotateOrientation.BottomFacingDown
                        barcode.UOM = UnitOfMeasure.PIXEL
                        barcode.drawBarcode("G:\Nizam\DalErp\APP\INTEGRA\BarCodeImage\barcode.JPG")
                        Dim path As String = Server.MapPath("~/BarCodeImage/barcode.JPG")
                        .BarCodeCount = Increment
                        .CreationDate = Date.Now
                        .Code = barcodedata
                        .StyleAssortmentMasterID = objStyleAssortmentMaster.GetID
                        .SizeRangeID = SizeRangeID 'dgStyleAssortment.Items(y).Cells(1).Text
                        .SizeDatabaseID = SizeDatabaseID ' dgStyleAssortment.Items(y).Cells(2).Text
                        .Size = Size 'dgStyleAssortment.Items(y).Cells(3).Text
                        .TotalOrderQty = txtQuantity.Text
                        .TotalSizeQty = SizeQTY
                        .Stitching = False
                        .Washing = False
                        .Finishing = False
                        .Packing = False
                        .Extra = 0
                        If LineNo = "" Then
                            .LineNumber = ""
                        Else
                            .LineNumber = LineNo
                        End If
                        .StyleAssortmentDetailID = StyleAssortmentDetailID
                        .SaveStyleAssortmentBarCodeDetail()
                    End With
                Next
            Next
        Catch ex As Exception
        End Try
    End Sub
    Sub SaveBarCodeDetailNewOnEdit()
        Try
            Dim dtcompletedate As DataTable
            Dim currentid As Long
            currentid = objStyleAssortmentMaster.GetID
            dtcompletedate = objStyleAssortmentBarCodeDetail.GetCompleteDataForNew(lStyleAssortmentMasterID, lJobOrderID, lJoborderDetailid)
            Dim Size As String = ""
            Dim SizeQTY As Decimal = 0
            Dim Breakup As String = ""
            Dim x As Integer
            Dim SizeRangeID As Long = 0
            Dim SizeDatabaseID As Long = 0
            Dim StyleAssortmentDetailID As Long = 0
            For x = 0 To dtcompletedate.Rows.Count - 1
                Breakup = dtcompletedate.Rows(x)("Breakup")
                Size = dtcompletedate.Rows(x)("Size")
                SizeRangeID = dtcompletedate.Rows(x)("SizeRangeID")
                SizeDatabaseID = dtcompletedate.Rows(x)("SizeDatabaseID")
                StyleAssortmentDetailID = dtcompletedate.Rows(x)("StyleAssortmentDetailID")
                If Breakup = "Assorted/Solid" Then
                    SizeQTY = dtcompletedate.Rows(x)("Asortqtyy")
                Else
                    SizeQTY = dtcompletedate.Rows(x)("QTYy")
                End If
                Dim LineNo As String = ""
                LineNo = dtcompletedate.Rows(x)("LineNumber")
                Dim dtchkbarcodegenerate As DataTable
                dtchkbarcodegenerate = objStyleAssortmentBarCodeDetail.ChkBarcodeTableHavedataNew(lStyleAssortmentMasterID, StyleAssortmentDetailID, LineNo)
                If dtchkbarcodegenerate.Rows.Count > 0 Then '----If have data then just update line no not Recreate Barcode
                    objStyleAssortmentBarCodeDetail.UpdateStyleAssortmentBarCodeDetailLineNo(LineNo, lStyleAssortmentMasterID, StyleAssortmentDetailID)
                Else
                    Dim totalCount As Integer
                    Dim Increment As Integer = 0
                    totalCount = SizeQTY
                    Dim y As Integer
                    For y = 0 To totalCount - 1
                        Increment = Increment + 1
                        With objStyleAssortmentBarCodeDetail
                            .StyleAssortmentBarCodeDetailID = 0
                            .JobOrderID = lJobOrderID
                            .JoborderDetailid = lJoborderDetailid
                            .Merchandiser = txtMarchand.Text
                            .Customer = txtCustomer.Text
                            .JobNo = txtJobNo.Text
                            .Style = txtStyle.Text
                            .Item = txtItem.Text
                            .Brand = txtBrand.Text
                            Dim barcodedata As String
                            barcodedata = (lJoborderDetailid.ToString) + (SizeDatabaseID.ToString) + (Increment.ToString)
                            Dim barcode As BarcodeLib.Barcode.Linear = New BarcodeLib.Barcode.Linear()
                            barcode.Type = BarcodeLib.Barcode.BarcodeType.CODE128
                            barcode.Data = barcodedata '"TFA-JO-00034PJTU50456P421"
                            barcode.LeftMargin = 0
                            barcode.RightMargin = 0
                            barcode.TopMargin = 0
                            barcode.BottomMargin = 0
                            barcode.Resolution = 72
                            barcode.Rotate = RotateOrientation.BottomFacingDown
                            barcode.UOM = UnitOfMeasure.PIXEL
                            barcode.drawBarcode("C:\inetpub\wwwroot\DalERP\BarCodeImage\barcode.JPG")
                            Dim path As String = Server.MapPath("~/BarCodeImage/barcode.JPG")
                            .BarCodeCount = Increment
                            .CreationDate = Date.Now
                            .Code = barcodedata
                            .StyleAssortmentMasterID = lStyleAssortmentMasterID 'objStyleAssortmentMaster.GetID
                            .SizeRangeID = SizeRangeID 'dgStyleAssortment.Items(y).Cells(1).Text
                            .SizeDatabaseID = SizeDatabaseID ' dgStyleAssortment.Items(y).Cells(2).Text
                            .Size = Size 'dgStyleAssortment.Items(y).Cells(3).Text
                            .TotalOrderQty = txtQuantity.Text
                            .TotalSizeQty = SizeQTY
                            .Stitching = False
                            .Washing = False
                            .Finishing = False
                            .Packing = False
                            .Extra = 0
                            If LineNo = "" Then
                                .LineNumber = ""
                            Else
                                .LineNumber = LineNo
                            End If
                            .StyleAssortmentDetailID = StyleAssortmentDetailID
                            .SaveStyleAssortmentBarCodeDetail()
                        End With
                    Next
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
    Sub SaveBarCodeDetailNewOnEditForDigital()
        Try
            Dim dtcompletedate As DataTable
            Dim currentid As Long
            currentid = objStyleAssortmentMaster.GetID

            dtcompletedate = objStyleAssortmentBarCodeDetail.GetCompleteDataForNew(lStyleAssortmentMasterID, lJobOrderID, lJoborderDetailid)

            Dim Size As String = ""
            Dim SizeQTY As Decimal = 0
            Dim Breakup As String = ""
            Dim x As Integer
            Dim SizeRangeID As Long = 0
            Dim SizeDatabaseID As Long = 0
            Dim StyleAssortmentDetailID As Long = 0
            For x = 0 To dtcompletedate.Rows.Count - 1
                Breakup = dtcompletedate.Rows(x)("Breakup")
                Size = dtcompletedate.Rows(x)("Size")
                SizeRangeID = dtcompletedate.Rows(x)("SizeRangeID")
                SizeDatabaseID = dtcompletedate.Rows(x)("SizeDatabaseID")
                StyleAssortmentDetailID = dtcompletedate.Rows(x)("StyleAssortmentDetailID")
                SizeQTY = dtcompletedate.Rows(x)("QTYy")
                Dim LineNo As String = ""
                LineNo = dtcompletedate.Rows(x)("LineNumberr")
                Dim dtchkbarcodegenerateWithLine As DataTable
                dtchkbarcodegenerateWithLine = objStyleAssortmentBarCodeDetail.ChkBarcodeTableHavedataNew(lStyleAssortmentMasterID, StyleAssortmentDetailID, LineNo)
                Dim dtchkbarcodegenerate As DataTable
                dtchkbarcodegenerate = objStyleAssortmentBarCodeDetail.ChkBarcodeTableHavedataNewWithOutLine(lStyleAssortmentMasterID, StyleAssortmentDetailID)
                If dtchkbarcodegenerateWithLine.Rows.Count > 0 Then '----If have data then just update line no not Recreate Barcode
                    objStyleAssortmentBarCodeDetail.UpdateStyleAssortmentBarCodeDetailLineNo(LineNo, lStyleAssortmentMasterID, StyleAssortmentDetailID)
                ElseIf dtchkbarcodegenerate.Rows.Count > 0 Then
                    objStyleAssortmentBarCodeDetail.UpdateStyleAssortmentBarCodeDetailLineNo(LineNo, lStyleAssortmentMasterID, StyleAssortmentDetailID)
                Else
                    Dim totalCount As Integer
                    Dim Increment As Integer = 0
                    totalCount = SizeQTY
                    Dim y As Integer
                    For y = 0 To totalCount - 1
                        Increment = Increment + 1
                        With objStyleAssortmentBarCodeDetail
                            .StyleAssortmentBarCodeDetailID = 0
                            .JobOrderID = lJobOrderID
                            .JoborderDetailid = lJoborderDetailid
                            .Merchandiser = txtMarchand.Text
                            .Customer = txtCustomer.Text
                            .JobNo = txtJobNo.Text
                            .Style = txtStyle.Text
                            .Item = txtItem.Text
                            .Brand = txtBrand.Text
                            Dim barcodedata As String
                            barcodedata = (lJoborderDetailid.ToString) + (SizeDatabaseID.ToString) + (Increment.ToString)
                            Dim barcode As BarcodeLib.Barcode.Linear = New BarcodeLib.Barcode.Linear()
                            barcode.Type = BarcodeLib.Barcode.BarcodeType.CODE128
                            barcode.Data = barcodedata '"TFA-JO-00034PJTU50456P421"
                            barcode.LeftMargin = 0
                            barcode.RightMargin = 0
                            barcode.TopMargin = 0
                            barcode.BottomMargin = 0
                            barcode.Resolution = 72
                            barcode.Rotate = RotateOrientation.BottomFacingDown
                            barcode.UOM = UnitOfMeasure.PIXEL
                            barcode.drawBarcode("C:\inetpub\wwwroot\DalERP\BarCodeImage\barcode.JPG")
                            Dim path As String = Server.MapPath("~/BarCodeImage/barcode.JPG")
                            .BarCodeCount = Increment
                            .CreationDate = Date.Now
                            .Code = barcodedata
                            .StyleAssortmentMasterID = lStyleAssortmentMasterID 'objStyleAssortmentMaster.GetID
                            .SizeRangeID = SizeRangeID 'dgStyleAssortment.Items(y).Cells(1).Text
                            .SizeDatabaseID = SizeDatabaseID ' dgStyleAssortment.Items(y).Cells(2).Text
                            .Size = Size 'dgStyleAssortment.Items(y).Cells(3).Text
                            .TotalOrderQty = txtQuantity.Text
                            .TotalSizeQty = SizeQTY
                            .Stitching = False
                            .Washing = False
                            .Finishing = False
                            .Packing = False
                            .Extra = 0
                            If LineNo = "" Then
                                .LineNumber = ""
                            Else
                                .LineNumber = LineNo
                            End If
                            .StyleAssortmentDetailID = StyleAssortmentDetailID
                            .SaveStyleAssortmentBarCodeDetail()
                        End With
                    Next
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
    Private Function GetFileContent(ByVal imageFilePath As String) As Byte()
        Dim fileStream As Stream = New FileStream(imageFilePath, FileMode.Open)
        Dim fileContent As Byte() = New Byte(fileStream.Length - 1) {}
        fileStream.Read(fileContent, 0, CInt(fileStream.Length))
        fileStream.Close()
        Return fileContent
    End Function
End Class

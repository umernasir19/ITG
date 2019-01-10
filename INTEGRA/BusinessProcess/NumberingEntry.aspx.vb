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
Public Class NumberingEntry
    Inherits System.Web.UI.Page
    Dim objStyleAssortmentBarCodeDetail As New StyleAssortmentBarCodeDetail
    Dim objGeneralCode As New GeneralCode
    Dim objStyleAssortmentMaster As New StyleAssortmentMaster
    Dim objStyleAssortmentDetail As New StyleAssortmentDetail
    Dim dtWashingDatabase As New DataTable
    Dim dr As DataRow
    Dim lJobOrderID, lJoborderDetailid, lStyleAssortmentMasterID, lSizeWiseWeightListMstID As Long
    Dim UserId As Long
    Dim DtStyleAssortmentDetail As New DataTable
    Dim dtGrid, dtAddQty As New DataTable
    Dim Styles As String
    Dim RoleID As Long
    Dim objSizeWiseWeightListMst As New SizeWiseWeightListMst
    Dim objSizeWiseWeightListDtl As New SizeWiseWeightListDtl
    Dim objCuttingProMst As New CuttingProMst
    Dim objNumbering As New Numbering
    Dim objNumberingDtl As New NumberingDtl
    Dim dtNumbering As DataTable
    Dim objNumberingFinal As New NumberingFinal
    Dim objNumberingFinalDtl As New NumberingFinalDtl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lJobOrderID = Request.QueryString("JobOrderID")
        lJoborderDetailid = Request.QueryString("JoborderDetailid")
        Styles = Request.QueryString("Styles")
        UserId = Session("UserId")
        RoleID = Session("RoleId")
        If Not IsPostBack Then
            Session("dtGrid") = Nothing
            Session("dtNumbering") = Nothing
            Session("dtAddQty") = Nothing
            txtReceiveDate.Text = Date.Now
            GetReceivingNo()
            GetMasterData()
            BindGrid()
            BindSize()
            Dim dt As DataTable = objStyleAssortmentMaster.GetNumberingNo(lJoborderDetailid)
            If dt.Rows.Count > 0 Then
                lblNumberingNo.Text = dt.Rows(0)("NumberingNo")
            End If
            If dgStyleAssortment.Items.Count = 0 Then
                AddPnl.Visible = True
            Else
                AddPnl.Visible = False
            End If
        End If
        PageHeader("Numbering Entry")
    End Sub
    Protected Sub btnAddQty_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddQty.Click
        If cmbSize.SelectedItem.Text = "Select" Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Size")
        ElseIf txtAddQty.Text = "" Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Qty")
        Else
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
            AddQtySession()
            BindGridAfterNewQtyAdd()
            txtAddQty.Text = ""
            cmbSize.SelectedIndex = -1
        End If
    End Sub
    Sub AddQtySession()
        If (Not CType(Session("dtAddQty"), DataTable) Is Nothing) Then
            dtAddQty = Session("dtAddQty")
        Else
            dtAddQty = New DataTable
            With dtAddQty
                .Columns.Add("NumberingDtlID", GetType(Long))
                .Columns.Add("NumberingID", GetType(Long))
                .Columns.Add("SizeRangeId", GetType(Long))
                .Columns.Add("SizeDatabaseId", GetType(Long))
                .Columns.Add("StyleAssortmentDetailID", GetType(Long))
                .Columns.Add("StyleAssortmentMasterID", GetType(Long))
                .Columns.Add("CuttingProDetailID", GetType(Long))
                .Columns.Add("CuttingProMasterID", GetType(Long))
                .Columns.Add("Joborderid", GetType(Long))
                .Columns.Add("JoborderDetailid", GetType(Long))
                .Columns.Add("BuyerColor", GetType(String))
                .Columns.Add("Style", GetType(String))
                .Columns.Add("CartonNo", GetType(Decimal))
                .Columns.Add("Code", GetType(String))
                .Columns.Add("Sizee", GetType(String))
                .Columns.Add("PcsPerCarton", GetType(String))
                .Columns.Add("SelectNumbering", GetType(String))
                .Columns.Add("SerialNo", GetType(Decimal))
                .Columns.Add("Weight", GetType(Decimal))  
            End With
        End If
        Dim dt As DataTable
        If cmbSize.SelectedItem.Text = "Mixed" Then
            dt = objStyleAssortmentMaster.GetDataAddNew2(lJoborderDetailid)
        Else
            dt = objStyleAssortmentMaster.GetDataAddNew(lJoborderDetailid, cmbSize.SelectedValue)
        End If
        dr = dtAddQty.NewRow()
        dr("SizeRangeId") = dt.Rows(0)("SizeRangeId")
        dr("SizeDatabaseId") = dt.Rows(0)("SizeDatabaseId")
        If cmbSize.SelectedItem.Text = "Mixed" Then
            dr("StyleAssortmentDetailID") = 0
            dr("StyleAssortmentMasterID") = 0
            dr("CuttingProDetailID") = 0
            dr("CuttingProMasterID") = 0
        Else
            dr("StyleAssortmentDetailID") = dt.Rows(0)("StyleAssortmentDetailID")
            dr("StyleAssortmentMasterID") = dt.Rows(0)("StyleAssortmentMasterID")
            dr("CuttingProDetailID") = dt.Rows(0)("CuttingProDetailID")
            dr("CuttingProMasterID") = dt.Rows(0)("CuttingProMasterID")
        End If
        dr("Joborderid") = dt.Rows(0)("Joborderid")
        dr("JoborderDetailid") = dt.Rows(0)("JoborderDetailid")
        dr("BuyerColor") = dt.Rows(0)("BuyerColor")
        dr("Style") = dt.Rows(0)("Style")
        If cmbSize.SelectedItem.Text = "Mixed" Then
            dr("Sizee") = "Mixed"
        Else
            dr("Sizee") = dt.Rows(0)("Sizee")
        End If
        dr("PcsPerCarton") = txtAddQty.Text
        dr("Weight") = 0
        Dim CartonNo As Decimal = 0
        Dim CartonNoo As Decimal = 0
        Dim dtr As DataTable = objStyleAssortmentMaster.GetNumberingNoNewwww(lJoborderDetailid)
        CartonNo = dtr.Rows(0)("CartonNo")
        CartonNoo = CartonNo + 1
        dr("CartonNo") = CartonNoo
        Dim Code As Decimal = 0
        Dim Codee As Decimal = 0
        Code = dtr.Rows(0)("Code")
        Codee = Code + 1
        dr("Code") = Codee
        dr("NumberingDtlID") = dtr.Rows(0)("NumberingDtlID") + 1
        dr("NumberingID") = dtr.Rows(0)("NumberingID")
        Dim dtre As DataTable = objStyleAssortmentMaster.GetNumberingNoNewwwwwww(lJoborderDetailid)
        Dim Serial As Decimal = 0
        Dim Seriall As Decimal = 0
        Serial = dtre.Rows(0)("SerialNo")
        Seriall = Serial + 1
        dr("SerialNo") = Seriall
        dr("SelectNumbering") = 0
        dtAddQty.Rows.Add(dr)
        Session("dtAddQty") = dtAddQty
    End Sub
    Private Sub BindGridAfterNewQtyAdd()
        Dim x As Integer
        Try
            Dim objDatatable As DataTable = Session("dtAddQty")
            If objDatatable.Rows.Count > 0 Then
                dgStyleAssortment.Visible = True
                dgStyleAssortment.RecordCount = objDatatable.Rows.Count
                dgStyleAssortment.DataSource = objDatatable
                dgStyleAssortment.DataBind()
                btnsave.Visible = True
            Else
                dgStyleAssortment.Visible = False
            End If
            For x = 0 To dgStyleAssortment.Items.Count - 1
                Dim txtQty As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtQty"), TextBox)
                Dim ChkSelect As CheckBox = CType(dgStyleAssortment.Items(x).FindControl("ChkSelect"), CheckBox)
                Dim txtCartonNo As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtCartonNo"), TextBox)
                Dim txtSize As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtSize"), TextBox)
                Dim Status As String = objDatatable.Rows(x)("SelectNumbering")
                If Status = 1 Then
                    ChkSelect.Checked = True
                Else
                    ChkSelect.Checked = False
                End If
                txtQty.Text = objDatatable.Rows(x)("PcsPerCarton")
                txtCartonNo.Text = objDatatable.Rows(x)("CartonNo")
                txtSize.Text = objDatatable.Rows(x)("Sizee")
            Next
            Dim total As Decimal = 0
            Dim z As Integer
            For z = 0 To dgStyleAssortment.Items.Count - 1
                Dim txtQty As TextBox = CType(dgStyleAssortment.Items(z).FindControl("txtQty"), TextBox)
                Dim ChkSelect As CheckBox = CType(dgStyleAssortment.Items(z).FindControl("ChkSelect"), CheckBox)
                If ChkSelect.Checked = True Then
                    total = total + Val(txtQty.Text)
                End If
            Next
            lblTotal.Text = total
            Dim totalCount As Decimal = 0
            Dim a As Integer
            For a = 0 To dgStyleAssortment.Items.Count - 1
                Dim ChkSelect As CheckBox = CType(dgStyleAssortment.Items(a).FindControl("ChkSelect"), CheckBox)
                If ChkSelect.Checked = True Then
                    totalCount = totalCount + 1
                End If
            Next
            LBLNoOfCarton.Text = totalCount
        Catch ex As Exception
        End Try
    End Sub
    Sub BindSize()
        Try
            Dim dtPONO As DataTable
            dtPONO = objStyleAssortmentMaster.GetSizeFromAddQty(lJoborderDetailid)
            cmbSize.DataSource = dtPONO
            cmbSize.DataTextField = "Size"
            cmbSize.DataValueField = "StyleAssortmentDetailID"
            cmbSize.DataBind()
            cmbSize.Items.Insert(0, New ListItem("Mixed", 0))
            cmbSize.Items.Insert(0, New ListItem("Select"))
        Catch ex As Exception
        End Try
    End Sub
    Sub GetReceivingNo()
        Try
            Dim VoucherNo As String
            Dim Voucherdate As Date = Date.Now
            Dim month As String = Voucherdate.Month
            Dim LastVoucherNo As String = objStyleAssortmentMaster.GetLastNoLatestReceiveNo()
            Dim LastCode As String
            If LastVoucherNo = "" Then
                LastCode = "0001"
            Else
                LastCode = LastVoucherNo.Substring(4, 4)
                If LastCode < 10 Then
                    If LastCode = 9 Then
                        LastCode = "00" & Val(LastCode + 1)
                    Else
                        LastCode = "000" & Val(LastCode + 1)
                    End If
                ElseIf LastCode < 100 Or LastCode = 10 Then
                    If LastCode = 99 Then
                        LastCode = "0" & Val(LastCode + 1)
                    Else
                        LastCode = "00" & Val(LastCode + 1)
                    End If
                ElseIf LastCode < 1000 Or LastCode = 100 Then
                    If LastCode = 999 Then
                        LastCode = "" & Val(LastCode + 1)
                    Else
                        LastCode = "0" & Val(LastCode + 1)
                    End If
                ElseIf LastCode < 10000 Or LastCode = 1000 Then
                    If LastCode = 9999 Then
                        LastCode = Val(LastCode + 1)
                    Else
                        LastCode = "" & Val(LastCode + 1)
                    End If
                Else
                    LastCode = Val(LastCode + 1)
                End If
            End If
            VoucherNo = "REC" & "-" & LastCode
            txtReceiveNo.Text = VoucherNo
        Catch ex As Exception
        End Try
    End Sub
    Sub GetMasterData()
        Dim dtMasterData As New DataTable
        Try
            dtMasterData = objStyleAssortmentMaster.GetDataWeight(lJobOrderID)
            txtStyle.Text = dtMasterData.Rows(0)("Style")
            txtJobNo.Text = dtMasterData.Rows(0)("SRNo")
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
    Protected Sub Status(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim total As Decimal = 0
        Dim z As Integer
        For z = 0 To dgStyleAssortment.Items.Count - 1
            Dim txtQty As TextBox = CType(dgStyleAssortment.Items(z).FindControl("txtQty"), TextBox)
            Dim ChkSelect As CheckBox = CType(dgStyleAssortment.Items(z).FindControl("ChkSelect"), CheckBox)
            If ChkSelect.Checked = True Then
                total = total + Val(txtQty.Text)
            End If
        Next
        lblTotal.Text = total
        Dim totalCount As Decimal = 0
        Dim a As Integer
        For a = 0 To dgStyleAssortment.Items.Count - 1
            Dim ChkSelect As CheckBox = CType(dgStyleAssortment.Items(a).FindControl("ChkSelect"), CheckBox)
            If ChkSelect.Checked = True Then
                totalCount = totalCount + 1
            End If
        Next
        LBLNoOfCarton.Text = totalCount
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub save()
        With objNumberingFinal
            .NumberingFinalID = 0
            .NumberingID = dgStyleAssortment.Items(0).Cells(1).Text
            .CreationDate = Date.Now
            .UserId = UserId
            Dim dt As DataTable = objStyleAssortmentMaster.GetJoborderData(lJoborderDetailid)
            If dt.Rows.Count > 0 Then
                .CustomerID = dt.Rows(0)("CustomerDatabaseid")
                .CustomerPoNo = dt.Rows(0)("CustomerOrder")
            End If
            .ReceivingNo = txtReceiveNo.Text
            .ReceiveDate = txtReceiveDate.Text
            .Qty = lblTotal.Text
            .Carton = LBLNoOfCarton.Text
            .Weight = 0
            .Save()
        End With
        Dim x As Integer
        For x = 0 To dgStyleAssortment.Items.Count - 1
            Dim ChkSelect As CheckBox = CType(dgStyleAssortment.Items(x).FindControl("ChkSelect"), CheckBox)
            With objNumberingDtl
                Dim Status As String
                Dim NumberingDtlID As Long
                NumberingDtlID = dgStyleAssortment.Items(x).Cells(0).Text
                If ChkSelect.Checked = True Then
                    Status = 1
                Else
                    Status = 0
                End If
                Dim dt As DataTable = objStyleAssortmentMaster.UpdateNumberingDtl(NumberingDtlID, Status)
            End With
        Next
        Dim z As Integer
        For z = 0 To dgStyleAssortment.Items.Count - 1
            Dim txtQty As TextBox = CType(dgStyleAssortment.Items(z).FindControl("txtQty"), TextBox)
            Dim txtCartonNo As TextBox = CType(dgStyleAssortment.Items(z).FindControl("txtCartonNo"), TextBox)
            Dim ChkSelect As CheckBox = CType(dgStyleAssortment.Items(z).FindControl("ChkSelect"), CheckBox)
            Dim txtSize As TextBox = CType(dgStyleAssortment.Items(z).FindControl("txtSize"), TextBox)
            With objNumberingFinalDtl
                If ChkSelect.Checked = True Then
                    .NumberingFinalDtlID = 0
                    .NumberingFinalID = objNumberingFinal.GetID()
                    .NumberingDtlID = dgStyleAssortment.Items(z).Cells(0).Text
                    .NumberingID = dgStyleAssortment.Items(z).Cells(1).Text
                    .SizeRangeId = dgStyleAssortment.Items(z).Cells(2).Text
                    .SizeDatabaseId = dgStyleAssortment.Items(z).Cells(3).Text
                    If txtSize.Text = dgStyleAssortment.Items(z).Cells(16).Text Then
                        .StyleAssortmentDetailID = dgStyleAssortment.Items(z).Cells(4).Text
                    Else
                        Dim dt As DataTable = objStyleAssortmentMaster.GetStyleAssortmrntDetailId(lJoborderDetailid, txtSize.Text)
                        .StyleAssortmentDetailID = dt.Rows(0)("StyleAssortmentDetailID")
                    End If
                    .StyleAssortmentMasterID = dgStyleAssortment.Items(z).Cells(5).Text
                    .CuttingProDetailID = dgStyleAssortment.Items(z).Cells(6).Text
                    .CuttingProMasterID = dgStyleAssortment.Items(z).Cells(7).Text
                    .Joborderid = dgStyleAssortment.Items(z).Cells(8).Text
                    .JoborderDetailid = dgStyleAssortment.Items(z).Cells(9).Text
                    .CartonNo = txtCartonNo.Text
                    .Code = dgStyleAssortment.Items(z).Cells(14).Text
                    .SerialNo = dgStyleAssortment.Items(z).Cells(15).Text
                    .SelectNumbering = 1
                    .SelectPacking = 1
                    .DonePacking = 0
                    .PcsPerCarton = txtQty.Text
                    .Save()
                End If
            End With
        Next
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("NumberingView.aspx")
    End Sub
    Protected Sub dgStyleAssortment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgStyleAssortment.SelectedIndexChanged
    End Sub
    Protected Sub dgStyleAssortment_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgStyleAssortment.SortCommand
    End Sub
    Private Sub BindGrid()
        Dim x As Integer
        Try
                Dim objDatatable As DataTable
            objDatatable = objStyleAssortmentMaster.CheckNumberingData(lJoborderDetailid)
                If objDatatable.Rows.Count > 0 Then
                    dgStyleAssortment.Visible = True
                    dgStyleAssortment.RecordCount = objDatatable.Rows.Count
                    dgStyleAssortment.DataSource = objDatatable
                    dgStyleAssortment.DataBind()
                    btnsave.Visible = True
                Else
                    dgStyleAssortment.Visible = False
                End If
                For x = 0 To dgStyleAssortment.Items.Count - 1
                Dim txtQty As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtQty"), TextBox)
                Dim ChkSelect As CheckBox = CType(dgStyleAssortment.Items(x).FindControl("ChkSelect"), CheckBox)
                Dim txtCartonNo As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtCartonNo"), TextBox)
                Dim txtSize As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtSize"), TextBox)
                Dim Status As String = objDatatable.Rows(x)("SelectNumbering")
                If Status = 1 Then
                    ChkSelect.Checked = True
                Else
                    ChkSelect.Checked = False
                End If
                txtQty.Text = objDatatable.Rows(x)("PcsPerCartonn")
                txtCartonNo.Text = objDatatable.Rows(x)("CartonNo")
                txtSize.Text = objDatatable.Rows(x)("Sizee")
            Next
            Dim total As Decimal = 0
            Dim z As Integer
            For z = 0 To dgStyleAssortment.Items.Count - 1
                Dim txtQty As TextBox = CType(dgStyleAssortment.Items(z).FindControl("txtQty"), TextBox)
                Dim ChkSelect As CheckBox = CType(dgStyleAssortment.Items(z).FindControl("ChkSelect"), CheckBox)
                If ChkSelect.Checked = True Then
                    total = total + Val(txtQty.Text)
                End If
            Next
            lblTotal.Text = total
            Dim totalCount As Decimal = 0
            Dim a As Integer
            For a = 0 To dgStyleAssortment.Items.Count - 1
                Dim ChkSelect As CheckBox = CType(dgStyleAssortment.Items(a).FindControl("ChkSelect"), CheckBox)
                If ChkSelect.Checked = True Then
                    totalCount = totalCount + 1
                End If
            Next
            LBLNoOfCarton.Text = totalCount
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Try
            save()
            Response.Redirect("NumberingView.aspx")
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtQty_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim total As Decimal = 0
        Dim z As Integer
        For z = 0 To dgStyleAssortment.Items.Count - 1
            Dim txtQty As TextBox = CType(dgStyleAssortment.Items(z).FindControl("txtQty"), TextBox)
            Dim ChkSelect As CheckBox = CType(dgStyleAssortment.Items(z).FindControl("ChkSelect"), CheckBox)
            If ChkSelect.Checked = True Then
                total = total + Val(txtQty.Text)
            End If
        Next
        lblTotal.Text = total
        Dim totalCount As Decimal = 0
        Dim a As Integer
        For a = 0 To dgStyleAssortment.Items.Count - 1
            Dim ChkSelect As CheckBox = CType(dgStyleAssortment.Items(a).FindControl("ChkSelect"), CheckBox)
            If ChkSelect.Checked = True Then
                totalCount = totalCount + 1
            End If
        Next
        LBLNoOfCarton.Text = totalCount
    End Sub
End Class

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
Public Class NumberingWeightEntry
    Inherits System.Web.UI.Page
    Dim objStyleAssortmentBarCodeDetail As New StyleAssortmentBarCodeDetail
    Dim objGeneralCode As New GeneralCode
    Dim objStyleAssortmentMaster As New StyleAssortmentMaster
    Dim objStyleAssortmentDetail As New StyleAssortmentDetail
    Dim dtWashingDatabase As New DataTable
    Dim dr As DataRow
    Dim lJobOrderID, lNumberingFinalID, lStyleAssortmentMasterID, lSizeWiseWeightListMstID As Long
    Dim UserId As Long
    Dim DtStyleAssortmentDetail As New DataTable
    Dim dtGrid As New DataTable
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
        lNumberingFinalID = Request.QueryString("NumberingFinalID")
        Styles = Request.QueryString("Styles")
        UserId = Session("UserId")
        RoleID = Session("RoleId")
        If Not IsPostBack Then
            BindGrid()
            SummaryGridNew()
            Dim dt As DataTable = objStyleAssortmentMaster.GetReceivingNo(lNumberingFinalID)
            If dt.Rows.Count > 0 Then
                lblReceivingNo.Text = dt.Rows(0)("ReceivingNo")
            End If
        End If
        PageHeader("Weight Entry")
    End Sub
    Sub SummaryGridNew()
        Dim dt As DataTable = objStyleAssortmentMaster.CheckWeightDataSummaryGrid(lNumberingFinalID)
        dgViewNew.DataSource = dt
        dgViewNew.DataBind()
        Dim totalCartonNew As Decimal = 0
        Dim totalQtyy As Decimal = 0
        Dim totalWeightt As Decimal = 0
        Dim v As Integer
        For v = 0 To dgViewNew.Items.Count - 1
            Dim txtWeight As Decimal = dgViewNew.Items(v).Cells(2).Text
            totalCartonNew = totalCartonNew + txtWeight
            totalQtyy = totalQtyy + dgViewNew.Items(v).Cells(3).Text
            totalWeightt = totalWeightt + dgViewNew.Items(v).Cells(4).Text
        Next
        lblTotalCarton.Text = totalCartonNew
        lblTotalQty.Text = totalQtyy
        lblTotalWeightnew.Text = totalWeightt
    End Sub
    Protected Sub Status(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim z As Integer
        For z = 0 To dgViewNew.Items.Count - 1
            Dim totalQty As Decimal = 0
            Dim totalWeight As Decimal = 0
            Dim totalCarton As Decimal = 0
            Dim totalCartonFinal As Decimal = 0
            Dim SizeId As Long
            Dim IDS As String = dgViewNew.Items(z).Cells(0).Text.Replace("&nbsp;", "")
            Dim Name As String = IDS.ToString
            If Name = "" Then
                SizeId = 0
            Else
                SizeId = dgViewNew.Items(z).Cells(0).Text
            End If
            Dim x As Integer
            For x = 0 To dgStyleAssortment.Items.Count - 1
                Dim SizeMainId As Long
                Dim IDSS As String = dgStyleAssortment.Items(x).Cells(4).Text.Replace("&nbsp;", "")
                Dim Namee As String = IDSS.ToString
                If Namee = "" Then
                    SizeMainId = 0
                Else
                    SizeMainId = dgStyleAssortment.Items(x).Cells(4).Text
                End If
                Dim ChkSelect As CheckBox = CType(dgStyleAssortment.Items(x).FindControl("ChkSelect"), CheckBox)
                Dim txtWeight As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtWeight"), TextBox)
                If ChkSelect.Checked = True And SizeId = SizeMainId Then
                    totalCarton = totalCarton + 1
                    totalQty = totalQty + dgStyleAssortment.Items(x).Cells(16).Text
                    totalWeight = Math.Round(totalWeight + Val(txtWeight.Text), 3)
                    totalCartonFinal = totalCartonFinal + totalCarton
                End If
            Next
            dgViewNew.Items(z).Cells(3).Text = totalQty
            dgViewNew.Items(z).Cells(4).Text = totalWeight
            dgViewNew.Items(z).Cells(2).Text = totalCarton
        Next
        Dim totalCartonNew As Decimal = 0
        Dim totalQtyy As Decimal = 0
        Dim totalWeightt As Decimal = 0
        Dim v As Integer
        For v = 0 To dgViewNew.Items.Count - 1
            Dim txtWeight As Decimal = dgViewNew.Items(v).Cells(2).Text
            totalCartonNew = totalCartonNew + txtWeight
            totalQtyy = totalQtyy + dgViewNew.Items(v).Cells(3).Text
            totalWeightt = totalWeightt + dgViewNew.Items(v).Cells(4).Text
        Next
        lblTotalCarton.Text = totalCartonNew
        lblTotalQty.Text = totalQtyy
        lblTotalWeightnew.Text = totalWeightt
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub save()
        Dim z As Integer
        For z = 0 To dgStyleAssortment.Items.Count - 1
            Dim NumberingFinalDtlID As Long = dgStyleAssortment.Items(z).Cells(0).Text
            Dim txtWeight As TextBox = CType(dgStyleAssortment.Items(z).FindControl("txtWeight"), TextBox)
            Dim ChkSelect As CheckBox = CType(dgStyleAssortment.Items(z).FindControl("ChkSelect"), CheckBox)
            Dim Status As String = ""
            If ChkSelect.Checked = True Then
                Status = 1
            Else
                Status = 0
            End If
            Dim dt As DataTable = objStyleAssortmentMaster.UpdateNumberingFinalDtl(NumberingFinalDtlID, Val(txtWeight.Text), Status)
            Dim dtt As DataTable = objStyleAssortmentMaster.GetNumberingFinalId(NumberingFinalDtlID)
            Dim ID As Long = dtt.Rows(0)("NumberingFinalID")
            objStyleAssortmentMaster.UpdateNumberingFinalDtlMasterTable(ID, Val(lblTotalWeight.Text))
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
            objDatatable = objStyleAssortmentMaster.CheckWeightData(lNumberingFinalID)
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
                Dim txtWeight As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtWeight"), TextBox)
                Dim ChkSelect As CheckBox = CType(dgStyleAssortment.Items(x).FindControl("ChkSelect"), CheckBox)
                Dim Status As String = objDatatable.Rows(x)("SelectPacking")
                Dim DonePacking As String = objDatatable.Rows(x)("DonePacking")
                txtWeight.Text = objDatatable.Rows(x)("Weight")
                If Status = 1 Then
                    ChkSelect.Checked = True
                Else
                    ChkSelect.Checked = False
                End If
                If DonePacking = 1 Then
                    ChkSelect.Enabled = False
                Else
                    ChkSelect.Enabled = True
                End If
            Next
            Dim total As Decimal = 0
            Dim z As Integer
            For z = 0 To dgStyleAssortment.Items.Count - 1
                Dim txtWeight As TextBox = CType(dgStyleAssortment.Items(z).FindControl("txtWeight"), TextBox)
                total = total + Val(txtWeight.Text)
            Next
            lblTotalWeight.Text = total
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
    Protected Sub txtWeight_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim total As Decimal = 0
        Dim c As Integer
        For c = 0 To dgStyleAssortment.Items.Count - 1
            Dim txtWeight As TextBox = CType(dgStyleAssortment.Items(c).FindControl("txtWeight"), TextBox)
            total = total + Val(txtWeight.Text)
        Next
        lblTotalWeight.Text = total
        Dim z As Integer
        For z = 0 To dgViewNew.Items.Count - 1
            Dim totalQty As Decimal = 0
            Dim totalWeight As Decimal = 0
            Dim totalCarton As Decimal = 0
            Dim totalCartonFinal As Decimal = 0
            Dim SizeId As Long
            Dim IDS As String = dgViewNew.Items(z).Cells(0).Text.Replace("&nbsp;", "")
            Dim Name As String = IDS.ToString
            If Name = "" Then
                SizeId = 0
            Else
                SizeId = dgViewNew.Items(z).Cells(0).Text
            End If
            Dim x As Integer
            For x = 0 To dgStyleAssortment.Items.Count - 1
                Dim SizeMainId As Long
                Dim IDSS As String = dgStyleAssortment.Items(x).Cells(4).Text.Replace("&nbsp;", "")
                Dim Namee As String = IDSS.ToString
                If Namee = "" Then
                    SizeMainId = 0
                Else
                    SizeMainId = dgStyleAssortment.Items(x).Cells(4).Text
                End If
                Dim ChkSelect As CheckBox = CType(dgStyleAssortment.Items(x).FindControl("ChkSelect"), CheckBox)
                Dim txtWeight As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtWeight"), TextBox)
                If ChkSelect.Checked = True And SizeId = SizeMainId Then
                    totalCarton = totalCarton + 1
                    totalQty = totalQty + dgStyleAssortment.Items(x).Cells(16).Text
                    totalWeight = Math.Round(totalWeight + Val(txtWeight.Text), 3)
                    totalCartonFinal = totalCartonFinal + totalCarton
                End If
            Next
            dgViewNew.Items(z).Cells(3).Text = totalQty
            dgViewNew.Items(z).Cells(4).Text = totalWeight
            dgViewNew.Items(z).Cells(2).Text = totalCarton
        Next
        Dim totalCartonNew As Decimal = 0
        Dim totalQtyy As Decimal = 0
        Dim totalWeightt As Decimal = 0
        Dim v As Integer
        For v = 0 To dgViewNew.Items.Count - 1
            Dim txtWeight As Decimal = dgViewNew.Items(v).Cells(2).Text
            totalCartonNew = totalCartonNew + txtWeight
            totalQtyy = totalQtyy + dgViewNew.Items(v).Cells(3).Text
            totalWeightt = totalWeightt + dgViewNew.Items(v).Cells(4).Text
        Next
        lblTotalCarton.Text = totalCartonNew
        lblTotalQty.Text = totalQtyy
        lblTotalWeightnew.Text = totalWeightt
    End Sub
End Class

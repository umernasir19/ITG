Imports System.Data
Imports Integra.classes
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports classes
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
Public Class SizeWiseWeightList
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
    Dim dtGrid As New DataTable
    Dim Styles As String
    Dim RoleID As Long
    Dim objSizeWiseWeightListMst As New SizeWiseWeightListMst
    Dim objSizeWiseWeightListDtl As New SizeWiseWeightListDtl
    Dim objCuttingProMst As New CuttingProMst
    Dim objNumbering As New Numbering
    Dim objNumberingDtl As New NumberingDtl
    Dim dtNumbering As DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lJobOrderID = Request.QueryString("JobOrderID")
        Styles = Request.QueryString("Styles")
        UserId = Session("UserId")
        RoleID = Session("RoleId")
        If Not IsPostBack Then
            Session("dtGrid") = Nothing
            Session("dtNumbering") = Nothing
            Dim dtcheck As DataTable = objCuttingProMst.checkSizeWeight(lJobOrderID)
            If dtcheck.Rows.Count > 0 Then
                lblid.Text = dtcheck.Rows(0)("SizeWiseWeightListMstID")
            End If
            GetMasterData()
            BindGrid()
        End If
        PageHeader("Size Wise Weight List")
    End Sub
    Sub GRNNoGenerateOnLoad()
        Try
            Dim VoucherNo As String
            Dim Voucherdate As Date = Date.Now
            Dim month As String = Voucherdate.Month
            Dim LastVoucherNo As String = objStyleAssortmentMaster.GetLastNoLatest()
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
            VoucherNo = "SHP" & "-" & LastCode
            txtShipNo.Text = VoucherNo
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
    Sub GetForEdit()
        Dim dt As New DataTable
        dt = objStyleAssortmentMaster.GetForEditForSizeWiseWeightList(lSizeWiseWeightListMstID)
        If dt.Rows.Count > 0 Then
            txtCreationDate.Text = dt.Rows(0)("CreationDate")
          Session("dtGrid") = dt
            BindGrid()
        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub SaveMaster()
        Try
            With objSizeWiseWeightListMst
                If Val(lblid.Text) > 0 Then
                    .SizeWiseWeightListMstID = lblid.Text
                Else
                    .SizeWiseWeightListMstID = 0
                End If
                .JobOrderID = lJobOrderID
                .UserID = UserId
                .CreationDate = objGeneralCode.GetDate(txtCreationDate.Text)
                .Save()
            End With
        Catch ex As Exception
        End Try
    End Sub
    Sub saveDetail()
        Dim x As Integer
        Try
            For x = 0 To dgStyleAssortment.Items.Count - 1
                Dim txtDimension As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtDimension"), TextBox)
                Dim txtPcsPerCarton As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtPcsPerCarton"), TextBox)
                Dim txtWeightPerPiece As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtWeightPerPiece"), TextBox)
                Dim txtNoOfCarton As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtNoOfCarton"), TextBox)
                Dim txtExtra As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtExtra"), TextBox)
                Dim txtTotalQty As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtTotalQty"), TextBox)
                Dim txtBalance As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtBalance"), TextBox)
                Dim txtWeight As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtWeight"), TextBox)
                With objSizeWiseWeightListDtl
                    If Val(lblid.Text) > 0 Then
                        .SizeWiseWeightListMstID = lblid.Text
                    Else
                        .SizeWiseWeightListMstID = objSizeWiseWeightListMst.GetID
                    End If
                    .SizeWiseWeightListDtlID = dgStyleAssortment.Items(x).Cells(0).Text
                    .SizeRangeId = dgStyleAssortment.Items(x).Cells(1).Text
                    .SizeDatabaseId = dgStyleAssortment.Items(x).Cells(2).Text
                    .StyleAssortmentDetailID = dgStyleAssortment.Items(x).Cells(3).Text
                    .StyleAssortmentMasterID = dgStyleAssortment.Items(x).Cells(4).Text
                    .CuttingProDetailID = dgStyleAssortment.Items(x).Cells(5).Text
                    .CuttingProMasterID = dgStyleAssortment.Items(x).Cells(6).Text
                    .Joborderid = dgStyleAssortment.Items(x).Cells(7).Text
                    .JoborderDetailid = dgStyleAssortment.Items(x).Cells(8).Text
                    .Color = dgStyleAssortment.Items(x).Cells(9).Text
                    .Size = dgStyleAssortment.Items(x).Cells(10).Text
                    .Qty = dgStyleAssortment.Items(x).Cells(11).Text
                    .WeightPerPiece = txtWeightPerPiece.Text
                    .PcsPerCarton = txtPcsPerCarton.Text
                    .NoOfCarton = txtNoOfCarton.Text
                    .Dimension = txtDimension.Text
                    .Extra = txtExtra.Text
                    .TotalQtyy = txtTotalQty.Text
                    .Balance = txtBalance.Text
                    If txtWeight.Text = "" Then
                        .Weight = 0
                    Else
                        .Weight = txtWeight.Text
                    End If
                    .Save()
                End With
            Next
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("JobOrderDatabaseViewExportView.aspx")
    End Sub
    Protected Sub dgStyleAssortment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgStyleAssortment.SelectedIndexChanged

    End Sub
    Protected Sub dgStyleAssortment_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgStyleAssortment.SortCommand

    End Sub
    Private Sub BindGrid()
        Dim x As Integer
        Try
            Dim dtEdit As DataTable = objStyleAssortmentMaster.CheckEditData(lJobOrderID)
            If dtEdit.Rows.Count > 0 Then
                Dim objDatatable As DataTable
                objDatatable = objStyleAssortmentMaster.GetDataonEdit(lJobOrderID)
                Session("dtGrid") = objDatatable
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
                    Dim txtDimension As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtDimension"), TextBox)
                    Dim txtPcsPerCarton As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtPcsPerCarton"), TextBox)
                    Dim txtWeightPerPiece As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtWeightPerPiece"), TextBox)
                    Dim txtNoOfCarton As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtNoOfCarton"), TextBox)
                    Dim txtExtra As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtExtra"), TextBox)
                    Dim txtTotalQty As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtTotalQty"), TextBox)
                    Dim txtBalance As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtBalance"), TextBox)
                    Dim txtWeight As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtWeight"), TextBox)
                    txtDimension.Text = objDatatable.Rows(x)("Dimension")
                    txtPcsPerCarton.Text = objDatatable.Rows(x)("PcsPerCarton")
                    txtWeightPerPiece.Text = objDatatable.Rows(x)("WeightPerPiece")
                    txtNoOfCarton.Text = objDatatable.Rows(x)("NoOfCarton")
                    txtExtra.Text = objDatatable.Rows(x)("Extra")
                    txtTotalQty.Text = Math.Round(objDatatable.Rows(x)("TotalQtyy"), 0)
                    txtBalance.Text = objDatatable.Rows(x)("Balance")
                    txtWeight.Text = objDatatable.Rows(x)("Weight")
                Next
            Else
                Dim objDatatable As DataTable
                objDatatable = objStyleAssortmentMaster.GetDataSizeWeightWithDyedColorNew(lJobOrderID)
                Session("dtGrid") = objDatatable
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
                    Dim txtDimension As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtDimension"), TextBox)
                    Dim txtPcsPerCarton As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtPcsPerCarton"), TextBox)
                    Dim txtWeightPerPiece As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtWeightPerPiece"), TextBox)
                    Dim txtNoOfCarton As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtNoOfCarton"), TextBox)
                    Dim txtExtra As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtExtra"), TextBox)
                    Dim txtTotalQty As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtTotalQty"), TextBox)
                    Dim txtBalance As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtBalance"), TextBox)
                    Dim txtWeight As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtWeight"), TextBox)
                    txtDimension.Text = objDatatable.Rows(x)("Dimension")
                    txtPcsPerCarton.Text = objDatatable.Rows(x)("PcsPerCarton")
                    txtWeightPerPiece.Text = objDatatable.Rows(x)("WeightPerPiece")
                    txtNoOfCarton.Text = objDatatable.Rows(x)("NoOfCarton")
                    txtExtra.Text = objDatatable.Rows(x)("Extra")
                    txtTotalQty.Text = Math.Round(objDatatable.Rows(x)("TotalQtyy"), 0)
                    txtBalance.Text = objDatatable.Rows(x)("Balance")
                    txtWeight.Text = objDatatable.Rows(x)("Weight")
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Try
            SaveMaster()
            saveDetail()
            If Val(lblid.Text) > 0 Then
            Else
                SaveNumbering()
            End If
            Response.Redirect("JobOrderDatabaseViewExportView.aspx")
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub dgStyleAssortment_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgStyleAssortment.ItemCommand
        Try
            Select Case e.CommandName
                Case Is = "Remove"
                    Dim SizeWiseWeightListMstID As Integer = dgStyleAssortment.Items(e.Item.ItemIndex).Cells(0).Text
                    If lSizeWiseWeightListMstID > 0 Then
                        objStyleAssortmentMaster.DeleteSizeWiseWeightListDtl(SizeWiseWeightListMstID)
                        Dim dtsession As New DataTable
                        dtsession = Session("dtGrid")
                        dtsession.Rows.RemoveAt(e.Item.ItemIndex)
                        Session("dtGrid") = dtsession
                        BindGrid()
                    Else
                        Dim dtsession As New DataTable
                        dtsession = Session("dtGrid")
                        dtsession.Rows.RemoveAt(e.Item.ItemIndex)
                        Session("dtGrid") = dtsession
                        BindGrid()
                    End If
            End Select
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
    Protected Sub txtPcsPerCarton_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim dtCurrentTable As DataTable = DirectCast(Session("dtGrid"), DataTable)
        For i As Integer = 0 To dgStyleAssortment.Items.Count - 1
            Dim txtPcsPerCarton As TextBox = CType(dgStyleAssortment.Items(i).FindControl("txtPcsPerCarton"), TextBox)
            Dim txtNoOfCarton As TextBox = DirectCast(dgStyleAssortment.Items(i).FindControl("txtNoOfCarton"), TextBox)
            Dim txtBalance As TextBox = DirectCast(dgStyleAssortment.Items(i).FindControl("txtBalance"), TextBox)
            Dim txtTotalQty As TextBox = DirectCast(dgStyleAssortment.Items(i).FindControl("txtTotalQty"), TextBox)
            If txtPcsPerCarton.Text = 0 Then
                txtNoOfCarton.Text = 0
            Else
                Dim Bal As Long = Math.Floor(Val(txtTotalQty.Text) / Val(txtPcsPerCarton.Text))
                txtNoOfCarton.Text = Math.Floor((Val(txtTotalQty.Text) / txtPcsPerCarton.Text))
                txtBalance.Text = Val(txtTotalQty.Text) - (Bal * Val(txtPcsPerCarton.Text))
            End If
        Next
    End Sub
    Protected Sub txtExtra_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim dtCurrentTable As DataTable = DirectCast(Session("dtGrid"), DataTable)
        For i As Integer = 0 To dgStyleAssortment.Items.Count - 1
            Dim txtExtra As TextBox = CType(dgStyleAssortment.Items(i).FindControl("txtExtra"), TextBox)
            Dim txtTotalQty As TextBox = DirectCast(dgStyleAssortment.Items(i).FindControl("txtTotalQty"), TextBox)
            Dim Qty As String = dtCurrentTable.Rows(i)("Qty")
            Dim Per As Decimal = 0
            Dim TotalQty As Decimal = 0
            Dim Extra As Decimal
            If txtExtra.Text <> 0 Then
                Extra = txtExtra.Text
            Else
                txtExtra.Text = Extra
            End If

            If txtExtra.Text = 0 Then
                txtExtra.Text = Extra
            Else
                TotalQty = (Qty * Val(Extra) / 100) + Qty
                txtTotalQty.Text = Math.Round(TotalQty, 0)
            End If
        Next
    End Sub
    Protected Sub txtDimension_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim dtCurrentTable As DataTable = DirectCast(Session("dtGrid"), DataTable)
        For i As Integer = 0 To dgStyleAssortment.Items.Count - 1
            Dim txtDimension As TextBox = CType(dgStyleAssortment.Items(i).FindControl("txtDimension"), TextBox)
            Dim Name As String
            If txtDimension.Text <> "" Then
                Name = txtDimension.Text
            Else
            End If
            If Name <> "" Then
                txtDimension.Text = Name
            ElseIf Name = "" Then
                txtDimension.Text = Name
            End If
        Next
    End Sub
    Protected Sub txtWeight_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim dtCurrentTable As DataTable = DirectCast(Session("dtGrid"), DataTable)
        Dim Weight As Decimal = 0
        For i As Integer = 0 To dgStyleAssortment.Items.Count - 1
            Dim txtWeight As TextBox = CType(dgStyleAssortment.Items(i).FindControl("txtWeight"), TextBox)
            If txtWeight.Text <> 0 Then
                Weight = txtWeight.Text
            Else
            End If
            If Weight <> 0 Then
                txtWeight.Text = Weight
            ElseIf Weight = 0 Then
                txtWeight.Text = Weight
            End If
        Next
    End Sub
    Sub SaveNumbering()
        Session("dtNumbering") = Nothing
        If (Not CType(Session("dtNumbering"), DataTable) Is Nothing) Then
            dtNumbering = Session("dtNumbering")
        Else
            dtNumbering = New DataTable
            With dtNumbering
                .Columns.Add("NumberingDtlID", GetType(Long))
                .Columns.Add("SizeRangeId", GetType(Long))
                .Columns.Add("SizeDatabaseId", GetType(Long))
                .Columns.Add("StyleAssortmentDetailID", GetType(Long))
                .Columns.Add("StyleAssortmentMasterID", GetType(Long))
                .Columns.Add("CuttingProDetailID", GetType(Long))
                .Columns.Add("CuttingProMasterID", GetType(Long))
                .Columns.Add("Joborderid", GetType(Long))
                .Columns.Add("JoborderDetailid", GetType(Long))
                .Columns.Add("PcsPerCarton", GetType(String))
                .Columns.Add("CartonNo", GetType(Decimal))
                .Columns.Add("Code", GetType(String))
                .Columns.Add("SerialNo", GetType(Decimal))
                .Columns.Add("Weight", GetType(Decimal))
            End With
        End If
        Dim x As Integer
        For x = 0 To dgStyleAssortment.Items.Count - 1
            Dim txtPcsPerCarton As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtPcsPerCarton"), TextBox)
            Dim txtNoOfCarton As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtNoOfCarton"), TextBox)
            Dim txtBalance As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtBalance"), TextBox)
            Dim txtWeightPerPiece As TextBox = CType(dgStyleAssortment.Items(x).FindControl("txtWeightPerPiece"), TextBox)
            Dim SizeRangeId As Long = dgStyleAssortment.Items(x).Cells(1).Text
            Dim SizeDatabaseId As Long = dgStyleAssortment.Items(x).Cells(2).Text
            Dim StyleAssortmentDetailID As Long = dgStyleAssortment.Items(x).Cells(3).Text
            Dim StyleAssortmentMasterID As Long = dgStyleAssortment.Items(x).Cells(4).Text
            Dim CuttingProDetailID As Long = dgStyleAssortment.Items(x).Cells(5).Text
            Dim CuttingProMasterID As Long = dgStyleAssortment.Items(x).Cells(6).Text
            Dim Joborderid As Long = dgStyleAssortment.Items(x).Cells(7).Text
            Dim JoborderDetailid As Long = dgStyleAssortment.Items(x).Cells(8).Text
            Dim totalCount As Integer = txtNoOfCarton.Text
            Dim Increment As Integer
            Dim Increment2 As Integer
            Dim Z As Integer
            Dim y As Integer
            Dim Serial As Decimal = 0
            For y = 0 To totalCount - 1
                Increment = Increment + 1
                If y = 0 Then
                    If x = 0 Then
                        Z = 1
                    Else
                        Z = (Increment + y)
                    End If
                Else
                    If x = 0 Then
                        Z = y + 1
                    Else
                        Z = Increment
                    End If
                End If
                Serial = Serial + 1
                Increment2 = Z
                dr = dtNumbering.NewRow()
                dr("NumberingDtlID") = 0
                dr("SizeRangeId") = SizeRangeId
                dr("SizeDatabaseId") = SizeDatabaseId
                dr("StyleAssortmentDetailID") = StyleAssortmentDetailID
                dr("StyleAssortmentMasterID") = StyleAssortmentMasterID
                dr("CuttingProDetailID") = CuttingProDetailID
                dr("CuttingProMasterID") = CuttingProMasterID
                dr("Joborderid") = Joborderid
                dr("JoborderDetailid") = JoborderDetailid
                dr("PcsPerCarton") = txtPcsPerCarton.Text
                dr("Weight") = txtWeightPerPiece.Text
                Increment = Increment
                dr("CartonNo") = Increment
                Dim barcodedata As String
                barcodedata = (JoborderDetailid.ToString) + (SizeDatabaseId.ToString) + (Increment2.ToString)
                dr("Code") = barcodedata
                dr("SerialNo") = Serial
                dtNumbering.Rows.Add(dr)
                If y + 1 = txtNoOfCarton.Text Then
                    dr = dtNumbering.NewRow()
                    Serial = Serial + 1
                    Increment2 = Z + 1
                    dr("NumberingDtlID") = 0
                    dr("SizeRangeId") = SizeRangeId
                    dr("SizeDatabaseId") = SizeDatabaseId
                    dr("StyleAssortmentDetailID") = StyleAssortmentDetailID
                    dr("StyleAssortmentMasterID") = StyleAssortmentMasterID
                    dr("CuttingProDetailID") = CuttingProDetailID
                    dr("CuttingProMasterID") = CuttingProMasterID
                    dr("Joborderid") = Joborderid
                    dr("JoborderDetailid") = JoborderDetailid
                    dr("PcsPerCarton") = txtBalance.Text
                    dr("Weight") = txtWeightPerPiece.Text
                    Increment = Increment + 1
                    dr("CartonNo") = Increment
                    Dim barcodedataeea As String
                    barcodedataeea = (JoborderDetailid.ToString) + (SizeDatabaseId.ToString) + (Increment2.ToString)
                    dr("Code") = barcodedataeea
                    dr("SerialNo") = Serial
                    dtNumbering.Rows.Add(dr)
                    Session("dtNumbering") = dtNumbering
                End If
            Next
            dr = dtNumbering.NewRow()
            Increment = Increment + 1
            Increment2 = Increment2 + 1
            dr("NumberingDtlID") = 0
            dr("SizeRangeId") = SizeRangeId
            dr("SizeDatabaseId") = SizeDatabaseId
            dr("StyleAssortmentDetailID") = 0
            dr("StyleAssortmentMasterID") = 0
            dr("CuttingProDetailID") = 0
            dr("CuttingProMasterID") = 0
            dr("Joborderid") = Joborderid
            dr("JoborderDetailid") = JoborderDetailid
            dr("Weight") = 0
            dr("PcsPerCarton") = ""
            dr("CartonNo") = Increment
            Dim barcodedataa As String
            barcodedataa = (JoborderDetailid.ToString) + (SizeDatabaseId.ToString) + (Increment2.ToString)
            dr("Code") = barcodedataa
            dr("SerialNo") = 0
            dtNumbering.Rows.Add(dr)
            Session("dtNumbering") = dtNumbering
            Dim v As Integer = dgStyleAssortment.Items.Count - 1
            If x = v Then
                dr = dtNumbering.NewRow()
                Increment = Increment + 1
                Increment2 = Increment2 + 1
                dr("NumberingDtlID") = 0
                dr("SizeRangeId") = SizeRangeId
                dr("SizeDatabaseId") = SizeDatabaseId
                dr("StyleAssortmentDetailID") = 0
                dr("StyleAssortmentMasterID") = 0
                dr("CuttingProDetailID") = 0
                dr("CuttingProMasterID") = 0
                dr("Joborderid") = Joborderid
                dr("JoborderDetailid") = JoborderDetailid
                dr("Weight") = 0
                dr("PcsPerCarton") = ""
                dr("CartonNo") = Increment
                Dim barcodedataaa As String
                barcodedataaa = (JoborderDetailid.ToString) + (SizeDatabaseId.ToString) + (Increment2.ToString)
                dr("Code") = barcodedataaa
                dr("SerialNo") = 0
                dtNumbering.Rows.Add(dr)
                Session("dtNumbering") = dtNumbering
                dr = dtNumbering.NewRow()
                Increment = Increment + 1
                Increment2 = Increment2 + 1
                dr("NumberingDtlID") = 0
                dr("SizeRangeId") = SizeRangeId
                dr("SizeDatabaseId") = SizeDatabaseId
                dr("StyleAssortmentDetailID") = 0
                dr("StyleAssortmentMasterID") = 0
                dr("CuttingProDetailID") = 0
                dr("CuttingProMasterID") = 0
                dr("Joborderid") = Joborderid
                dr("JoborderDetailid") = JoborderDetailid
                dr("PcsPerCarton") = ""
                dr("CartonNo") = Increment
                dr("SerialNo") = 0
                dr("Weight") = 0
                Dim barcodedataaaa As String
                barcodedataaaa = (JoborderDetailid.ToString) + (SizeDatabaseId.ToString) + (Increment2.ToString)
                dr("Code") = barcodedataaaa
                dtNumbering.Rows.Add(dr)
                Session("dtNumbering") = dtNumbering
            End If
        Next
        Dim Finaldt As DataTable = Session("dtNumbering")
        With objNumbering
            .NumberingID = 0
            .CreationDate = Date.Now
            .UserId = UserId
            GRNNoGenerateOnLoad()
            .NumberingNo = txtShipNo.Text
            .Save()
        End With
        With objNumberingDtl
            Dim S As Integer
            For S = 0 To Finaldt.Rows.Count - 1
                .NumberingDtlID = Finaldt.Rows(S)("NumberingDtlID")
                .NumberingID = objNumbering.GetID()
                .SizeRangeId = Finaldt.Rows(S)("SizeRangeId")
                .SizeDatabaseId = Finaldt.Rows(S)("SizeDatabaseId")
                .StyleAssortmentDetailID = Finaldt.Rows(S)("StyleAssortmentDetailID")
                .StyleAssortmentMasterID = Finaldt.Rows(S)("StyleAssortmentMasterID")
                .CuttingProDetailID = Finaldt.Rows(S)("CuttingProDetailID")
                .CuttingProMasterID = Finaldt.Rows(S)("CuttingProMasterID")
                .Joborderid = Finaldt.Rows(S)("Joborderid")
                .JoborderDetailid = Finaldt.Rows(S)("JoborderDetailid")
                .PcsPerCarton = Finaldt.Rows(S)("PcsPerCarton")
                .CartonNo = Finaldt.Rows(S)("CartonNo")
                .Code = Finaldt.Rows(S)("Code")
                .SerialNo = Finaldt.Rows(S)("SerialNo")
                .Weight = Finaldt.Rows(S)("Weight")
                .SelectNumbering = 0
                .Save()
            Next
        End With
    End Sub
End Class

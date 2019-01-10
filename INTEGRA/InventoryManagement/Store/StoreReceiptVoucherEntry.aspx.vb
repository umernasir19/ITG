Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Xml
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Public Class StoreReceiptVoucherEntry
    Inherits System.Web.UI.Page
    Dim objStoreReceiptVoucherMst As New StoreReceiptVoucherMst
    Dim objStoreReceiptVoucherDtl As New StoreReceiptVoucherDtl
    Dim ObjIMSStoreLedger As New EuroCentra.IMSStoreLedger
    Dim DtStoreReceiptDetail As New DataTable
    Dim Dr As DataRow
    Dim Userid As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Userid = CLng(Session("Userid"))

        If Not Page.IsPostBack Then
            Session("DtStoreReceiptDetail") = Nothing
            
            If Userid = 240 Then
                txtGRNNo.Text = "00000"
                txtGRNNo.BackColor = Drawing.Color.Gray
                txtGRNNo.Enabled = True
                BinItemFabricClassName()
                cmbItemClassName.SelectedValue = 6
                BinItemCode()
                BindUnit()

                BindSupplierforFabric()

                cmbItemClassName.Enabled = False

            Else

                BindSupplierNew()
                BindUnit()
                txtVoucherDate.Text = Date.Now
                txtVehicleNo.BackColor = Drawing.Color.Gray
                txtVehicleNo.Enabled = False
                txtRollNo.BackColor = Drawing.Color.Gray
                txtRollNo.Enabled = False
                txtColor.BackColor = Drawing.Color.Gray
                txtColor.Enabled = False

                txtOrderNo.Enabled = True
                txtCustomer.BackColor = Drawing.Color.Gray
                txtCustomer.Enabled = False
                GRNNoGenerateOnLoad()

                BinItemClassName()
            End If
        End If

            PageHeader("STORE RECEIPT VOUCHER FORM")
    End Sub
    Sub GRNNoGenerateOnLoad()
        Try
            Dim LastCode As String
            Dim VoucherNo As String
            Dim Voucherdate As Date = txtVoucherDate.Text
            Dim year As String = Voucherdate.Year
            Dim yearP As String = Voucherdate.Year
            year = year.Substring(2, 2)
            Dim Month As String = Voucherdate.Month
            Dim CodeMonth As String
            If Month = 1 Then
                CodeMonth = "01"
            ElseIf Month = 2 Then
                CodeMonth = "02"
            ElseIf Month = 3 Then
                CodeMonth = "03"
            ElseIf Month = 4 Then
                CodeMonth = "04"
            ElseIf Month = 5 Then
                CodeMonth = "05"
            ElseIf Month = 6 Then
                CodeMonth = "06"
            ElseIf Month = 7 Then
                CodeMonth = "07"
            ElseIf Month = 8 Then
                CodeMonth = "08"
            ElseIf Month = 9 Then
                CodeMonth = "09"
            Else
                CodeMonth = Month
            End If

            Dim lastNo As Integer = objStoreReceiptVoucherMst.GetMaxGRNNo(Month, yearP)
            Dim LastVoucherNo As String = objStoreReceiptVoucherMst.GetLastGRNNo(lastNo, Month, yearP)
            Dim PreviousMonth As Integer

            If LastVoucherNo = "" Then
                LastCode = "00001"
            Else
                Dim LastCodee As Integer
                PreviousMonth = LastVoucherNo.Substring(6, 2)
                If LastVoucherNo.Length = 11 Then
                    LastCodee = LastVoucherNo.Substring(0, 5)
                ElseIf LastVoucherNo.Length = 12 Then
                    LastCodee = LastVoucherNo.Substring(1, 4)
                ElseIf LastVoucherNo.Length = 13 Then
                    LastCodee = LastVoucherNo.Substring(2, 3)
                ElseIf LastVoucherNo.Length = 14 Then
                    LastCodee = LastVoucherNo.Substring(3, 2)
                End If

                If PreviousMonth = Month Then
                    If LastCodee < 10 Then
                        If LastCodee = 9 Then
                            LastCode = "000" & Val(LastCodee + 1)
                        Else
                            LastCode = "0000" & Val(LastCodee + 1)
                        End If

                    ElseIf LastCodee < 100 Or LastCodee = 10 Then
                        If LastCodee = 99 Then
                            LastCode = "00" & Val(LastCodee + 1)
                        Else
                            LastCode = "000" & Val(LastCodee + 1)
                        End If

                    ElseIf LastCodee < 1000 Or LastCodee = 100 Then
                        If LastCodee = 999 Then
                            LastCode = "0" & Val(LastCodee + 1)
                        Else
                            LastCode = "00" & Val(LastCodee + 1)
                        End If
                    ElseIf LastCodee < 10000 Or LastCodee = 1000 Then
                        If LastCodee = 9999 Then
                            LastCode = "" & Val(LastCodee + 1)
                        Else
                            LastCode = "0" & Val(LastCodee + 1)
                        End If
                    Else
                        LastCode = Val(LastCodee + 1)
                    End If
                Else
                    LastCode = "00001"
                End If
            End If
            VoucherNo = LastCode & "-" & CodeMonth & "-" & year
            txtGRNNo.Text = VoucherNo


        Catch ex As Exception

        End Try
    End Sub
    Sub BindSupplier()
        Dim dt As DataTable
        dt = objStoreReceiptVoucherMst.GetSupplier()
        CmbSuppliers.DataSource = dt
        CmbSuppliers.DataTextField = "AccountName"
        CmbSuppliers.DataValueField = "AccountCode"
        CmbSuppliers.DataBind()
        CmbSuppliers.Items.Insert(0, New ListItem("Select", "0"))

    End Sub
    Sub BindSupplier2()
        Dim dt As DataTable
        dt = objStoreReceiptVoucherMst.GetSupplier2()
        CmbSuppliers.DataSource = dt
        CmbSuppliers.DataTextField = "AccountName"
        CmbSuppliers.DataValueField = "AccountCode"
        CmbSuppliers.DataBind()
        CmbSuppliers.Items.Insert(0, New ListItem("Select", "0"))

    End Sub
    Sub BindSupplierNew()
        Dim dt As DataTable
        dt = objStoreReceiptVoucherMst.GetSupplierNew()
        CmbSuppliers.DataSource = dt
        CmbSuppliers.DataTextField = "SupplierName"
        CmbSuppliers.DataValueField = "SupplierDatabaseId"
        CmbSuppliers.DataBind()
        CmbSuppliers.Items.Insert(0, New ListItem("Select", "0"))

    End Sub
    Sub BindSupplierforFabric()
        Dim dt As DataTable
        dt = objStoreReceiptVoucherMst.GetSupplierFabric()
        CmbSuppliers.DataSource = dt
        CmbSuppliers.DataTextField = "SupplierName"
        CmbSuppliers.DataValueField = "SupplierDatabaseId"
        CmbSuppliers.DataBind()
        CmbSuppliers.Items.Insert(0, New ListItem("Select", "0"))

    End Sub


    Sub BinItemCode()
        Dim dt As DataTable
        dt = objStoreReceiptVoucherMst.GetItemName()
        cmbitemCode.DataSource = dt
        cmbitemCode.DataTextField = "ItemName"
        cmbitemCode.DataValueField = "IMSItemID"
        cmbitemCode.DataBind()
        cmbitemCode.Items.Insert(0, New ListItem("Select", "0"))

    End Sub
    Sub BinItemCodeWithoutFabric()
        Dim dt As DataTable
        dt = objStoreReceiptVoucherMst.GetItemNameWithoutFabric(cmbItemClassName.SelectedValue)
        cmbitemCode.DataSource = dt
        cmbitemCode.DataTextField = "ItemName"
        cmbitemCode.DataValueField = "IMSItemID"
        cmbitemCode.DataBind()
        cmbitemCode.Items.Insert(0, New ListItem("Select", "0"))

    End Sub
    Sub BindUnit()
        Dim dt As DataTable
        dt = objStoreReceiptVoucherMst.GetUnit()
        cmbUnit.DataSource = dt
        cmbUnit.DataTextField = "Symbol"
        cmbUnit.DataValueField = "ItemUnitId"
        cmbUnit.DataBind()
        cmbUnit.Items.Insert(0, New ListItem("Select", "0"))

    End Sub


    Sub BinItemClassName()
        Dim dt As DataTable
        dt = objStoreReceiptVoucherMst.GetItemClassName()
        cmbItemClassName.DataSource = dt
        cmbItemClassName.DataTextField = "ItemClassName"
        cmbItemClassName.DataValueField = "IMSItemClassID"
        cmbItemClassName.DataBind()
        cmbItemClassName.Items.Insert(0, New ListItem("Select", "0"))

    End Sub
    Sub BinItemFabricClassName()
        Dim dt As DataTable
        dt = objStoreReceiptVoucherMst.GetItemFabricClassName()
        cmbItemClassName.DataSource = dt
        cmbItemClassName.DataTextField = "ItemClassName"
        cmbItemClassName.DataValueField = "IMSItemClassID"
        cmbItemClassName.DataBind()
        cmbItemClassName.Items.Insert(0, New ListItem("Select", "0"))

    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Protected Sub btnAddDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddDetail.Click
        Try
            If txtVoucherDate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Voucher Date Empty.")
            ElseIf txtRollNo.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("RollNo Empty.")
            ElseIf cmbitemCode.SelectedIndex = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("CodeNo Empty.")
            ElseIf txtColor.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Color Empty.")
            ElseIf txtDCNo.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("DCNo Empty.")
            ElseIf txtOrderNo.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("OrderNo Empty.")
            ElseIf CmbSuppliers.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Suppliers.")
               ElseIf txtFabricRcv.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("FabricRcv Empty.")
            ElseIf txtCustomer.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Customer Empty.")
                ElseIf txtStatus.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Status Empty.")
            ElseIf txtSalesTax.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("SalesTax Empty.")
            ElseIf txtAmount.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Amount Empty.")
            ElseIf txtVehicleNo.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("VehicleNo Empty.")
            ElseIf txtRate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Rate Empty.")


            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                SaveSession()
                BindGrid()
                ClearControls()
            End If

        Catch ex As Exception

        End Try
    End Sub
    Sub SaveSession()
        If (Not CType(Session("DtStoreReceiptDetail"), DataTable) Is Nothing) Then
            DtStoreReceiptDetail = Session("DtStoreReceiptDetail")
        Else

            DtStoreReceiptDetail = New DataTable
            With DtStoreReceiptDetail
                .Columns.Add("StoreReceiptVoucherDtlID", GetType(Long))
                .Columns.Add("RollNumber", GetType(String))
                .Columns.Add("IMSItemID", GetType(Long))
                .Columns.Add("ItemCode", GetType(String))
                .Columns.Add("ItemName", GetType(String))
                .Columns.Add("Color", GetType(String))
                .Columns.Add("DCNo", GetType(String))
                .Columns.Add("OrderNo", GetType(String))
                .Columns.Add("Mills", GetType(String))
                .Columns.Add("Particulars", GetType(String))
                .Columns.Add("FabricReceived", GetType(String))
                .Columns.Add("Buyers", GetType(String))
                .Columns.Add("GRNNo", GetType(String))
                .Columns.Add("Cartage", GetType(String))
                .Columns.Add("Status", GetType(String))
                .Columns.Add("SalesTax", GetType(String))
                .Columns.Add("Amount", GetType(Decimal))
                .Columns.Add("VehicleNo", GetType(String))
                .Columns.Add("ReceiptDate", GetType(String))
                .Columns.Add("IMSItemClassID", GetType(Long))
                .Columns.Add("Rate", GetType(String))
                .Columns.Add("ItemUnitId", GetType(Long))
                .Columns.Add("Symbol", GetType(String))
                .Columns.Add("SupplierDatabaseId", GetType(String))
            End With
        End If
        Dr = DtStoreReceiptDetail.NewRow()
        Dr("StoreReceiptVoucherDtlID") = 0
        Dr("RollNumber") = txtRollNo.Text
        Dr("IMSItemID") = cmbitemCode.SelectedValue
        Dr("ItemCode") = cmbitemCode.SelectedItem.Text
        Dr("ItemName") = txtItemName.Text
        Dr("Color") = txtColor.Text
        Dr("DCNo") = txtDCNo.Text
        If txtOrderNo.Text = "" Then
            Dr("OrderNo") = "N/A"
        Else
            Dr("OrderNo") = txtOrderNo.Text
        End If

        Dr("Cartage") = "N/A" 'txtCartage.Text
        Dr("Mills") = CmbSuppliers.SelectedItem.Text 'txtSuppliers.Text
        Dr("Particulars") = "N/A" 'txtParticulars.Text
        Dr("FabricReceived") = txtFabricRcv.Text
        Dr("Buyers") = txtCustomer.Text
        Dr("GRNNo") = txtGRNNo.Text
        Dr("Status") = txtStatus.Text
        Dr("SalesTax") = txtSalesTax.Text
        Dr("Amount") = txtAmount.Text
        Dr("VehicleNo") = txtVehicleNo.Text
        Dr("ReceiptDate") = txtVoucherDate.Text
        Dr("IMSItemClassID") = cmbItemClassName.SelectedValue

        Dr("Rate") = txtRate.Text
        Dr("ItemUnitId") = cmbUnit.SelectedValue
        Dr("SupplierDatabaseId") = CmbSuppliers.SelectedValue
        Dr("Symbol") = cmbUnit.SelectedItem.Text

        DtStoreReceiptDetail.Rows.Add(Dr)
        Session("DtStoreReceiptDetail") = DtStoreReceiptDetail
    End Sub
    Private Sub BindGrid()
        Try
            Dim objDatatble As DataTable
            objDatatble = Session("DtStoreReceiptDetail")
            If objDatatble.Rows.Count > 0 Then
                dgVoucherViewAdd.Visible = True
                dgVoucherViewAdd.RecordCount = objDatatble.Rows.Count
                dgVoucherViewAdd.DataSource = objDatatble
                dgVoucherViewAdd.DataBind()
            Else
                dgVoucherViewAdd.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub ClearControls()
        txtRollNo.Text = ""
        cmbitemCode.SelectedIndex = 0
        txtColor.Text = ""
        txtDCNo.Text = ""
        txtOrderNo.Text = ""
        CmbSuppliers.SelectedValue = 0
        'txtSuppliers.Text = ""
        'txtParticulars.Text = ""
        txtFabricRcv.Text = ""
        txtCustomer.Text = ""
        'txtGRNNo.Text = ""
        txtStatus.Text = ""
        txtSalesTax.Text = ""
        txtAmount.Text = ""
        txtVehicleNo.Text = ""
        txtItemName.Text = ""
        txtRate.Text = ""
        cmbUnit.SelectedValue = 0
    End Sub

    Protected Sub cmbitemCode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbitemCode.SelectedIndexChanged
        Try
            Dim dt As New DataTable
            dt = objStoreReceiptVoucherMst.GetItemCode(cmbitemCode.SelectedValue)
            If dt.Rows.Count > 0 Then
                txtItemName.Text = dt.Rows(0)("ItemCode").ToString()
                cmbUnit.SelectedValue = dt.Rows(0)("ItemUnitId").ToString()
                cmbUnit.Enabled = False
            Else

            End If
            txtRollNo.Text = "N/A"

            txtColor.Text = "N/A"
            txtDCNo.Text = "N/A"
            txtOrderNo.Text = "N/A"
            'txtSuppliers.Text = "N/A"
            'CmbSuppliers.SelectedItem.Text = "N/A"
            txtFabricRcv.Text = 0
            txtCustomer.Text = "N/A"
            txtSalesTax.Text = 0
            txtAmount.Text = 0
            txtVehicleNo.Text = "N/A"
            txtStatus.Text = "N/A"

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If dgVoucherViewAdd.Items.Count > 0 Then

                With objStoreReceiptVoucherMst
                    .StoreReceiptVoucherMstID = 0
                    .StoreRecieptVoucherDate = Date.Now()
                    .CreatedbyID = CLng(Session("Userid"))
                    .SaveStoreRecieptVoucherMst()
                End With

                Dim x As Integer
                For x = 0 To dgVoucherViewAdd.Items.Count - 1
                    With objStoreReceiptVoucherDtl
                        .StoreReceiptVoucherDtlID = dgVoucherViewAdd.Items(x).Cells(0).Text
                        .StoreReceiptVoucherMstID = objStoreReceiptVoucherMst.GetID
                        .RollNumber = dgVoucherViewAdd.Items(x).Cells(3).Text
                        .CodeNo = dgVoucherViewAdd.Items(x).Cells(5).Text
                        .ItemName = dgVoucherViewAdd.Items(x).Cells(4).Text
                        .IMSItemID = dgVoucherViewAdd.Items(x).Cells(1).Text
                        .Color = dgVoucherViewAdd.Items(x).Cells(6).Text
                        .DCNo = dgVoucherViewAdd.Items(x).Cells(7).Text
                        .OrderNo = dgVoucherViewAdd.Items(x).Cells(8).Text
                        .Mills = dgVoucherViewAdd.Items(x).Cells(9).Text
                        .Particulars = dgVoucherViewAdd.Items(x).Cells(10).Text
                        .FabricReceived = Convert.ToDecimal(dgVoucherViewAdd.Items(x).Cells(11).Text)
                        .Buyers = dgVoucherViewAdd.Items(x).Cells(12).Text
                        .GRNNo = dgVoucherViewAdd.Items(x).Cells(13).Text
                        .Cartage = dgVoucherViewAdd.Items(x).Cells(14).Text
                        .Status = dgVoucherViewAdd.Items(x).Cells(15).Text
                        .SalesTax = dgVoucherViewAdd.Items(x).Cells(16).Text
                        .Amount = Convert.ToDecimal(dgVoucherViewAdd.Items(x).Cells(17).Text)
                        .VehicleNo = dgVoucherViewAdd.Items(x).Cells(18).Text
                        .ReceiptDate = dgVoucherViewAdd.Items(x).Cells(2).Text
                        .IMSItemClassID = dgVoucherViewAdd.Items(x).Cells(19).Text
                        .Rate = dgVoucherViewAdd.Items(x).Cells(20).Text
                        .ItemUnitId = dgVoucherViewAdd.Items(x).Cells(22).Text
                        ' .AccountCode = dgVoucherViewAdd.Items(x).Cells(23).Text
                        .SupplierDatabaseId = dgVoucherViewAdd.Items(x).Cells(23).Text
                        .SaveStoreReceiptVoucherDtl()
                    End With

                    'Update on Ledger
                    If dgVoucherViewAdd.Items(x).Cells(0).Text = 0 Then
                        With ObjIMSStoreLedger
                            .StoreLedgerID = 0
                            .IMSItemID = dgVoucherViewAdd.Items(x).Cells(1).Text
                            .CreationDate = Date.Now()
                            .TransactionDate = Date.Now.Date()
                            .TransactionType = "SRV"
                            .OpenQty = 0
                            .OpenAmount = 0
                            .ReceiveQty = Convert.ToDecimal(dgVoucherViewAdd.Items(x).Cells(11).Text)
                            .ReceiveAmount = Convert.ToDecimal(dgVoucherViewAdd.Items(x).Cells(17).Text)
                            .IssueQty = 0
                            .IssueAmount = 0
                            .CloseQty = ObjIMSStoreLedger.GetCloseQty(dgVoucherViewAdd.Items(x).Cells(1).Text) + Convert.ToDecimal(dgVoucherViewAdd.Items(x).Cells(11).Text)
                            .CloseAmount = ObjIMSStoreLedger.GetCloseAmount(dgVoucherViewAdd.Items(x).Cells(1).Text) + Convert.ToDecimal(dgVoucherViewAdd.Items(x).Cells(17).Text)
                            .SaveIMSStoreLedger()
                        End With
                    End If
                Next
            Else
            End If
            Response.Redirect("StoreReceiptVoucherViewNew.aspx")
        Catch ex As Exception
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" Error:" & ex.ToString & " ")
        End Try
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("StoreReceiptVoucherViewNew.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub cmbItemClassName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbItemClassName.SelectedIndexChanged
        Try
            BinItemCodeWithoutFabric()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub txtRate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRate.TextChanged
        txtAmount.Text = Val(txtRate.Text) * Val(txtFabricRcv.Text)
    End Sub

    Protected Sub txtFabricRcv_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFabricRcv.TextChanged
        txtAmount.Text = Val(txtRate.Text) * Val(txtFabricRcv.Text)
    End Sub

    Protected Sub txtVoucherDate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVoucherDate.TextChanged
        If Userid = 239 Then

            GRNNoGenerateOnLoad()
        End If


    End Sub








End Class

Imports Integra.EuroCentra
Imports System.Data
Imports Telerik.Web.UI.Upload
Imports System.Xml
Imports Telerik.Web.UI
Imports System.Data.DataTable
Imports System.IO
Imports Telerik.Web.UI.Barcode
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Net
Imports System.Net.Mail
Public Class PackingList
    Inherits System.Web.UI.Page
    Dim ObjCustomer As New Customer
    Dim ObjPO As New PurchaseOrder
    Dim ObjCargo As New Cargo
    Dim ObjCargoDetail As New CargoDetail
    Dim GeneralCode As New GeneralCode
    Dim dtPacking As New DataTable
    Dim dtPurchaseOrder As New DataTable
    Dim lPOID, lPackingMstid As Long
    Dim Dr As DataRow
    Dim ICargoID, userid As Long
    Dim Type As String
    Dim objSizeRange As New SizeRange
    Dim objJobOrderdatabase As New JobOrderdatabase
    Dim ObjTblRND As New TblDPRND
    Dim objDPSampleReceive As New DPSampleReceive
    Dim objPackingMst As New PackingMst
    Dim objPackingDtl As New PackingDtl
    Dim objGeneralCode As New GeneralCode
    Dim objStyleAssortmentMaster As New StyleAssortmentMaster
    Dim objStyleAssortmentDetail As New StyleAssortmentDetail
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lPackingMstid = Request.QueryString("PackingMstid")
        userid = Session("UserId")
        If Not Page.IsPostBack Then
            Session("dtPacking") = Nothing
            BindCustomer()
            If lPackingMstid > 0 Then
                Edit()
                btnSave.Visible = True
                btnSave.Text = "Update"
            Else
                GRNNoGenerateOnLoad()
                btnSave.Text = "Save"
            End If
        End If
    End Sub
    Sub GRNNoGenerateOnLoad()
        Try
            Dim VoucherNo As String
            Dim Voucherdate As Date = Date.Now
            Dim month As String = Voucherdate.Month
            Dim LastVoucherNo As String = objPackingDtl.GetLastNo()
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
            VoucherNo = "PAC" & "-" & LastCode
            txtPackingNO.Text = VoucherNo
        Catch ex As Exception
        End Try
    End Sub
    Sub BindCustomer()
        Dim dt As DataTable
        dt = objSizeRange.GetCustomerDatabaseNew()
        cmbCustomer.DataSource = dt
        cmbCustomer.DataTextField = "CustomerName"
        cmbCustomer.DataValueField = "CustomerID"
        cmbCustomer.DataBind()
        cmbCustomer.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Sub BindreceivingNo()
        Dim dt As DataTable
        dt = objSizeRange.GetShipmentNoNew(cmbCustomer.SelectedValue, cmbCustomerPONo.SelectedItem.Text)
        cmbReceivingNo.DataSource = dt
        cmbReceivingNo.DataTextField = "ReceivingNo"
        cmbReceivingNo.DataValueField = "NumberingFinalID"
        cmbReceivingNo.DataBind()
        cmbReceivingNo.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Sub BindCustomerPoNo()
        Dim dt As DataTable
        dt = objSizeRange.GetCustomerPONo(cmbCustomer.SelectedValue)
        cmbCustomerPONo.DataSource = dt
        cmbCustomerPONo.DataTextField = "CustomerPONo"
        cmbCustomerPONo.DataBind()
        cmbCustomerPONo.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Protected Sub cmbCustomerPONo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCustomerPONo.SelectedIndexChanged
        BindreceivingNo()
    End Sub
    Protected Sub cmbCustomer_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCustomer.SelectedIndexChanged
        BindCustomerPoNo()
    End Sub
    Protected Sub cmbReceivingNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbReceivingNo.SelectedIndexChanged
        SaveSession(cmbReceivingNo.SelectedValue)
        BindGrid()
        clear()
        btnSave.Visible = True
        btnCancel.Visible = True
    End Sub
    Protected Sub dgCargonEW_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgCargonEW.ItemCommand
        Try
            Select Case e.CommandName
                Case "Remove"
                    dtPacking = CType(Session("dtPacking"), DataTable)
                    If (Not dtPacking Is Nothing) Then
                        If (dtPacking.Rows.Count > 0) Then
                            Dim PackingDtlID As Integer = dgCargonEW.Items(e.Item.ItemIndex).Cells(0).Text
                            dtPacking.Rows.RemoveAt(e.Item.ItemIndex)
                            objSizeRange.DeletePackingDetail(PackingDtlID)
                            BindGrid()
                        End If
                    End If
            End Select
        Catch ex As Exception
        End Try
    End Sub
    'Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
    '    Try
    '        If cmbCustomer.SelectedValue = 0 Then
    '            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Customer.")
    '        ElseIf cmbReceivingNo.SelectedValue = 0 Then
    '            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Receiving No.")
    '        ElseIf cmbCustomerPONo.SelectedItem.Text = "Select" Then
    '            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Customer PO No.")
    '        Else
    '            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
    '                SaveSession()
    '                BindGrid()
    '            clear()
    '                btnSave.Visible = True
    '                btnCancel.Visible = True    
    '        End If
    '    Catch ex As Exception
    '    End Try
    'End Sub
    Sub clear()
        Try
            cmbReceivingNo.SelectedIndex = 0
        Catch ex As Exception
        End Try
    End Sub
    Sub SaveSession(ByVal NumberingFinalID As Long)
        If (Not CType(Session("dtPacking"), DataTable) Is Nothing) Then
            dtPacking = Session("dtPacking")
        Else
            dtPacking = New DataTable
            With dtPacking
                .Columns.Add("PackingDtlID", GetType(Long))
                .Columns.Add("CustomerID", GetType(String))
                .Columns.Add("Customer", GetType(String))
                .Columns.Add("CustomerPoNo", GetType(String))
                .Columns.Add("NumberingFinalID", GetType(String))
                .Columns.Add("ReceivingNo", GetType(String))
                .Columns.Add("NumberingFinalDtlID", GetType(String))
                .Columns.Add("NumberingDtlID", GetType(String))
                .Columns.Add("NumberingID", GetType(String))
                .Columns.Add("SizeRangeId", GetType(String))
                .Columns.Add("SizeDatabaseId", GetType(String))
                .Columns.Add("StyleAssortmentDetailID", GetType(String))
                .Columns.Add("StyleAssortmentMasterID", GetType(String))
                .Columns.Add("CuttingProDetailID", GetType(String))
                .Columns.Add("CuttingProMasterID", GetType(String))
                .Columns.Add("Joborderid", GetType(String))
                .Columns.Add("JoborderDetailid", GetType(String))
                .Columns.Add("Style", GetType(String))
                .Columns.Add("BuyerColor", GetType(String))
                .Columns.Add("NoOfCarton", GetType(String))
                .Columns.Add("Qty", GetType(String))
                .Columns.Add("Weight", GetType(String))
            End With
        End If
        Dim dt As DataTable
        dt = objSizeRange.GetNumberingDataNew2(NumberingFinalID)
        If dt.Rows.Count > 0 Then
            Dim x As Integer
            For x = 0 To dt.Rows.Count - 1
                Dr = dtPacking.NewRow()
                If lblIssueDtlID.Text = "" Then
                    Dr("PackingDtlID") = 0
                Else
                    Dr("PackingDtlID") = lblIssueDtlID.Text
                End If
                Dr("CustomerID") = cmbCustomer.SelectedValue
                Dr("Customer") = cmbCustomer.SelectedItem.Text
                Dr("NumberingFinalID") = cmbReceivingNo.SelectedValue
                Dr("ReceivingNo") = cmbReceivingNo.SelectedItem.Text
                Dr("CustomerPoNo") = cmbCustomerPONo.SelectedItem.Text
                Dr("Style") = dt.Rows(x)("Style")
                Dr("BuyerColor") = dt.Rows(x)("BuyerColor")
                Dr("NumberingFinalDtlID") = dt.Rows(x)("NumberingFinalDtlID")
                Dr("NumberingDtlID") = dt.Rows(x)("NumberingDtlID")
                Dr("NumberingID") = dt.Rows(x)("NumberingID")
                Dr("SizeRangeId") = dt.Rows(x)("SizeRangeId")
                Dr("SizeDatabaseId") = dt.Rows(x)("SizeDatabaseId")
                Dr("StyleAssortmentDetailID") = dt.Rows(x)("StyleAssortmentDetailID")
                Dr("StyleAssortmentMasterID") = dt.Rows(x)("StyleAssortmentMasterID")
                Dr("CuttingProDetailID") = dt.Rows(x)("CuttingProDetailID")
                Dr("CuttingProMasterID") = dt.Rows(x)("CuttingProMasterID")
                Dr("Joborderid") = dt.Rows(x)("Joborderid")
                Dr("JoborderDetailid") = dt.Rows(x)("JoborderDetailid")
                Dr("NoOfCarton") = dt.Rows(x)("CartonNoo")
                Dr("Qty") = dt.Rows(x)("PcsPerCarton")
                Dr("Weight") = dt.Rows(x)("Weightt")
                dtPacking.Rows.Add(Dr)
            Next
        End If
        Session("dtPacking") = dtPacking
    End Sub
    Private Sub BindGrid()
        Try
            Dim objDatatble As DataTable
            objDatatble = Session("dtPacking")
            dgCargonEW.Visible = True
            dgCargonEW.RecordCount = objDatatble.Rows.Count
            dgCargonEW.DataSource = objDatatble
            dgCargonEW.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("PackingListViewNew.aspx")
    End Sub
    Sub Edit()
        Dim dt As DataTable = ObjTblRND.GetEditForPacking(lPackingMstid)
        txtPackingNO.Text = dt.Rows(0)("PackingNo")
        txtDriverName.Text = dt.Rows(0)("DriverName")
        txtVehicleNO.Text = dt.Rows(0)("VehicleNO")
        txtTimeOut.Text = dt.Rows(0)("TimeOut")
            If (Not CType(Session("dtPacking"), DataTable) Is Nothing) Then
                dtPacking = Session("dtPacking")
            Else
                dtPacking = New DataTable
            With dtPacking
                .Columns.Add("PackingDtlID", GetType(Long))
                .Columns.Add("CustomerID", GetType(String))
                .Columns.Add("Customer", GetType(String))
                .Columns.Add("CustomerPoNo", GetType(String))
                .Columns.Add("NumberingFinalID", GetType(String))
                .Columns.Add("ReceivingNo", GetType(String))
                .Columns.Add("Style", GetType(String))
                .Columns.Add("BuyerColor", GetType(String))
                .Columns.Add("NoOfCarton", GetType(String))
                .Columns.Add("Qty", GetType(String))
                .Columns.Add("Weight", GetType(String))
            End With
            End If
            Dim x As Integer
        For x = 0 To dt.Rows.Count - 1
            Dr = dtPacking.NewRow()
            Dr("PackingDtlID") = dt.Rows(x)("PackingDtlID")
            Dr("CustomerID") = dt.Rows(x)("CustomerID")
            Dr("Customer") = dt.Rows(x)("CustomerName")
            Dr("CustomerPoNo") = dt.Rows(x)("CustomerPoNo")
            Dr("NumberingFinalID") = dt.Rows(x)("NumberingFinalID")
            Dr("ReceivingNo") = dt.Rows(x)("ReceivingNo")
            Dr("Style") = dt.Rows(x)("Style")
            Dr("BuyerColor") = dt.Rows(x)("BuyerColor")
            Dr("NoOfCarton") = dt.Rows(x)("NoOfCarton")
            Dr("Qty") = dt.Rows(x)("Qty")
            Dr("Weight") = dt.Rows(x)("Weight")
            dtPacking.Rows.Add(Dr)
            Session("dtPacking") = dtPacking
        Next
            BindGrid()
    End Sub
    Sub SaveMaster()
        With objPackingMst
            If lPackingMstid > 0 Then
                .PackingMstID = lPackingMstid
            Else
                .PackingMstID = 0
            End If
            .UserId = userid
            .CreationDate = Date.Now
            .PackingNo = txtPackingNO.Text
            .DriverName = txtDriverName.Text.ToUpper
            .VehicleNO = txtVehicleNO.Text.ToUpper
            .TimeOut = txtTimeOut.Text.ToUpper
            .Save()
        End With
    End Sub
    Sub SaveDetail()
        With objPackingDtl
            Dim a As Integer = 0
            For a = 0 To dgCargonEW.Items.Count - 1
                Dim ChkSelect As CheckBox = CType(dgCargonEW.Items(a).FindControl("ChkSelect"), CheckBox)
                Dim Status As String = ""
                If ChkSelect.Checked = True Then
                    Status = 1
                    Dim dt As DataTable = objStyleAssortmentMaster.UpdateDonePacking(dgCargonEW.Items(a).Cells(3).Text, Status)
                    .PackingDtlID = dgCargonEW.Items(a).Cells(0).Text
                    If lPackingMstid > 0 Then
                        .PackingMstID = lPackingMstid
                    Else
                        .PackingMstID = objPackingMst.GetId
                    End If
                    .CustomerID = dgCargonEW.Items(a).Cells(1).Text
                    .NumberingFinalID = dgCargonEW.Items(a).Cells(2).Text
                    .NumberingFinalDtlID = dgCargonEW.Items(a).Cells(3).Text
                    .NumberingDtlID = dgCargonEW.Items(a).Cells(4).Text
                    .NumberingID = dgCargonEW.Items(a).Cells(5).Text
                    .SizeRangeId = dgCargonEW.Items(a).Cells(6).Text
                    .SizeDatabaseId = dgCargonEW.Items(a).Cells(7).Text
                    .StyleAssortmentDetailID = dgCargonEW.Items(a).Cells(8).Text
                    .StyleAssortmentMasterID = dgCargonEW.Items(a).Cells(9).Text
                    .CuttingProDetailID = dgCargonEW.Items(a).Cells(10).Text
                    .CuttingProMasterID = dgCargonEW.Items(a).Cells(11).Text
                    .Joborderid = dgCargonEW.Items(a).Cells(12).Text
                    .JoborderDetailid = dgCargonEW.Items(a).Cells(13).Text
                    .CustomerPoNo = dgCargonEW.Items(a).Cells(15).Text
                    .BuyerColor = dgCargonEW.Items(a).Cells(17).Text
                    .Style = dgCargonEW.Items(a).Cells(18).Text
                    .Qty = dgCargonEW.Items(a).Cells(19).Text
                    .NoOfCarton = dgCargonEW.Items(a).Cells(20).Text
                    .Weight = dgCargonEW.Items(a).Cells(21).Text
                    .Save()
                End If
            Next
        End With
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        btnSave.Enabled = False
        SaveMaster()
        SaveDetail()
        Response.Redirect("PackingListViewNew.aspx")
    End Sub
End Class
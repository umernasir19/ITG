Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.Xml
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Net
Imports System.Net.Mail
Public Class DPPurchaseOrder
    Inherits System.Web.UI.Page
    ' Dim ObjTblRND As New DPPOMst
    Dim objDPPOMst As New DPPOMst
    Dim objDPPODtl As New DPPODtl
    Dim lDPPOMSTId, userid As Long
    Dim dtPODetail As DataTable
    Dim Dr As DataRow
    Dim ObjUnits As New Units
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lDPPOMSTId = Request.QueryString("lDPPOMSTId")
        userid = Session("UserId")
        If Not Page.IsPostBack Then
            Session("dtPODetail") = Nothing

            BindSupplier()
            BindUnit()
            BindPOType()
            POTypeDATA()
          


            If lDPPOMSTId > 0 Then
                Edit()

            Else
                VoucherNoGenerateOnLoad()
            End If


        End If
    End Sub
    Sub POTypeDATA()
        If cmbPoType.SelectedItem.Text = "Style Wise" Then

            Label2.Visible = True
            cmbStyle.Visible = True
            txtItemName.ReadOnly = True

        ElseIf cmbPoType.SelectedItem.Text = "Open" Then

            Label2.Visible = False
            cmbStyle.Visible = False
            txtItemName.ReadOnly = False
            txtRate.Text = ""
            txtAmount.Text = ""
            txtQuantity.Text = ""
            txtItemName.Text = ""
            txtDalNoO.Text = ""


        Else
            Label2.Visible = True
            cmbStyle.Visible = True
            txtItemName.ReadOnly = True
        End If
    End Sub

    Sub BindPOType()
        Try
            Dim dtPONO As DataTable
            dtPONO = objDPPOMst.BindPOType()
            cmbPoType.DataSource = dtPONO
            cmbPoType.DataTextField = "POType"
            cmbPoType.DataValueField = "POTypeid"
            cmbPoType.DataBind()
            ' cmbPoType.Items.Insert(0, New RadComboBoxItem("Select", 0))
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbPoType_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbPoType.SelectedIndexChanged
        Try
            If cmbPoType.SelectedItem.Text = "Style Wise" Then

                Label2.Visible = True
                cmbStyle.Visible = True
                txtItemName.ReadOnly = True

            ElseIf cmbPoType.SelectedItem.Text = "Open" Then

                Label2.Visible = False
                cmbStyle.Visible = False
                txtItemName.ReadOnly = False
                txtRate.Text = ""
                txtAmount.Text = ""
                txtQuantity.Text = ""
                txtItemName.Text = ""
                txtDalNoO.Text = ""


            Else
                Label2.Visible = True
                cmbStyle.Visible = True
                txtItemName.ReadOnly = True
            End If

        Catch ex As Exception

        End Try
    End Sub
    Sub Edit()
        Try
            Dim dt As DataTable = objDPPOMst.GetEdit(lDPPOMSTId)
            txtInvoiceDatee.SelectedDate = dt.Rows(0)("InvoiceDate")
            txtGRNNO.Text = dt.Rows(0)("PONo")
            txtDalNoO.Text = dt.Rows(0)("DALNo")
            txtDalNoO.Enabled = False
            cmbSupplier.SelectedValue = dt.Rows(0)("SupplierID")
            lblFabricMstId.Text = dt.Rows(0)("FabricDbMstID")
            TXTInditexPONo.Text = dt.Rows(0)("InditexPONo")
            BindPOType()
            cmbPoType.SelectedValue = dt.Rows(0)("POTypeID")
            BindStyle()
            cmbStyle.SelectedValue = dt.Rows(0)("DPRNDID")
            lblUserId.Text = dt.Rows(0)("UserId")
            ' txtItemName.Text = dt.Rows(0)("ItemName")
            If cmbPoType.SelectedItem.Text = "Style Wise" Then

                Label2.Visible = True
                cmbStyle.Visible = True
                txtItemName.ReadOnly = True

            ElseIf cmbPoType.SelectedItem.Text = "Open" Then

                Label2.Visible = False
                cmbStyle.Visible = False
                txtItemName.ReadOnly = False
                txtRate.Text = ""
                txtAmount.Text = ""
                txtQuantity.Text = ""
                txtItemName.Text = ""
                txtDalNoO.Text = ""

            Else
                Label2.Visible = True
                cmbStyle.Visible = True
                txtItemName.ReadOnly = True
            End If
            If (Not CType(Session("dtPODetail"), DataTable) Is Nothing) Then
                dtPODetail = Session("dtPODetail")
            Else
                dtPODetail = New DataTable
                With dtPODetail
                    .Columns.Add("DPPODetailID", GetType(Long))
                    .Columns.Add("ItemName", GetType(String))
                    .Columns.Add("UnitID", GetType(String))
                    .Columns.Add("Unit", GetType(String))
                    .Columns.Add("Quantity", GetType(String))
                    .Columns.Add("Rate", GetType(Decimal))
                    .Columns.Add("Amount", GetType(String))
                    .Columns.Add("DelDate", GetType(String))

                    .Columns.Add("DPRNDID", GetType(String))
                    .Columns.Add("Style", GetType(String))
                    .Columns.Add("DCNO", GetType(String))
                End With
            End If
            Dim x As Integer
            For x = 0 To dt.Rows.Count - 1

                Dr = dtPODetail.NewRow()
                Dr("DPPODetailID") = dt.Rows(x)("DPPODtlID")
                Dr("ItemName") = dt.Rows(x)("ItemName")
                Dr("UnitID") = dt.Rows(x)("UnitID")
                Dr("Unit") = dt.Rows(x)("Unit")
                Dr("Quantity") = dt.Rows(x)("Quantity")
                Dr("Rate") = dt.Rows(x)("Rate")
                Dr("Amount") = dt.Rows(x)("Amount")
                Dr("DelDate") = dt.Rows(x)("DelDate")
                Dr("DPRNDID") = dt.Rows(x)("DPRNDID")
                Dr("Style") = dt.Rows(x)("Style")
                Dr("DCNO") = dt.Rows(x)("DCNO")
                dtPODetail.Rows.Add(Dr)
            Next
            Session("dtPODetail") = dtPODetail
            BindAccessGrid()
        Catch ex As Exception

        End Try
    End Sub
    Sub VoucherNoGenerateOnLoad()
        Try
            Dim VoucherNo As String

            Dim Voucherdate As Date = Date.Now
            Dim year As String = Voucherdate.Year
            Dim yearP As String = Voucherdate.Year
            year = year.Substring(2, 2)

            Dim LastVoucherNo As String = objDPPOMst.GetLastVoucherNo(yearP)

            Dim LastCode As String
            If LastVoucherNo = "" Then
                LastCode = "0000001"
            Else

                LastCode = LastVoucherNo.Substring(6, 7)
                If LastCode < 10 Then
                    If LastCode = 9 Then
                        LastCode = "00000" & Val(LastCode + 1)
                    Else
                        LastCode = "000000" & Val(LastCode + 1)
                    End If

                ElseIf LastCode < 100 Or LastCode = 10 Then
                    If LastCode = 99 Then
                        LastCode = "0000" & Val(LastCode + 1)
                    Else
                        LastCode = "00000" & Val(LastCode + 1)
                    End If
                ElseIf LastCode < 1000 Or LastCode = 100 Then
                    If LastCode = 999 Then
                        LastCode = "000" & Val(LastCode + 1)
                    Else
                        LastCode = "0000" & Val(LastCode + 1)
                    End If
                ElseIf LastCode < 10000 Or LastCode = 1000 Then
                    If LastCode = 9999 Then
                        LastCode = "00" & Val(LastCode + 1)
                    Else
                        LastCode = "000" & Val(LastCode + 1)
                    End If
                ElseIf LastCode < 100000 Or LastCode = 10000 Then
                    If LastCode = 99999 Then
                        LastCode = "0" & Val(LastCode + 1)
                    Else
                        LastCode = "00" & Val(LastCode + 1)
                    End If
                ElseIf LastCode < 1000000 Or LastCode = 100000 Then
                    If LastCode = 999999 Then
                        LastCode = Val(LastCode + 1)
                    Else
                        LastCode = Val(LastCode + 1)
                    End If
                Else
                    LastCode = Val(LastCode + 1)
                End If

            End If
            VoucherNo = "PO" & "/" & year & "" & "/" & LastCode
            txtGRNNO.Text = VoucherNo


        Catch ex As Exception

        End Try
    End Sub

    Protected Sub txtRate_TextChanged(sender As Object, e As EventArgs) Handles txtRate.TextChanged
        Try
            txtAmount.Text = Val(txtRate.Text) * Val(txtQuantity.Text)
            UptxtAmount.Update()

        Catch ex As Exception

        End Try
    End Sub
    Sub BindUnit()
        Try
            Dim dtsupplier As DataTable
            dtsupplier = objDPPOMst.GetUnit
            cmbUnit.DataSource = dtsupplier
            cmbUnit.DataTextField = "UnitName"
            cmbUnit.DataValueField = "UnitID"
            cmbUnit.DataBind()

        Catch ex As Exception
        End Try
    End Sub
    Sub BindSupplier()
        Try
            Dim dtsupplier As DataTable
            dtsupplier = objDPPOMst.GetSupplierComboNNew
            cmbSupplier.DataSource = dtsupplier
            cmbSupplier.DataTextField = "SupplierName"
            cmbSupplier.DataValueField = "SupplierDatabaseID"
            cmbSupplier.DataBind()

        Catch ex As Exception
        End Try
    End Sub
    
    Protected Sub txtDalNoO_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtDalNoO.TextChanged
        Try


            If cmbPoType.SelectedItem.Text = "Style Wise" Then
                Dim dtFBData As DataTable = objDPPOMst.GetFBData(txtDalNoO.Text)
                If dtFBData.Rows.Count > 0 Then
                    lblFabricMstId.Text = dtFBData.Rows(0)("FabricDBMstId")
                    txtItemName.Text = dtFBData.Rows(0)("Item")
                    cmbSupplier.SelectedValue = dtFBData.Rows(0)("SupplierID")
                End If
                BindStyle()
                Dim dtStyle As DataTable = objDPPOMst.GetStyleQty(cmbStyle.SelectedValue)
                If dtStyle.Rows.Count > 0 Then

                    'Update Yasir on 2 June 2016
                    Dim DTQuantity As DataTable
                    DTQuantity = objDPPOMst.GetRemQty(cmbStyle.SelectedValue, txtDalNoO.Text)

                    Dim Qunatity As Decimal = DTQuantity.Rows(0)("Quantity")
                    If Qunatity > 0 Then
                        txtQuantity.Text = DTQuantity.Rows(0)("Quantity")
                        UptxtQuantity.Update()
                    Else

                        txtQuantity.Text = (-1) * (DTQuantity.Rows(0)("Quantity"))
                        UptxtQuantity.Update()
                    End If



                    Dim dtPrice As DataTable = objDPPOMst.GetPrice(dtFBData.Rows(0)("FabricDBMstId"))
                    txtRate.Text = dtPrice.Rows(0)("Price")
                    UptxtRate.Update()
                    ' txtRate.Text = dtStyle.Rows(0)("FabricPrice")

                    txtAmount.Text = Val(txtQuantity.Text) * Val(txtRate.Text)
                    UptxtAmount.Update()
                End If

            ElseIf cmbPoType.SelectedItem.Text = "Open" Then

                Dim dtFBData As DataTable = objDPPOMst.GetFBData(txtDalNoO.Text)
                If dtFBData.Rows.Count > 0 Then
                    lblFabricMstId.Text = dtFBData.Rows(0)("FabricDBMstId")
                    cmbSupplier.SelectedValue = dtFBData.Rows(0)("SupplierID")
                    txtItemName.Text = dtFBData.Rows(0)("Item")
                End If
            Else
                Dim dtFBData As DataTable = objDPPOMst.GetFBData(txtDalNoO.Text)
                If dtFBData.Rows.Count > 0 Then
                    lblFabricMstId.Text = dtFBData.Rows(0)("FabricDBMstId")
                    txtItemName.Text = dtFBData.Rows(0)("Item")
                    cmbSupplier.SelectedValue = dtFBData.Rows(0)("SupplierID")
                End If
                BindStyle()
                Dim dtStyle As DataTable = objDPPOMst.GetStyleQty(cmbStyle.SelectedValue)
                If dtStyle.Rows.Count > 0 Then


                    'Update Yasir on 2 June 2016
                    Dim DTQuantity As DataTable
                    DTQuantity = objDPPOMst.GetRemQty(cmbStyle.SelectedValue, txtDalNoO.Text)

                    Dim Qunatity As Decimal = DTQuantity.Rows(0)("Quantity")
                    If Qunatity > 0 Then
                        txtQuantity.Text = DTQuantity.Rows(0)("Quantity")
                        UptxtQuantity.Update()
                    Else

                        txtQuantity.Text = (-1) * (DTQuantity.Rows(0)("Quantity"))
                        UptxtQuantity.Update()
                    End If



                    Dim dtPrice As DataTable = objDPPOMst.GetPrice(dtFBData.Rows(0)("FabricDBMstId"))
                    txtRate.Text = dtPrice.Rows(0)("Price")
                    UptxtRate.Update()


                    txtAmount.Text = Val(txtQuantity.Text) * Val(txtRate.Text)
                    UptxtAmount.Update()
                End If
            End If



        Catch ex As Exception

        End Try
    End Sub
    Sub BindStyle()
        Dim dtStyle As DataTable = objDPPOMst.GetStyleForRND(lblFabricMstId.Text)
        cmbStyle.DataSource = dtStyle
        cmbStyle.DataTextField = "Style"
        cmbStyle.DataValueField = "DPRNDID"
        cmbStyle.DataBind()

    End Sub
    Protected Sub cmbStyle_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbStyle.SelectedIndexChanged
        Try

            Dim dtFBData As DataTable = objDPPOMst.GetFBData(txtDalNoO.Text)
            If dtFBData.Rows.Count > 0 Then
                lblFabricMstId.Text = dtFBData.Rows(0)("FabricDBMstId")
                txtItemName.Text = dtFBData.Rows(0)("Item")
                cmbSupplier.SelectedValue = dtFBData.Rows(0)("SupplierID")
                UpcmbItem.Update()
            End If


            Dim dtStyle As DataTable = objDPPOMst.GetStyleQty(cmbStyle.SelectedValue)
            If dtStyle.Rows.Count > 0 Then
                txtQuantity.Text = dtStyle.Rows(0)("Quantity")
                UptxtQuantity.Update()
                txtRate.Text = dtStyle.Rows(0)("FabricPrice")
                UptxtRate.Update()
                txtAmount.Text = Val(txtQuantity.Text) * Val(txtRate.Text)
                UptxtAmount.Update()
            End If
            '  BindAcc()



        Catch ex As Exception

        End Try
    End Sub
  
    Protected Sub btnAddAccessories_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddAccessories.Click
        Try
            If txtRate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Rate")
            ElseIf txtAmount.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Amount")
            ElseIf txtQuantity.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Quantity")
            ElseIf txtDelDate.ValidationDate = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Del. Date")

            ElseIf txtDCNO.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill DC NO")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                SaveSession()
                BindAccessGrid()
            End If

        Catch ex As Exception

        End Try


    End Sub
    Sub SaveSession()

        If (Not CType(Session("dtPODetail"), DataTable) Is Nothing) Then
            dtPODetail = Session("dtPODetail")
        Else
            dtPODetail = New DataTable
            With dtPODetail
                .Columns.Add("DPPODetailID", GetType(Long))
                .Columns.Add("ItemName", GetType(String))
                .Columns.Add("UnitID", GetType(String))
                .Columns.Add("Unit", GetType(String))
                .Columns.Add("Quantity", GetType(String))
                .Columns.Add("Rate", GetType(Decimal))
                .Columns.Add("Amount", GetType(String))
                .Columns.Add("DelDate", GetType(String))
                .Columns.Add("DPRNDID", GetType(String))
                .Columns.Add("Style", GetType(String))
                .Columns.Add("DCNO", GetType(String))
            End With
        End If
        Dr = dtPODetail.NewRow()
        If Val(lblDetailID.Text) > 0 Then
            Dr("DPPODetailID") = lblDetailID.Text
        Else
            Dr("DPPODetailID") = 0
        End If

        Dr("ItemName") = txtItemName.Text
        Dr("UnitID") = cmbUnit.SelectedValue
        Dr("Unit") = cmbUnit.SelectedItem.Text
        If txtQuantity.Text = "" Then
            Dr("Quantity") = 0
        Else
            Dr("Quantity") = txtQuantity.Text
        End If
        If txtRate.Text = "" Then
            Dr("Rate") = 0
        Else
            Dr("Rate") = txtRate.Text
        End If
        If txtAmount.Text = "" Then
            Dr("Amount") = 0
        Else
            Dr("Amount") = txtAmount.Text
        End If
        Dr("DelDate") = txtDelDate.SelectedDate


        If cmbPoType.SelectedItem.Text = "Style Wise" Then
            Dr("DPRNDID") = cmbStyle.SelectedValue
            Dr("Style") = cmbStyle.SelectedItem.Text
        ElseIf cmbPoType.SelectedItem.Text = "Open" Then
            Dr("DPRNDID") = 0
            Dr("Style") = "N/A"
        Else
            Dr("DPRNDID") = cmbStyle.SelectedValue
            Dr("Style") = cmbStyle.SelectedItem.Text
        End If

      
        Dr("DCNO") = txtDCNO.Text
        dtPODetail.Rows.Add(Dr)
        Session("dtPODetail") = dtPODetail


    End Sub


    Sub BindAccessGrid()
        Try
            dtPODetail = CType(Session("dtPODetail"), DataTable)
            If dtPODetail.Rows.Count > 0 Then
                dgPODETAIL.DataSource = dtPODetail
                dgPODETAIL.DataBind()
                dgPODETAIL.Visible = True
            Else

                dgPODETAIL.Visible = False
            End If

        Catch ex As Exception

        End Try

    End Sub
    Sub BindAccessGridonEdit()
        Try
            If dtPODetail.Rows.Count > 0 Then
                dgPODETAIL.DataSource = dtPODetail
                dgPODETAIL.DataBind()
                dgPODETAIL.Visible = True
            Else

                dgPODETAIL.Visible = False
            End If

        Catch ex As Exception

        End Try

    End Sub

    


    'Protected Sub dgPODETAIL_DeleteCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgPODETAIL.DeleteCommand
    '    Dim DT As DataTable = objDPPOMst.CheckExistingPO(lDPPOMSTId)
    '    If DT.Rows.Count > 0 Then
    '        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("This PO Already Used In Fabric Receive")
    '        BindAccessGrid()
    '    Else

    '        dtPODetail = CType(Session("dtPODetail"), DataTable)
    '        If (Not dtPODetail Is Nothing) Then
    '            If (dtPODetail.Rows.Count > 0) Then
    '                Dim DPPODetailID As Integer = dtPODetail.Rows(e.Item.ItemIndex)("DPPODtlID")
    '                dtPODetail.Rows.RemoveAt(e.Item.ItemIndex)
    '                objDPPOMst.Deletedetail(DPPODetailID)
    '                BindAccessGrid()


    '                If dtPODetail.Rows.Count = 0 Then
    '                    txtDalNoO.Text = ""
    '                    txtDalNoO.Enabled = True
    '                End If

    '            Else
    '            End If

    '        End If
    '    End If
    'End Sub

    'Protected Sub dgPODETAIL_EditCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgPODETAIL.EditCommand

    '    Select Case e.CommandName

    '        Case "Edit"

    '            dtPODetail = CType(Session("dtPODetail"), DataTable)
    '            If (Not dtPODetail Is Nothing) Then
    '                If (dtPODetail.Rows.Count > 0) Then
    '                    Dim DPPODetailID As Integer = dtPODetail.Rows(e.Item.ItemIndex)("DPPODetailID") 'dgPODETAIL.Items(e.Item.ItemIndex).Cells(0).Text '


    '                    If lDPPOMSTId > 0 Then
    '                        SetDetailEdit(e.Item.ItemIndex)
    '                        dtPODetail.Rows.RemoveAt(e.Item.ItemIndex)
    '                        Session("dtPODetail") = dtPODetail
    '                        BindAccessGrid()

    '                    Else
    '                        dtPODetail.Rows.RemoveAt(e.Item.ItemIndex)
    '                        BindAccessGrid()
    '                    End If
    '                Else
    '                End If
    '            End If
    '    End Select
    'End Sub

    Protected Sub dgPODETAIL_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgPODETAIL.ItemCommand
        Select Case e.CommandName

            Case "Delete"
                Dim DT As DataTable = objDPPOMst.CheckExistingPO(lDPPOMSTId)
                If DT.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("This PO Already Used In Fabric Receive")
                    BindAccessGrid()
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    dtPODetail = CType(Session("dtPODetail"), DataTable)
                    If (Not dtPODetail Is Nothing) Then
                        If (dtPODetail.Rows.Count > 0) Then
                            Dim DPPODetailID As Integer = dtPODetail.Rows(e.Item.ItemIndex)("DPPODetailID")
                            dtPODetail.Rows.RemoveAt(e.Item.ItemIndex)
                            objDPPOMst.Deletedetail(DPPODetailID)
                            BindAccessGrid()
                            txtDalNoO.Enabled = True
                        Else
                        End If
                    End If
                End If
        End Select
    End Sub

    Sub SetDetailEdit(ByVal dtrowNo As Long)
        Try
            Dim DelDate As String
            lblDetailID.Text = dtPODetail.Rows(dtrowNo)("DPPODetailID")
            txtItemName.Text = dtPODetail.Rows(dtrowNo)("ItemName")
            BindUnit()
            cmbUnit.SelectedValue = dtPODetail.Rows(dtrowNo)("UnitID")
            cmbUnit.SelectedItem.Text = dtPODetail.Rows(dtrowNo)("Unit")
            txtItemName.Text = dtPODetail.Rows(dtrowNo)("ItemName")
            txtQuantity.Text = dtPODetail.Rows(dtrowNo)("Quantity")
            txtRate.Text = dtPODetail.Rows(dtrowNo)("Rate")
            txtAmount.Text = dtPODetail.Rows(dtrowNo)("Amount")
            DelDate = dtPODetail.Rows(dtrowNo)("DelDate")
            txtDelDate.SelectedDate = DelDate
            BindStyle()
            cmbStyle.SelectedValue = dtPODetail.Rows(dtrowNo)("DPRNDID")
            cmbStyle.SelectedItem.Text = dtPODetail.Rows(dtrowNo)("Style")
            txtDCNO.Text = dtPODetail.Rows(dtrowNo)("DCNO")

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            Try

                'Dim dt As DataTable = objDPPOMst.GetPONo(txtGRNNO.Text)
                ' If dt.Rows.Count > 0 Then
                ' DirectCast(Me.Page.Master, MasterPage).ShowMessgae("PO No.Already Exist")
                ' Else
                If txtInvoiceDatee.ValidationDate = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Date")
                ElseIf dgPODETAIL.Items.Count = 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Atleast Add one item")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    save()
                    Response.Redirect("DPPOView.aspx")
                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
    Sub save()
        Try
            With objDPPOMst
                If lDPPOMSTId > 0 Then
                    .DPPOMstID = lDPPOMSTId
                Else
                    .DPPOMstID = 0
                End If

                .FabricDbMstID = lblFabricMstId.Text

                If Session("RoleId") = 46 And Session("Type") = "R.N.D" Then
                    If lDPPOMSTId > 0 Then
                        .UserID = lblUserId.Text
                    Else
                        .UserID = 270
                    End If
                Else
                    If lDPPOMSTId > 0 Then
                        .UserID = lblUserId.Text
                    Else
                        .UserID = userid
                    End If
                End If
                .CreationDate = Date.Now
                .InvoiceDate = txtInvoiceDatee.SelectedDate
                .PONo = txtGRNNO.Text
                .DALNo = txtDalNoO.Text
                .SupplierID = cmbSupplier.SelectedValue
                If TXTInditexPONo.Text = "" Then
                    .InditexPONo = " "
                Else
                    .InditexPONo = TXTInditexPONo.Text.ToUpper
                End If
                .POTypeID = cmbPoType.SelectedValue
                .SaveMST()
            End With
            Dim x As Integer
            For x = 0 To dgPODETAIL.Items.Count - 1
                Dim item As GridDataItem = DirectCast(dgPODETAIL.MasterTableView.Items(x), GridDataItem)
                With objDPPODtl
                    .DPPODtlID = item("DPPODetailID").Text
                    If lDPPOMSTId > 0 Then
                        .DPPOMstID = lDPPOMSTId
                    Else
                        .DPPOMstID = objDPPOMst.GetID
                    End If

                    .ItemName = item("ItemName").Text
                    .UnitID = item("UnitID").Text
                    .Unit = item("Unit").Text
                    .Quantity = item("Quantity").Text
                    .Rate = item("Rate").Text
                    .Amount = item("Amount").Text
                    .DelDate = item("DelDate").Text

                    .DPRNDID = item("DPRNDID").Text
                    .Style = item("Style").Text
                    .DCNO = item("DCNO").Text
                    .SavedTL()
                End With
            Next

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtQuantity_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtQuantity.TextChanged
        Try
            'Dim Qty As Decimal = 0
            'Qty = Val(txtQuantity.Text) * Val(txtRate.Text)
            'txtAmount.Text = Qty
            txtAmount.Text = Val(txtRate.Text) * Val(txtQuantity.Text)
            UptxtAmount.Update()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Response.Redirect("DPPOView.aspx")
    End Sub

    'Protected Sub txtRate_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtRate.TextChanged
    '    Try
    '        Dim Qty As Decimal = 0
    '        Qty = txtQuantity.Text * txtRate.Text
    '        txtAmount.Text = Qty
    '    Catch ex As Exception

    '    End Try
    'End Sub
    Protected Sub btnAddUnit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAddUnit.Click
        Try
            pnlUnit2.Visible = True
            pnlUnit1.Visible = False
        Catch ex As Exception

        End Try
    End Sub


    Protected Sub btnSaveUnit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSaveUnit.Click
        Try
            If txtAddUnit.Text = "" Then
                With ObjUnits

                    .UnitID = 0
                    .UnitName = txtAddUnit.Text.ToUpper
                End With
            Else
                With ObjUnits

                    .UnitID = 0
                    .UnitName = txtAddUnit.Text.ToUpper
                    .SaveUnits()

                End With
                txtAddUnit.Text = ""
            End If


        Catch ex As Exception

        End Try

        pnlUnit1.Visible = True
        pnlUnit2.Visible = False
        BindUnit()
    End Sub
End Class
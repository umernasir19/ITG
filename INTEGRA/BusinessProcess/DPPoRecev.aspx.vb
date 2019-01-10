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

Public Class DPPoRecev
    Inherits System.Web.UI.Page
    ' Dim ObjTblRND As New DPPOMst
    Dim objDPPOMst As New DPPOMst
    Dim objDPPODtl As New DPPODtl
    Dim lDPPOMSTId, userid As Long
    Dim dtPORecvDetail As DataTable
    Dim Dr As DataRow
    Dim objDPPoRecevMst As New DPPoRecevMst
    Dim objDPPoRecevDtl As New DPPoRecevDtl
    Dim lPOReceiveMstID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lPOReceiveMstID = Request.QueryString("lPOReceiveMstID")
        If Not Page.IsPostBack Then
            Session("dtPORecvDetail") = Nothing
            ' Dim timeZoneInfo As TimeZoneInfo
            ' Dim dateTime As DateTime
            'Set the time zone information to US Mountain Standard Time 
            ' timeZoneInfo = timeZoneInfo.FindSystemTimeZoneById("Pakistan Standard Time")
            'Get date and time in US Mountain Standard Time 
            'dateTime = timeZoneInfo.ConvertTime(dateTime.Now, timeZoneInfo)
            'Dim time As String = dateTime.ToLongTimeString()
            ' txtReceiveTime.Text = time   ' DateTime.Now.ToLongTimeString()
            PakistanTimezoneNew()
            BindSupplier()
            GRNNoGenerateOnLoad()
            If lPOReceiveMstID > 0 Then
                edit()
            Else
            End If

        End If
    End Sub
    Sub PakistanTimezoneNew()
        txtReceiveTime.Text = DateTime.Now.ToString("HH:mm:ss")
    End Sub
    Sub edit()
        Try
            Dim dt As DataTable = objDPPoRecevMst.GetEdit(lPOReceiveMstID)
            txtReceiveDate.SelectedDate = dt.Rows(0)("ReceiveDate")
            txtReceiveTime.Text = dt.Rows(0)("ReceiveTime")
            txtGRNNO.Text = dt.Rows(0)("GRNO")
            cmbSupplier.SelectedValue = dt.Rows(0)("SupplierID")
            txtDCNo.Text = dt.Rows(0)("DCNo")
            BindPONO()
            If (Not CType(Session("dtPORecvDetail"), DataTable) Is Nothing) Then
                dtPORecvDetail = Session("dtPORecvDetail")
            Else
                dtPORecvDetail = New DataTable
                With dtPORecvDetail
                    .Columns.Add("POReceiveDtlID", GetType(Long))
                    .Columns.Add("DPPOMstID", GetType(Long))
                    .Columns.Add("PONO", GetType(String))
                    .Columns.Add("Dal", GetType(String))
                    .Columns.Add("FabricMstID", GetType(Long))
                    .Columns.Add("ItemName", GetType(String))
                    .Columns.Add("DPPODtlID", GetType(Long))
                    .Columns.Add("Style", GetType(String))
                    .Columns.Add("Unit", GetType(String))
                    .Columns.Add("POQty", GetType(Decimal))
                    .Columns.Add("POReceivedQty", GetType(Decimal))
                    .Columns.Add("ReceivedQty", GetType(Decimal))
                End With
            End If
            Dim x As Integer
            For x = 0 To dt.Rows.Count - 1
                Dr = dtPORecvDetail.NewRow()
                Dr("POReceiveDtlID") = dt.Rows(x)("POReceiveDtlID")
                Dr("DPPOMstID") = dt.Rows(x)("DPPOMstID")
                Dr("PONO") = dt.Rows(x)("PONO")
                Dr("Dal") = dt.Rows(x)("DALNO")
                Dr("FabricMstID") = dt.Rows(x)("DPFabricMstID")
                Dr("ItemName") = dt.Rows(x)("ItemName")
                Dr("DPPODtlID") = dt.Rows(x)("DPPODtlID")
                Dr("Style") = dt.Rows(x)("Style")
                Dr("Unit") = dt.Rows(x)("Unit")
                Dr("POQty") = dt.Rows(x)("Quantity")
                Dr("POReceivedQty") = dt.Rows(x)("POReceivedQty")
                Dr("ReceivedQty") = dt.Rows(x)("ReceiveQty")
                dtPORecvDetail.Rows.Add(Dr)
            Next
            Session("dtPORecvDetail") = dtPORecvDetail
            BindAccessGrid()
        Catch ex As Exception

        End Try
    End Sub
    Sub BindSupplier()
        Try
            Dim dtsupplier As DataTable
            dtsupplier = objDPPoRecevMst.GetSupplierComboNNeww
            cmbSupplier.DataSource = dtsupplier
            cmbSupplier.DataTextField = "SupplierName"
            cmbSupplier.DataValueField = "SupplierDatabaseID"
            cmbSupplier.DataBind()
            cmbSupplier.Items.Insert(0, New RadComboBoxItem("Select", 0))

        Catch ex As Exception
        End Try
    End Sub
    Sub BindPONO()
        Try
            Dim dtPONO As DataTable
            dtPONO = objDPPoRecevMst.GetPONO(cmbSupplier.SelectedValue)
            CmbPONO.DataSource = dtPONO
            CmbPONO.DataTextField = "PONO"
            CmbPONO.DataValueField = "DPPOMstID"
            CmbPONO.DataBind()
            CmbPONO.Items.Insert(0, New RadComboBoxItem("Select", 0))
        Catch ex As Exception
        End Try
    End Sub
    Sub GetDalNo()
        Try
            Dim dtPONO As DataTable
            dtPONO = objDPPoRecevMst.GetDalNO(CmbPONO.SelectedValue)
            txtDalNo.Text = dtPONO.Rows(0)("DalNo")
            LBLDalNo.Text = dtPONO.Rows(0)("FabricDbMstID")
        Catch ex As Exception
        End Try
    End Sub
    Sub BindItem()
        Try
            Dim dtItem As DataTable
            dtItem = objDPPoRecevMst.GetItemStyleUnitPOQty(CmbPONO.SelectedValue)
            CmbItem.DataSource = dtItem
            CmbItem.DataTextField = "ItemName"
            CmbItem.DataValueField = "DPPODtlID"
            CmbItem.DataBind()
            CmbItem.Items.Insert(0, New RadComboBoxItem("Select", 0))
           


        Catch ex As Exception
        End Try
    End Sub
    Protected Sub CmbItem_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles CmbItem.SelectedIndexChanged
        Try
            GetPOData()
           
        Catch ex As Exception

        End Try
    End Sub
    Sub GetPOData()
        Dim dtItem As DataTable
        dtItem = objDPPoRecevMst.GetItemStyleUnitPOQtyData(CmbPONO.SelectedValue, CmbItem.SelectedValue)
        If dtItem.Rows.Count > 0 Then
            txtStyle.Text = dtItem.Rows(0)("Style")
            txtUnit.Text = dtItem.Rows(0)("Unit")
            txtPoQty.Text = dtItem.Rows(0)("Quantity")
        End If
        Dim DTRecv As DataTable = objDPPoRecevMst.GetItemRecvePOQtyData(CmbPONO.SelectedValue, CmbItem.SelectedValue)
        If DTRecv.Rows.Count > 0 Then
            txtPOReceivedQty.Text = DTRecv.Rows(0)("RecvQty")
        Else
            txtPOReceivedQty.Text = 0
        End If
    End Sub

    Protected Sub cmbSupplier_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbSupplier.SelectedIndexChanged
        Try
            BindPONO()
            clear()
            txtDalNo.Text = ""
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub CmbPONO_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles CmbPONO.SelectedIndexChanged
        Try
            GetDalNo()
            BindItem()
        Catch ex As Exception

        End Try
    End Sub





    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
        Try
            If Val(txtPOReceivedQty.Text) + Val(txtReceivQty.Text) > Val(txtPoQty.Text) Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Quantity exceed")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                SaveSession()
                clear()
            End If
        

        Catch ex As Exception

        End Try


    End Sub
    Sub SaveSession()

        If (Not CType(Session("dtPORecvDetail"), DataTable) Is Nothing) Then
            dtPORecvDetail = Session("dtPORecvDetail")
        Else
            dtPORecvDetail = New DataTable
            With dtPORecvDetail
                .Columns.Add("POReceiveDtlID", GetType(Long))
                .Columns.Add("DPPOMstID", GetType(Long))
                .Columns.Add("PONO", GetType(String))
                .Columns.Add("Dal", GetType(String))
                .Columns.Add("FabricMstID", GetType(Long))
                .Columns.Add("ItemName", GetType(String))
                .Columns.Add("DPPODtlID", GetType(Long))
                .Columns.Add("Style", GetType(String))
                .Columns.Add("Unit", GetType(String))
                .Columns.Add("POQty", GetType(Decimal))
                .Columns.Add("POReceivedQty", GetType(Decimal))
                .Columns.Add("ReceivedQty", GetType(Decimal))
            End With
        End If
        Dr = dtPORecvDetail.NewRow()
        If Val(lblDetailID.Text) > 0 Then
            Dr("POReceiveDtlID") = lblDetailID.Text
        Else
            Dr("POReceiveDtlID") = 0
        End If

        Dr("DPPOMstID") = CmbPONO.SelectedValue
        Dr("PONO") = CmbPONO.SelectedItem.Text
        Dr("Dal") = txtDalNo.Text
        Dr("FabricMstID") = LBLDalNo.Text
        Dr("ItemName") = CmbItem.SelectedItem.Text
        Dr("DPPODtlID") = CmbItem.SelectedValue
        Dr("Style") = txtStyle.Text
        Dr("Unit") = txtUnit.Text
        Dr("POQty") = txtPoQty.Text
        Dr("POReceivedQty") = txtPOReceivedQty.Text
        Dr("ReceivedQty") = txtReceivQty.Text
         dtPORecvDetail.Rows.Add(Dr)
        Session("dtPORecvDetail") = dtPORecvDetail
        BindAccessGrid()

    End Sub


    Sub BindAccessGrid()
        Try
            If dtPORecvDetail.Rows.Count > 0 Then
                dgPORecv.DataSource = dtPORecvDetail
                dgPORecv.DataBind()
                dgPORecv.Visible = True
            Else

                dgPORecv.Visible = False
            End If

        Catch ex As Exception

        End Try

    End Sub
    Sub clear()

        CmbPONO.SelectedIndex = 0
        CmbItem.SelectedIndex = 0
        ' txtDalNo.Text = ""
        txtStyle.Text = ""
        txtPoQty.Text = ""
        txtUnit.Text = ""
        txtReceivQty.Text = ""
        txtPOReceivedQty.Text = ""
        txtPoQty.Text = ""

    End Sub



    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            Try
                If txtReceiveDate.ValidationDate = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Date")
                ElseIf txtDCNo.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill DC No.")
                ElseIf dgPORecv.Items.Count = 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Atleast add one record in grid")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    save()
                    Response.Redirect("DPPoRecevView.aspx")
                End If

                  
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Try
                Response.Redirect("DPPoRecevView.aspx")
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
    Sub save()
        Try
            With objDPPoRecevMst
                If lPOReceiveMstID > 0 Then
                    .POReceiveMstID = lPOReceiveMstID
                Else
                    .POReceiveMstID = 0
                End If

                .ReceiveDate = txtReceiveDate.SelectedDate
                .CreationDate = Date.Now
                .ReceiveTime = txtReceiveTime.Text
                .GRNo = txtGRNNO.Text
                .SupplierID = Convert.ToInt64(cmbSupplier.SelectedValue)
                .DPFabricMstID = Val(LBLDalNo.Text)
                .DCNo = txtDCNo.Text
                .Save()
            End With


            Dim x As Integer
            For x = 0 To dgPORecv.Items.Count - 1
                Dim item As GridDataItem = DirectCast(dgPORecv.MasterTableView.Items(x), GridDataItem)
                With objDPPoRecevDtl
                    .POReceiveDtlID = item("POReceiveDtlID").Text
                    If lPOReceiveMstID > 0 Then
                        .POReceiveMstID = lPOReceiveMstID
                    Else
                        .POReceiveMstID = objDPPoRecevMst.GetID()
                    End If

                    .DPPODtlID = item("DPPODtlID").Text
                    .DPPOMstID = item("DPPOMstID").Text
                    .DPFabricMstID = item("FabricMstID").Text
                    .POReceivedQty = item("POReceivedQty").Text
                    .ReceiveQty = item("ReceivedQty").Text
                 .Save()
                End With
            Next

        Catch ex As Exception

        End Try
    End Sub

    Sub GRNNoGenerateOnLoad()
        Try
            Dim VoucherNo As String
            Dim Voucherdate As Date = Date.Now
            Dim month As String = Voucherdate.Month
            ' Dim year As String = Voucherdate.Year
            ' Dim yearv As String = year.Substring(2, 2)
            Dim LastVoucherNo As String = objDPPoRecevMst.GetLastNo()
            Dim LastCode As String
            If LastVoucherNo = "" Then
                LastCode = "0001"
            Else
                ' PreviousMonth = LastVoucherNo.Substring(7, 2)
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
            VoucherNo = "DFR" & "-" & LastCode
            txtGRNNO.Text = VoucherNo
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub dgPORecv_DeleteCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgPORecv.DeleteCommand
        dtPORecvDetail = CType(Session("dtPORecvDetail"), DataTable)
        If (Not dtPORecvDetail Is Nothing) Then
            If (dtPORecvDetail.Rows.Count > 0) Then
                Dim POReceiveDtlID As Integer = dtPORecvDetail.Rows(e.Item.ItemIndex)("POReceiveDtlID")
                dtPORecvDetail.Rows.RemoveAt(e.Item.ItemIndex)
                objDPPoRecevMst.Deletedetail(POReceiveDtlID)
                BindAccessGrid()
                '  txtDalNoO.Enabled = True
            Else
            End If

        End If
    End Sub
    Sub SetDetailEdit(ByVal dtrowNo As Long)
        Try

            lblDetailID.Text = dtPORecvDetail.Rows(dtrowNo)("POReceiveDtlID")
            BindPONO()
            CmbPONO.SelectedValue = dtPORecvDetail.Rows(dtrowNo)("DPPOMstID")
            ' CmbPONO.SelectedItem.Text = dtPORecvDetail.Rows(dtrowNo)("PONO")
            GetDalNo()
            BindItem()
            '  txtDalNo.Text = dtPORecvDetail.Rows(dtrowNo)("Dal")
            ' LBLDalNo.Text = dtPORecvDetail.Rows(dtrowNo)("FabricMstID")
            '  BindItem()
            CmbItem.SelectedValue = dtPORecvDetail.Rows(dtrowNo)("DPPODtlID")
            '  CmbItem.SelectedItem.Text = dtPORecvDetail.Rows(dtrowNo)("ItemName")
            txtStyle.Text = dtPORecvDetail.Rows(dtrowNo)("Style")
            txtReceivQty.Text = dtPORecvDetail.Rows(dtrowNo)("ReceivedQty")
            txtUnit.Text = dtPORecvDetail.Rows(dtrowNo)("Unit")
            Dim dtItem As DataTable
            dtItem = objDPPoRecevMst.GetItemStyleUnitPOQtyData(CmbPONO.SelectedValue, CmbItem.SelectedValue)
            If dtItem.Rows.Count > 0 Then
                ' txtStyle.Text = dtItem.Rows(0)("Style")
                ' txtUnit.Text = dtItem.Rows(0)("Unit")
                txtPoQty.Text = dtItem.Rows(0)("Quantity")
            End If
            Dim DTRecv As DataTable = objDPPoRecevMst.GetItemRecvePOQtyData(CmbPONO.SelectedValue, CmbItem.SelectedValue)
            If DTRecv.Rows.Count > 0 Then

                txtPOReceivedQty.Text = Val(DTRecv.Rows(0)("RecvQty")) - Val(txtReceivQty.Text)
            Else
                txtPOReceivedQty.Text = 0
            End If
            ' txtPoQty.Text = 0 'dtPORecvDetail.Rows(dtrowNo)("POQty")
            ' txtPOReceivedQty.Text = 0 'dtPORecvDetail.Rows(dtrowNo)("POReceivedQty")

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub dgPORecv_EditCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgPORecv.EditCommand
        dtPORecvDetail = CType(Session("dtPORecvDetail"), DataTable)
        If (Not dtPORecvDetail Is Nothing) Then
            If (dtPORecvDetail.Rows.Count > 0) Then
                Dim POReceiveDtlID As Integer = dtPORecvDetail.Rows(e.Item.ItemIndex)("POReceiveDtlID") 'dgPODETAIL.Items(e.Item.ItemIndex).Cells(0).Text '
                SetDetailEdit(e.Item.ItemIndex)

                dtPORecvDetail.Rows.RemoveAt(e.Item.ItemIndex)
                Session("dtPORecvDetail") = dtPORecvDetail
                ' objDPPOMst.Deletedetail(DPPODetailID)

                BindAccessGrid()

            Else
            End If

        End If
    End Sub

End Class
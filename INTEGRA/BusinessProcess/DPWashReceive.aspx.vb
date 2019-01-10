Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Xml
Public Class DPWashReceive
    Inherits System.Web.UI.Page
    Dim lDPWashRecvMstID, userid As Long
    Dim dtPODetail As DataTable
    Dim objDPWashRecvMst As New DPWashRecvMst
    Dim objType As New DPWashType
    Dim Dr As DataRow
    Dim dtWashRecvDetail As DataTable
    Dim objDPWashRecvDtl As New DPWashRecvDtl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lDPWashRecvMstID = Request.QueryString("DPWashRecvMstID")
        If Not Page.IsPostBack Then
            Session("dtWashRecvDetail") = Nothing
            If lDPWashRecvMstID > 0 Then
                Edit()
                btnSave.Text = "Update"
            Else
                btnSave.Text = "Save"
                VoucherNoGenerateOnLoad()
            End If
        End If
    End Sub
    Sub Edit()
        Dim dtedit As DataTable = objDPWashRecvMst.GetEdit(lDPWashRecvMstID)
        If dtedit.Rows.Count > 0 Then


            txtWashRecvNo.Text = dtedit.Rows(0)("WashRecvNo")
            txtWashRecvDatee.SelectedDate = dtedit.Rows(0)("RecvDate")
            txtWashNo.Text = dtedit.Rows(0)("WashNo")
            lblWashMstId.Text = dtedit.Rows(0)("WashMstID")
            dtWashRecvDetail = New DataTable
            With dtWashRecvDetail
                .Columns.Add("WashRecvDtlID", GetType(String))
                .Columns.Add("WashType", GetType(String))
                .Columns.Add("WashTypeID", GetType(String))
                .Columns.Add("DalNo", GetType(String))
                .Columns.Add("DalID", GetType(String))
                .Columns.Add("StyleID", GetType(String))
                .Columns.Add("Style", GetType(String))
                .Columns.Add("Qty", GetType(Decimal))
                .Columns.Add("ReceiveQuantity", GetType(Decimal))
                .Columns.Add("ReceivedQty", GetType(Decimal))
                .Columns.Add("RejectQty", GetType(Decimal))
            End With

            Dim x As Integer
            For x = 0 To dtedit.Rows.Count - 1
                Dr = dtWashRecvDetail.NewRow()

                Dr("WashRecvDtlID") = dtedit.Rows(x)("DPWashRecvDtlID")
                Dr("WashType") = dtedit.Rows(x)("WashType")
                Dr("WashTypeID") = dtedit.Rows(x)("WashTypeID")
                Dr("DalNo") = dtedit.Rows(x)("DalNo")
                Dr("DalID") = dtedit.Rows(x)("DalID")
                Dr("StyleID") = dtedit.Rows(x)("StyleID")
                Dr("Style") = dtedit.Rows(x)("Style")


                Dr("Qty") = dtedit.Rows(x)("Qty")
                Dr("ReceiveQuantity") = dtedit.Rows(x)("ReceiveQuantity")
                Dr("ReceivedQty") = dtedit.Rows(x)("ReceivedQty")
                Dr("RejectQty") = dtedit.Rows(x)("RejectQty")
                dtWashRecvDetail.Rows.Add(Dr)
                Session("dtWashRecvDetail") = dtWashRecvDetail
            Next
        End If
        BindGrid()
    End Sub
    Protected Sub dgWashRecv_DeleteCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgWashRecv.DeleteCommand
        dtWashRecvDetail = CType(Session("dtWashRecvDetail"), DataTable)
        If (Not dtWashRecvDetail Is Nothing) Then
            If (dtWashRecvDetail.Rows.Count > 0) Then
                Dim WashRecvDtlID As Integer = dtWashRecvDetail.Rows(e.Item.ItemIndex)("WashRecvDtlID")
                dtWashRecvDetail.Rows.RemoveAt(e.Item.ItemIndex)
                objDPWashRecvMst.Deletedetail(WashRecvDtlID)
                BindGrid()
                txtWashNo.Text = ""
                'Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)
            Else
            End If

        End If
    End Sub
    Sub VoucherNoGenerateOnLoad()
        Try
            Dim VoucherNo As String
            Dim Voucherdate As Date = Date.Now
            Dim month As String = Voucherdate.Month
            ' Dim year As String = Voucherdate.Year
            ' Dim yearv As String = year.Substring(2, 2)
            Dim LastVoucherNo As String = objDPWashRecvMst.GetLastNo()
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
            VoucherNo = "DWR" & "-" & LastCode
            txtWashRecvNo.Text = VoucherNo
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtWashNo_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtWashNo.TextChanged
        Try
            Dim dtData As DataTable = objDPWashRecvMst.DalNo(txtWashNo.Text)
            ' lblFabricMstId.Text = dtData.Rows(0)("FabricDBMstId")
            If dtData.Rows.Count > 0 Then
                cmbDalNo.DataSource = dtData
                cmbDalNo.DataTextField = "DalNo"
                cmbDalNo.DataValueField = "FabricDBMstId"
                cmbDalNo.DataBind()
                cmbDalNo.Items.Insert(0, New RadComboBoxItem("Select", 0))

            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbStyle_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbStyle.SelectedIndexChanged
        Try

            Dim dt As DataTable = objDPWashRecvMst.getdataStyleNo(txtWashNo.Text, cmbDalNo.SelectedItem.Text, cmbStyle.SelectedValue)
            lblWashMstId.Text = dt.Rows(0)("WashMstID")
            Dim dtRecvdQty As DataTable = objDPWashRecvMst.ReceivedQty(lblWashMstId.Text, cmbDalNo.SelectedValue, cmbStyle.SelectedValue)

           
            If dt.Rows.Count > 0 Then
                cmbWashType.DataSource = dt
                cmbWashType.DataTextField = "WashType"
                cmbWashType.DataValueField = "WashTypeID"
                cmbWashType.DataBind()
                ' cmbWashType.Items.Insert(0, New RadComboBoxItem("Select", 0))
                UpcmbWashType.Update()

            End If
            If dt.Rows.Count > 0 Then
                txtQty.Text = dt.Rows(0)("IssueQty")
                txtReceivedQty.Text = 0
                UptxtQty.Update()
                UptxtReceivedQty.Update()
            Else
                txtQty.Text = 0
                UptxtQty.Update()
                txtReceivedQty.Text = 0
                UptxtReceivedQty.Update()
            End If
            If dtRecvdQty.Rows.Count > 0 Then
                txtReceivedQty.Text = dtRecvdQty.Rows(0)("ReceiveQuantity")
                txtRejectQty.Text = dtRecvdQty.Rows(0)("RejectQty")
                UptxtReceivedQty.Update()
                UptxtRejectQty.Update()
            Else
                txtReceivedQty.Text = 0
                UptxtReceivedQty.Update()
                txtRejectQty.Text = 0
                UptxtRejectQty.Update()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbDalNo_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbDalNo.SelectedIndexChanged
        Try

            Dim dt As DataTable = objDPWashRecvMst.StyleNo(txtWashNo.Text, cmbDalNo.SelectedItem.Text)
            lblWashMstId.Text = dt.Rows(0)("WashMstID")
            ' Dim dtRecvdQty As DataTable = objDPWashRecvMst.ReceivedQty(lblWashMstId.Text, cmbDalNo.SelectedValue, cmbStyle.SelectedValue)

            If dt.Rows.Count > 0 Then
                cmbStyle.DataSource = dt
                cmbStyle.DataTextField = "Style"
                cmbStyle.DataValueField = "DPRNDID"
                cmbStyle.DataBind()
                cmbStyle.Items.Insert(0, New RadComboBoxItem("Select", 0))
                UpcmbStyle.Update()
            End If
            'If dt.Rows.Count > 0 Then
            '    cmbWashType.DataSource = dt
            '    cmbWashType.DataTextField = "WashType"
            '    cmbWashType.DataValueField = "WashTypeID"
            '    cmbWashType.DataBind()
            '    cmbWashType.Items.Insert(0, New RadComboBoxItem("Select", 0))
            '    UpcmbWashType.Update()

            'End If
            'If dt.Rows.Count > 0 Then
            '    txtQty.Text = dt.Rows(0)("IssueQty")
            '    txtReceivedQty.Text = 0
            '    UptxtQty.Update()
            '    UptxtReceivedQty.Update()
            'Else
            '    txtQty.Text = 0
            '    UptxtQty.Update()
            '    txtReceivedQty.Text = 0
            '    UptxtReceivedQty.Update()
            'End If
            'If dtRecvdQty.Rows.Count > 0 Then
            '    txtReceivedQty.Text = dtRecvdQty.Rows(0)("ReceiveQuantity")
            '    UptxtReceivedQty.Update()
            'Else
            '    txtReceivedQty.Text = 0
            '    UptxtReceivedQty.Update()
            'End If
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveSession()
        If (Not CType(Session("dtWashRecvDetail"), DataTable) Is Nothing) Then
            dtWashRecvDetail = Session("dtWashRecvDetail")
        Else
            dtWashRecvDetail = New DataTable
            With dtWashRecvDetail
                .Columns.Add("WashRecvDtlID", GetType(String))
                .Columns.Add("WashType", GetType(String))
                .Columns.Add("WashTypeID", GetType(String))
                .Columns.Add("DalNo", GetType(String))
                .Columns.Add("DalID", GetType(String))
                .Columns.Add("StyleID", GetType(String))
                .Columns.Add("Style", GetType(String))
                .Columns.Add("Qty", GetType(Decimal))
                .Columns.Add("ReceiveQuantity", GetType(Decimal))
                .Columns.Add("ReceivedQty", GetType(Decimal))
                .Columns.Add("RejectQty", GetType(Decimal))
            End With
        End If
        Dr = dtWashRecvDetail.NewRow()

        Dr("WashRecvDtlID") = 0
        Dr("WashType") = cmbWashType.SelectedItem.Text
        Dr("WashTypeID") = cmbWashType.SelectedValue
        Dr("DalNo") = cmbDalNo.SelectedItem.Text
        Dr("DalID") = cmbDalNo.SelectedValue
        Dr("StyleID") = cmbStyle.SelectedValue
        Dr("Style") = cmbStyle.SelectedItem.Text

       
        Dr("Qty") = txtQty.Text
        Dr("ReceiveQuantity") = txtReceiveQuantity.Text
        Dr("ReceivedQty") = txtReceivedQty.Text
        Dr("RejectQty") = txtRejectQty.Text

        dtWashRecvDetail.Rows.Add(Dr)
        Session("dtWashRecvDetail") = dtWashRecvDetail
    End Sub
    Private Sub BindGrid()
        Try
            Dim objDatatble As DataTable
            objDatatble = Session("dtWashRecvDetail")
            If objDatatble.Rows.Count > 0 Then
                dgWashRecv.Visible = True
                dgWashRecv.VirtualItemCount = objDatatble.Rows.Count
                dgWashRecv.DataSource = objDatatble
                dgWashRecv.DataBind()
            Else
                dgWashRecv.Visible = False
            End If

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnAddRecv_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddRecv.Click
        Try
            If Val(txtReceiveQuantity.Text) + Val(txtReceivedQty.Text) + Val(txtRejectQty.Text) > Val(txtQty.Text) Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Quantity Exceed")

            ElseIf txtRejectQty.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Reject Qty")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                SaveSession()
                BindGrid()
                clear()
            End If
          
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
        Catch ex As Exception

        End Try
    End Sub
    Sub clear()
        cmbStyle.SelectedValue = 0
        cmbDalNo.SelectedValue = 0
        txtQty.Text = ""
        txtReceiveQuantity.Text = ""
        txtReceivedQty.Text = ""
        txtRejectQty.Text = ""

    End Sub
    Protected Sub txtReceiveQuantity_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtReceiveQuantity.TextChanged
        Try
            If Val(txtReceiveQuantity.Text) + Val(txtReceivedQty.Text) + Val(txtRejectQty.Text) > Val(txtQty.Text) Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Quantity Exceed")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try


          
                If txtWashRecvDatee.ValidationDate = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Date")
                ElseIf dgWashRecv.Items.Count = 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Atleast Add One row in Grid")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                    SaveData()
                    Response.Redirect("DPWashRecvView.aspx")
                End If

        Catch ex As Exception

        End Try
    End Sub
    Sub SaveData()
        With objDPWashRecvMst
            If lDPWashRecvMstID > 0 Then
                .DPWashRecvMstID = lDPWashRecvMstID
            Else
                .DPWashRecvMstID = 0
            End If

            .CreationDate = Date.Now
            .WashRecvNo = txtWashRecvNo.Text
            .RecvDate = txtWashRecvDatee.SelectedDate
            .WashNo = txtWashNo.Text
            .WashMstID = lblWashMstId.Text
            .Save()
        End With
        Dim x As Integer
        For x = 0 To dgWashRecv.Items.Count - 1
            Dim item As GridDataItem = DirectCast(dgWashRecv.MasterTableView.Items(x), GridDataItem)

            With objDPWashRecvDtl
                .DPWashRecvDtlID = item("WashRecvDtlID").Text
                If lDPWashRecvMstID > 0 Then
                    .DPWashRecvMstID = lDPWashRecvMstID
                Else
                    .DPWashRecvMstID = objDPWashRecvMst.GetCurrentId
                End If
                .WashTypeID = item("WashTypeID").Text
                .DalID = item("DalID").Text
                .StyleID = item("StyleID").Text
                .WashType = item("WashType").Text
                .DalNo = item("DalNo").Text
                .Style = item("Style").Text
                .Qty = item("Qty").Text
                .ReceiveQuantity = item("ReceiveQuantity").Text
                .ReceivedQty = item("ReceivedQty").Text
                .RejectQty = item("RejectQty").Text
                .Save()
            End With
        Next
    End Sub



End Class
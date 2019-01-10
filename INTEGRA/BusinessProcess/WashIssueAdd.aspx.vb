Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Xml
Public Class WashIssueAdd
    Inherits System.Web.UI.Page
    Dim lWashMstID, userid As Long
    Dim dtPODetail As DataTable
    Dim objDPWashMst As New DPWashMst
    Dim objType As New DPWashType
    Dim Dr As DataRow
    Dim dtWashIssueDetail As DataTable
    Dim objDPWashDtl As New DPWashDtl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lWashMstID = Request.QueryString("WashMstID")
        userid = Session("UserId")
        If Not Page.IsPostBack Then
            Session("dtWashIssueDetail") = Nothing
            BindWashType()
            If lWashMstID > 0 Then
                Edit()
                btnSave.Text = "Update"
            Else
                btnSave.Text = "Save"
                VoucherNoGenerateOnLoad()
            End If


        End If
    End Sub
    Sub Edit()
        Dim dtedit As DataTable = objDPWashMst.GetEdit(lWashMstID)
        If dtedit.Rows.Count > 0 Then
            txtWashNo.Text = dtedit.Rows(0)("WashIssueNo")
            txtWashDatee.SelectedDate = dtedit.Rows(0)("IssueDate")
            dtWashIssueDetail = New DataTable
            With dtWashIssueDetail
                .Columns.Add("WashDtlID", GetType(String))
                .Columns.Add("WashType", GetType(String))
                .Columns.Add("WashTypeID", GetType(String))
                .Columns.Add("DalNo", GetType(String))
                .Columns.Add("FabricDBMstID", GetType(String))
                .Columns.Add("Style", GetType(String))
                .Columns.Add("TblRNDID", GetType(String))
                .Columns.Add("DPSampleReceiveID", GetType(String))
                .Columns.Add("SampleRecvQty", GetType(Decimal))
                .Columns.Add("IssuedQty", GetType(Decimal))
                .Columns.Add("IssueQty", GetType(Decimal))
                .Columns.Add("DSRNO", GetType(String))
            End With

            Dim x As Integer
            For x = 0 To dtedit.Rows.Count - 1
                Dr = dtWashIssueDetail.NewRow()
                Dr("WashDtlID") = dtedit.Rows(x)("WashDtlID")
                Dr("WashType") = dtedit.Rows(x)("WashType")
                Dr("WashTypeID") = dtedit.Rows(x)("WashTypeID")
                Dr("DalNo") = dtedit.Rows(x)("DalNo")
                Dr("FabricDBMstID") = dtedit.Rows(x)("FabricDBMstID")
                Dr("Style") = dtedit.Rows(x)("Style")
                Dr("TblRNDID") = dtedit.Rows(x)("DPRNDID")
                Dr("DPSampleReceiveID") = dtedit.Rows(x)("DPSampleReceiveID")
                Dr("SampleRecvQty") = dtedit.Rows(x)("SampleRecvQty")
                Dr("IssuedQty") = dtedit.Rows(x)("IssuedQty")
                Dr("IssueQty") = dtedit.Rows(x)("IssueQty")
                Dr("DSRNO") = dtedit.Rows(x)("DSRNO")


                dtWashIssueDetail.Rows.Add(Dr)
                Session("dtWashIssueDetail") = dtWashIssueDetail
            Next
        End If
        BindGrid()
    End Sub
    Sub BindWashType()
        Try
            Dim dtsupplier As DataTable
            dtsupplier = objDPWashMst.GetDPWashType
            cmbType.DataSource = dtsupplier
            cmbType.DataTextField = "WashType"
            cmbType.DataValueField = "WashTypeId"
            cmbType.DataBind()

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub txtDalNoO_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtDalNoO.TextChanged
        Try
            'Dim dtFBData As DataTable = objDPWashMst.StyleForSampleIssue(txtDalNoO.Text)
            'If dtFBData.Rows.Count > 0 Then
            '    cmbStyle.DataSource = dtFBData
            '    cmbStyle.DataTextField = "Style"
            '    cmbStyle.DataValueField = "DPRNDID"
            '    cmbStyle.DataBind()
            '    cmbStyle.Items.Insert(0, New RadComboBoxItem("Select", 0))

            'End If




            'Dim dt As DataTable = objDPWashMst.GetDalNo(txtDalNoO.Text)
            'If dt.Rows.Count > 0 Then
            '    lblFabricMstId.Text = dt.Rows(0)("FabricDBMstId")


            'End If

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtDSRNo_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtDSRNo.TextChanged
        Try


            Dim DTGetDSINO As DataTable = objDPWashMst.GetDSRNo(txtDSRNo.Text)
            txtDalNoO.Text = DTGetDSINO.Rows(0)("DalNo")
            LBLSampleReceiveID.Text = DTGetDSINO.Rows(0)("DPSampleReceiveID")



            Dim dtFBData As DataTable = objDPWashMst.StyleForSampleIssue(txtDalNoO.Text, LBLSampleReceiveID.Text)
            If dtFBData.Rows.Count > 0 Then
                cmbStyle.DataSource = dtFBData
                cmbStyle.DataTextField = "Style"
                cmbStyle.DataValueField = "DPRNDID"
                cmbStyle.DataBind()
                'cmbStyle.Items.Insert(0, New RadComboBoxItem("Select", 0))

            End If




            Dim dt As DataTable = objDPWashMst.GetDalNo(txtDalNoO.Text)
            If dt.Rows.Count > 0 Then
                lblFabricMstId.Text = dt.Rows(0)("FabricDBMstId")


            End If



            Dim dtt As DataTable
            dtt = objDPWashMst.GetQty(txtDSRNo.Text)
            If dtt.Rows.Count > 0 Then
                txtQty.Text = dtt.Rows(0)("ReceiveQty")
                UptxtQty.Update()
            End If

            Dim dtcheck As DataTable = objDPWashMst.GetIssuedQty(lblFabricMstId.Text, cmbStyle.SelectedValue, LBLSampleReceiveID.Text, txtDSRNo.Text)
            If dtcheck.Rows.Count > 0 Then
                txtIssuedQty.Text = dtcheck.Rows(0)("IssudeQty")
                UptxtIssuedQty.Update()
            Else
                txtIssuedQty.Text = 0
                UptxtIssuedQty.Update()
            End If


        Catch ex As Exception

        End Try
    End Sub
    Sub VoucherNoGenerateOnLoad()
        Try
             Dim VoucherNo As String
            Dim Voucherdate As Date = Date.Now
            Dim month As String = Voucherdate.Month
            ' Dim year As String = Voucherdate.Year
            ' Dim yearv As String = year.Substring(2, 2)
            Dim LastVoucherNo As String = objDPWashMst.GetLastNo()
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
            VoucherNo = "DWI" & "-" & LastCode
            txtWashNo.Text = VoucherNo
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnAddType_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles btnAddType.Click
        Try
            cmbType.Visible = False
            txtType.Visible = True
            btnAddType.Visible = False
            BtnSaveType.Visible = True
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbStyle_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbStyle.SelectedIndexChanged
        Try
            ' BindFabricRcv()
            'Dim dt As DataTable
            'dt = objDPWashMst.GetQty(cmbStyle.SelectedValue)
            'If dt.Rows.Count > 0 Then
            '    txtQty.Text = dt.Rows(0)("")
            'End If
        Catch ex As Exception

        End Try
    End Sub
    'Protected Sub cmbFRecvNo_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbFRecvNo.SelectedIndexChanged
    ' Try

    'Dim dt As DataTable
    'dt = objDPWashMst.GetQty(cmbFRecvNo.SelectedValue)
    'If dt.Rows.Count > 0 Then
    '    txtQty.Text = dt.Rows(0)("ReceiveQty")
    '    UptxtQty.Update()
    'End If
    'Dim dtcheck As DataTable = objDPWashMst.GetIssuedQty(lblFabricMstId.Text, cmbStyle.SelectedValue, cmbFRecvNo.SelectedValue)
    'If dtcheck.Rows.Count > 0 Then
    '    txtIssuedQty.Text = dtcheck.Rows(0)("IssudeQty")
    '    UptxtIssuedQty.Update()
    'Else
    '    txtIssuedQty.Text = 0
    '    UptxtIssuedQty.Update()
    'End If

    '  Catch ex As Exception

    '   End Try
    ' End Sub
    'Sub BindFabricRcv()
    '    Try
    '        Dim dtFabricRcv As DataTable
    '        dtFabricRcv = objDPWashMst.GetDPFabricRcv(lblFabricMstId.Text, cmbStyle.SelectedValue)
    '        cmbFRecvNo.DataSource = dtFabricRcv
    '        cmbFRecvNo.DataTextField = "DSRNO"
    '        cmbFRecvNo.DataValueField = "DPSampleReceiveID"
    '        cmbFRecvNo.DataBind()
    '        cmbFRecvNo.Items.Insert(0, New RadComboBoxItem("Select", 0))
    '        UpcmbFRecvNo.Update()

    '    Catch ex As Exception
    '    End Try
    'End Sub

    Protected Sub BtnSaveType_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSaveType.Click
        Try
            If txtType.Text = "" Then

            Else
                With objType
                    .WashTypeID = 0
                    .WashType = txtType.Text.ToUpper
                    .SaveDPType()
                End With

            End If
            BindWashType()
            txtType.Text = ""
            cmbType.Visible = True
            txtType.Visible = False
            btnAddType.Visible = True
            BtnSaveType.Visible = False
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnAddAccessories_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddAccessories.Click
        Try
            If Val(txtIssuedQty.Text) + Val(txtIssueQuantity.Text) > Val(txtQty.Text) Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Quantity Exceed")
            Else

                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                SaveSession()
                BindGrid()
                Clear()

            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub Clear()
        txtDSRNo.Text = ""
        cmbStyle.SelectedIndex = 0
        txtQty.Text = ""
        txtIssuedQty.Text = ""
        txtIssueQuantity.Text = ""
        txtDalNoO.Text = ""

    End Sub
    Sub SaveSession()
        If (Not CType(Session("dtWashIssueDetail"), DataTable) Is Nothing) Then
            dtWashIssueDetail = Session("dtWashIssueDetail")
        Else
            dtWashIssueDetail = New DataTable
            With dtWashIssueDetail
                .Columns.Add("WashDtlID", GetType(String))
                .Columns.Add("WashType", GetType(String))
                .Columns.Add("WashTypeID", GetType(String))
                .Columns.Add("DalNo", GetType(String))
                .Columns.Add("FabricDBMstID", GetType(String))
                .Columns.Add("Style", GetType(String))
                .Columns.Add("TblRNDID", GetType(String))
                .Columns.Add("DPSampleReceiveID", GetType(String))

                .Columns.Add("SampleRecvQty", GetType(Decimal))
                .Columns.Add("IssuedQty", GetType(Decimal))
                .Columns.Add("IssueQty", GetType(Decimal))
                .Columns.Add("DSRNO", GetType(String))


            End With
        End If
        Dr = dtWashIssueDetail.NewRow()

        Dr("WashDtlID") = 0
        Dr("WashType") = cmbType.SelectedItem.Text
        Dr("WashTypeID") = cmbType.SelectedValue
        Dr("DalNo") = txtDalNoO.Text
        Dr("FabricDBMstID") = lblFabricMstId.Text
        Dr("Style") = cmbStyle.SelectedItem.Text
        Dr("TblRNDID") = cmbStyle.SelectedValue
        Dr("DPSampleReceiveID") = LBLSampleReceiveID.Text

        Dr("SampleRecvQty") = txtQty.Text
        Dr("IssuedQty") = txtIssuedQty.Text
        Dr("IssueQty") = txtIssueQuantity.Text


        Dr("DSRNO") = txtDSRNo.Text


        dtWashIssueDetail.Rows.Add(Dr)
        Session("dtWashIssueDetail") = dtWashIssueDetail
    End Sub
    Private Sub BindGrid()
        Try
            Dim objDatatble As DataTable
            objDatatble = Session("dtWashIssueDetail")
            If objDatatble.Rows.Count > 0 Then
                dgWashIssue.Visible = True
                dgWashIssue.VirtualItemCount = objDatatble.Rows.Count
                dgWashIssue.DataSource = objDatatble
                dgWashIssue.DataBind()
            Else
                dgWashIssue.Visible = False
            End If

        Catch ex As Exception
        End Try
    End Sub


    Protected Sub dgWashIssue_DeleteCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgWashIssue.DeleteCommand
        dtWashIssueDetail = CType(Session("dtWorkerDetail"), DataTable)
        If (Not dtWashIssueDetail Is Nothing) Then
            If (dtWashIssueDetail.Rows.Count > 0) Then
                Dim WashDtlID As Integer = dtWashIssueDetail.Rows(e.Item.ItemIndex)("WashDtlID")
                dtWashIssueDetail.Rows.RemoveAt(e.Item.ItemIndex)
                objDPWashMst.Deletedetail(WashDtlID)
                BindGrid()
            Else
            End If

        End If
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            If txtWashDatee.ValidationDate = "" Then
            ElseIf dgWashIssue.Items.Count = 0 Then
            Else
                SaveData()
                Response.Redirect("WashIssueView.aspx")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub SaveData()
        With objDPWashMst
            If lWashMstID > 0 Then
                .WashMstID = lWashMstID
            Else
                .WashMstID = 0
            End If

            .CreationDate = Date.Now
            .WashIssueNo = txtWashNo.Text
            .IssueDate = txtWashDatee.SelectedDate
            .Save()
        End With
        Dim x As Integer
        For x = 0 To dgWashIssue.Items.Count - 1
            Dim item As GridDataItem = DirectCast(dgWashIssue.MasterTableView.Items(x), GridDataItem)

            With objDPWashDtl
                .WashDtlID = item("WashDtlID").Text
                If lWashMstID > 0 Then
                    .WashMstID = lWashMstID
                Else
                    .WashMstID = objDPWashMst.GetCurrentId
                End If
                .WashTypeID = item("WashTypeID").Text
                .FabricDBMstID = item("FabricDBMstID").Text
                .TblRNDID = item("TblRNDID").Text
                .DPSampleReceiveID = item("DPSampleReceiveID").Text
                .IssuedQty = item("IssuedQty").Text
                .IssueQty = item("IssueQty").Text
                .SampleRecvQty = item("SampleRecvQty").Text
                .DSRNO = item("DSRNO").Text
                .Save()
            End With
        Next
    End Sub



    Protected Sub txtIssueQuantity_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtIssueQuantity.TextChanged
        Try
            If Val(txtIssueQuantity.Text) + Val(txtIssuedQty.Text) > Val(txtQty.Text) Then

                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Quantity Exceed")
            Else

                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
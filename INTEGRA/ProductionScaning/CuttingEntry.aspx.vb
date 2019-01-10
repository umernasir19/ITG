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
Public Class CuttingEntry
    Inherits System.Web.UI.Page
    Dim ObjPO As New PurchaseOrder
    Dim ObjCargo As New Cargo
    Dim ObjCargoDetail As New CargoDetail
    Dim GeneralCode As New GeneralCode
    Dim dtPacking As New DataTable
    Dim dtPurchaseOrder, DtPanalChecking As DataTable
    Dim lPOID, lPackingMstid, lCommercialPackingListMstID As Long
    Dim Dr As DataRow
    Dim ICargoID, userid, lTodayCuttingMstID As Long
    Dim Type As String
    Dim objSizeRange As New SizeRange
    Dim objJobOrderdatabase As New JobOrderdatabase
    Dim ObjTblRND As New TblDPRND
    Dim objDPSampleReceive As New DPSampleReceive
    Dim objPackingMst As New PackingMst
    Dim objPackingDtl As New PackingDtl
    Dim dtPackingListDetail As DataTable
    Dim ObjCommercialPackingListMst As New CommercialPackingListMst
    Dim ObjCommercialPackingListDtl As New CommercialPackingListDtl
    Dim objTodayCutting As New TodayCutting
    Dim objTodayCuttingDtl As New TodayCuttingDtl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lTodayCuttingMstID = Request.QueryString("TodayCuttingMstID")
        userid = Session("UserId")
        If Not Page.IsPostBack Then
            Session("DtPanalChecking") = Nothing
            BindSeason()
            'BindSrNo()
            'BindColor()
            'GetStyle()
            'GetQuantity()
            'GetAlreadyIssueQty()
            If lTodayCuttingMstID > 0 Then
                Edit()
                btnSave.Text = "Update"
                txtTodayQty.Text = 0
                TXTTodayIssue.Text = 0
            Else
                btnSave.Text = "Save"
                txtTodayQty.Text = 0
                TXTTodayIssue.Text = 0
            End If
        End If
    End Sub
    Protected Sub txtTodayQty_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtTodayQty.TextChanged
        If Val(txtTodayQty.Text) + Val(txtAlreadyCut.Text) > Val(txtTotalQuantity.Text) Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Quantity Exceed")
        Else
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
        End If
    End Sub
    Sub Edit()
        Try
            ' Dim dt As DataTable = ObjCommercialPackingListDtl.GetforEditForCutting(lTodayCuttingMstID)
            ' cmbSeason.SelectedValue = dt.Rows(0)("SeasonDatabaseID")
            Dim dt As DataTable = ObjCommercialPackingListDtl.GetforEditForCuttingNew(lTodayCuttingMstID)
            lblUserId.Text = dt.Rows(0)("UserIdd")
            'Dim dtInvoiceNo As DataTable
            'dtInvoiceNo = objSizeRange.GetSrnOForCutting(cmbSeason.SelectedValue)
            'cmbSrNo.DataSource = dtInvoiceNo
            'cmbSrNo.DataTextField = "SrNO"
            'cmbSrNo.DataValueField = "JobOrderID"
            'cmbSrNo.DataBind()
            'cmbSrNo.Items.Insert(0, New RadComboBoxItem("Select", String.Empty))

            If (Not CType(Session("DtPanalChecking"), DataTable) Is Nothing) Then
                DtPanalChecking = Session("DtPanalChecking")
            Else
                DtPanalChecking = New DataTable
                With DtPanalChecking
                    .Columns.Add("TodayCuttingDtlID", GetType(Long))
                    .Columns.Add("SeasonDatabaseID", GetType(Long))
                    .Columns.Add("JobOrderID", GetType(Long))
                    .Columns.Add("CuttingDate", GetType(String))
                    .Columns.Add("Season", GetType(String))
                    .Columns.Add("SRNO", GetType(String))
                    .Columns.Add("JobOrderDetailID", GetType(Long))
                    .Columns.Add("Color", GetType(String))
                    .Columns.Add("Style", GetType(String))
                    .Columns.Add("TodayCut", GetType(String))
                    .Columns.Add("TodayIssue", GetType(String))
                End With
            End If
            Dim x As Integer
            For x = 0 To dt.Rows.Count - 1
                Dr = DtPanalChecking.NewRow()
                Dr("TodayCuttingDtlID") = dt.Rows(x)("TodayCuttingDtlID")
                Dr("SeasonDatabaseID") = dt.Rows(x)("SeasonDatabaseID")
                Dr("Season") = dt.Rows(x)("SeasonName")
                Dr("JobOrderID") = dt.Rows(x)("JobOrderID")
                Dr("SRNO") = dt.Rows(x)("SRNO")
                Dr("CuttingDate") = dt.Rows(x)("CuttingDatee")
                Dr("JobOrderDetailID") = dt.Rows(x)("JobOrderDetailID")
                Dr("Color") = dt.Rows(x)("BuyerColor")
                Dr("Style") = dt.Rows(x)("Style")
                Dr("TodayCut") = dt.Rows(x)("TodayCut")
                Dr("TodayIssue") = dt.Rows(x)("TodayIssue")
                DtPanalChecking.Rows.Add(Dr)
                Session("DtPanalChecking") = DtPanalChecking
            Next
            BindGrid()
        Catch ex As Exception

        End Try
    End Sub
   Sub BindSeason()
        Try
            Dim dtcmbSeason As DataTable
            dtcmbSeason = ObjCommercialPackingListDtl.GetSeasonsFromJobOrderDatabase
            cmbSeason.DataSource = dtcmbSeason
            cmbSeason.DataTextField = "SeasonName"
            cmbSeason.DataValueField = "SeasonDatabaseID"
            cmbSeason.DataBind()
            cmbSeason.Items.Insert(0, New RadComboBoxItem("Select", String.Empty))
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbSeason_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbSeason.SelectedIndexChanged
        Try
            BindSrNo()
            ' BindColor()
            ' GetStyle()
            ' GetQuantity()
            ' GetAlreadyIssueQty()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbSrNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbSrNo.SelectedIndexChanged
        Try
            BindColor()
            ' GetStyle()
            ' GetQuantity()
            ' GetAlreadyIssueQty()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbColor_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbColor.SelectedIndexChanged
        Try
            GetStyle()
            GetQuantity()
            GetAlreadyIssueQty()
        Catch ex As Exception

        End Try
    End Sub
    Sub BindSrNo()
        Try
            Dim dtInvoiceNo As DataTable
            dtInvoiceNo = objSizeRange.GetSrnOForCutting(cmbSeason.SelectedValue)
            cmbSrNo.DataSource = dtInvoiceNo
            cmbSrNo.DataTextField = "SrNO"
            cmbSrNo.DataValueField = "JobOrderID"
            cmbSrNo.DataBind()
            cmbSrNo.Items.Insert(0, New RadComboBoxItem("Select", String.Empty))
        Catch ex As Exception

        End Try
    End Sub
    Sub BindColor()
        Try
            Dim dtInvoiceNo As DataTable
            dtInvoiceNo = objSizeRange.GetColorForCutting(cmbSeason.SelectedValue, cmbSrNo.SelectedValue)
            cmbColor.DataSource = dtInvoiceNo
            cmbColor.DataTextField = "BuyerColor"
            cmbColor.DataValueField = "JobOrderDetailID"
            cmbColor.DataBind()
            cmbColor.Items.Insert(0, New RadComboBoxItem("Select", String.Empty))
        Catch ex As Exception

        End Try
    End Sub
   Sub GetStyle()
        Dim dtInvoiceNo As DataTable
        dtInvoiceNo = objSizeRange.GetStyleForCutting(cmbSeason.SelectedValue, cmbSrNo.SelectedValue, cmbColor.SelectedValue)
        txtStyle.Text = dtInvoiceNo.Rows(0)("Style")
    End Sub
    Sub GetQuantity()
        Dim dtInvoiceNo As DataTable
        dtInvoiceNo = objSizeRange.GetTotalQuantityForCutting(cmbSeason.SelectedValue, cmbSrNo.SelectedValue, cmbColor.SelectedValue)
        txtTotalQuantity.Text = dtInvoiceNo.Rows(0)("Quantity")
    End Sub
    Sub GetAlreadyIssueQty()
        Dim dtInvoiceNo As DataTable
        dtInvoiceNo = objSizeRange.GetAlreadyCutForCutting(cmbSeason.SelectedValue, cmbSrNo.SelectedValue, cmbColor.SelectedValue)
        txtAlreadyCut.Text = dtInvoiceNo.Rows(0)("TodayQty")
    End Sub
    Sub Save()
        With objTodayCutting
            If lTodayCuttingMstID > 0 Then
                .TodayCuttingMstID = lTodayCuttingMstID
            Else
                .TodayCuttingMstID = 0
            End If
            If Session("RoleId") = 46 And Session("Type") = "Production" Then
                If lTodayCuttingMstID > 0 Then
                    .UserID = lblUserId.Text
                Else
                    .UserID = 270
                End If
            Else
                If lTodayCuttingMstID > 0 Then
                    .UserID = lblUserId.Text
                Else
                    .UserID = userid
                End If
            End If
            .CreationDate = Date.Now
            .Save()
        End With
        Dim x As Integer
        For x = 0 To dgPanalEntry.Items.Count - 1
            With objTodayCuttingDtl
                .TodayCuttingDtlID = dgPanalEntry.Items(x).Cells(0).Text()
                If lTodayCuttingMstID > 0 Then
                    .TodayCuttingMstID = lTodayCuttingMstID
                Else
                    .TodayCuttingMstID = objTodayCutting.GetID
                End If
                .JobOrderId = dgPanalEntry.Items(x).Cells(1).Text()
                .JobOrderDetailId = dgPanalEntry.Items(x).Cells(2).Text()
                .SeasonDatabaseID = dgPanalEntry.Items(x).Cells(3).Text()
                .CuttingDate = dgPanalEntry.Items(x).Cells(4).Text()
                .Style = dgPanalEntry.Items(x).Cells(8).Text()
                .TodayCut = dgPanalEntry.Items(x).Cells(9).Text()
                .TodayIssue = dgPanalEntry.Items(x).Cells(10).Text()
                .Save()
            End With
        Next
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            Save()
            Response.Redirect("CuttingView.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("CuttingView.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Sub Clear()
        cmbSeason.SelectedValue = 0
        cmbSrNo.SelectedValue = 0
        cmbColor.SelectedValue = 0
        txtStyle.Text = ""
        txtTodayQty.Text = 0
        TXTTodayIssue.Text = 0
        txtAlreadyCut.Text = ""
        txtTotalQuantity.Text = ""
    End Sub
    Sub SaveSession()
        If (Not CType(Session("DtPanalChecking"), DataTable) Is Nothing) Then
            DtPanalChecking = Session("DtPanalChecking")
        Else
            DtPanalChecking = New DataTable
            With DtPanalChecking
                .Columns.Add("TodayCuttingDtlID", GetType(Long))
                .Columns.Add("SeasonDatabaseID", GetType(Long))
                .Columns.Add("JobOrderID", GetType(Long))
                .Columns.Add("CuttingDate", GetType(String))
                .Columns.Add("Season", GetType(String))
                .Columns.Add("SRNO", GetType(String))
                .Columns.Add("JobOrderDetailID", GetType(Long))
                .Columns.Add("Color", GetType(String))
                .Columns.Add("Style", GetType(String))
                .Columns.Add("TodayCut", GetType(String))
                .Columns.Add("TodayIssue", GetType(String))
               End With
        End If
        Dr = DtPanalChecking.NewRow()
        Dr("TodayCuttingDtlID") = Convert.ToInt32(lblDtlIDwhenEdit.Text)
        Dr("SeasonDatabaseID") = cmbSeason.SelectedValue
        Dr("Season") = cmbSeason.SelectedItem.Text
        Dr("JobOrderID") = cmbSrNo.SelectedValue
        Dr("CuttingDate") = txtDate.Text
        Dr("SRNO") = cmbSrNo.SelectedItem.Text
        Dr("JobOrderDetailID") = cmbColor.SelectedValue
        Dr("Color") = cmbColor.SelectedItem.Text
        If txtStyle.Text = "" Then
            Dr("Style") = ""
        Else
            Dr("Style") = txtStyle.Text
        End If
        Dr("TodayCut") = txtTodayQty.Text
        Dr("TodayIssue") = TXTTodayIssue.Text
        DtPanalChecking.Rows.Add(Dr)
        Session("DtPanalChecking") = DtPanalChecking
        BindGrid()
        Clear()
    End Sub
    Sub BindGrid()
        Try
            If DtPanalChecking.Rows.Count > 0 Then
                dgPanalEntry.DataSource = DtPanalChecking
                dgPanalEntry.DataBind()
                dgPanalEntry.Visible = True
            Else
                dgPanalEntry.Visible = False
            End If
        Catch ex As Exception

        End Try

    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If txtDate.Text = "" Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Date")
        ElseIf cmbSeason.SelectedIndex = 0 Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Season")
        ElseIf txtTodayQty.Text = "" Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Today Qty Empty")
        ElseIf TXTTodayIssue.Text = "" Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Today Issue Empty")
        Else
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
            SaveSession()
            btnSave.Visible = True
        End If

    End Sub
    Protected Sub dgPanalEntry_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgPanalEntry.ItemCommand
        Try
            Select Case e.CommandName
                Case "Edit"
                    DtPanalChecking = CType(Session("DtPanalChecking"), DataTable)
                    If (Not DtPanalChecking Is Nothing) Then
                        If (DtPanalChecking.Rows.Count > 0) Then
                            Dim PanalDtlID As Integer = DtPanalChecking.Rows(e.Item.ItemIndex)("TodayCuttingDtlID")
                            lblDtlIDwhenEdit.Text = PanalDtlID
                            SetDetailValuesByDataTable(PanalDtlID)
                            DtPanalChecking.Rows.RemoveAt(e.Item.ItemIndex)
                            Session("DtPanalChecking") = DtPanalChecking
                            BindGrid()
                            'dgPanalEntry.Visible = False
                            btnAdd.Visible = True
                        Else
                        End If
                    End If
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Sub SetDetailValuesByDataTable(ByVal dtrowNo As Long)
        Try
            Dim dt As DataTable
            dt = objTodayCuttingDtl.GetCuttingDetailByID(dtrowNo)
            If dt.Rows.Count > 0 Then
                BindSeason()
                cmbSeason.SelectedValue = dt.Rows(0)("SeasonDatabaseID")
                BindSrNo()
                cmbSrNo.SelectedValue = dt.Rows(0)("JobOrderID")
                BindColor()
                cmbColor.SelectedValue = dt.Rows(0)("JobOrderDetailId")
                txtDate.Text = dt.Rows(0)("CuttingDate")
                GetStyle()
                GetQuantity()
                GetAlreadyIssueQty()
                txtTodayQty.Text = dt.Rows(0)("TodayCut")
                TXTTodayIssue.Text = dt.Rows(0)("TodayIssue")
            End If

        Catch ex As Exception
        End Try
    End Sub
End Class
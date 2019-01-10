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
Public Class CommercialPackingList
    Inherits System.Web.UI.Page
    Dim ObjCustomer As New Customer
    ' Dim ObjVendor As New Vendor
    Dim ObjPO As New PurchaseOrder
    Dim ObjCargo As New Cargo
    Dim ObjCargoDetail As New CargoDetail
    Dim GeneralCode As New GeneralCode
    Dim dtPacking As New DataTable
    Dim dtPurchaseOrder As New DataTable
    Dim lPOID, lPackingMstid, lCommercialPackingListMstID As Long
    Dim Dr As DataRow
    Dim ICargoID, userid As Long
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        lCommercialPackingListMstID = Request.QueryString("CommercialPackingListMstID")
        userid = Session("UserId")
        If Not Page.IsPostBack Then
            Session("dtPackingListDetail") = Nothing
            BindInvoiceNo()
            If lCommercialPackingListMstID > 0 Then
                Edit()
                btnSave.Visible = True
                btnSave.Text = "Update"
            Else
                btnSave.Text = "Save"
            End If



        End If
    End Sub
    Sub Edit()
        Try
            Dim dt As DataTable = ObjCommercialPackingListDtl.GetforEdit(lCommercialPackingListMstID)
            cmbInvoiceNo.SelectedValue = dt.Rows(0)("CargoID")
            Dim dtSRNO As DataTable = objSizeRange.GetSrnOForCommericalPacking(cmbInvoiceNo.SelectedValue)
            cmbSrNo.DataSource = dtSRNO
            cmbSrNo.DataTextField = "SrNO"
            cmbSrNo.DataValueField = "JobOrderID"
            cmbSrNo.DataBind()
            cmbSrNo.SelectedValue = dt.Rows(0)("JobOrderId")
            Dim DtColor As DataTable = objSizeRange.GetColorForCommericalPacking(cmbInvoiceNo.SelectedValue, cmbSrNo.SelectedValue)
            cmbColor.DataSource = DtColor
            cmbColor.DataTextField = "BuyerColor"
            cmbColor.DataValueField = "JobOrderDetailID"
            cmbColor.DataBind()
            Dim dtSize As DataTable
            dtSize = objSizeRange.GetSizeForCommericalPacking(cmbInvoiceNo.SelectedValue, cmbSrNo.SelectedValue, cmbColor.SelectedValue)
            cmbSize.DataSource = dtSize
            cmbSize.DataTextField = "Size"
            cmbSize.DataValueField = "StyleAssortmentDetailID"
            cmbSize.DataBind()
            txtStyle.Text = dtSize.Rows(0)("Style")
            dtPackingListDetail = Nothing
            Session("dtPackingListDetail") = Nothing
            dtPackingListDetail = New DataTable
            With dtPackingListDetail
                .Columns.Add("CommercialPackingListDtlid", GetType(Long))
                .Columns.Add("CartonFrom", GetType(String))
                .Columns.Add("CartonTo", GetType(String))
                .Columns.Add("CTNS", GetType(String))
                .Columns.Add("JobOrderDetailID", GetType(Long))
                .Columns.Add("BuyerColor", GetType(String))
                .Columns.Add("Style", GetType(String))
                .Columns.Add("StyleAssortmentDetailID", GetType(Long))
                .Columns.Add("Size", GetType(String))
                .Columns.Add("Quantity", GetType(String))
                .Columns.Add("PCSCTN", GetType(String))
            End With
            Dim x As Integer
            For x = 0 To dt.Rows.Count - 1
                Dr = dtPackingListDetail.NewRow()
                Dr("CommercialPackingListDtlid") = dt.Rows(x)("CommercialPackingListDtlid")
                Dr("CartonFrom") = dt.Rows(x)("CartonFrom")
                Dr("CartonTo") = dt.Rows(x)("CartonTo")
                Dr("CTNS") = dt.Rows(x)("CTNS")
                Dr("JobOrderDetailID") = dt.Rows(x)("JobOrderDetailID")
                Dr("BuyerColor") = dt.Rows(x)("BuyerColor")
                Dr("Style") = dt.Rows(x)("Style")
                Dr("StyleAssortmentDetailID") = dt.Rows(x)("StyleAssortmentDetailID")
                Dr("Size") = dt.Rows(x)("Size")
                Dr("Quantity") = dt.Rows(x)("Quantity")
                Dr("PCSCTN") = dt.Rows(x)("PCSCTN")
                dtPackingListDetail.Rows.Add(Dr)
            Next
            Session("dtPackingListDetail") = dtPackingListDetail
            BindGrid()
        Catch ex As Exception

        End Try
    End Sub

    Sub SaveSession()
        If (Not CType(Session("dtPackingListDetail"), DataTable) Is Nothing) Then
            dtPackingListDetail = Session("dtPackingListDetail")
        Else
            dtPackingListDetail = New DataTable
            With dtPackingListDetail
                .Columns.Add("CommercialPackingListDtlid", GetType(Long))
                .Columns.Add("CartonFrom", GetType(String))
                .Columns.Add("CartonTo", GetType(String))
                .Columns.Add("CTNS", GetType(String))
                .Columns.Add("JobOrderDetailID", GetType(Long))
                .Columns.Add("BuyerColor", GetType(String))
                .Columns.Add("Style", GetType(String))
                .Columns.Add("StyleAssortmentDetailID", GetType(Long))
                .Columns.Add("Size", GetType(String))
                .Columns.Add("Quantity", GetType(String))
                .Columns.Add("PCSCTN", GetType(String))
            End With
        End If

        dr = dtPackingListDetail.NewRow()
        Dr("CommercialPackingListDtlid") = 0
        Dr("CartonFrom") = txtCartonFrom.Text
        Dr("CartonTo") = txtCartonTo.Text
        Dr("CTNS") = TXTCTNS.Text
        Dr("JobOrderDetailID") = cmbColor.SelectedValue
        Dr("BuyerColor") = cmbColor.SelectedItem.Text
        Dr("Style") = txtStyle.Text
        Dr("StyleAssortmentDetailID") = cmbSize.SelectedValue
        Dr("Size") = cmbSize.SelectedItem.Text
        Dr("Quantity") = txtQuantity.Text
        Dr("PCSCTN") = TXTPcsCtn.Text
        dtPackingListDetail.Rows.Add(Dr)
        Session("dtPackingListDetail") = dtPackingListDetail
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
        Try
            SaveSession()
            BindGrid()
            Clear()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BindGrid()
        Try
            Dim objDatatable As New DataTable
            objDatatable = Session("dtPackingListDetail")
            If objDatatable.Rows.Count > 0 Then
                dgPackingListDetail.Visible = True
                dgPackingListDetail.VirtualItemCount = objDatatable.Rows.Count
                dgPackingListDetail.DataSource = objDatatable
                dgPackingListDetail.DataBind()
            Else
                dgPackingListDetail.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub Clear()
        TXTCTNS.Text = ""
        txtQuantity.Text = ""
        txtCartonFrom.Text = ""
        txtCartonTo.Text = ""
    End Sub
    Protected Sub txtCartonTo_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtCartonFrom.TextChanged
        If txtCartonFrom.Text = "" Or txtCartonFrom.Text = "0" Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Carton From Empty")
        Else
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
            TXTCTNS.Text = Val(txtCartonTo.Text) - Val(txtCartonFrom.Text) + 1
           End If
    End Sub
    Sub BindInvoiceNo()
        Try
            Dim dtInvoiceNo As DataTable
            dtInvoiceNo = objSizeRange.GetInvoiceNo()
            cmbInvoiceNo.DataSource = dtInvoiceNo
            cmbInvoiceNo.DataTextField = "InvoiceNo"
            cmbInvoiceNo.DataValueField = "CargoID"
            cmbInvoiceNo.DataBind()
            cmbInvoiceNo.Items.Insert(0, New RadComboBoxItem("Select", String.Empty))
        Catch ex As Exception

        End Try
    End Sub
    Sub BindSrNo()
        Try
            Dim dtInvoiceNo As DataTable
            dtInvoiceNo = objSizeRange.GetSrnOForCommericalPacking(cmbInvoiceNo.SelectedValue)
            cmbSrNo.DataSource = dtInvoiceNo
            cmbSrNo.DataTextField = "SrNO"
            cmbSrNo.DataValueField = "JobOrderID"
            cmbSrNo.DataBind()

        Catch ex As Exception

        End Try
    End Sub
    Sub BindColor()
        Try
            Dim dtInvoiceNo As DataTable
            dtInvoiceNo = objSizeRange.GetColorForCommericalPacking(cmbInvoiceNo.SelectedValue, cmbSrNo.SelectedValue)
            cmbColor.DataSource = dtInvoiceNo
            cmbColor.DataTextField = "BuyerColor"
            cmbColor.DataValueField = "JobOrderDetailID"
            cmbColor.DataBind()

        Catch ex As Exception

        End Try
    End Sub
    Sub BindSize()
        Try
            Dim dtInvoiceNo As DataTable
            dtInvoiceNo = objSizeRange.GetSizeForCommericalPacking(cmbInvoiceNo.SelectedValue, cmbSrNo.SelectedValue, cmbColor.SelectedValue)
            cmbSize.DataSource = dtInvoiceNo
            cmbSize.DataTextField = "Size"
            cmbSize.DataValueField = "StyleAssortmentDetailID"
            cmbSize.DataBind()

        Catch ex As Exception

        End Try
    End Sub
    Sub GetStyle()
        Dim dtInvoiceNo As DataTable
        dtInvoiceNo = objSizeRange.GetStyleForCommericalPacking(cmbInvoiceNo.SelectedValue, cmbSrNo.SelectedValue, cmbColor.SelectedValue)
        txtStyle.Text = dtInvoiceNo.Rows(0)("Style")
    End Sub
    Protected Sub cmbInvoiceNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbInvoiceNo.SelectedIndexChanged
        Try
            BindSrNo()
            BindColor()
            BindSize()
            GetStyle()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbSrNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbSrNo.SelectedIndexChanged
        Try
            BindColor()
            BindSize()
            GetStyle()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbColor_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbColor.SelectedIndexChanged
        Try
            BindSize()
            GetStyle()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            SavePackingListMaster()
            SavePackingListDetail()
            Response.Redirect("CommercialPackingListView.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("CommercialPackingListView.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Sub SavePackingListMaster()
        With ObjCommercialPackingListMst
            If lCommercialPackingListMstID > 0 Then
                .CommercialPackingListMstID = lCommercialPackingListMstID
            Else
                .CommercialPackingListMstID = 0
            End If
            .UserId = userid
            .CargoId = cmbInvoiceNo.SelectedValue
            .JobOrderId = cmbSrNo.SelectedValue
            .CreationDate = Date.Now
            .Save()
        End With
    End Sub
    Sub SavePackingListDetail()
        Dim x As Integer
        For x = 0 To dgPackingListDetail.Items.Count - 1
            Dim item As GridDataItem = DirectCast(dgPackingListDetail.MasterTableView.Items(x), GridDataItem)
            With ObjCommercialPackingListDtl

                .CommercialPackingListDtlID = item("CommercialPackingListDtlID").Text
                If lCommercialPackingListMstID > 0 Then
                    .CommercialPackingListMstid = lCommercialPackingListMstID
                Else
                    .CommercialPackingListMstid = ObjCommercialPackingListMst.GetId()
                End If
                .CartonFrom = item("CartonFrom").Text
                .CartonTo = item("CartonTo").Text
                .CTNS = item("CTNS").Text
                .JobOrderDetailID = item("JobOrderDetailID").Text
                .BuyerColor = item("BuyerColor").Text
                .Style = item("Style").Text
                .StyleAssortmentDetailID = item("StyleAssortmentDetailID").Text
                .Size = item("Size").Text
                .Quantity = item("Quantity").Text
                .PCSCTN = item("PCSCTN").Text
                .Save()
            End With
        Next
    End Sub
End Class
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
Public Class BuyerComment
    Inherits System.Web.UI.Page
    Dim dtCourier As DataTable
    Dim Dr As DataRow
    Dim ObjDPCourierMst As New DPCourierMst
    Dim ObjDPBuyerComment As New DPBuyerComment
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            txtBuyerCommentDate.SelectedDate = Date.Now
        End If
    End Sub
    Sub BindCustomer()
        Dim dtsupplier As DataTable
        dtsupplier = ObjDPCourierMst.GetCustomer
        cmbBuyerName.DataSource = dtsupplier
        cmbBuyerName.DataTextField = "CustomerName"
        cmbBuyerName.DataValueField = "CustomerID"
        cmbBuyerName.DataBind()
    End Sub
   
    'Sub BindCurrency()
    '    Dim dt As DataTable
    '    dt = ObjDPCourierMst.GetCurrency
    '    cmbCurrency.DataSource = dt
    '    cmbCurrency.DataTextField = "CurrencyName"
    '    cmbCurrency.DataValueField = "CurrencyID"
    '    cmbCurrency.DataBind()
    'End Sub
    Protected Sub txtDcdNo_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtDcdNo.TextChanged
        Try
            Dim dt As DataTable
            dt = ObjDPCourierMst.GetCourierData(txtDcdNo.Text)
            lblCourierMstID.Text = dt.Rows(0)("DPCourierMstId")
            If dt.Rows.Count > 0 Then
                txtDatee.SelectedDate = dt.Rows(0)("CourDate")
                txtExRegNo.Text = dt.Rows(0)("ExpRegNo")
                txtNtnNo.Text = dt.Rows(0)("NtnNo")
                txtInvNo.Text = dt.Rows(0)("InvNo")
                txtAccountNo.Text = dt.Rows(0)("AccountNo")
                txtInvOf.Text = dt.Rows(0)("InvOf")
                txtShippedPer.Text = dt.Rows(0)("ShippedPer")
                txtFrmKhi.Text = dt.Rows(0)("FrmKhiTo")
                txtWeight.Text = dt.Rows(0)("Weight")
                txtCourAirBillNo.Text = dt.Rows(0)("CourAirBillNo")
                BindCustomer()
                cmbBuyerName.SelectedValue = dt.Rows(0)("BuyerId")
                txtAddress.Text = dt.Rows(0)("Address")
                txtDcdNo.Text = dt.Rows(0)("DCDNo")
            End If
            dtCourier = New DataTable
            With dtCourier
                .Columns.Add("DPCourierDtlId", GetType(Long))
                .Columns.Add("NoOfPackage", GetType(String))
                .Columns.Add("Qty", GetType(Decimal))
                .Columns.Add("Rate", GetType(Decimal))
                .Columns.Add("QtyType", GetType(String))
                .Columns.Add("Desc", GetType(String))
                .Columns.Add("deliverDate", GetType(String))
                .Columns.Add("ConvergeRate", GetType(Decimal))
                .Columns.Add("Amount", GetType(Decimal))
                .Columns.Add("CurrencyID", GetType(Long))
            End With
            For x = 0 To dt.Rows.Count - 1
                Dr = dtCourier.NewRow()

                Dr = dtCourier.NewRow()
                Dr("DPCourierDtlId") = dt.Rows(x)("DPCourierDtlId")
                Dr("NoOfPackage") = dt.Rows(x)("NoOfPackage")
                Dr("Qty") = dt.Rows(x)("Qty")
                Dr("Rate") = dt.Rows(x)("Rate")
                Dr("QtyType") = dt.Rows(x)("QtyType")
                Dr("Desc") = dt.Rows(x)("Desc")
                Dr("deliverDate") = dt.Rows(x)("deliverDate")
                Dr("ConvergeRate") = dt.Rows(x)("ConvergeRate")
                Dr("Amount") = dt.Rows(x)("Amount")
                Dr("CurrencyID") = dt.Rows(x)("CurrencyID")
                dtCourier.Rows.Add(Dr)
            Next
            Session("dtCourier") = dtCourier
            BindGridCD()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BindGridCD()
        Try
            Dim objDatatble As DataTable
            objDatatble = Session("dtCourier")
            If objDatatble.Rows.Count > 0 Then
                dgCourier.Visible = True
                dgCourier.VirtualItemCount = objDatatble.Rows.Count
                dgCourier.DataSource = objDatatble
                dgCourier.DataBind()
            Else
                dgCourier.Visible = False
            End If

        Catch ex As Exception
        End Try
    End Sub
    Sub BindGrid()

        dgCourier.DataSource = dtCourier
        dgCourier.DataBind()
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            If txtBuyerComment.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Buyer Comment")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                SaveData()
                Response.Redirect("BuyerCommentView.aspx")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveData()
        With ObjDPBuyerComment

            .BuyerCommentID = 0
            .DPCourierMstId = lblCourierMstID.Text
            .DCDNo = txtDcdNo.Text.ToUpper
            .BuyerComment = txtBuyerComment.Text.ToUpper
            .CommentDate = txtBuyerCommentDate.SelectedDate
            .Save()
        End With
    End Sub
End Class
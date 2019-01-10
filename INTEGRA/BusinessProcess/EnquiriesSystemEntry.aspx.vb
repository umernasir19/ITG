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
Public Class EnquiriesSystemEntry
    Inherits System.Web.UI.Page
    Dim IEnquiriesSystemID As Long
    Public MarchandID As Long
    Dim objVendor As New Vender
    Dim objCustomer As New Customer
    Dim dtArticle As New DataTable
    Dim Dr As DataRow
    Dim objEnquiriesSystem As New EnquiriesSystem
    Dim objEnquiriesSystemDetail As New EnquiriesSystemDetail

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        IEnquiriesSystemID = Request.QueryString("EnquiriesSystemID")
        MarchandID = Session("MarchandID")
        If Not Page.IsPostBack Then

            BindCustomer()
            BindSupplier()

            lblConfirmedDate.Visible = False
            txtConfirmedDate.Visible = False
            ImageButton1.Visible = False
            lblPONo.Visible = False
            txtPONO.Visible = False
            lblRemarks.Visible = False
            txtRemarks.Visible = False

            If IEnquiriesSystemID > 0 Then
                EditModes()
            Else

            End If

        End If
    End Sub
    Sub BindCustomer()
        Try
            Dim dtCustomer As DataTable
            dtCustomer = objCustomer.GetBindCombo
            cmbCustomer.DataSource = dtCustomer
            cmbCustomer.DataTextField = "CustomerName"
            cmbCustomer.DataValueField = "CustomerID"
            cmbCustomer.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Sub BindSupplier()
        Try
            Dim dtSupplier As DataTable = objVendor.getDataforBindCombo
            With cmbSupplier
                .DataSource = dtSupplier
                .DataTextField = "VenderName"
                .DataValueField = "VenderLibraryID"
                .DataBind()
            End With
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnAddDetail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddDetail.Click
        Try
            FillGridByArticle()
        Catch ex As Exception

        End Try
    End Sub
    Sub FillGridByArticle()
        Try
            If (Not CType(Session("dtArticle"), DataTable) Is Nothing) Then
                dtArticle = Session("dtArticle")
            Else
                dtArticle = New DataTable
                With dtArticle
                    .Columns.Add("EnquiriesSystemDetailID", GetType(Long))
                    .Columns.Add("ArtName", GetType(String))
                    .Columns.Add("ArtNo", GetType(String))
                    .Columns.Add("Colorways", GetType(String))
                    .Columns.Add("MOQorQty", GetType(Decimal))
                End With
            End If

            Dr = dtArticle.NewRow()
            Dr("EnquiriesSystemDetailID") = 0
            Dr("ArtName") = txtArtName.Text
            Dr("ArtNo") = txtArtNo.Text
            Dr("Colorways") = txtColorways.Text
            Dr("MOQorQty") = txtQty.Text
            dtArticle.Rows.Add(Dr)

            Session("dtArticle") = dtArticle
            BindGrid()
        Catch ex As Exception

        End Try
    End Sub
    Private Function BindGrid() As Boolean
        If (Not dtArticle Is Nothing) Then
            If (dtArticle.Rows.Count > 0) Then
                dgPurchaseOrder.DataSource = dtArticle
                dgPurchaseOrder.DataBind()
                dgPurchaseOrder.Visible = True

                Return (True)
            End If
        End If
        Return (False)
    End Function
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            If txtEnqNo.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Enq No empty.")
            ElseIf dgPurchaseOrder.Items.Count = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Atleast one article required.")
            Else

                With objEnquiriesSystem
                    .EnquiriesSystemID = IEnquiriesSystemID
                    .CreationDate = Date.Now()
                    .EnqNo = txtEnqNo.Text
                    .EnqDate = InqDate.Text
                    .EnqType = cmbEnqType.SelectedItem.Text
                    .CustomerID = cmbCustomer.SelectedValue
                    .SupplierID = cmbSupplier.SelectedValue
                    .Dept = txtDept.Text
                    .Season = txtSeason.Text
                    .Status = cmbStatus.SelectedItem.Text
                    If cmbStatus.SelectedValue = 1 Then
                        .ConfirmedDate = txtConfirmedDate.Text
                    Else
                        .ConfirmedDate = Date.Now()
                    End If
                    .PONO = txtPONO.Text
                    .Remarks = txtRemarks.Text
                    .MarchandID = CLng(Session("Userid"))
                    .SaveEnquiriesSystem()
                End With

                Dim x As Integer
                For x = 0 To dgPurchaseOrder.Items.Count - 1
                    With objEnquiriesSystemDetail
                        .EnquiriesSystemDetailID = dgPurchaseOrder.Items(x).Cells(0).Text
                        If IEnquiriesSystemID > 0 Then
                            .EnquiriesSystemID = IEnquiriesSystemID
                        Else
                            .EnquiriesSystemID = objEnquiriesSystem.GetId()
                        End If

                        .ArtName = dgPurchaseOrder.Items(x).Cells(1).Text
                        .ArtNo = dgPurchaseOrder.Items(x).Cells(2).Text
                        .Colorways = dgPurchaseOrder.Items(x).Cells(3).Text
                        .MOQorQty = dgPurchaseOrder.Items(x).Cells(4).Text
                        .SaveEnquiriesSystemDetail()
                    End With
                Next

                Session("dtArticle") = Nothing
                Response.Redirect("EnquiriesSystemView")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Session("dtArticle") = Nothing
            Response.Redirect("EnquiriesSystemView")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbStatus.SelectedIndexChanged
        Try
            If cmbStatus.SelectedValue = 0 Then
                lblConfirmedDate.Visible = False
                txtConfirmedDate.Visible = False
                ImageButton1.Visible = False
                lblPONo.Visible = False
                txtPONO.Visible = False
                lblRemarks.Visible = False
                txtRemarks.Visible = False
            ElseIf cmbStatus.SelectedValue = 1 Then
                lblConfirmedDate.Visible = True
                txtConfirmedDate.Visible = True
                ImageButton1.Visible = True
                lblPONo.Visible = True
                txtPONO.Visible = True
                lblRemarks.Visible = True
                txtRemarks.Visible = True
            ElseIf cmbStatus.SelectedValue = 2 Then
                lblConfirmedDate.Visible = True
                txtConfirmedDate.Visible = True
                ImageButton1.Visible = True
                lblPONo.Visible = True
                txtPONO.Visible = True
                lblRemarks.Visible = True
                txtRemarks.Visible = True
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub EditModes()
        Try
            Dim dt As DataTable
            dt = objEnquiriesSystem.GetEdit(IEnquiriesSystemID)

            txtEnqNo.Text = dt.Rows(0)("EnqNo")
            InqDate.Text = dt.Rows(0)("EnqDate")
            If dt.Rows(0)("EnqType") = "Initial" Then
                cmbEnqType.SelectedValue = 0
            Else
                cmbEnqType.SelectedValue = 1
            End If

            cmbCustomer.SelectedValue = dt.Rows(0)("CustomerID")
            cmbSupplier.SelectedValue = dt.Rows(0)("SupplierID")
            txtDept.Text = dt.Rows(0)("Dept")
            txtSeason.Text = dt.Rows(0)("Season")
            If dt.Rows(0)("ESstatus") = "Unconfirmed" Then
                cmbStatus.SelectedValue = 0

                lblConfirmedDate.Visible = False
                txtConfirmedDate.Visible = False
                ImageButton1.Visible = False
                lblPONo.Visible = False
                txtPONO.Visible = False
                lblRemarks.Visible = False
                txtRemarks.Visible = False
            ElseIf dt.Rows(0)("ESstatus") = "Confirmed" Then
                cmbStatus.SelectedValue = 1

                lblConfirmedDate.Visible = True
                txtConfirmedDate.Visible = True
                ImageButton1.Visible = True
                lblPONo.Visible = True
                txtPONO.Visible = True
                lblRemarks.Visible = True
                txtRemarks.Visible = True

                txtConfirmedDate.Text = dt.Rows(0)("ConfirmedDate")
                txtPONO.Text = dt.Rows(0)("PONO")
                txtRemarks.Text = dt.Rows(0)("Remarks")
            ElseIf dt.Rows(0)("ESstatus") = "Cancelled" Then
                cmbStatus.SelectedValue = 2

                lblConfirmedDate.Visible = True
                txtConfirmedDate.Visible = True
                ImageButton1.Visible = True
                lblPONo.Visible = True
                txtPONO.Visible = True
                lblRemarks.Visible = True
                txtRemarks.Visible = True
            End If

            dtArticle = Nothing
            Session("dtArticle") = Nothing
            dtArticle = New DataTable
            With dtArticle
                .Columns.Add("EnquiriesSystemDetailID", GetType(Long))
                .Columns.Add("ArtName", GetType(String))
                .Columns.Add("ArtNo", GetType(String))
                .Columns.Add("Colorways", GetType(String))
                .Columns.Add("MOQorQty", GetType(Decimal))
            End With
            For x = 0 To dt.Rows.Count - 1
                Dr = dtArticle.NewRow()
                Dr("EnquiriesSystemDetailID") = dt.Rows(x)("EnquiriesSystemDetailID")
                Dr("ArtName") = dt.Rows(x)("ArtName")
                Dr("ArtNo") = dt.Rows(x)("ArtNo")
                Dr("Colorways") = dt.Rows(x)("Colorways")
                Dr("MOQorQty") = dt.Rows(x)("MOQorQty")
                dtArticle.Rows.Add(Dr)
            Next

            Session("dtArticle") = dtArticle
            BindGrid()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub dgPurchaseOrder_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgPurchaseOrder.ItemCommand
        Select Case e.CommandName
            Case Is = "Remove"
                dtArticle = CType(Session("dtArticle"), DataTable)
                If (Not dtArticle Is Nothing) Then
                    If (dtArticle.Rows.Count > 0) Then
                        Dim lEnquiriesSystemDetailID As Integer = dtArticle.Rows(e.Item.ItemIndex)("EnquiriesSystemDetailID")
                        dtArticle.Rows.RemoveAt(e.Item.ItemIndex)
                        objEnquiriesSystemDetail.DeleteDetailById(lEnquiriesSystemDetailID)
                        BindGrid()
                        
                        If dtArticle.Rows.Count = 0 Then
                            dgPurchaseOrder.Visible = False
                        End If
                    Else
                        dgPurchaseOrder.Visible = False
                    End If
                End If
          
        End Select
    End Sub

End Class
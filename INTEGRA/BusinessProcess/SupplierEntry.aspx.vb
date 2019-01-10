Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Public Class SupplierEntry
    Inherits System.Web.UI.Page
    Dim objDtaBaseSupplier As New SupplierDataBase
    Dim lSupplierDataBaseId As Long
    Dim objIMSSupplierDetail As New SupplierDatabaseDetail
    Dim DtSupplierDetail As DataTable
    Dim Dr As DataRow
    Dim ObjIMSSupplierCategory As New IMSSupplierCategory
    Dim userid As Long
    Dim objCustomerDatabase As New CustomerDatabase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Expires = 0
        lSupplierDataBaseId = Request.QueryString("lSupplierDataBaseId")
        userid = Session("UserId")
        If Not Page.IsPostBack Then
            Session("DtSupplierDetail") = Nothing
            BindSupplierCategory()
            If lSupplierDataBaseId > 0 Then
                SetValuesEditMod()
                btnSave.Text = "Update"
            Else
                btnSave.Text = "Save"
            End If
            PageHeader("")
        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub BindSupplierCategory()
        Dim dtSupplierCategory As New DataTable
        dtSupplierCategory = objDtaBaseSupplier.GetSupplierCategory()
        Try
            With cmbSupplierCategory
                .DataSource = dtSupplierCategory
                .DataTextField = "SupplierCategoryShortName"
                .DataValueField = "SupplierCategoryId"
                .DataBind()
            End With
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SetValuesEditMod()
        Try
            Dim dtSupplierDatabase As DataTable = objDtaBaseSupplier.GetSupplierById(lSupplierDataBaseId)
            txtSupplierName.Text = dtSupplierDatabase.Rows(0)("SupplierName")
            cmbSupplierCategory.SelectedValue = dtSupplierDatabase.Rows(0)("SupplierCategoryId")
            txtAddress.Text = dtSupplierDatabase.Rows(0)("SupplieAddress")
            txtEmailAddress.Text = dtSupplierDatabase.Rows(0)("Email")
            txtPhone.Text = dtSupplierDatabase.Rows(0)("TelephoneNo")
            txtSupplierCode.Text = dtSupplierDatabase.Rows(0)("SupplierCode")
            txtFax.Text = dtSupplierDatabase.Rows(0)("FaxNo")
            txtAccountCode.Text = dtSupplierDatabase.Rows(0)("AccountCode")
            lblUserId.Text = dtSupplierDatabase.Rows(0)("UserId")
            Dim x As Integer
            If dtSupplierDatabase.Rows.Count > 0 Then
                If (Not CType(Session("DtBDtSupplierDetailuyer"), DataTable) Is Nothing) Then
                    DtSupplierDetail = Session("DtSupplierDetail")
                Else
                    DtSupplierDetail = New DataTable
                    With DtSupplierDetail
                        .Columns.Add("SupplierDatabaseDetailId", GetType(Long))
                        .Columns.Add("ContactPerson", GetType(String))
                        .Columns.Add("CellNumber", GetType(String))
                    End With
                End If
                For x = 0 To dtSupplierDatabase.Rows.Count - 1
                    With DtSupplierDetail
                        Dr = DtSupplierDetail.NewRow()
                        Dr("SupplierDatabaseDetailId") = dtSupplierDatabase.Rows(x)("SupplierDatabaseDetailId")
                        Dr("ContactPerson") = dtSupplierDatabase.Rows(x)("ContactPerson")
                        Dr("CellNumber") = dtSupplierDatabase.Rows(x)("CellNumber")
                        DtSupplierDetail.Rows.Add(Dr)
                    End With
                Next
                Session("DtSupplierDetail") = DtSupplierDetail
                BindGrid()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If dgSupplierDetail.Items.Count > 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                With objDtaBaseSupplier
                    If lSupplierDataBaseId > 0 Then
                        .SupplierDatabaseId = lSupplierDataBaseId
                        .CreationDate = objCustomerDatabase.GetCreationDateSupplier(lSupplierDataBaseId)
                    Else
                        .SupplierDatabaseId = 0
                        .CreationDate = Date.Now
                    End If
                    .SupplierName = txtSupplierName.Text
                    If txtAddress.Text = "" Then
                        .SupplieAddress = "N/A"
                    Else
                        .SupplieAddress = txtAddress.Text
                    End If
                    .SupplieAddress = txtAddress.Text
                    .IsActive = 1
                    If txtPhone.Text = "" Then
                        .TelephoneNo = "N/A"
                    Else
                        .TelephoneNo = txtPhone.Text
                    End If
                    If txtEmailAddress.Text = "" Then
                        .Email = ""
                    Else
                        .Email = txtEmailAddress.Text
                    End If
                    If lSupplierDataBaseId > 0 Then
                        .SupplierCode = txtSupplierCode.Text
                    Else
                        Dim FinalCode As String = "0"
                        Dim a As String = .GetID
                        If a <= "9" Then
                            FinalCode = "1000" + a
                        ElseIf a <= "99" Then
                            FinalCode = "100" + a
                        ElseIf a <= "999" Then
                            FinalCode = "100" + a
                        Else
                            FinalCode = "10" + a
                        End If
                        txtSupplierCode.Text = FinalCode
                    End If
                    .SupplierCategoryId = cmbSupplierCategory.SelectedValue
                    .SupplierCode = txtSupplierCode.Text
                    If txtFax.Text = "" Then
                        .FaxNo = "N/A"
                    Else
                        .FaxNo = txtFax.Text
                    End If
                    .AccountCode = txtAccountCode.Text
                    If Session("RoleId") = 46 And Session("Type") = "R.N.D" Then
                        If lSupplierDataBaseId > 0 Then
                            .userid = lblUserId.Text
                        Else
                            .userid = 270
                        End If
                    ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                        If lSupplierDataBaseId > 0 Then
                            .userid = lblUserId.Text
                        Else
                            .userid = 270
                        End If
                    Else
                        If lSupplierDataBaseId > 0 Then
                            .userid = lblUserId.Text
                        Else
                            .userid = userid
                        End If
                    End If
                    .SaveSupplierDatabase()
                End With
                SaveIMSSupplierDetail()
                Response.Redirect("SupplierView.aspx")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Atleast one contact detail required")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SaveIMSSupplierDetail()
        Try
            Dim x As Integer
            For x = 0 To dgSupplierDetail.Items.Count - 1
                With objIMSSupplierDetail
                    .SupplierDatabaseDetailId = dgSupplierDetail.Items(x).Cells(0).Text
                    If lSupplierDataBaseId > 0 Then
                        .SupplierDatabaseId = lSupplierDataBaseId
                    Else
                        .SupplierDatabaseId = objDtaBaseSupplier.GetID
                    End If
                    .ContactPerson = dgSupplierDetail.Items(x).Cells(1).Text
                    .CellNumber = dgSupplierDetail.Items(x).Cells(2).Text
                    .SaveSupplierDatabaseDetail()
                End With
            Next
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("SupplierView.aspx")
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnAddDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddDetail.Click
        Try
            If txtContactPerson.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Contact Person Empty.")
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
        If (Not CType(Session("DtSupplierDetail"), DataTable) Is Nothing) Then
            DtSupplierDetail = Session("DtSupplierDetail")
        Else
            DtSupplierDetail = New DataTable
            With DtSupplierDetail
                .Columns.Add("SupplierDatabaseDetailId", GetType(Long))
                .Columns.Add("ContactPerson", GetType(String))
                .Columns.Add("CellNumber", GetType(String))
            End With
        End If
        Dr = DtSupplierDetail.NewRow()
        Dr("SupplierDatabaseDetailId") = 0
        Dr("ContactPerson") = txtContactPerson.Text
        If txtCellNo.Text = "" Then
            Dr("CellNumber") = "N/A"
        Else
            Dr("CellNumber") = txtCellNo.Text
        End If
        DtSupplierDetail.Rows.Add(Dr)
        Session("DtSupplierDetail") = DtSupplierDetail
    End Sub
    Private Sub BindGrid()
        Try
            Dim objDatatble As DataTable
            objDatatble = Session("DtSupplierDetail")
            If objDatatble.Rows.Count > 0 Then
                dgSupplierDetail.Visible = True
                dgSupplierDetail.RecordCount = objDatatble.Rows.Count
                dgSupplierDetail.DataSource = objDatatble
                dgSupplierDetail.DataBind()
            Else
                dgSupplierDetail.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub ClearControls()
        txtContactPerson.Text = ""
        txtCellNo.Text = ""
    End Sub
    Protected Sub dgSupplierDetail_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgSupplierDetail.ItemCommand
        Select Case e.CommandName
            Case "Remove"
                DtSupplierDetail = CType(Session("DtSupplierDetail"), DataTable)
                If (Not DtSupplierDetail Is Nothing) Then
                    If (DtSupplierDetail.Rows.Count > 0) Then
                        Dim IMSSupplierDetailId As Integer = DtSupplierDetail.Rows(e.Item.ItemIndex)("SupplierDatabaseDetailId")
                        DtSupplierDetail.Rows.RemoveAt(e.Item.ItemIndex)
                        objIMSSupplierDetail.DeleteDetail(IMSSupplierDetailId)
                        BindGrid()
                        If DtSupplierDetail.Rows.Count = 0 Then
                            dgSupplierDetail.Visible = False
                        End If
                    Else
                        dgSupplierDetail.Visible = False
                    End If
                End If
        End Select
    End Sub
    Protected Sub txtSupplierName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSupplierName.TextChanged
        Try
            Dim dtac As New DataTable
            If txtSupplierName.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Enter Valid Supplier Name.")
            ElseIf txtSupplierName.Text <> "" Then
                dtac = objDtaBaseSupplier.GetUniqueAccountName(txtSupplierName.Text)
                If dtac.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Account Name Not Exist")
                End If
                txtAccountCode.Text = dtac.Rows(0)("AccountCode")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnAddSupplierCate_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAddSupplierCate.Click
        Try
            pnl2.Visible = True
            pnl1.Visible = False
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnSaveSupplierCate_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSaveSupplierCate.Click
        Try
            If txtSupplierCategory.Text = "" And txtShortName.Text = "" Then
                With ObjIMSSupplierCategory
                    .SupplierCategoryId = 0
                    .SupplierCategory = txtSupplierCategory.Text
                    .SupplierCategoryShortName = txtShortName.Text
                End With
            Else
                With ObjIMSSupplierCategory
                    .SupplierCategoryId = 0
                    .SupplierCategory = txtSupplierCategory.Text
                    .SupplierCategoryShortName = txtShortName.Text
                    .SaveIMSSupplierCategory()
                End With
            End If
            pnl2.Visible = False
            pnl1.Visible = True
            BindSupplierCategory()
        Catch ex As Exception
        End Try
    End Sub
End Class



Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Public Class ComplainDatabaseEntry
    Inherits System.Web.UI.Page
    Dim objVender As New Vender
    Dim ObjCustomer As New Customer
    Dim objPurchaseorder As New PurchaseOrder
    Dim objComplainDatabase As New ComplainDatabase
    Dim objComplainDatabaseDetail As New ComplainDatabaseDetail
    Dim ComplainDatabaseID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ComplainDatabaseID = Request.QueryString("ComplainDatabaseID")
        If Not Page.IsPostBack Then
            BindReclamationType()
            BindCustomer()
            BindDefectCode()
            BindCurrentStatus()
            If ComplainDatabaseID > 0 Then
                EditMode()
            End If
        End If
    End Sub
    Sub BindReclamationType()
        Try
            Dim dt As DataTable
            dt = objVender.getReclamationTypes()
            With cmbReclamationType
                .DataSource = dt
                .DataTextField = "ReclamationType"
                .DataValueField = "ReclamationTypeID"
                .DataBind()

            End With
        Catch ex As Exception
        End Try
    End Sub
    Sub BindCustomer()
        Try
            Dim dt As DataTable
            dt = ObjCustomer.GetBindCombo()
            With cmbCustomer
                .DataSource = dt
                .DataTextField = "CustomerName"
                .DataValueField = "CustomerID"
                .DataBind()
                .Items.Insert(0, New ListItem("Select", "0"))
            End With
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbCustomer_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCustomer.SelectedIndexChanged
        Try
            Dim dt As DataTable
            dt = ObjCustomer.GetDept(cmbCustomer.SelectedValue)
            With cmbDept
                .DataSource = dt
                .DataTextField = "Eknumber"
                .DataBind()
                .Items.Insert(0, New ListItem("Select", "0"))
            End With
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbDept_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbDept.SelectedIndexChanged
        Try
            Dim dt As DataTable
            dt = ObjCustomer.GetSupplier(cmbCustomer.SelectedValue, cmbDept.SelectedItem.Text)
            With cmbSupplier
                .DataSource = dt
                .DataTextField = "Vendername"
                .DataValueField = "Supplierid"
                .DataBind()
                .Items.Insert(0, New ListItem("Select", "0"))
            End With
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbSupplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSupplier.SelectedIndexChanged
        Try
            Dim dt As DataTable
            dt = ObjCustomer.GetSeason(cmbCustomer.SelectedValue, cmbDept.SelectedItem.Text, cmbSupplier.SelectedValue)
            With cmbSeason
                .DataSource = dt
                .DataTextField = "Season"
                .DataBind()
                .Items.Insert(0, New ListItem("Select", "0"))
            End With
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbSeason_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSeason.SelectedIndexChanged
        Try
            Dim dt As DataTable
            dt = ObjCustomer.GetPONO(cmbCustomer.SelectedValue, cmbDept.SelectedItem.Text, cmbSupplier.SelectedValue, cmbSeason.SelectedItem.Text)
            With cmbPONO
                .DataSource = dt
                .DataTextField = "PONO"
                .DataValueField = "POID"
                .DataBind()
                .Items.Insert(0, New ListItem("Select", "0"))
            End With
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbPONO_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPONO.SelectedIndexChanged
        Try
            Dim dt As DataTable
            dt = objPurchaseorder.getArtcile(cmbPONO.SelectedValue)
            With cmbArticleNo
                .DataSource = dt
                .DataTextField = "Article"
                .DataBind()
                .Items.Insert(0, New ListItem("Select", "0"))
            End With
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbArticleNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbArticleNo.SelectedIndexChanged
        Try
            Dim dt As DataTable
            Dim objDataView As DataView
            dt = objPurchaseorder.getArtcileData(cmbPONO.SelectedValue, cmbArticleNo.SelectedItem.Text)
            objDataView = New DataView(dt)
            Dim strSortExpression As String
            If objDataView.Count > 0 Then
                dgArticle.Visible = True
                strSortExpression = dgArticle.SortExpression
                If strSortExpression <> "" Then
                    objDataView.Sort = strSortExpression
                    If Not dgArticle.IsSortedAscending Then
                        objDataView.Sort += " DESC"
                    End If
                End If
                dgArticle.RecordCount = objDataView.Count
                dgArticle.DataSource = objDataView
                dgArticle.DataBind()

            Else
                dgArticle.Visible = False
            End If

        Catch ex As Exception

        End Try
    End Sub
    Sub BindDefectCode()
        Try
            Dim dt As DataTable
            dt = ObjCustomer.GetErrorCodes()
            With cmbDefectCode
                .DataSource = dt
                .DataTextField = "ErrorNo"
                .DataValueField = "ID"
                .DataBind()
                .Items.Insert(0, New ListItem("Select", "0"))
            End With
        Catch ex As Exception
        End Try
    End Sub
    Sub BindCurrentStatus()
        Try
            Dim dt As DataTable
            dt = ObjCustomer.GetCurrentStatus()
            With cmbCurrentStatus
                .DataSource = dt
                .DataTextField = "CurrentStatus"
                .DataValueField = "CurrentStatusID"
                .DataBind()
                .Items.Insert(0, New ListItem("Select", "0"))
            End With
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            If txtClaimNo.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Claim No Required.")
            ElseIf txtANZNo.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("ANZ No Required.")
            ElseIf txtInspectorName.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Inspector Name Required.")
            ElseIf dgArticle.Items.Count = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Atleast one record required in detail")
            Else
                With objComplainDatabase
                    .ComplainDatabaseID = ComplainDatabaseID
                    .ClaimNo = txtClaimNo.Text
                    .ReclamationTypeID = cmbReclamationType.SelectedValue
                    .ANZNo = txtANZNo.Text
                    .InspectorName = txtInspectorName.Text
                    .CustomerID = cmbCustomer.SelectedValue
                    .Dept = cmbDept.SelectedItem.Text
                    .SupplierID = cmbSupplier.SelectedValue
                    .Season = cmbSeason.SelectedItem.Text
                    .POID = cmbPONO.SelectedValue
                    .ArticleNo = cmbArticleNo.SelectedItem.Text
                    .DefectID = cmbDefectCode.SelectedValue
                    .Defect = txtDefect.Text
                    .CurrentStatusID = cmbCurrentStatus.SelectedValue
                    .Notes = txtNotes.Text
                    .SaveComplainDatabase()
                End With

                Dim x As Integer
                For x = 0 To dgArticle.Items.Count - 1
                    Dim txtFaultPcs As TextBox = CType(dgArticle.Items(x).FindControl("txtFaultPcs"), TextBox)
                    With objComplainDatabaseDetail
                        .ComplainDatabaseDetailID = dgArticle.Items(x).Cells(0).Text
                        If ComplainDatabaseID > 0 Then
                            .ComplainDatabaseID = ComplainDatabaseID
                        Else
                            .ComplainDatabaseID = objComplainDatabase.GetId()
                        End If

                        .POID = dgArticle.Items(x).Cells(1).Text
                        .PoDetailID = dgArticle.Items(x).Cells(2).Text
                        .FaultQty = Val(txtFaultPcs.Text)
                        .SaveComplainDatabaseDetail()
                    End With
                Next

                Response.Redirect("ComplainDatabaseView.aspx")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("ComplainDatabaseView.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Sub EditMode()
        Try
            Dim dt As DataTable = objComplainDatabase.Edit(ComplainDatabaseID)
            txtClaimNo.Text = dt.Rows(0)("ClaimNo")
            cmbReclamationType.SelectedValue = dt.Rows(0)("ReclamationTypeID")
            txtANZNo.Text = dt.Rows(0)("ANZNo")
            txtInspectorName.Text = dt.Rows(0)("InspectorName")
            cmbCustomer.SelectedValue = dt.Rows(0)("CustomerID")

            Dim dtDept As DataTable = ObjCustomer.GetDept(cmbCustomer.SelectedValue)
            With cmbDept
                .DataSource = dtDept
                .DataTextField = "Eknumber"
                .DataBind()
                .Items.Insert(0, New ListItem("Select", "0"))
            End With
            cmbDept.SelectedItem.Text = dt.Rows(0)("Dept")

            Dim dtSupplier As DataTable = ObjCustomer.GetSupplier(cmbCustomer.SelectedValue, cmbDept.SelectedItem.Text)
            With cmbSupplier
                .DataSource = dtSupplier
                .DataTextField = "Vendername"
                .DataValueField = "Supplierid"
                .DataBind()
                .Items.Insert(0, New ListItem("Select", "0"))
            End With
            cmbSupplier.SelectedValue = dt.Rows(0)("SupplierID")

            Dim dtSeason As DataTable = ObjCustomer.GetSeason(cmbCustomer.SelectedValue, cmbDept.SelectedItem.Text, cmbSupplier.SelectedValue)
            With cmbSeason
                .DataSource = dtSeason
                .DataTextField = "Season"
                .DataBind()
                .Items.Insert(0, New ListItem("Select", "0"))
            End With
            cmbSeason.SelectedItem.Text = dt.Rows(0)("Season")

            Dim dtPONO As DataTable = ObjCustomer.GetPONO(cmbCustomer.SelectedValue, cmbDept.SelectedItem.Text, cmbSupplier.SelectedValue, cmbSeason.SelectedItem.Text)
            With cmbPONO
                .DataSource = dt
                .DataTextField = "PONO"
                .DataValueField = "POID"
                .DataBind()
                .Items.Insert(0, New ListItem("Select", "0"))
            End With
            cmbPONO.SelectedValue = dt.Rows(0)("POID")

            Dim dtArticle As DataTable = objPurchaseorder.getArtcile(cmbPONO.SelectedValue)
            With cmbArticleNo
                .DataSource = dtArticle
                .DataTextField = "Article"
                .DataBind()
                .Items.Insert(0, New ListItem("Select", "0"))
            End With
            cmbArticleNo.SelectedItem.Text = dt.Rows(0)("ArticleNo")

            Dim objDataView As DataView
            'Dim dtGrid As DataTable = objPurchaseorder.getArtcileData(cmbPONO.SelectedValue, cmbArticleNo.SelectedItem.Text)
            objDataView = New DataView(dt)
            Dim strSortExpression As String
            If objDataView.Count > 0 Then
                dgArticle.Visible = True
                strSortExpression = dgArticle.SortExpression
                If strSortExpression <> "" Then
                    objDataView.Sort = strSortExpression
                    If Not dgArticle.IsSortedAscending Then
                        objDataView.Sort += " DESC"
                    End If
                End If
                dgArticle.RecordCount = objDataView.Count
                dgArticle.DataSource = objDataView
                dgArticle.DataBind()

                Dim x As Integer
                For x = 0 To dgArticle.Items.Count - 1
                    Dim txtFaultPcs As TextBox = CType(dgArticle.Items(x).FindControl("txtFaultPcs"), TextBox)
                    txtFaultPcs.Text = dt.Rows(x)("FaultQty")
                Next
            Else
                dgArticle.Visible = False
            End If

            cmbDefectCode.SelectedValue = dt.Rows(0)("DefectID")
            txtDefect.Text = dt.Rows(0)("Defect")
            cmbCurrentStatus.SelectedValue = dt.Rows(0)("CurrentStatusID")
            txtNotes.Text = dt.Rows(0)("Notes")

        Catch ex As Exception

        End Try
    End Sub
End Class
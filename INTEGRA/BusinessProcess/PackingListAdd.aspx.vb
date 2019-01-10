Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO

Public Class PackingListAdd
    Inherits System.Web.UI.Page
    Dim objPackingList As New PackingList
    Dim objPackingListDetail As New PackingListDetail
    Dim dtPackingListDetail As DataTable
    Dim dr As DataRow
    Dim PackingListID As Long
    Dim PackingListDetailID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PackingListID = Request.QueryString("lPackingListID")
        If Not Page.IsPostBack Then
            BindInvoiceNo()
            PageHeader("Packing List")
            Session("dtPackingListDetail") = Nothing
            If PackingListID > 0 Then
                SetValuesEditMod()
                btnSave.Text = "Update"
            Else
                btnSave.Text = "Save"
                txtInvoiceNo.Visible = False
                txtPONO.Visible = False
            End If
        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub BindInvoiceNo()
        Try
            Dim dtInvoiceNo As DataTable
            dtInvoiceNo = objPackingList.GetInvoiceNo()
            cmbInvoiceNo.DataSource = dtInvoiceNo
            cmbInvoiceNo.DataTextField = "InvoiceNo"
            cmbInvoiceNo.DataValueField = "CommercialInvoiceID"
            cmbInvoiceNo.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Sub BindPONO(ByVal CommercialInvoiceID)
        Try
            Dim dtPONO As DataTable
            dtPONO = objPackingList.GetPONo(CommercialInvoiceID)
            cmbPONO.DataSource = dtPONO
            cmbPONO.DataTextField = "PONO"
            cmbPONO.DataValueField = "POID"
            cmbPONO.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbInvoiceNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbInvoiceNo.SelectedIndexChanged
        Dim CommercialInvoiceID As Long = cmbInvoiceNo.SelectedValue
        BindPONO(CommercialInvoiceID)
    End Sub
    Sub BindArticleNo(ByVal POID)
        Dim dtarticle As DataTable
        dtarticle = objPackingList.GetArticleNo(POID)
        cmbArticleNo.DataSource = dtarticle
        cmbArticleNo.DataTextField = "Article"
        cmbArticleNo.DataBind()
    End Sub
    Protected Sub cmbPONO_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbPONO.SelectedIndexChanged
        Dim POID As Long = cmbPONO.SelectedValue
        BindArticleNo(POID)
    End Sub
    Protected Sub txtStartSeriesNo_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtStartSeriesNo.TextChanged
        If Not String.IsNullOrEmpty(txtTotalCarton.Text) AndAlso Not String.IsNullOrEmpty(txtStartSeriesNo.Text) Then
            txtEndSeriesNo.Text = (Convert.ToInt32(txtTotalCarton.Text) + Convert.ToInt32(txtStartSeriesNo.Text)).ToString()
        End If
    End Sub
    Protected Sub txtTotalCarton_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtTotalCarton.TextChanged
        If Not String.IsNullOrEmpty(txtTotalCarton.Text) AndAlso Not String.IsNullOrEmpty(txtStartSeriesNo.Text) Then
            txtEndSeriesNo.Text = (Convert.ToInt32(txtTotalCarton.Text) + Convert.ToInt32(txtStartSeriesNo.Text)).ToString()
        End If
    End Sub
    Protected Sub lnkAddexisting_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkAddexisting.Click
        Try
            If txtCartonSeriesStart.Text = "" Or txtCartonSeriesEnd.Text = "" Or cmbArticleNo.Text = "" Or cmbSizes.Text = "" Or txtQuantity.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Fill All Fields For Packing List Detail")
            Else
                Dim GridQty As Decimal = 0
                If dgPackingListDetail.Items.Count = 0 Then
                    Dim ComercalQTY As Decimal = objPackingList.GetQuantity(cmbSizes.SelectedValue)
                    If txtQuantity.Text <= ComercalQTY Then
                        SaveSession()
                        BindPackingListDetailGrid()
                        ClearControls()
                        btnSave.Enabled = True
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Else
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Entered Quantity is Greater then Orignal Quantity")
                    End If
                Else
                    For x = 0 To dgPackingListDetail.Items.Count - 1
                        Dim item As GridDataItem = DirectCast(dgPackingListDetail.MasterTableView.Items(x), GridDataItem)
                        Dim GridSize As String = dgPackingListDetail.Items(x).Cells(8).Text

                        If cmbSizes.SelectedItem.Text = GridSize Then
                            Dim quantity As Decimal = dgPackingListDetail.Items(x).Cells(9).Text
                            GridQty = GridQty + quantity
                        End If
                    Next
                    Dim commercialQTY As Decimal = objPackingList.GetQuantity(cmbSizes.SelectedValue)
                    If (GridQty + txtQuantity.Text) > commercialQTY Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Entered Quantity is Greater then Orignal Quantity")
                    Else
                        SaveSession()
                        BindPackingListDetailGrid()
                        ClearControls()
                        btnSave.Enabled = True
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub lnkAddother_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkAddother.Click
        Try
            If txtCartonSeriesStart.Text = "" Or txtCartonSeriesEnd.Text = "" Or cmbArticleNo.Text = "" Or cmbSizes.Text = "" Or txtQuantity.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Fill All Fields For Packing List Detail")
            Else
                Dim GridQty As Decimal = 0
                If dgPackingListDetail.Items.Count = 0 Then
                    Dim ComercalQTY As Decimal = objPackingList.GetQuantity(cmbSizes.SelectedItem.Text)
                    If txtQuantity.Text <= ComercalQTY Then
                        SaveSession()
                        BindPackingListDetailGrid()
                        ClearControl()
                        btnSave.Enabled = True
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Else
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Entered Quantity is Greater then Orignal Quantity")
                    End If
                Else
                    For x = 0 To dgPackingListDetail.Items.Count - 1
                        Dim item As GridDataItem = DirectCast(dgPackingListDetail.MasterTableView.Items(x), GridDataItem)
                        Dim GridSize As String = dgPackingListDetail.Items(x).Cells(8).Text

                        If cmbSizes.SelectedItem.Text = GridSize Then
                            Dim quantity As Decimal = dgPackingListDetail.Items(x).Cells(9).Text
                            GridQty = GridQty + quantity
                        End If
                    Next
                    Dim commercialQTY As Decimal = objPackingList.GetQuantity(cmbSizes.SelectedItem.Text)
                    If (GridQty + txtQuantity.Text) > commercialQTY Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Entered Quantity is Greater then Orignal Quantity")
                    Else
                        SaveSession()
                        BindPackingListDetailGrid()
                        ClearControl()
                        btnSave.Enabled = True
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BindPackingListDetailGrid()
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
    Sub SaveSession()
        If (Not CType(Session("dtPackingListDetail"), DataTable) Is Nothing) Then
            dtPackingListDetail = Session("dtPackingListDetail")
        Else
            dtPackingListDetail = New DataTable
            With dtPackingListDetail
                .Columns.Add("PackingListDetailID", GetType(Long))
                .Columns.Add("POID", GetType(Long))
                .Columns.Add("PoDetailID", GetType(Long))
                .Columns.Add("CartonSeriesStart", GetType(String))
                .Columns.Add("CartonSeriesEnd", GetType(String))
                .Columns.Add("Article", GetType(String))
                .Columns.Add("SizeRange", GetType(String))
                .Columns.Add("Quantity", GetType(String))
            End With
        End If
        Dim aa As String = cmbSizes.SelectedValue
        dr = dtPackingListDetail.NewRow()
        dr("PackingListDetailID") = 0
        dr("POID") = cmbPONO.SelectedValue
        dr("PoDetailID") = cmbSizes.SelectedValue
        dr("CartonSeriesStart") = txtCartonSeriesStart.Text
        dr("CartonSeriesEnd") = txtCartonSeriesEnd.Text
        dr("Article") = cmbArticleNo.SelectedItem.Text
        dr("SizeRange") = cmbSizes.SelectedItem.Text
        dr("Quantity") = txtQuantity.Text
        dtPackingListDetail.Rows.Add(dr)
        Session("dtPackingListDetail") = dtPackingListDetail
    End Sub
    Protected Sub dgPackingListDetail_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgPackingListDetail.ItemCommand
       
    End Sub
    Sub ClearControls()
        txtQuantity.Text = ""
    End Sub
    Sub ClearControl()
        txtCartonSeriesEnd.Text = ""
        txtCartonSeriesStart.Text = ""
        txtQuantity.Text = ""
    End Sub
    Sub BindSizes(ByVal POID, ByVal CommercialInvoiceID, ByVal Article)
        Dim dtSizes As DataTable
        dtSizes = objPackingList.GetSizes(POID, CommercialInvoiceID, Article)
        cmbSizes.DataSource = dtSizes
        cmbSizes.DataTextField = "SizeRange"
        cmbSizes.DataValueField = "PODetailID"
        cmbSizes.DataBind()
    End Sub
    Protected Sub cmbArticleNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbArticleNo.SelectedIndexChanged
        Dim POID As Long = cmbPONO.SelectedValue()
        Dim CommercialinvoiceID As Long = cmbInvoiceNo.SelectedValue
        Dim Article As String = cmbArticleNo.SelectedItem.Text
        BindSizes(POID, CommercialinvoiceID, Article)
    End Sub
    Protected Sub cmbSizes_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbSizes.SelectedIndexChanged
        Dim CommercialInvoiceDetailID As Long = cmbSizes.SelectedValue
        txtQuantity.Text = objPackingList.GetQuantity(CommercialInvoiceDetailID)
        lblCommecialQuantity.Text = txtQuantity.Text
    End Sub
    Sub SavePackingListMaster()
        With objPackingList
            If PackingListID > 0 Then
                .PackingListID = PackingListID
            Else
                .PackingListID = 0
            End If
            .CommercialinvoiceID = cmbInvoiceNo.SelectedValue
            .CreationDate = Date.Now
            .TotalCarton = txtTotalCarton.Text
            .GrossWeight = txtGrossWeight.Text
            .GrossUOM = cmbWeightUOM.SelectedItem.Text
            .NetWeight = txtNetWeigth.Text
            .StartSeriesNo = txtStartSeriesNo.Text
            .EndSeriesNo = txtEndSeriesNo.Text
            .Lenght = txtLenght.Text
            .LenghtUOM = cmblenghtUOM.SelectedItem.Text
            .Width = txtWidth.Text
            .Height = txtHeight.Text
            .Comments = txtComments.Text
            .PackingListNo = txtPackingListNo.Text
            .SavePackingList()
        End With
    End Sub
    Sub SavePackingListDetail()
        Dim x As Integer
        Dim PackingListDetailID As Integer = 0
        For x = 0 To dgPackingListDetail.Items.Count - 1
            Dim item As GridDataItem = DirectCast(dgPackingListDetail.MasterTableView.Items(x), GridDataItem)
            With objPackingListDetail
                .PackingListDetailID = item("PackingListdetailID").Text
                If PackingListID > 0 Then
                    .PackingListID = PackingListID
                Else
                    .PackingListID = objPackingList.GetID
                End If
                .CartonSeriesStart = item("CartonseriesStart").Text
                .CartonSeriesEnd = item("CartonSeriesEnd").Text
                .POID = cmbPONO.SelectedValue

                .PODetailID = item("PODetailID").Text
                .Quantity = item("Quantity").Text
                .SavePackingListDetail()
            End With
        Next
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            If PackingListID > 0 Then
                Validation()
                Response.Redirect("PackingListView.aspx")
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
            Else
                Dim dtValidate As New DataTable
                dtValidate = objPackingList.CheckExistingValue(txtPackingListNo.Text, cmbInvoiceNo.SelectedValue, cmbPONO.SelectedValue)
                If dtValidate.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Packing List No Already Exist.")
                Else
                    Validation()
                    Response.Redirect("PackingListView.aspx")
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub Validation()
        If txtPackingListNo.Text = "" Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Insert Packing List No.")
            btnSave.Enabled = False
        ElseIf txtTotalCarton.Text = "" Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Insert Total Carton.")
        ElseIf txtGrossWeight.Text = "" Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Insert Gross Weight.")
        ElseIf txtNetWeigth.Text = "" Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Insert Net Weight.")
        ElseIf txtStartSeriesNo.Text = "" Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Insert start Series No.")
        ElseIf txtEndSeriesNo.Text = "" Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Insert End Series No.")
        ElseIf txtLenght.Text = "" Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Insert Lenght.")
        ElseIf txtWidth.Text = "" Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Insert Width.")
        ElseIf txtHeight.Text = "" Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Insert Height.")
        ElseIf dgPackingListDetail.Items.Count = 0 Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Atleast One article description Reqiured")
        Else
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
            SavePackingListMaster()
            SavePackingListDetail()
        End If
    End Sub
    Sub SetValuesEditMod()
        Dim dt As DataTable
        Dim x As Integer
        Try
            dt = objPackingList.GetPackingListValueforEdit(PackingListID)
            cmbInvoiceNo.SelectedValue = dt.Rows(0)("CommercialInvoiceID")
            txtInvoiceNo.Text = dt.Rows(0)("InvoiceNo")
            cmbInvoiceNo.Visible = False
            BindPONO(cmbInvoiceNo.SelectedValue)
            cmbPONO.SelectedValue = dt.Rows(0)("POID")
            cmbPONO.Visible = False
            txtPONO.Text = dt.Rows(0)("PONO")
            'cmbPONO.Enabled = False
            'cmbArticleNo.SelectedValue = dt.Rows(0)("POID")
            BindArticleNo(cmbPONO.SelectedValue)
            'cmbPONO.SelectedItem.Text = dt.Rows(0)("PONO")
            If String.IsNullOrEmpty(dt.Rows(0)("PackingListNo").ToString()) = False Then
                txtPackingListNo.Text = dt.Rows(0)("PackingListNo")
                txtPackingListNo.ReadOnly = True
            Else
                txtPackingListNo.Text = ""
            End If
            If String.IsNullOrEmpty(dt.Rows(0)("TotalCarton").ToString()) = False Then
                txtTotalCarton.Text = dt.Rows(0)("TotalCarton")
            Else
                txtTotalCarton.Text = ""
            End If
            If String.IsNullOrEmpty(dt.Rows(0)("GrossWeight").ToString()) = False Then
                txtGrossWeight.Text = dt.Rows(0)("GrossWeight")
            Else
                txtGrossWeight.Text = ""
            End If
            If String.IsNullOrEmpty(dt.Rows(0)("GrossUOM").ToString()) = False Then
                cmbWeightUOM.SelectedItem.Text = dt.Rows(0)("GrossUOM")

            Else
                cmbWeightUOM.SelectedItem.Text = ""
            End If
            If String.IsNullOrEmpty(dt.Rows(0)("NetWeight").ToString()) = False Then
                txtNetWeigth.Text = dt.Rows(0)("NetWeight")
            Else
                txtNetWeigth.Text = ""
            End If
            If String.IsNullOrEmpty(dt.Rows(0)("StartSeriesNo").ToString()) = False Then
                txtStartSeriesNo.Text = dt.Rows(0)("StartSeriesNo")
            Else
                txtStartSeriesNo.Text = ""
            End If
            If String.IsNullOrEmpty(dt.Rows(0)("EndSeriesNo").ToString()) = False Then
                txtEndSeriesNo.Text = dt.Rows(0)("EndSeriesNo")
            Else
                txtEndSeriesNo.Text = ""
            End If
            If String.IsNullOrEmpty(dt.Rows(0)("LenghtUOM").ToString()) = False Then
                cmblenghtUOM.SelectedItem.Text = dt.Rows(0)("LenghtUOM")

            Else
                cmblenghtUOM.SelectedItem.Text = ""
            End If
            If String.IsNullOrEmpty(dt.Rows(0)("Lenght").ToString()) = False Then
                txtLenght.Text = dt.Rows(0)("Lenght")
            Else
                txtLenght.Text = ""
            End If
            If String.IsNullOrEmpty(dt.Rows(0)("Width").ToString()) = False Then
                txtWidth.Text = dt.Rows(0)("Width")
            Else
                txtWidth.Text = ""
            End If
            If String.IsNullOrEmpty(dt.Rows(0)("Height").ToString()) = False Then
                txtHeight.Text = dt.Rows(0)("Height")
            Else
                txtHeight.Text = ""
            End If
            If String.IsNullOrEmpty(dt.Rows(0)("Comments").ToString()) = False Then
                txtComments.Text = dt.Rows(0)("Comments")
            Else
                txtComments.Text = ""
            End If

            dtPackingListDetail = Nothing
            Session("dtPackingListDetail") = Nothing
            dtPackingListDetail = New DataTable
            With dtPackingListDetail
                .Columns.Add("PackingListDetailID", GetType(Long))
                .Columns.Add("PODetailID", GetType(Long))
                .Columns.Add("CartonSeriesStart", GetType(String))
                .Columns.Add("CartonSeriesEnd", GetType(String))
                .Columns.Add("POID", GetType(Long))
                .Columns.Add("Article", GetType(String))
                .Columns.Add("SizeRange", GetType(String))
                .Columns.Add("Quantity", GetType(Decimal))

            End With
            For x = 0 To dt.Rows.Count - 1
                dr = dtPackingListDetail.NewRow()
                dr("PackingListDetailID") = dt.Rows(x)("PackingListDetailID")
                dr("PODetailID") = dt.Rows(x)("PODetailID")
                dr("CartonSeriesStart") = dt.Rows(x)("CartonSeriesStart")
                dr("CartonSeriesEnd") = dt.Rows(x)("CartonSeriesEnd")
                dr("POID") = dt.Rows(x)("POID")
                dr("Article") = dt.Rows(x)("Article")
                dr("SizeRange") = dt.Rows(x)("SizeRange")
                dr("Quantity") = dt.Rows(x)("Quantity")

                dtPackingListDetail.Rows.Add(dr)
            Next
            Session("dtPackingListDetail") = dtPackingListDetail
            BindPackingListDetailGrid()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub dgPackingListDetail_DeleteCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgPackingListDetail.DeleteCommand
        dtPackingListDetail = CType(Session("dtPackingListDetail"), DataTable)
        If (Not dtPackingListDetail Is Nothing) Then
            If (dtPackingListDetail.Rows.Count > 0) Then
                Dim PackingListDetailID As Integer = dtPackingListDetail.Rows(e.Item.ItemIndex)("PackingListDetailID")
                dtPackingListDetail.Rows.RemoveAt(e.Item.ItemIndex)
                objPackingListDetail.DeleteDetailFromPackingListDetail(PackingListDetailID)
                BindPackingListDetailGrid()
            Else
            End If
        End If
    End Sub
    Protected Sub txtCartonSeriesEnd_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtCartonSeriesEnd.TextChanged
        If txtCartonSeriesEnd.Text <= txtEndSeriesNo.Text Then
            lblvalidation.Visible = False
            btnSave.Enabled = True
        Else
            lblvalidation.Visible = True
            lblvalidation.Text = "Enter Valid End Series No"
            btnSave.Enabled = False
        End If
    End Sub
    Protected Sub txtCartonSeriesStart_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtCartonSeriesStart.TextChanged
        If txtCartonSeriesStart.Text >= txtStartSeriesNo.Text And txtCartonSeriesStart.Text <= txtEndSeriesNo.Text Then
            lblValidate.Visible = False
            btnSave.Enabled = True
        Else
            lblValidate.Visible = True
            lblValidate.Text = "Enter Valid Start Series No"
            btnSave.Enabled = False
        End If
    End Sub
    Protected Sub txtQuantity_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtQuantity.TextChanged
        If Not String.IsNullOrEmpty(txtQuantity.Text) AndAlso Not String.IsNullOrEmpty(lblCommecialQuantity.Text) Then
            lblCommecialQuantity.Text = (Convert.ToInt32(lblCommecialQuantity.Text) - Convert.ToInt32(txtQuantity.Text)).ToString()
        End If
    End Sub
End Class
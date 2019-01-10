Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.Xml
Imports System.Net
Imports System.Net.Mail
Public Class FabricCalculation
    Inherits System.Web.UI.Page
    Dim ObjFPOReturn As New PoReturnClass
    Dim ObjIMSStoreLedger As New IMSStoreLedger
    Dim ObjIssue As New IssueMst
    Dim objJobOrderdatabase As New JobOrderdatabase
    Dim dtFabricCalculation, dtCalculation As DataTable
    Dim Dr As DataRow
    Dim OBJFabCalMst As New FabCalMst
    'Dim OBJFabCalDtl As New FabCalDtl
    Dim OBJFabCalDtl As New FabCalDtlNew
    Dim OBJFabCalContractDtl As New FabCalContractDtl
    Dim LFabCalMstID, lUserId As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Try
                Session("dtFabricCalculation") = Nothing
                Session("dtCalculation") = Nothing
                BindBuyer()
                BindSeason()
                BindSrNo()
            Catch objUDException As UDException
            End Try
        End If
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If dgContract.Items.Count = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Add Grid")
            ElseIf dgDetail.Items.Count = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Add Grid")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                save()
                savedtl()
                savedtlContract()
                Response.Redirect("FabricCalculationView.aspx")
            End If

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("FabricCalculationView.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Sub save()
        With OBJFabCalMst
            If LFabCalMstID > 0 Then
                .FabCalMstID = LFabCalMstID
            Else
                .FabCalMstID = 0
            End If
            .CreationDate = Date.Now
            .UserId = lUserId
            .OrderConDate = txtOrderConsumptionDate.Text
            .CustomerId = cmbBuyer.SelectedValue
            .IMSItemId = lblItemId.Text
            .Save()
        End With
    End Sub
    Sub savedtlContract()
        Try
            Dim x As Integer
            For x = 0 To dgContract.Items.Count - 1
                With OBJFabCalContractDtl
                    .FabCalContractDtlID = dgContract.Items(x).Cells(0).Text
                    If LFabCalMstID > 0 Then
                        .FabCalMstID = LFabCalMstID
                    Else
                        .FabCalMstID = OBJFabCalMst.GetID()
                    End If
                    .Contract = dgContract.Items(x).Cells(1).Text
                    .Price = dgContract.Items(x).Cells(2).Text
                    .Booked = dgContract.Items(x).Cells(3).Text
                    .DeliveryDate = dgContract.Items(x).Cells(4).Text
                    .Save()
                End With
            Next
        Catch ex As Exception
        End Try
    End Sub
    Sub savedtl()
        Try
            Dim x As Integer
            For x = 0 To dgDetail.Items.Count - 1
                With OBJFabCalDtl
                    .FabCalDtlId = dgDetail.Items(x).Cells(0).Text
                    If LFabCalMstID > 0 Then
                        .FabCalMstID = LFabCalMstID
                    Else
                        .FabCalMstID = OBJFabCalMst.GetID()
                    End If
                    .JobOrderId = dgDetail.Items(x).Cells(1).Text
                    .SeasonDatabaseId = dgDetail.Items(x).Cells(3).Text
                    .JobOrderDetailid = dgDetail.Items(x).Cells(2).Text
                    .Srno = dgDetail.Items(x).Cells(4).Text
                    .ORDERNO = dgDetail.Items(x).Cells(5).Text
                    .Color = dgDetail.Items(x).Cells(6).Text
                    .MODEL = dgDetail.Items(x).Cells(7).Text
                    .DESCRIPTION = dgDetail.Items(x).Cells(8).Text
                    .SIZES = dgDetail.Items(x).Cells(9).Text
                    .ExtraQty = dgDetail.Items(x).Cells(10).Text
                    .EstCon = dgDetail.Items(x).Cells(11).Text
                    .OrderCon = dgDetail.Items(x).Cells(12).Text
                    .ActCon = dgDetail.Items(x).Cells(13).Text
                    .FinalCon = dgDetail.Items(x).Cells(14).Text
                    .Actlpcs = dgDetail.Items(x).Cells(15).Text
                    .MulPercnt = dgDetail.Items(x).Cells(16).Text
                    .TotalPcs = dgDetail.Items(x).Cells(17).Text
                    .FabricReq = dgDetail.Items(x).Cells(18).Text
                    .TotalRequirement = dgDetail.Items(x).Cells(19).Text
                    .Save()
                End With
            Next
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnAddNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
        Try
            If txtBooked.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Booked")
            ElseIf txtPrice.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Price")
            ElseIf txtDeliveryDate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Delivery Date")
            ElseIf TXTContract.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Contract")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                SaveSessionContractDetail()
                BindContractGrid()
                ClearControlContract()
                btnSave.Visible = True
                btnCancel.Visible = True
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BindContractGrid()
        Try
            Dim objDatatble As DataTable
            objDatatble = Session("dtCalculation")
            dgContract.Visible = True
            dgContract.RecordCount = objDatatble.Rows.Count
            dgContract.DataSource = objDatatble
            dgContract.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Sub ClearControlContract()
        txtBooked.Text = ""
        txtPrice.Text = ""
        txtDeliveryDate.Text = ""
        TXTContract.Text = ""
    End Sub
    Sub SaveSessionContractDetail()
        If (Not CType(Session("dtCalculation"), DataTable) Is Nothing) Then
            dtCalculation = Session("dtCalculation")
        Else
            dtCalculation = New DataTable
            With dtCalculation
                .Columns.Add("FabCalContractDtlID", GetType(Long))
                .Columns.Add("Contract", GetType(String))
                .Columns.Add("Price", GetType(String))
                .Columns.Add("Booked", GetType(String))
                .Columns.Add("DeliveryDate", GetType(String))
            End With
        End If
        Dr = dtCalculation.NewRow()
        If lblFabricCaluctaionContractDtlID.Text = "" Then
            Dr("FabCalContractDtlID") = 0
        Else
            Dr("FabCalContractDtlID") = lblFabricCaluctaionContractDtlID.Text
        End If
        Dr("Contract") = TXTContract.Text
        Dr("Price") = txtPrice.Text
        Dr("Booked") = txtBooked.Text
        Dr("DeliveryDate") = txtDeliveryDate.Text
        dtCalculation.Rows.Add(Dr)
        Session("dtCalculation") = dtCalculation
    End Sub
    Sub BindBuyer()
        Try
            Dim dtItemCode As DataTable
            dtItemCode = ObjIMSStoreLedger.GetBindCustomerFROMfABRIC()
            cmbBuyer.DataSource = dtItemCode
            cmbBuyer.DataTextField = "CustomerName"
            cmbBuyer.DataValueField = "CustomerID"
            cmbBuyer.DataBind()
            cmbBuyer.Items.Insert(0, New RadComboBoxItem("Select", 0))
        Catch ex As Exception
        End Try
    End Sub
    Sub BindSeason()
        Dim dt As DataTable = ObjIssue.GetSeasonFromIssue()
        CMBSeason.DataSource = dt
        CMBSeason.DataValueField = "SeasonDatabaseId"
        CMBSeason.DataTextField = "SeasonName"
        CMBSeason.DataBind()
        cmbSeason.Items.Insert(0, New RadComboBoxItem("Select", 0))
    End Sub
    Sub BindSrNo()
        Dim dtt As DataTable = ObjIssue.GetSrNoFromIssueForAny()
        CMBSrNo.DataSource = dtt
        CMBSrNo.DataValueField = "JobOrderId"
        CMBSrNo.DataTextField = "SrNo"
        CMBSrNo.DataBind()
        cmbSrNo.Items.Insert(0, New RadComboBoxItem("Select", 0))
    End Sub
    Protected Sub CMBSeason_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbSeason.SelectedIndexChanged
        Try
            If txtDALNo.Text = "" Then
                Dim dtt As DataTable = ObjIssue.GetSrNoFromIssue(cmbSeason.SelectedValue)
                cmbSrNo.DataSource = dtt
                cmbSrNo.DataValueField = "JobOrderId"
                cmbSrNo.DataTextField = "SrNo"
                cmbSrNo.DataBind()
                cmbSrNo.Items.Insert(0, New RadComboBoxItem("Select", 0))
            Else
                Dim dtt As DataTable = ObjIssue.GetSrNoFromIssueForNew(cmbSeason.SelectedValue, txtDALNo.Text)
                cmbSrNo.DataSource = dtt
                cmbSrNo.DataValueField = "JobOrderId"
                cmbSrNo.DataTextField = "SrNo"
                cmbSrNo.DataBind()
                cmbSrNo.Items.Insert(0, New RadComboBoxItem("Select", 0))
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbSrNo_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbSrNo.SelectedIndexChanged
        Try
            Dim dt As DataTable = ObjIssue.GetCustomerOrderNoFromIssue(cmbSrNo.SelectedValue)
            txtORDERNO.Text = dt.Rows(0)("CustomerOrder")


            Dim dtt As DataTable = ObjIssue.GetStyleFromIssue(cmbSrNo.SelectedValue)
            cmbStyle.DataSource = dtt
            cmbStyle.DataValueField = "JobOrderDetailId"
            cmbStyle.DataTextField = "Style"
            cmbStyle.DataBind()
            cmbStyle.Items.Insert(0, New RadComboBoxItem("Select", 0))

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbStyle_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbStyle.SelectedIndexChanged
        Try
            Dim dt As DataTable = ObjIssue.GetDescriptionAndModelFromIssue(cmbStyle.SelectedValue)
            txtModel.Text = dt.Rows(0)("Model")
            txtDescription.Text = dt.Rows(0)("ItemDesc")
            txtTotalQuantity.Text = dt.Rows(0)("Quantity")
            txtColor.Text = dt.Rows(0)("BuyerColor")

            Dim dtT As DataTable = ObjIssue.GetSizessFromIssue(cmbStyle.SelectedValue)
            txtSize.Text = dtT.Rows(0)("SizeRange")
            txtExtraQuantity.Text = dtT.Rows(0)("ExtraQty")
            txtPercentRatio.Text = dtT.Rows(0)("PercentRatio")
           

            Dim dttT As DataTable = ObjIssue.GetCONSUMPTIONFromIssue(cmbStyle.SelectedValue)
            If dttT.Rows.Count > 0 Then
                txtConOne.Text = dttT.Rows(0)("EstCon")
                txtConTwo.Text = dttT.Rows(0)("OrderCon")
                txtConThree.Text = dttT.Rows(0)("ActCon")
                txtConfour.Text = 0
                txtFabricSupplier.Text = dttT.Rows(0)("Suppliername")
            Else
                txtConOne.Text = 0
                txtConTwo.Text = 0
                txtConThree.Text = 0
                txtConfour.Text = 0
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtDALNo_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtDALNo.TextChanged
        Dim dtItem As DataTable = objJobOrderdatabase.GetItemDataCodeNew(txtDALNo.Text)
        Dim dtItem2 As DataTable = objJobOrderdatabase.GetItemDataCodeForDalRefNo(txtDALNo.Text)
        If dtItem.Rows.Count > 0 Then
            txtConstrunctionn.Text = dtItem.Rows(0)("FabricQualityy")
            lblItemId.Text = dtItem.Rows(0)("IMSITemId")
        ElseIf dtItem2.Rows.Count > 0 Then
            txtConstrunctionn.Text = dtItem2.Rows(0)("FabricQualityy")
            lblItemId.Text = dtItem2.Rows(0)("IMSITemId")
        End If

        Dim dt As DataTable = objJobOrderdatabase.GetItemDataCodeNewForFabricCalculation(txtDALNo.Text)
        If dt.Rows.Count > 0 Then
            cmbSeason.DataSource = dt
            cmbSeason.DataValueField = "SeasonDatabaseId"
            cmbSeason.DataTextField = "SeasonName"
            cmbSeason.DataBind()
            'cmbSeason.Items.Insert(0, New RadComboBoxItem("Select", 0))
            Dim dtt As DataTable = objJobOrderdatabase.GetItemDataCodeNewForFabricCalculationAndSRNO(txtDALNo.Text, cmbSeason.SelectedValue)
            cmbSrNo.DataSource = dtt
            cmbSrNo.DataValueField = "JobOrderId"
            cmbSrNo.DataTextField = "SrNo"
            cmbSrNo.DataBind()
            cmbSrNo.Items.Insert(0, New RadComboBoxItem("Select", 0))
        End If
    End Sub
    Sub SaveSession()
        If (Not CType(Session("dtFabricCalculation"), DataTable) Is Nothing) Then
            dtFabricCalculation = Session("dtFabricCalculation")
        Else
            dtFabricCalculation = New DataTable
            With dtFabricCalculation
                .Columns.Add("FabCalDtlId", GetType(Long))
                .Columns.Add("JobOrderId", GetType(String))
                .Columns.Add("Srno", GetType(String))
                .Columns.Add("SeasonDatabaseId", GetType(String))
                .Columns.Add("JobOrderDetailid", GetType(String))
                .Columns.Add("ORDERNO", GetType(String))
                .Columns.Add("Color", GetType(String))
                .Columns.Add("MODEL", GetType(String))
                .Columns.Add("DESCRIPTION", GetType(String))
                .Columns.Add("SIZES", GetType(String))
                .Columns.Add("ExtraQty", GetType(String))
                .Columns.Add("EstCon", GetType(String))
                .Columns.Add("OrderCon", GetType(String))
                .Columns.Add("ActCon", GetType(String))
                .Columns.Add("FinalCon", GetType(String))
                .Columns.Add("Actlpcs", GetType(String))
                .Columns.Add("MulPercnt", GetType(String))
                .Columns.Add("TotalPcs", GetType(String))
                .Columns.Add("FabricReq", GetType(String))
                .Columns.Add("TotalRequirement", GetType(String))
            End With
        End If
        Dr = dtFabricCalculation.NewRow()
        If lblFabricCaluctaionDtlID.Text = "" Then
            Dr("FabCalDtlId") = 0
        Else
            Dr("FabCalDtlId") = lblFabricCaluctaionDtlID.Text
        End If
        Dr("JobOrderId") = cmbSrNo.SelectedValue
        Dr("SrNo") = cmbSrNo.SelectedItem.Text.ToUpper

        Dr("SeasonDatabaseId") = cmbSeason.SelectedValue
        Dr("JobOrderDetailid") = cmbStyle.SelectedValue
        Dr("ORDERNO") = txtORDERNO.Text.ToUpper
        Dr("Color") = txtColor.Text.ToUpper
        Dr("MODEL") = txtModel.Text.ToUpper

        Dr("DESCRIPTION") = txtDescription.Text.ToUpper
        Dr("SIZES") = txtSize.Text.ToUpper

        If txtPercentRatio.Text = "" Then
            Dr("ExtraQty") = 0
        Else
            Dr("ExtraQty") = txtPercentRatio.Text
        End If

        If txtConOne.Text = "" Then
            Dr("EstCon") = 0
        Else
            Dr("EstCon") = txtConOne.Text
        End If
        If txtConTwo.Text = "" Then
            Dr("OrderCon") = 0
        Else
            Dr("OrderCon") = txtConTwo.Text
        End If
        If txtConThree.Text = "" Then
            Dr("ActCon") = 0
        Else
            Dr("ActCon") = txtConThree.Text
        End If
        If txtConfour.Text = "" Then
            Dr("FinalCon") = 0
        Else
            Dr("FinalCon") = txtConfour.Text
        End If

        If txtTotalQuantity.Text = "" Then
            Dr("Actlpcs") = 0
        Else
            Dr("Actlpcs") = txtTotalQuantity.Text
        End If


        Dr("MulPercnt") = (Val(txtTotalQuantity.Text) * txtPercentRatio.Text) / 100

        If txtExtraQuantity.Text = "" Then
            Dr("TotalPcs") = 0
        Else
            Dr("TotalPcs") = txtExtraQuantity.Text
        End If
        If txtConfour.Text = "" Then
            Dr("FabricReq") = txtConfour.Text
        Else
            Dr("FabricReq") = Val(txtExtraQuantity.Text) * Val(txtConfour.Text)
        End If
        Dr("TotalRequirement") = Val(txtExtraQuantity.Text) * Val(txtConfour.Text)
        dtFabricCalculation.Rows.Add(Dr)
        Session("dtFabricCalculation") = dtFabricCalculation
    End Sub
    Private Sub BindGrid()
        Try
            Dim objDatatble As DataTable
            objDatatble = Session("dtFabricCalculation")
            dgDetail.Visible = True
            dgDetail.RecordCount = objDatatble.Rows.Count
            dgDetail.DataSource = objDatatble
            dgDetail.DataBind()

        Catch ex As Exception
        End Try
    End Sub
    Sub ClearControl()
        cmbSeason.SelectedValue = 0
        cmbSrNo.SelectedValue = 0
        txtFabricSupplier.Text = ""
        txtORDERNO.Text = ""
        cmbStyle.SelectedValue = 0
        txtModel.Text = ""
        txtDescription.Text = ""
        txtSize.Text = ""
        txtTotalQuantity.Text = ""
        txtExtraQuantity.Text = ""
        txtPercentRatio.Text = ""
        txtConOne.Text = ""
        txtConTwo.Text = ""
        txtConThree.Text = ""
        txtConfour.Text = ""
        txtColor.Text = ""
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            If cmbSrNo.SelectedItem.Text = "Select" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Sr No")
            ElseIf cmbStyle.SelectedItem.Text = "Select" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Style")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                SaveSession()
                BindGrid()
                ClearControl()
                btnSave.Visible = True
                btnCancel.Visible = True
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
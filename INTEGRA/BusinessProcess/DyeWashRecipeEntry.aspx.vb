Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Xml
Public Class DyeWashRecipeEntry
    Inherits System.Web.UI.Page
    Dim Dr As DataRow
    Dim dtDetail As DataTable
    Dim objDyeWashRecipeMst As New DyeWashRecipeMst
    Dim objDyeWashRecipeDtl As New DyeWashRecipeDtl
    Dim lDyeWashRecipeMstId As Long
    Dim ObjTblRND As New TblDPRND
    Dim ObjDPIMst As New DPIMst
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lDyeWashRecipeMstId = Request.QueryString("lDyeWashRecipeMstId")
        If Not Page.IsPostBack Then
            Session("dtDetail") = Nothing
            BindCustomer()
            BindUnit()
            BindSrno()
            If lDyeWashRecipeMstId > 0 Then
                Edit()
                btnSave.Text = "Update"
            Else
                btnSave.Text = "Save"
            End If

        End If
    End Sub
    Sub BindSrno()
        Try
            Dim dtcmbSrno As DataTable
            dtcmbSrno = objDyeWashRecipeMst.GetSrnoAndSeason()
            CMBIntOrdNo.DataSource = dtcmbSrno
            CMBIntOrdNo.DataTextField = "SRNOo"
            CMBIntOrdNo.DataValueField = "Joborderid"
            CMBIntOrdNo.DataBind()
            CMBIntOrdNo.Items.Insert(0, New RadComboBoxItem("Select", 0))

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtChemName_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtChemName.TextChanged
        Try
            Dim dt As DataTable = ObjTblRND.GetChemicalNameID(txtChemName.Text)
            If dt.Rows.Count > 0 Then
                lblChemPrID.Text = dt.Rows(0)("IMSItemID")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub Edit()
        Try
            Dim dt As DataTable = objDyeWashRecipeMst.GetEdit(lDyeWashRecipeMstId)

            txtRecipeNo.Text = dt.Rows(0)("RecipeNo")
            txtComp.Text = dt.Rows(0)("Composition")
            txtCreationDate.Text = dt.Rows(0)("CreationDate")
            txtColor.Text = dt.Rows(0)("Color")
            cmbCustomer.SelectedValue = dt.Rows(0)("CustomerID")
            CMBIntOrdNo.SelectedValue = dt.Rows(0)("JobID")
            BindStyle()
            cmbStyle.SelectedValue = dt.Rows(0)("StyleID")
            txtQtyPcs.Text = dt.Rows(0)("QtyPcs")
            txtMachine.Text = dt.Rows(0)("MachineID")
            txtCreationDate.Text = dt.Rows(0)("RecipeDate")

            dtDetail = New DataTable
            With dtDetail
                .Columns.Add("DyeWashRecipeDtlId", GetType(Long))
                .Columns.Add("ChemPrLotNo", GetType(String))
                .Columns.Add("ChemPrName", GetType(String))
                .Columns.Add("Unit", GetType(String))
                .Columns.Add("ItemUnitID", GetType(String))
                .Columns.Add("Qty", GetType(String))
                .Columns.Add("ChemPrID", GetType(String))

            End With
            Dim y As Integer
            For y = 0 To dt.Rows.Count - 1
                Dr = dtDetail.NewRow()
                Dr("DyeWashRecipeDtlId") = dt.Rows(y)("DyeWashRecipeDtlId")
                Dr("ChemPrLotNo") = dt.Rows(y)("ChemPrLotNo")
                Dr("ChemPrName") = dt.Rows(y)("ChemPrName")
                Dr("Unit") = dt.Rows(y)("Symbol")
                Dr("Qty") = dt.Rows(y)("Qty")
                Dr("ChemPrID") = dt.Rows(y)("ChemPrID")
                Dr("ItemUnitID") = dt.Rows(y)("ItemUnitID")
                dtDetail.Rows.Add(Dr)
            Next
            Session("dtDetail") = dtDetail
            BindDetailGrid()

        Catch ex As Exception

        End Try
    End Sub
    Sub BindCustomer()
        Try
            Dim dt As DataTable
            dt = objDyeWashRecipeMst.GetCustomer
            cmbCustomer.DataSource = dt
            cmbCustomer.DataTextField = "CustomerName"
            cmbCustomer.DataValueField = "CustomerID"
            cmbCustomer.DataBind()

        Catch ex As Exception
        End Try
    End Sub
    Sub BindStyle()
        Dim dt As DataTable
        dt = objDyeWashRecipeMst.GetStyle(CMBIntOrdNo.SelectedValue)
        cmbStyle.DataSource = dt
        cmbStyle.DataTextField = "Style"
        cmbStyle.DataValueField = "JobOrderDetailID"
        cmbStyle.DataBind()
        cmbStyle.Items.Insert(0, New RadComboBoxItem("Select", 0))
    End Sub
    Sub BindUnit()
        Dim dt As DataTable
        dt = objDyeWashRecipeMst.GetUnit
        cmbUnit.DataSource = dt
        cmbUnit.DataTextField = "Symbol"
        cmbUnit.DataValueField = "ItemUnitID"
        cmbUnit.DataBind()
    End Sub
    Protected Sub cmbIntOrdNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CMBIntOrdNo.SelectedIndexChanged
        Try
            BindStyle()
        Catch ex As Exception

        End Try
    End Sub
   Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            If txtRecipeNo.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("RecipeNo Empty")
            ElseIf txtComp.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Composition Empty")

            ElseIf txtCreationDate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Date")
            ElseIf txtColor.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Color Empty")
            ElseIf CMBIntOrdNo.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Internal Order No")
            ElseIf cmbStyle.SelectedItem.Text = "Select" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Style")
            ElseIf txtMachine.Text = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("MachineID Empty")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                saveMst()
                SaveDtl()

                Response.Redirect("DyeWashRecipeView.aspx")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveSessionDetailGrid()


        If (Not CType(Session("dtDetail"), DataTable) Is Nothing) Then
            dtDetail = Session("dtDetail")
        Else
            dtDetail = New DataTable
            With dtDetail
                .Columns.Add("DyeWashRecipeDtlId", GetType(Long))
                .Columns.Add("ChemPrLotNo", GetType(String))
                .Columns.Add("ChemPrName", GetType(String))
                .Columns.Add("Unit", GetType(String))
                .Columns.Add("Qty", GetType(String))
                .Columns.Add("ChemPrID", GetType(String))
                .Columns.Add("ItemUnitId", GetType(String))

            End With
        End If

        Dr = dtDetail.NewRow()
        Dr("DyeWashRecipeDtlId") = 0
        If txtChPrlot.Text = "" Then
            Dr("ChemPrLotNo") = " "
        Else
            Dr("ChemPrLotNo") = txtChPrlot.Text
        End If
        If txtChemName.Text = "" Then
            Dr("ChemPrName") = " "
        Else
            Dr("ChemPrName") = txtChemName.Text
        End If
        If cmbUnit.SelectedItem.Text = "" Then
            Dr("Unit") = " "
        Else
            Dr("Unit") = cmbUnit.SelectedItem.Text
        End If
        If txtQty.Text = "" Then
            Dr("Qty") = " "
        Else
            Dr("Qty") = txtQty.Text
        End If
        Dr("ChemPrID") = lblChemPrID.Text
        Dr("ItemUnitId") = cmbUnit.SelectedValue
        dtDetail.Rows.Add(Dr)
        Session("dtDetail") = dtDetail
        BindDetailGrid()
        Clear()
    End Sub
    Sub Clear()
        txtChPrlot.Text = ""
        txtChemName.Text = ""
        txtQty.Text = ""
        lblChemPrID.Text = ""
    End Sub
    Protected Sub BtnDetail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnDetail.Click
        Try
            SaveSessionDetailGrid()
        Catch ex As Exception
        End Try
    End Sub
    Sub BindDetailGrid()
        If dtDetail.Rows.Count > 0 Then
            DgDetail.DataSource = dtDetail
            DgDetail.DataBind()
            DgDetail.Visible = True
        Else
            DgDetail.Visible = False
        End If
    End Sub
    Protected Sub btncancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btncancel.Click
        Response.Redirect("DyeWashRecipeView.aspx")
    End Sub
    Protected Sub cmbStyle_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbStyle.SelectedIndexChanged
        Try
            Dim dt As DataTable
            dt = objDyeWashRecipeMst.GetQty(CMBIntOrdNo.SelectedValue, cmbStyle.SelectedValue)
            If dt.Rows.Count > 0 Then
                txtQtyPcs.Text = dt.Rows(0)("Quantity")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub saveMst()
        Try
            With objDyeWashRecipeMst
                If lDyeWashRecipeMstId > 0 Then
                    .DyeWashRecipeMstId = lDyeWashRecipeMstId
                Else
                    .DyeWashRecipeMstId = 0
                End If
                .RecipeNo = txtRecipeNo.Text
                .Composition = txtComp.Text
                .CreationDate = Date.Now ' txtCreationDate.Text
                .Color = txtColor.Text
                .CustomerID = cmbCustomer.SelectedValue
                .IntOrdNo = CMBIntOrdNo.SelectedItem.Text
                .StyleID = cmbStyle.SelectedValue
                .QtyPcs = txtQtyPcs.Text
                .MachineID = txtMachine.Text
                .JobID = CMBIntOrdNo.SelectedValue
                .RecipeDate = txtCreationDate.Text
                .SaveMst()
            End With

        Catch ex As Exception

        End Try
    End Sub
    Sub SaveDtl()
        Try
            Dim x As Integer
            For x = 0 To DgDetail.Items.Count - 1
                Dim item As GridDataItem = DirectCast(DgDetail.MasterTableView.Items(x), GridDataItem)
                With objDyeWashRecipeDtl
                    .DyeWashRecipeDtlId = item("DyeWashRecipeDtlId").Text

                    If lDyeWashRecipeMstId > 0 Then
                        .DyeWashRecipeMstId = lDyeWashRecipeMstId
                    Else
                        .DyeWashRecipeMstId = objDyeWashRecipeMst.GetCurrentId
                    End If
                    .ChemPrID = item("ChemPrID").Text.ToUpper
                    .ChemPrLotNo = item("ChemPrLotNo").Text.ToUpper
                    .ChemPrName = item("ChemPrName").Text.ToUpper
                    .ItemUnitID = item("ItemUnitID").Text.ToUpper
                    .Qty = item("Qty").Text.ToUpper
                    .Savedtl()
                End With
            Next
        Catch ex As Exception

        End Try
    End Sub
End Class
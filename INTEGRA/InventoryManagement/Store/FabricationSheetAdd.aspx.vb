Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Xml
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Public Class FabricationSheetAdd
    Inherits System.Web.UI.Page
    Dim ObjFabricationSheetmst As New FabricationSheetMst
    Dim ObjFabricationSheetDtl As New FabricationSheetDtl
    Dim DtDetail As New DataTable
    Dim Dr As DataRow
    Dim FabricationSheetMstID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FabricationSheetMstID = Request.QueryString("FabricationSheetMstID")
        If Not Page.IsPostBack Then
            Session("DtDetail") = Nothing
            BinItemCode()
            If FabricationSheetMstID > 0 Then
                Edit()
                btnSave.Text = "Update"
            Else
                btnSave.Text = "Save"
                'BinItemCode()
            End If
        End If
    End Sub
    Sub Edit()
        Try
            Dim dt As DataTable
            dt = ObjFabricationSheetmst.Edit(FabricationSheetMstID)
            txtDate.Text = dt.Rows(0)("FabricDate")
            txtReference.Text = dt.Rows(0)("ReferenceNo")
            txtBuyer.Text = dt.Rows(0)("Buyer")
            'txtTotalOrderQty.Text = dt.Rows(0)("TotalOrderQty")
            txtPONumber.Text = dt.Rows(0)("PONumber")
            txtItem.Text = dt.Rows(0)("Item")
            DtDetail = New DataTable
            With DtDetail
                .Columns.Add("FabricationSheetDtlID", GetType(Long))
                .Columns.Add("FabricIMSItemID", GetType(String))
                .Columns.Add("StyleNo", GetType(String))
                .Columns.Add("Fabric", GetType(String))
                .Columns.Add("FabricCode", GetType(String))
                .Columns.Add("Wash", GetType(String))
                .Columns.Add("OrderQty", GetType(String))
                .Columns.Add("Consumption", GetType(String))
                .Columns.Add("QtyInMtr", GetType(String))
                .Columns.Add("Size", GetType(String))
                .Columns.Add("Percent", GetType(String))

            End With
            '  End If
            Dim x As Integer
            For x = 0 To dt.Rows.Count - 1


                Dr = DtDetail.NewRow()
                Dr("FabricationSheetDtlID") = dt.Rows(x)("FabricationSheetDtlID")
                Dr("FabricIMSItemID") = dt.Rows(x)("FabricIMSItemID")
                Dr("Fabric") = dt.Rows(0)("ItemName")
                Dr("StyleNo") = dt.Rows(x)("StyleNo")
                Dr("FabricCode") = dt.Rows(x)("FabricCode")
                Dr("Wash") = dt.Rows(x)("Wash")
                Dr("OrderQty") = dt.Rows(x)("OrderQty")
                Dr("Consumption") = dt.Rows(x)("Consumption")
                Dr("QtyInMtr") = dt.Rows(x)("QtyInMtr")
                Dr("Size") = dt.Rows(x)("Size")
                Dr("Percent") = dt.Rows(x)("Percent")


                DtDetail.Rows.Add(Dr)
            Next
            Session("DtDetail") = DtDetail
            BindGrid()

        Catch ex As Exception

        End Try
    End Sub
    Sub BinItemCode()
        Dim dt As DataTable
        dt = ObjFabricationSheetmst.GetItemName()
        cmbFabricName.DataSource = dt
        cmbFabricName.DataTextField = "ItemName"
        cmbFabricName.DataValueField = "IMSItemID"
        cmbFabricName.DataBind()
        cmbFabricName.Items.Insert(0, New ListItem("Select", "0"))

    End Sub

    Protected Sub btnAddDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddDetail.Click
        Try
            If txtStyleNo.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("StyleNo Empty.")
            ElseIf cmbFabricName.SelectedValue = "Select" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" Select FabricName.")
            ElseIf txtFabricCode.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("FabricCode Empty.")
            ElseIf txtWash.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Wash Empty.")
            ElseIf txtOrderQty.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Order Qty Empty.")
            ElseIf txtConsumption.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Consumption Empty.")
            ElseIf txtPercent.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("% Percent Empty.")
            ElseIf txtSize.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Size Empty.")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                SaveSession()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveSession()
        If (Not CType(Session("DtDetail"), DataTable) Is Nothing) Then
            DtDetail = Session("DtDetail")
        Else

            DtDetail = New DataTable
            With DtDetail
                .Columns.Add("FabricationSheetDtlID", GetType(Long))
                .Columns.Add("FabricIMSItemID", GetType(String))
                .Columns.Add("StyleNo", GetType(String))
                .Columns.Add("Fabric", GetType(String))
                .Columns.Add("FabricCode", GetType(String))
                .Columns.Add("Wash", GetType(String))
                .Columns.Add("OrderQty", GetType(String))
                .Columns.Add("Consumption", GetType(String))
                .Columns.Add("QtyInMtr", GetType(String))
                .Columns.Add("Size", GetType(String))
                .Columns.Add("Percent", GetType(String))

            End With
        End If
        Dr = DtDetail.NewRow()
        Dr("FabricationSheetDtlID") = 0
        Dr("FabricIMSItemID") = cmbFabricName.SelectedValue
        Dr("Fabric") = cmbFabricName.SelectedItem.Text
        Dr("StyleNo") = txtStyleNo.Text
        Dr("FabricCode") = txtFabricCode.Text
        Dr("Wash") = txtWash.Text
        Dr("OrderQty") = txtOrderQty.Text
        Dr("Consumption") = txtConsumption.Text
        Dr("QtyInMtr") = txtQtyInMtr.Text
        Dr("Size") = txtSize.Text
        Dr("Percent") = txtPercent.Text


        DtDetail.Rows.Add(Dr)
        Session("DtDetail") = DtDetail
        BindGrid()
        ClearControls()
    End Sub
    Private Sub BindGrid()
        Try
            Dim objDatatble As DataTable
            objDatatble = Session("DtDetail")
            If objDatatble.Rows.Count > 0 Then
                dgView.Visible = True
                dgView.RecordCount = objDatatble.Rows.Count
                dgView.DataSource = objDatatble
                dgView.DataBind()
            Else
                dgView.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub ClearControls()
        txtStyleNo.Text = ""
        txtFabricCode.Text = ""
        txtWash.Text = ""
        txtOrderQty.Text = ""
        txtConsumption.Text = ""
        txtQtyInMtr.Text = ""
        txtSize.Text = ""
        txtPercent.Text = ""
        cmbFabricName.SelectedValue = 0
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If txtDate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Date.")
            ElseIf txtReference.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" Reference Empty.")
            ElseIf txtBuyer.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" Buyer Empty.")
            ElseIf txtPONumber.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" PONumber Empty.")
            ElseIf txtItem.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" Item Empty.")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                Save()
                Response.Redirect("FabricationSheetView.aspx")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub Save()
        Try
            With ObjFabricationSheetmst
                If FabricationSheetMstID > 0 Then
                    .FabricationSheetMstID = FabricationSheetMstID
                Else
                    .FabricationSheetMstID = 0
                End If

                .FabricDate = txtDate.Text
                .ReferenceNo = txtReference.Text
                .Buyer = txtBuyer.Text
                ' .TotalOrderQty = txtTotalOrderQty.Text
                .PONumber = txtPONumber.Text
                .Item = txtItem.Text
                .SaveFabricationSheetMst()

            End With
            Dim x As Integer
            For x = 0 To dgView.Items.Count - 1
                With ObjFabricationSheetDtl
                    .FabricationSheetDtlID = dgView.Items(x).Cells(0).Text
                    If FabricationSheetMstID > 0 Then
                        .FabricationSheetMstID = FabricationSheetMstID
                    Else
                        .FabricationSheetMstID = ObjFabricationSheetmst.GetID
                    End If

                    .FabricIMSItemID = dgView.Items(x).Cells(1).Text
                    .StyleNo = dgView.Items(x).Cells(2).Text
                    .FabricCode = dgView.Items(x).Cells(4).Text
                    .Wash = dgView.Items(x).Cells(5).Text
                    .OrderQty = dgView.Items(x).Cells(6).Text
                    .Consumption = dgView.Items(x).Cells(7).Text
                    .Percent = dgView.Items(x).Cells(10).Text
                    .QtyInMtr = dgView.Items(x).Cells(8).Text
                    .Size = dgView.Items(x).Cells(9).Text
                    .SaveFabricationSheetDtl()
                End With
            Next

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("FabricationSheetView.aspx")
    End Sub

    Protected Sub cmbFabricName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFabricName.SelectedIndexChanged
        Try
            Dim dt As New DataTable
            dt = ObjFabricationSheetmst.GetItemCode(cmbFabricName.SelectedValue)
            If dt.Rows.Count > 0 Then
                txtFabricCode.Text = dt.Rows(0)("ItemCode").ToString()
            Else

            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub txtPercent_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPercent.TextChanged
        Try
            Dim QtyMeter As Decimal
            Dim QtyPer As Decimal
            Dim QtyInMtr As Decimal

            QtyMeter = Val(txtOrderQty.Text) * Val(txtConsumption.Text)
            QtyPer = QtyMeter
            QtyInMtr = Val(QtyPer) * Val(txtPercent.Text) / 100
            txtQtyInMtr.Text = Val(QtyMeter) + Val(QtyInMtr)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub dgView_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgView.ItemCommand
        Try
            Select Case e.CommandName
                Case "Remove"
                    DtDetail = CType(Session("DtDetail"), DataTable)
                    If (Not DtDetail Is Nothing) Then
                        If (DtDetail.Rows.Count > 0) Then
                            Dim FabricationSheetDtlID As Integer = DtDetail.Rows(e.Item.ItemIndex)("FabricationSheetDtlID")
                            DtDetail.Rows.RemoveAt(e.Item.ItemIndex)
                            ObjFabricationSheetmst.DeleteDetail(FabricationSheetDtlID)
                            BindGrid()
                            If DtDetail.Rows.Count = 0 Then
                                dgView.Visible = False
                            End If
                        Else
                            dgView.Visible = False
                        End If
                    End If

            End Select
        Catch ex As Exception

        End Try
    End Sub
End Class

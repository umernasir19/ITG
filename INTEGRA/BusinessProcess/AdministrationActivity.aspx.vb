Imports System.Data
Imports Integra.EuroCentra
Imports Telerik.Web.UI
Imports System.IO
Public Class AdministrationActivity
    Inherits System.Web.UI.Page
    Dim objAdminAct As New AdministrationActivities
    Dim DtGrid As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            pnlAuthentication.Visible = True
            cmbaction.Visible = False
            txtSearch.Visible = False
            btnSearch.Visible = False
            dgAdminitrationAct.Visible = False
        End If
    End Sub
    Sub BindGrid()
        Try
            Dim PONO As String = txtSearch.Text
            If txtSearch.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                dgAdminitrationAct.Visible = False
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                dgAdminitrationAct.Visible = True
                If cmbaction.SelectedItem.Text = "Revised Original Shipment Date" Then
                    dgAdminitrationAct.Columns(11).Visible = False
                    dgAdminitrationAct.Columns(10).Visible = True
                    dgAdminitrationAct.Columns(12).Visible = True
                    dgAdminitrationAct.Visible = True
                    Dim dtBindGrid As New DataTable
                    dtBindGrid = objAdminAct.GetGridData(PONO)
                    Session("dtBindGrid") = dtBindGrid
                    dgAdminitrationAct.DataSource = dtBindGrid
                    dgAdminitrationAct.DataBind()
                ElseIf cmbaction.SelectedItem.Text = "Delete Purchase Order" Then
                    dgAdminitrationAct.Columns(11).Visible = True
                    dgAdminitrationAct.Columns(10).Visible = False
                    dgAdminitrationAct.Columns(12).Visible = False

                    dgAdminitrationAct.Visible = True
                    Dim dtBindGrid As New DataTable
                    dtBindGrid = objAdminAct.GetGridData(PONO)
                    Session("dtBindGrid") = dtBindGrid
                    dgAdminitrationAct.DataSource = dtBindGrid
                    dgAdminitrationAct.DataBind()
                    Dim a As Integer
                    For a = 0 To dgAdminitrationAct.Items.Count - 1
                        Dim item As GridDataItem = DirectCast(dgAdminitrationAct.MasterTableView.Items(a), GridDataItem)
                        Dim lblInShipment As Label = CType(dgAdminitrationAct.Items(a).FindControl("lblInShipment"), Label)
                        Dim lnkDelete As LinkButton = CType(dgAdminitrationAct.Items(a).FindControl("lnkDelete"), LinkButton)
                        If lblInShipment.Text = "Yes" Then
                            lnkDelete.Enabled = False
                        Else
                            lnkDelete.Enabled = True
                        End If
                    Next
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        BindGrid()
    End Sub
    Protected Sub dgAdminitrationAct_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgAdminitrationAct.ItemCommand
        Select Case e.CommandName
            Case Is = "Remove"
                Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                DtGrid = CType(Session("dtBindGrid"), DataTable)

                If (Not DtGrid Is Nothing) Then
                    If (DtGrid.Rows.Count > 0) Then
                        Dim lPOID As Integer = item("POID").Text
                        DtGrid.Rows.RemoveAt(e.Item.ItemIndex)
                        objAdminAct.DeleteTNA(lPOID)
                        objAdminAct.DeleteTNAChart(lPOID)
                        objAdminAct.DeletePurchaseOrderDetail(lPOID)
                        objAdminAct.DeletePurchaseOrder(lPOID)
                        BindGrid()
                    End If
                End If
            Case Is = "Revised"

                DtGrid = CType(Session("dtBindGrid"), DataTable)
                If (Not DtGrid Is Nothing) Then
                    If (DtGrid.Rows.Count > 0) Then
                        Dim a As Integer
                        Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                        Dim lblNewShipmentDate As RadDatePicker = CType(item.FindControl("dpNewShipmentDate"), RadDatePicker)

                        Dim lPOID As Integer = item("POID").Text
                        Dim NewShipmentDate As DateTime = lblNewShipmentDate.SelectedDate
                        Dim NshipmentDate As String = NewShipmentDate
                        Dim ShipmentDate As DateTime = item("ShipmentDatee").Text
                        Dim ShipmentDates As String = ShipmentDate
                        If NshipmentDate = ShipmentDates Then
                            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Original Shipment date and New Shipment date are equal Please Select Different One.")
                        Else

                            objAdminAct.UpdateShipmentDate(NewShipmentDate, lPOID)
                            objAdminAct.UpdatePOShipmentDate(NewShipmentDate, lPOID)
                            Dim objPOOSDH As New PurchaseOrderOriginalShipmentDatehistory
                            With objPOOSDH
                                .POOSDHID = 0
                                .POID = lPOID
                                .CreationDate = Today.Date
                                .SavePurchaseOrderOriginalShipmentDateHistory()
                            End With
                            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Original Shipment Date Changed. ")
                            BindGrid()
                        End If

                    End If
                End If

        End Select

    End Sub
    Protected Sub btnAuthentication_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAuthentication.Click
        If txtAuthentication.Text = "ITGPK" Then
            lblmsg.Text = " "
            cmbaction.Visible = True
            txtSearch.Visible = True
            btnSearch.Visible = True
            dgAdminitrationAct.Visible = True
            pnlAuthentication.Visible = False
        Else
            lblmsg.Text = "Invalid Authentication Code"
            cmbaction.Visible = False
            txtSearch.Visible = False
            btnSearch.Visible = False
            dgAdminitrationAct.Visible = False
        End If
    End Sub
End Class
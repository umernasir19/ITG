Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class CostControlAc2
    Inherits System.Web.UI.Page
    Dim lJobOrderID, lJoborderDetailid, lStyleAssortmentMasterID As Long
    Dim jOBdT, dtDetail, dtAccCheckListDetail, dtAccCheckListThreasDtl, dtAccCheckListZipperDtl As DataTable
    Dim objAccCheckListCostMst As New AccCheckListCostMst
    Dim objAccCheekListCostDetail As New AccCheekListCostDetail
    Dim objThreadCheckCostList As New ThreadCheckCostList
    Dim objZipperCheckListCostDetail As New ZipperCheckListCostDetail
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lJobOrderID = Request.QueryString("JobOrderID")
        If Not Page.IsPostBack Then
            Session("dtAccCheckListDetail") = Nothing
            Session("dtAccCheckListThreasDtl") = Nothing
            Session("dtAccCheckListZipperDtl") = Nothing
            FillMasterdate()
            txtDate.Text = Date.Now
            Dim dtedit As DataTable = objAccCheckListCostMst.GetEdit(lJobOrderID)
            If dtedit.Rows.Count > 0 Then
                lblAccChecklistCostMstId.Text = dtedit.Rows(0)("AccCheckListCostMstID")
                txtDate.Text = dtedit.Rows(0)("CheckDate")
            End If
            Dim dtacc As DataTable = objAccCheekListCostDetail.GetAccDtlEdit(lJobOrderID)
            If dtacc.Rows.Count > 0 Then
                dtAccCheckListDetail = dtacc
                Session("dtAccCheckListDetail") = dtacc
                BindAccessGrid()
            Else
                AccessDtlCheckList()
            End If
            Dim dthread As DataTable = objThreadCheckCostList.GetAccThreadDtlEdit(lJobOrderID)
            If dthread.Rows.Count > 0 Then
                dtAccCheckListThreasDtl = dthread
                Session("dtAccCheckListThreasDtl") = dthread
                BindAccessThreadGrid()
            Else
                ThreadDtl()
            End If


            Dim dtZipper As DataTable = objThreadCheckCostList.GetAccZipperDtlEdit(lJobOrderID)
            If dtZipper.Rows.Count > 0 Then
                dtAccCheckListZipperDtl = dtZipper
                Session("dtAccCheckListZipperDtl") = dtZipper
                BindAccessZipperGrid()
            Else
                ZipperDtl()
            End If

        End If
    End Sub
    Sub ZipperDtl()
        Dim dtZipperDtl As DataTable = objAccCheckListCostMst.GetAccZipperDtl(lJobOrderID)
        If dtZipperDtl.Rows.Count > 0 Then
            dtAccCheckListZipperDtl = dtZipperDtl
            Session("dtAccCheckListZipperDtl") = dtZipperDtl
            BindAccessZipperGrid()
        End If
    End Sub
    Sub BindAccessZipperGrid()
        Try
            If dtAccCheckListZipperDtl.Rows.Count > 0 Then
                dgAccCheckListZipper.DataSource = dtAccCheckListZipperDtl
                dgAccCheckListZipper.DataBind()
                dgAccCheckListZipper.Visible = True
            Else
                dgAccCheckListZipper.Visible = False
            End If

        Catch ex As Exception

        End Try

    End Sub
    Sub AccessDtlCheckList()
        Dim dtAccsDtl As DataTable = objAccCheckListCostMst.GetAccDtlNew(lJobOrderID)
        If dtAccsDtl.Rows.Count > 0 Then
            dtAccCheckListDetail = dtAccsDtl
            Session("dtAccCheckListDetail") = dtAccsDtl
            BindAccessGrid()
        End If

    End Sub
    Sub ThreadDtl()
        Dim dtThreadDtl As DataTable = objAccCheckListCostMst.GetAccThreadDtl(lJobOrderID)
        If dtThreadDtl.Rows.Count > 0 Then
            dtAccCheckListThreasDtl = dtThreadDtl
            Session("dtAccCheckListThreasDtl") = dtThreadDtl
            BindAccessThreadGrid()
        End If
    End Sub
    Sub BindAccessThreadGrid()
        Try
            If dtAccCheckListThreasDtl.Rows.Count > 0 Then
                dgAccCheckListThread.DataSource = dtAccCheckListThreasDtl
                dgAccCheckListThread.DataBind()
                dgAccCheckListThread.Visible = True
            Else

                dgAccCheckListThread.Visible = False
            End If

        Catch ex As Exception

        End Try

    End Sub
    Sub BindAccessGrid()
        Try
            If dtAccCheckListDetail.Rows.Count > 0 Then
                dgAccCheckList.DataSource = dtAccCheckListDetail
                dgAccCheckList.DataBind()
                dgAccCheckList.Visible = True

                Dim x As Integer = 0
                For x = 0 To dgAccCheckList.Items.Count - 1
                    Dim lblItemID As Label = DirectCast(dgAccCheckList.Items(x).FindControl("lblItemID"), Label)
                    Dim lblItemCategoryID As Label = DirectCast(dgAccCheckList.Items(x).FindControl("lblItemCategoryID"), Label)
                    Dim txtItemCode As TextBox = DirectCast(dgAccCheckList.Items(x).FindControl("txtItemCode"), TextBox)

                    txtItemCode.Text = dtAccCheckListDetail.Rows(x)("ItemCodee")
                    lblItemID.Text = dtAccCheckListDetail.Rows(x)("IMSItemId")
                    lblItemCategoryID.Text = dtAccCheckListDetail.Rows(x)("IMSItemCategoryID")


                Next

            Else

                dgAccCheckList.Visible = False
            End If

        Catch ex As Exception

        End Try

    End Sub
    Sub FillMasterdate()
        jOBdT = objAccCheckListCostMst.GetJobOrderData(lJobOrderID)
        If jOBdT.Rows.Count > 0 Then
            txtJobOrder.Text = jOBdT.Rows(0)("SRNO")
            'txtstyle.Text = jOBdT.Rows(0)("style")
            txtBuyer.Text = jOBdT.Rows(0)("CustomerName")
            '   txtItem.Text = jOBdT.Rows(0)("ItemName")
            txtQty.Text = jOBdT.Rows(0)("Qty")
            txtShipDate.Text = jOBdT.Rows(0)("ShipmentDate")
        End If



    End Sub

    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnsave.Click
        Try
            If txtDate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Date Empty")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                saveAccCheckListCostmaster()
                SaveAccCheckListDetail()
                SaveThreadCheckListDetail()
                SaveAccCheckListZipperDetail()
                Response.Redirect("JobOrderDatabaseView.aspx")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub saveAccCheckListCostmaster()
        With objAccCheckListCostMst
            If Val(lblAccChecklistCostMstId.Text) > 0 Then
                .AccCheckListCostMstID = lblAccChecklistCostMstId.Text
            Else
                .AccCheckListCostMstID = 0
            End If
            .JoborderID = lJobOrderID
            .CheckDate = txtDate.Text
            .CreationDate = Date.Now
            .SaveAccCheckListMst()
        End With
    End Sub
    Sub SaveAccCheckListDetail()
        Try
            Dim x As Integer = 0
            For x = 0 To dgAccCheckList.Items.Count - 1
                Dim txtUnitPrice As TextBox = DirectCast(dgAccCheckList.Items(x).FindControl("txtUnitPrice"), TextBox)
                With objAccCheekListCostDetail
                    .AccCheckListCostDetailID = dgAccCheckList.Items(x).Cells(0).Text
                    .AccCheckListDetailID = dgAccCheckList.Items(x).Cells(1).Text
                    If txtUnitPrice.Text = "" Then
                        .UnitPrice = 0
                    Else
                        .UnitPrice = txtUnitPrice.Text
                    End If
                    .JobOrderID = lJobOrderID
                    If Val(lblAccChecklistCostMstId.Text) > 0 Then
                        .AccCheckListCostMstID = lblAccChecklistCostMstId.Text
                    Else
                        .AccCheckListCostMstID = objAccCheckListCostMst.GetID
                    End If
                    .SaveAccCheckListCostDetail()
                End With
            Next

        Catch ex As Exception

        End Try

    End Sub
    Sub SaveThreadCheckListDetail()
        Try
            Dim x As Integer = 0
            For x = 0 To dgAccCheckListThread.Items.Count - 1
                Dim txtThreadUnitPrice As TextBox = DirectCast(dgAccCheckListThread.Items(x).FindControl("txtThreadUnitPrice"), TextBox)
                With objThreadCheckCostList
                    .ThreadCheckCostListID = dgAccCheckListThread.Items(x).Cells(0).Text
                    If Val(lblAccChecklistCostMstId.Text) > 0 Then
                        .AccCheckListCostMstID = lblAccChecklistCostMstId.Text
                    Else
                        .AccCheckListCostMstID = objAccCheckListCostMst.GetID
                    End If
                    If txtThreadUnitPrice.Text = "" Then
                        .UnitPrice = 0
                    Else
                        .UnitPrice = txtThreadUnitPrice.Text
                    End If
                    .ThreadCheckListID = dgAccCheckListThread.Items(x).Cells(1).Text
                    .JobOrderID = lJobOrderID
                    .SaveThreadCheckListCostDetail()
                End With
            Next

        Catch ex As Exception

        End Try

    End Sub
    Sub SaveAccCheckListZipperDetail()
        Try
            Dim x As Integer = 0
            For x = 0 To dgAccCheckListZipper.Items.Count - 1
                Dim txtUnitPrice As TextBox = DirectCast(dgAccCheckListZipper.Items(x).FindControl("txtUnitPrice"), TextBox)
                With objZipperCheckListCostDetail
                    .ZipperCheckListCostDetailID = dgAccCheckListZipper.Items(x).Cells(0).Text
                    .ZipperCheckListDetailID = dgAccCheckListZipper.Items(x).Cells(1).Text
                    If txtUnitPrice.Text = "" Then
                        .UnitPrice = 0
                    Else
                        .UnitPrice = txtUnitPrice.Text
                    End If
                    .JobOrderID = lJobOrderID
                    If Val(lblAccChecklistCostMstId.Text) > 0 Then
                        .AccCheckListCostMstID = lblAccChecklistCostMstId.Text
                    Else
                        .AccCheckListCostMstID = objAccCheckListCostMst.GetID
                    End If
                    .SaveAccCheckListCostDetail()
                End With
            Next

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("JobOrderDatabaseView.aspx")
        Catch ex As Exception

        End Try
    End Sub
End Class
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
Public Class BuyerEntry
    Inherits System.Web.UI.Page
    Dim objBuyer As New Buyer
    Dim BuyerID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BuyerID = Request.QueryString("BuyerID")
        If Not Page.IsPostBack Then
            If BuyerID > 0 Then
                EditModes()
                btnSave.Text = "Update"
            Else
                btnSave.Text = "Save"

            End If
        End If
    End Sub
    Sub EditModes()
        Try
            Dim dt As DataTable
            dt = objBuyer.GetAll(BuyerID)
            txtBuyerName.Text = dt.Rows(0)("BuyerName")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            Dim dtChk As New DataTable
            dtChk = objBuyer.checkBuyer(txtBuyerName.Text)
            If txtBuyerName.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Buyer Name Empty.")
            Else
                If BuyerID > 0 Then
                    SaveBuyer()
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                    Response.Redirect("BuyerView.aspx")
                Else
                    If dtChk.Rows.Count > 0 Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Buyer Name: " & txtBuyerName.Text & " Already Exist In Database.")
                    Else
                        SaveBuyer()
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                        Response.Redirect("BuyerView.aspx")
                    End If
                   
                End If

               
            End If

        Catch ex As Exception

        End Try
    End Sub
    Sub SaveBuyer()
        Try
            With objBuyer
                If BuyerID > 0 Then
                    .BuyerID = BuyerID
                Else
                    .BuyerID = 0
                End If
                .BuyerName = txtBuyerName.Text
                .SaveBuyer()
            End With
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("BuyerView.aspx")
        Catch ex As Exception

        End Try
    End Sub


End Class
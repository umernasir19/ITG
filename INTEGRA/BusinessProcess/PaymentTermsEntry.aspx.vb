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
Public Class PaymentTermsEntry
    Inherits System.Web.UI.Page
    Dim objPORelatedFields As New PORelatedFields
    Dim ID As Long

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ID = Request.QueryString("ID")
        If Not Page.IsPostBack Then
            If ID > 0 Then
                EditModes()
            Else

            End If
        End If
    End Sub
    Sub EditModes()
        Try
            Dim dt As DataTable
            dt = objPORelatedFields.GetPaymentTermForEdit(ID)
            txtPaymentTermName.Text = dt.Rows(0)("Name")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            If txtPaymentTermName.Text = "" Then

            Else
                With objPORelatedFields
                    .ID = ID
                    .Name = txtPaymentTermName.Text
                    .Type = "Payment Type"
                    .IsActive = 1
                    .Save()
                End With

                Response.Redirect("PaymentTermsView.aspx")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("PaymentTermsView.aspx")
        Catch ex As Exception

        End Try
    End Sub

End Class
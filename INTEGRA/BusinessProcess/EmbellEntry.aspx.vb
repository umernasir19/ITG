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
Public Class EmbellEntry
    Inherits System.Web.UI.Page
    Dim objEmbell As New Embell
    Dim EmbellID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        EmbellID = Request.QueryString("lEmbellID")
        If Not Page.IsPostBack Then
            If EmbellID > 0 Then
                EditModes()
            Else

            End If
        End If
    End Sub
    Sub EditModes()
        Try
            Dim dt As DataTable
            dt = objEmbell.GetAll(EmbellID)
            txtEmbellName.Text = dt.Rows(0)("EmbellName")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            If txtEmbellName.Text = "" Then

            Else
                With objEmbell
                    .EmbellID = EmbellID
                    .EmbellName = txtEmbellName.Text
                    .SaveEmbell()
                End With

                Response.Redirect("EmbellView.aspx")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("EmbellView.aspx")
        Catch ex As Exception

        End Try
    End Sub


End Class
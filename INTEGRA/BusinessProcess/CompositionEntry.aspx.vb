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
Public Class CompositionEntry
    Inherits System.Web.UI.Page
    Dim objComposition As New Composition
    Dim CompositionID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CompositionID = Request.QueryString("lCompositionID")
        If Not Page.IsPostBack Then
            If CompositionID > 0 Then
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
            dt = objComposition.GetAll(CompositionID)
            txtComposition.Text = dt.Rows(0)("CompositionName")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            If txtComposition.Text = "" Then

            Else
                With objComposition
                    .CompositionID = CompositionID
                    .CompositionName = txtComposition.Text
                    .SaveComposition()
                End With

                Response.Redirect("CompositionView.aspx")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("CompositionView.aspx")
        Catch ex As Exception
        End Try

    End Sub
End Class
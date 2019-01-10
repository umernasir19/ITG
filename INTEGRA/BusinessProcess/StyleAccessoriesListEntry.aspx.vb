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
Public Class StyleAccessoriesListEntry
    Inherits System.Web.UI.Page
    Dim objStyleAccessoriesList As New StyleAccessoriesList
    Dim AccessoriesID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AccessoriesID = Request.QueryString("AccessoriesID")
        If Not Page.IsPostBack Then
            If AccessoriesID > 0 Then
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
            dt = objStyleAccessoriesList.GetAll(AccessoriesID)
            txtAccessoriesName.Text = dt.Rows(0)("AccessoriesName")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            If txtAccessoriesName.Text = "" Then

            Else
                With objStyleAccessoriesList
                    .AccessoriesID = AccessoriesID
                    .AccessoriesName = txtAccessoriesName.Text
                    .SaveStyleAccessoriesList()
                End With

                Response.Redirect("StyleAccessoriesListView.aspx")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("StyleAccessoriesListView.aspx")
        Catch ex As Exception

        End Try
    End Sub

End Class
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
Public Class UnitsEntry
    Inherits System.Web.UI.Page
    Dim objUnits As New Units
    Dim UnitID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UnitID = Request.QueryString("UnitID")
        If Not Page.IsPostBack Then
            If UnitID > 0 Then
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
            dt = objUnits.GetAll(UnitID)
            txtUnitName.Text = dt.Rows(0)("UnitName")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            If txtUnitName.Text = "" Then

            Else
                With objUnits
                    .UnitID = UnitID
                    .UnitName = txtUnitName.Text
                    .SaveUnits()
                End With

                Response.Redirect("UnitsView.aspx")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("UnitsView.aspx")
        Catch ex As Exception

        End Try
    End Sub


End Class
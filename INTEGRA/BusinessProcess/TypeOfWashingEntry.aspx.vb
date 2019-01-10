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
Public Class TypeOfWashingEntry
    Inherits System.Web.UI.Page

    Dim objTypeOfWashing As New TypeOfWashing
    Dim TypeOfWashingID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TypeOfWashingID = Request.QueryString("TypeOfWashingID")
        If Not Page.IsPostBack Then
            If TypeOfWashingID > 0 Then
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
            dt = objTypeOfWashing.GetAll(TypeOfWashingID)
            txtTypeOfWashing.Text = dt.Rows(0)("TypeOfWashingName")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            If txtTypeOfWashing.Text = "" Then

            Else
                With objTypeOfWashing
                    .TypeOfWashingID = TypeOfWashingID
                    .TypeOfWashingName = txtTypeOfWashing.Text
                    .SaveTypeOfWashing()
                End With

                Response.Redirect("TypeOfWashingView.aspx")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("TypeOfWashingView.aspx")
        Catch ex As Exception

        End Try
    End Sub

End Class
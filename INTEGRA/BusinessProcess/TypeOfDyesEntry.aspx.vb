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
Public Class TypeOfDyesEntry
    Inherits System.Web.UI.Page
    Dim objTypeOfDyes As New TypeOfDyes
    Dim TypeOfDyesID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TypeOfDyesID = Request.QueryString("TypeOfDyesID")
        If Not Page.IsPostBack Then
            If TypeOfDyesID > 0 Then
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
            dt = objTypeOfDyes.GetAll(TypeOfDyesID)
            txtTypeOfDyesName.Text = dt.Rows(0)("TypeOfDyesName")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            If txtTypeOfDyesName.Text = "" Then

            Else
                With objTypeOfDyes
                    .TypeOfDyesID = TypeOfDyesID
                    .TypeOfDyesName = txtTypeOfDyesName.Text
                    .SaveTypeOfDyes()
                End With

                Response.Redirect("TypeOfDyesView.aspx")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("TypeOfDyesView.aspx")
        Catch ex As Exception

        End Try
    End Sub


End Class
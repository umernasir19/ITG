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

Public Class DestinationEntryNew
    Inherits System.Web.UI.Page
    Dim objDestination As New Destination
    Dim lDestinationID As Long
    Dim DestinationID As Long
    Dim DestinationName As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lDestinationID = Request.QueryString("lDestinationID")
        If Not Page.IsPostBack Then
            If lDestinationID > 0 Then
                btnSave.Text = "Update"
                Edit()
            Else
                btnSave.Text = "Save"
            End If
        End If
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If txtDestination.Text = "" Then

            Else
                With objDestination
                    If lDestinationID > 0 Then
                        .DestinationID = lDestinationID
                    Else
                        .DestinationID = 0
                    End If
                    .DestinationName = txtDestination.Text
                    .SaveDestination()
                End With
                Response.Redirect("DestinationView.aspx")
            End If

        Catch ex As Exception

        End Try
    End Sub
    Sub Edit()
        Try
            Dim dt As DataTable
            dt = objDestination.GetDestination(lDestinationID)
            txtDestination.Text = dt.Rows(0)("DestinationName")
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("DestinationView.aspx")
    End Sub

    Private Sub SaveDestination()
        Throw New NotImplementedException
    End Sub

    Private Function GetDestination(lDestinationID As Long) As DataTable
        Throw New NotImplementedException
    End Function

    Function GetAll() As DataTable
        Throw New NotImplementedException
    End Function

End Class
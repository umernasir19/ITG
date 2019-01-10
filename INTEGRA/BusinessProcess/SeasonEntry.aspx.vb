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
Public Class SeasonEntry
    Inherits System.Web.UI.Page
    Dim objSeason As New Season
    Dim objSeasonNew As New SeasonDatabase
    Dim SeasonID, UserId As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SeasonID = Request.QueryString("SeasonDatabaseID")
        UserId = Session("UserId")
        If Not Page.IsPostBack Then
            If SeasonID > 0 Then
                EditModes()
            Else
            End If
        End If
    End Sub
    Sub EditModes()
        Try
            Dim dt As DataTable
            dt = objSeason.GetAll(SeasonID)
            txtSeason.Text = dt.Rows(0)("SeasonName")
            lblUserId.Text = dt.Rows(0)("UmuserID")
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            Dim toDayDate As Date = Date.Today
            Dim Year As String = toDayDate.Year
            If txtSeason.Text = "" Then
            Else
                With objSeasonNew
                    If SeasonID > 0 Then
                        .SeasonDatabaseID = SeasonID
                    Else
                        .SeasonDatabaseID = 0
                    End If
                    .CreationDate = Date.Today
                    If Session("RoleId") = 46 And Session("Type") = "Merchandising" Then
                        If SeasonID > 0 Then
                            .UmuserID = lblUserId.Text
                        Else
                            .UmuserID = 270
                        End If
                    Else
                        If SeasonID > 0 Then
                            .UmuserID = lblUserId.Text
                        Else
                            .UmuserID = UserId
                        End If
                    End If
                    .Year = Year
                    .SeasonName = txtSeason.Text.ToUpper()
                    .saveSeasonDatabase()
                End With
                Response.Redirect("SeasonView.aspx")
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
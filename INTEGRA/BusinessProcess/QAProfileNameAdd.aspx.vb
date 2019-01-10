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
Public Class QAProfileNameAdd
    Inherits System.Web.UI.Page
    Dim objQAProfileName As New QAProfileName
    Dim QAProfileNameID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        QAProfileNameID = Request.QueryString("QAProfileNameID")
        If Not Page.IsPostBack Then
            If QAProfileNameID > 0 Then
                EditModes()
            Else

            End If
        End If
    End Sub
    Sub EditModes()
        Try
            Dim dt As DataTable
            dt = objQAProfileName.GetAllForEdit(QAProfileNameID)
            txtQAName.Text = dt.Rows(0)("QAProfileName")
            txtQAGroup.Text = dt.Rows(0)("QAProfileGroup")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            If txtQAName.Text = "" Then
            ElseIf txtQAGroup.Text = "" Then

            Else
                With objQAProfileName
                    .QAProfileNameID = QAProfileNameID
                    .QAProfileName = txtQAName.Text
                    .QAProfileGroup = txtQAGroup.Text
                    .CreationDate = Date.Today
                    .SaveQAProfileName()
                End With

                Response.Redirect("QAProfileNameView.aspx")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("QAProfileNameView.aspx")
        Catch ex As Exception

        End Try
    End Sub



End Class
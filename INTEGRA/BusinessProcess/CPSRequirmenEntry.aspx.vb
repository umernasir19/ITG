Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Net
Imports System.Net.Mail
Imports Integra.EuroCentra
Public Class CPSRequirmenEntry
    Inherits System.Web.UI.Page

    Dim objtblCPRequirmen As New tblCPRequirmen
    Dim lCPRequirmentId As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lCPRequirmentId = Request.QueryString("lCPRequirmentId")
        If Not Page.IsPostBack Then
            If lCPRequirmentId > 0 Then
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
            dt = objtblCPRequirmen.GetAll(lCPRequirmentId)
            txtRequirment.Text = dt.Rows(0)("CPRequirmen")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            If txtRequirment.Text = "" Then

            Else
                With objtblCPRequirmen
                    If lCPRequirmentId > 0 Then
                        .CPRequirmentId = lCPRequirmentId
                    Else
                        .CPRequirmentId = 0
                    End If

                    .CPRequirmen = txtRequirment.Text
                    .SavetblCPRequirmen()
                End With

                Response.Redirect("CPSRequirmenView.aspx")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("CPSRequirmenView.aspx")
        Catch ex As Exception
        End Try

    End Sub

End Class
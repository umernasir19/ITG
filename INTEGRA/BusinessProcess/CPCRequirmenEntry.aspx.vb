Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Net
Imports System.Net.Mail
Imports Integra.EuroCentra
Public Class CPCRequirmenEntry
    Inherits System.Web.UI.Page

    Dim objtblCPRequirmenBuyer As New tblCPRequirmenBuyer
    Dim lCPRequirmentBID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lCPRequirmentBID = Request.QueryString("lCPRequirmentBID")
        If Not Page.IsPostBack Then
            If lCPRequirmentBID > 0 Then
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
            dt = objtblCPRequirmenBuyer.GetAll(lCPRequirmentBID)
            txtRequirment.Text = dt.Rows(0)("CPRequirementB")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            If txtRequirment.Text = "" Then

            Else
                With objtblCPRequirmenBuyer
                    If lCPRequirmentBID > 0 Then
                        .CPRequirmentBID = lCPRequirmentBID
                    Else
                        .CPRequirmentBID = 0
                    End If

                    .CPRequirementB = txtRequirment.Text
                    .SaveCPRequirmenBuyer()
                End With

                Response.Redirect("CPCRequirmenView.aspx")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("CPCRequirmenView.aspx")
        Catch ex As Exception
        End Try

    End Sub
End Class
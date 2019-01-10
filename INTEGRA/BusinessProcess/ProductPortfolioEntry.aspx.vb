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
Public Class ProductPortfolioEntry
    Inherits System.Web.UI.Page
    Dim objVenderVerticalIntegration As New VenderVerticalIntegration
    Dim VVIID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        VVIID = Request.QueryString("VVIID")
        If Not Page.IsPostBack Then
            If VVIID > 0 Then
                EditModes()
            Else

            End If
        End If
    End Sub
    Sub EditModes()
        Try
            Dim dt As DataTable
            dt = objVenderVerticalIntegration.GetAllProductForEdit(VVIID)
            txtProductPortfolio.Text = dt.Rows(0)("Name")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            If txtProductPortfolio.Text = "" Then

            Else
                With objVenderVerticalIntegration
                    If VVIID > 0 Then
                        .VVIID = VVIID
                    Else
                        .VVIID = 0
                    End If

                    .Name = txtProductPortfolio.Text
                    .CreationDate = Date.Now()
                    .Type = "Product Group"
                    .IsActive = True
                    .SaveVenderVerticalIntegration()
                End With

                Response.Redirect("ProductPortfolioView.aspx")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("ProductPortfolioView.aspx")
        Catch ex As Exception

        End Try
    End Sub
End Class
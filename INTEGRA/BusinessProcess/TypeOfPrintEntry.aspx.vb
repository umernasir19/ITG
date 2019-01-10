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
Public Class TypeOfPrintEntry
    Inherits System.Web.UI.Page
    Dim objTypeOfPrint As New TypeOfPrint
    Dim TypeOfPrintID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TypeOfPrintID = Request.QueryString("TypeOfPrintID")
        If Not Page.IsPostBack Then
            If TypeOfPrintID > 0 Then
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
            dt = objTypeOfPrint.GetAll(TypeOfPrintID)
            txtTypeOfPrintName.Text = dt.Rows(0)("TypeOfPrintName")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            If txtTypeOfPrintName.Text = "" Then

            Else
                With objTypeOfPrint
                    .TypeOfPrintID = TypeOfPrintID
                    .TypeOfPrintName = txtTypeOfPrintName.Text
                    .SaveTypeOfPrint()
                End With

                Response.Redirect("TypeOfPrintView.aspx")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("TypeOfPrintView.aspx")
        Catch ex As Exception

        End Try
    End Sub

End Class
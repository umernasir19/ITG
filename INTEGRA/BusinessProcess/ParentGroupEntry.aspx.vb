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
Public Class ParentGroupEntry
    Inherits System.Web.UI.Page
    Dim objParentGroup As New ParentGroupp
    Dim ParentGroupID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ParentGroupID = Request.QueryString("ParentGroupID")
        If Not Page.IsPostBack Then
            If ParentGroupID > 0 Then
                EditModes()
            Else

            End If
        End If
    End Sub
    Sub EditModes()
        Try
            Dim dt As DataTable
            dt = objParentGroup.GetAllForEdit(ParentGroupID)
            txtParentGroupName.Text = dt.Rows(0)("Parent")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            If txtParentGroupName.Text = "" Then

            Else
                With objParentGroup
                    .ParentGroupID = ParentGroupID
                    .Parent = txtParentGroupName.Text
                    .SaveParentGroup()
                End With

                Response.Redirect("ParentGroup.aspx")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("ParentGroupEntry.aspx")
        Catch ex As Exception

        End Try
    End Sub



End Class
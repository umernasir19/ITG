Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.Xml
Imports System.IO
Public Class TypeOfSamplingEntry
    Inherits System.Web.UI.Page
    Dim objTypeOfSampling As New TypeOfSampling
    Dim ITypeOfSamplingID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ITypeOfSamplingID = Request.QueryString("ITypeOfSamplingID")
        If Not Page.IsPostBack Then
            If ITypeOfSamplingID > 0 Then
                btnSave.Text = "Update"
                EditMode()
            Else
                btnSave.Text = "Save"
            End If
        End If
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            If txtTypeName.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Not allow to save.")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                With objTypeOfSampling
                    .TypeOfSamplingID = ITypeOfSamplingID
                    .TypeName = txtTypeName.Text
                    .isactive = True
                    .SaveTypeOfSampling()
                End With
                Response.Redirect("TypeOfSamplingView.aspx")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Response.Redirect("TypeOfSamplingView.aspx")
    End Sub
    Sub EditMode()
        Try
            Dim dtEdit As DataTable = objTypeOfSampling.GetDataForEdit(ITypeOfSamplingID)
            txtTypeName.Text = dtEdit.Rows(0)("TypeName")
        Catch ex As Exception

        End Try
    End Sub


End Class
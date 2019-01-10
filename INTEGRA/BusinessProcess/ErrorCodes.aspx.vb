Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Public Class ErrorCodes
    Inherits System.Web.UI.Page
    Dim objError As New ErrorCode
    Dim ErrorID As Integer
    Dim Dt As DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ErrorID = Request.QueryString("lID")

        If Not Page.IsPostBack Then
            Try
                If ErrorID > 0 Then
                    btnSave.Text = "Update"
                    EditErrorCodes()
                Else
                    btnSave.Text = "Save"
                End If
            Catch ex As Exception

            End Try
        End If
        
    End Sub
    Sub EditErrorCodes()
        Try
            Dt = objError.GetErrorCodesData(ErrorID)
            txtErrorNo.Text = Dt.Rows(0)("ErrorNo")
            txtErrorDescription.Text = Dt.Rows(0)("errorDescription")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            With objError
                If ErrorID > 0 Then
                    .ID = ErrorID
                Else
                    .ID = 0
                End If
                .ErrorNo = txtErrorNo.Text
                .errorDescription = txtErrorDescription.Text
                .SaveErrorCodes()
            End With
            Response.Redirect("ErrorCodesView.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("ErrorCodesView.aspx")
        Catch ex As Exception

        End Try
    End Sub
End Class
Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Public Class AccountGroupEntry
    Inherits System.Web.UI.Page
    Dim objAccountGroup As New AccountGroup
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

        End If
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            If txtAccountGroup.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Account Group Emty")
            Else

                Dim dtExist As DataTable = objAccountGroup.CheckExisting(txtAccountGroup.Text)
                If dtExist.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Already Exist")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    With objAccountGroup
                        .AccountGroupID = 0
                        .AccountGroup = txtAccountGroup.Text
                        Dim CurrentID As Long = objAccountGroup.MaxId
                        If CurrentID = 0 Then
                            .AccountGroupCode = "01"
                        Else
                            If CurrentID + 1 <= "9" Then
                                .AccountGroupCode = "0" & (CurrentID + 1)
                            Else
                                .AccountGroupCode = (CurrentID + 1)
                            End If
                        End If
                        .SaveAccountGroup()
                    End With
                    Response.Redirect("AccountGroupView.aspx")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Response.Redirect("AccountGroupView.aspx")
    End Sub
End Class
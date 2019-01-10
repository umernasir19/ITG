Imports Integra.EuroCentra
Imports System.Data
Imports System.Data.DataTable
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Data.SqlClient
Public Class Dashboard
    Inherits System.Web.UI.Page
    Dim UserLogined As New UserLogined
    Dim dtemail As New DataTable
    Dim ObjUmUserLinkLog As New UmUserLinkLog
    Dim RoleId, ID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ID = Request.QueryString("ID")
        If Not Page.IsPostBack Then


        End If
    End Sub
    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLogin.Click
        If cmbDepartment.SelectedItem.Text = "Merchandising" Or cmbDepartment.SelectedItem.Text = "G.G.T" Or cmbDepartment.SelectedItem.Text = "R.N.D" Or cmbDepartment.SelectedItem.Text = "Production" Or cmbDepartment.SelectedItem.Text = "Fabric Store" Then
            Session("DepttName") = cmbDepartment.SelectedItem.Text
            HttpContext.Current.Response.Redirect("~/MainPage.aspx?ID=" & ID & " &Type=" & cmbDepartment.SelectedItem.Text & "")
        End If


    End Sub

End Class
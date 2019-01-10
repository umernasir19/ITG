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
Public Class BrandEntry
    Inherits System.Web.UI.Page
    Dim objBrand As New Brand
    Dim objBrandNew As New BrandDatabase
    Dim lBrandID, UserId As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lBrandID = Request.QueryString("BrandDatabaseID")
        UserId = Session("UserId")
        If Not Page.IsPostBack Then
            If lBrandID > 0 Then
                btnSave.Text = "Update"
                EditModes()
            Else
                btnSave.Text = "Save"
            End If
        End If
        PageHeader("BRAND ENTRY FORM")
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub EditModes()
        Try
            Dim dt As DataTable
            dt = objBrand.GetAll(lBrandID)
            txtBrandName.Text = dt.Rows(0)("Brand")
            lblUserId.Text = dt.Rows(0)("UmuserID")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            If txtBrandName.Text = "" Then

            Else
                With objBrandNew
                    If lBrandID > 0 Then
                        .BrandDatabaseID = lBrandID
                    Else
                        .BrandDatabaseID = 0
                    End If
                    .Brand = txtBrandName.Text
                    .CreationDate = Date.Now
                    If Session("RoleId") = 46 And Session("Type") = "Merchandising" Then
                        If lBrandID > 0 Then
                            .UmuserID = lblUserId.Text
                        Else
                            .UmuserID = 270
                        End If
                    Else
                        If lBrandID > 0 Then
                            .UmuserID = lblUserId.Text
                        Else
                            .UmuserID = UserId
                        End If
                    End If
                    .saveBrandDatabase()
                End With
                Response.Redirect("BrandView.aspx")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("BrandView.aspx")
        Catch ex As Exception

        End Try
    End Sub


End Class
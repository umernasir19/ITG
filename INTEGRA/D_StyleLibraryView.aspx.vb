Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports System.IO
Public Class D_StyleLibraryView
    Inherits System.Web.UI.Page
    Dim objD_Style As New D_Style
    Dim DstyleID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DstyleID = Request.QueryString("DstyleID")
        If Not Page.IsPostBack Then
            If DstyleID > 0 Then
                ShowData()
            End If

        End If
    End Sub
    Sub ShowData()
        Try
            Dim dt As DataTable = objD_Style.Show(DstyleID)
            If dt.Rows.Count > 0 Then
                lblStyle.Text = dt.Rows(0)("Style")
                imgFornt.ImageUrl = dt.Rows(0)("URL_Fornt")
                txtDiscription.Text = dt.Rows(0)("Description")
                txtCategory.Text = dt.Rows(0)("Category")
                txtMaterial.Text = dt.Rows(0)("Material")
                txtPrice.Text = dt.Rows(0)("Price")
                txtMOQ.Text = dt.Rows(0)("MOQ")

                imgForntThumbnail.ImageUrl = dt.Rows(0)("Thumbnail_Fornt")
                imgBackThumbnail.ImageUrl = dt.Rows(0)("Thumbnail_Back")
                imgLeftThumbnail.ImageUrl = dt.Rows(0)("Thumbnail_Left")
                imgRightThumbnail.ImageUrl = dt.Rows(0)("Thumbnail_Right")

            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub lnkForntThumbnail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkForntThumbnail.Click
        Try
            Dim dt As DataTable = objD_Style.Show(DstyleID)
            If dt.Rows.Count > 0 Then
                lblStyle.Text = dt.Rows(0)("Style")

                txtDiscription.Text = dt.Rows(0)("Description")
                txtCategory.Text = dt.Rows(0)("Category")
                txtMaterial.Text = dt.Rows(0)("Material")
                txtPrice.Text = dt.Rows(0)("Price")
                txtMOQ.Text = dt.Rows(0)("MOQ")

                imgFornt.ImageUrl = dt.Rows(0)("URL_Fornt")

                imgForntThumbnail.ImageUrl = dt.Rows(0)("Thumbnail_Fornt")
                imgBackThumbnail.ImageUrl = dt.Rows(0)("Thumbnail_Back")
                imgLeftThumbnail.ImageUrl = dt.Rows(0)("Thumbnail_Left")
                imgRightThumbnail.ImageUrl = dt.Rows(0)("Thumbnail_Right")
            End If

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub lnkBackThumbnail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkBackThumbnail.Click
        Try
            Dim dt As DataTable = objD_Style.Show(DstyleID)
            If dt.Rows.Count > 0 Then
                lblStyle.Text = dt.Rows(0)("Style")

                txtDiscription.Text = dt.Rows(0)("Description")
                txtCategory.Text = dt.Rows(0)("Category")
                txtMaterial.Text = dt.Rows(0)("Material")
                txtPrice.Text = dt.Rows(0)("Price")
                txtMOQ.Text = dt.Rows(0)("MOQ")

                imgFornt.ImageUrl = dt.Rows(0)("URL_Back")

                imgForntThumbnail.ImageUrl = dt.Rows(0)("Thumbnail_Fornt")
                imgBackThumbnail.ImageUrl = dt.Rows(0)("Thumbnail_Back")
                imgLeftThumbnail.ImageUrl = dt.Rows(0)("Thumbnail_Left")
                imgRightThumbnail.ImageUrl = dt.Rows(0)("Thumbnail_Right")
            End If

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub lnkLeftThumbnail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkLeftThumbnail.Click
        Try
            Dim dt As DataTable = objD_Style.Show(DstyleID)
            If dt.Rows.Count > 0 Then
                lblStyle.Text = dt.Rows(0)("Style")

                txtDiscription.Text = dt.Rows(0)("Description")
                txtCategory.Text = dt.Rows(0)("Category")
                txtMaterial.Text = dt.Rows(0)("Material")
                txtPrice.Text = dt.Rows(0)("Price")
                txtMOQ.Text = dt.Rows(0)("MOQ")

                imgFornt.ImageUrl = dt.Rows(0)("URL_Left")

                imgForntThumbnail.ImageUrl = dt.Rows(0)("Thumbnail_Fornt")
                imgBackThumbnail.ImageUrl = dt.Rows(0)("Thumbnail_Back")
                imgLeftThumbnail.ImageUrl = dt.Rows(0)("Thumbnail_Left")
                imgRightThumbnail.ImageUrl = dt.Rows(0)("Thumbnail_Right")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub lnkRightThumbnail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkRightThumbnail.Click
        Try
            Dim dt As DataTable = objD_Style.Show(DstyleID)
            If dt.Rows.Count > 0 Then
                lblStyle.Text = dt.Rows(0)("Style")

                txtDiscription.Text = dt.Rows(0)("Description")
                txtCategory.Text = dt.Rows(0)("Category")
                txtMaterial.Text = dt.Rows(0)("Material")
                txtPrice.Text = dt.Rows(0)("Price")
                txtMOQ.Text = dt.Rows(0)("MOQ")

                imgFornt.ImageUrl = dt.Rows(0)("URL_Right")

                imgForntThumbnail.ImageUrl = dt.Rows(0)("Thumbnail_Fornt")
                imgBackThumbnail.ImageUrl = dt.Rows(0)("Thumbnail_Back")
                imgLeftThumbnail.ImageUrl = dt.Rows(0)("Thumbnail_Left")
                imgRightThumbnail.ImageUrl = dt.Rows(0)("Thumbnail_Right")
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
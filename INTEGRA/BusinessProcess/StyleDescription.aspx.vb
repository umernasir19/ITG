Imports System.Data
Imports Integra.classes
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Drawing.Color
Imports System.Drawing.KnownColor
Imports System.Web
Imports System.Reflection
Imports System.Drawing
Imports System
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports BarcodeLib.Barcode
Imports System.Drawing.Text
Imports System.Drawing.Imaging
Public Class StyleDescription
    Inherits System.Web.UI.Page
    Dim dtSizeRangeDatabase As New DataTable
    Dim dr As DataRow
    Dim objSizeRange As New SizeRange
    Dim objSizeRangeDetail As New SizeRangeDetail
    Dim StyleDescriptionId As Long
    Dim ObjGender1 As New Gender1
    Dim ObjSizeDatabase As New SizeDatabase
    Dim objStyleDesriptionClass As New StyleDesriptionClass
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        StyleDescriptionId = Request.QueryString("StyleDescriptionId")
        If Not Page.IsPostBack Then
            BindStyleCategory()
            If StyleDescriptionId > 0 Then
                btnSave.Text = "Update"
                EditMode()
            Else
                btnSave.Text = "Save"
            End If
        End If
        PageHeader("Style Description Entry Form")
    End Sub
    Sub EditMode()
        Try
            Dim dt As DataTable
            dt = objStyleDesriptionClass.GetEdit(StyleDescriptionId)
            txtStyleDescription.Text = dt.Rows(0)("StyleDescription")
            cmbStyleCategory.SelectedValue = dt.Rows(0)("StyleCategoryId")
        Catch ex As Exception
        End Try
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub BindStyleCategory()
        Dim dt As DataTable
        dt = objSizeRange.GetStyleCategory()
        cmbStyleCategory.DataSource = dt
        cmbStyleCategory.DataTextField = "StyleCategory"
        cmbStyleCategory.DataValueField = "StyleCategoryId"
        cmbStyleCategory.DataBind()
        cmbStyleCategory.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If txtStyleDescription.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Fill Style Description")
            ElseIf cmbStyleCategory.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Select Style Category")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                With objStyleDesriptionClass
                    If StyleDescriptionId > 0 Then
                        .StyleDescriptionID = StyleDescriptionId
                    Else
                        .StyleDescriptionID = 0
                    End If
                    .StyleDescription = txtStyleDescription.Text.ToUpper
                    .StyleCategoryId = cmbStyleCategory.SelectedValue
                    .Save()
                End With
                Response.Redirect("StyleDescriptionView.aspx")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("StyleDescriptionView.aspx")
        Catch ex As Exception
        End Try
    End Sub
End Class
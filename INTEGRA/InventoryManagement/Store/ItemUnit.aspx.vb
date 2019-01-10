Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Xml
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Public Class ItemUnit
    Inherits System.Web.UI.Page
    Dim ItemUnitId As Long
    Dim ObjItemUnitStore As New ItemUnitStore
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ItemUnitId = Request.QueryString("ItemUnitId")
        If Not Page.IsPostBack Then
            If ItemUnitId > 0 Then
                SetValuesEditMod()
                btnSave.Text = "Update"
            Else
                btnSave.Text = "Save"
            End If
            PageHeader(" ")
        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim dtCheck As DataTable
            If txtName.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Unit Name Empty.")
            ElseIf txtUnitPerfix.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Unit Perfix Empty.")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                If ItemUnitId > 0 Then
                    dtCheck = ObjItemUnitStore.CheckExistingEdit(ItemUnitId, txtName.Text)
                    If dtCheck.Rows.Count > 0 Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Unit Already Exist.")
                    Else
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                        With ObjItemUnitStore
                            If ItemUnitId > 0 Then
                                .ItemUnitId = ItemUnitId
                            Else
                                .ItemUnitId = 0
                            End If
                            .Name = txtName.Text.ToUpper
                            .Symbol = txtUnitPerfix.Text.ToUpper
                            .IsActive = True
                            .SaveStoreUnits()
                        End With
                        Response.Redirect("ItemUnitView.aspx")
                    End If
                Else
                    dtCheck = ObjItemUnitStore.CheckExisting(txtName.Text)
                    If dtCheck.Rows.Count > 0 Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Unit Already Exist.")
                    Else
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                        With ObjItemUnitStore
                            If ItemUnitId > 0 Then
                                .ItemUnitId = ItemUnitId
                            Else
                                .ItemUnitId = 0
                            End If
                            .Name = txtName.Text.ToUpper
                            .Symbol = txtUnitPerfix.Text.ToUpper
                            .IsActive = True
                            .SaveStoreUnits()
                        End With
                        Response.Redirect("ItemUnitView.aspx")
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub SetValuesEditMod()
        Try
            Dim dt As DataTable = ObjItemUnitStore.GetItemUnitsEdit(ItemUnitId)
            txtName.Text = dt.Rows(0)("Name")
            txtUnitPerfix.Text = dt.Rows(0)("Symbol")
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("ItemUnitView.aspx")
    End Sub
End Class

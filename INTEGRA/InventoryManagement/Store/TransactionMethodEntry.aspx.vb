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
Public Class TransactionMethodEntry
    Inherits System.Web.UI.Page
    Dim ObjIMSItem As New IMSItem
    Dim ObjIMSTransactionMethod As New IMSTransactionMethod
    Dim TransactionMethodID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TransactionMethodID = Request.QueryString("TransactionMethodID")
        If Not Page.IsPostBack Then
            If TransactionMethodID > 0 Then
                BindcmbItemName()
                SetValuesEditMod()
                btnSave.Text = "Update"
            Else
                BindcmbItemNameNew()
                btnSave.Text = "Save"
            End If
        End If
    End Sub
    Sub BindcmbItemName()
        Dim dt As DataTable
        dt = ObjIMSItem.GetIMSItemCode
        cmbItem.DataSource = dt
        cmbItem.DataTextField = "ItemName"
        cmbItem.DataValueField = "IMSItemID"
        cmbItem.DataBind()
    End Sub
    Sub BindcmbItemNameNew()
        Dim dt As DataTable
        dt = ObjIMSItem.GetIMSItemCodeNew
        cmbItem.DataSource = dt
        cmbItem.DataTextField = "ItemName"
        cmbItem.DataValueField = "IMSItemID"
        cmbItem.DataBind()
    End Sub
    Private Sub SetValuesEditMod()
        Try
            Dim dt As DataTable = ObjIMSTransactionMethod.Edit(TransactionMethodID)
            cmbItem.SelectedValue = dt.Rows(0)("IMSItemID")
            cmbItem.Enabled = False
            If dt.Rows(0)("TransactionMethod") = "Average Method" Then
                cmbTransactionMethod.SelectedValue = 0
            Else
                cmbTransactionMethod.SelectedValue = 1
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If TransactionMethodID > 0 Then
                With ObjIMSTransactionMethod
                    .TransactionMethodID = TransactionMethodID
                    .CreationDate = Date.Now
                    .IMSItemID = cmbItem.SelectedValue
                    .TransactionMethod = cmbTransactionMethod.SelectedItem.Text
                    .SaveIMSTransactionMethod()
                End With
                Response.Redirect("TransactionMethodView.aspx")
            Else
                Dim dtExist As DataTable = ObjIMSTransactionMethod.Exist(cmbItem.SelectedValue)
                If dtExist.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("This Item have already Transaction Method defined.")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    With ObjIMSTransactionMethod
                        .TransactionMethodID = TransactionMethodID
                        .CreationDate = Date.Now
                        .IMSItemID = cmbItem.SelectedValue
                        .TransactionMethod = cmbTransactionMethod.SelectedItem.Text
                        .SaveIMSTransactionMethod()
                    End With
                    Response.Redirect("TransactionMethodView.aspx")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub BtnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Try
            Response.Redirect("TransactionMethodView.aspx")
        Catch ex As Exception

        End Try
    End Sub
End Class

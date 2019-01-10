Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Public Class VAFapproval
    Inherits System.Web.UI.Page
    Dim objVender As New Vender
    Dim objVAF_BasicInformation As New VAF_BasicInformation
    Dim VAFID As Long
    Dim SupplierID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        VAFID = Vender.DecryptString(Request.QueryString("VAFID"))
        If Not Page.IsPostBack Then
            BindSupplier()
            LoadInfo()
        End If
        PageHeader("Approval From")
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub BindSupplier()
        Try
            Dim dtSupplier As DataTable
            If VAFID > 0 Then
                dtSupplier = objVender.getDataforBindCombo11
            Else
                dtSupplier = objVender.getDataforBindCombo1
            End If
            With cmbSupplier
                .DataSource = dtSupplier
                .DataTextField = "VenderName"
                .DataValueField = "VenderLibraryID"
                .DataBind()

            End With
        Catch ex As Exception
        End Try
    End Sub
    Sub LoadInfo()
        Try
            Dim dt As DataTable
            dt = objVAF_BasicInformation.EditVAF_BasicInformation(VAFID)
            cmbSupplier.SelectedValue = dt.Rows(0)("VenderLibraryID")
            cmbSupplier.Enabled = False
            If dt.Rows(0)("SupplierStatus") = "Active" Then
                cmbSupplierStatus.SelectedValue = 0
            ElseIf dt.Rows(0)("SupplierStatus") = "No Decision" Then
                cmbSupplierStatus.SelectedValue = 2
            ElseIf dt.Rows(0)("SupplierStatus") = "Deactive" Then
                cmbSupplierStatus.SelectedValue = 1
            End If

            txtCode.Text = dt.Rows(0)("Code")
            txtRemarks.Text = dt.Rows(0)("Remarks")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            'Update objVAF_BasicInformation
            If txtCode.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Code empty.")
            Else
                objVAF_BasicInformation.UpdateVAF_BasicInformation(VAFID, txtCode.Text, cmbSupplierStatus.SelectedItem.Text, txtRemarks.Text)
                Response.Redirect("VAFPanelView.aspx")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("VAFPanelView.aspx")
        Catch ex As Exception

        End Try
    End Sub
End Class
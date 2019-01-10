Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Public Class CertificateView
    Inherits System.Web.UI.Page
    Dim objCertificate As New EuroCentra.Certificate
    Dim objVendor As New Vender
    Dim objvenderCertificate As New VenderCertificate
    Dim pdfData As Byte()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindSupplier()
        End If
    End Sub
    Sub BindCertificate(ByVal VenderID As Long)
        Try
            Dim dtCertificate As DataTable = objCertificate.GetCertificateOfVenderNew(VenderID)
            cmbCertificate.DataSource = dtCertificate
            cmbCertificate.DataTextField = "Certificate"
            cmbCertificate.DataValueField = "CertificateID"
            cmbCertificate.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Sub BindSupplier()
        Try
            Dim dtSupplier As DataTable = objVendor.GetVenderForCertificateNew
            With cmbSupplier
                .DataSource = dtSupplier
                .DataTextField = "VenderName"
                .DataValueField = "VenderLibraryID"
                .DataBind()
            End With
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbSupplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbSupplier.SelectedIndexChanged
        Try
            Dim VenderID As Long = cmbSupplier.SelectedValue
            BindCertificate(VenderID)
            upcmbCertificate.Update()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnViewCertificate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnViewCertificate.Click
        Try
            'Response.Write("<script> window.open('CertificatePopup.aspx?SupplierID=" & cmbSupplier.SelectedValue & "&CertificateID=" & cmbCertificate.SelectedValue & "', 'newwindow', 'left=12, top=30, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")
            ScriptManager.RegisterClientScriptBlock(Me.upbtnViewCertificate, Me.upbtnViewCertificate.GetType(), "New ClientScript", "window.open('CertificatePopup.aspx?SupplierID=" & cmbSupplier.SelectedValue & "&CertificateID=" & cmbCertificate.SelectedValue & "', 'newwindow', 'left=12, top=60, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no');", True)
        Catch ex As Exception

        End Try
    End Sub
End Class
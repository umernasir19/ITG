Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Public Class CertificatePopup
    Inherits System.Web.UI.Page
    Dim objCertificate As New EuroCentra.Certificate
    Dim objVendor As New Vender
    Dim objvenderCertificate As New VenderCertificate
    Dim pdfData As Byte()
    Dim SupplierID As Long
    Dim CertificateID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SupplierID = Request.QueryString("SupplierID")
        CertificateID = Request.QueryString("CertificateID")
        If Not Page.IsPostBack Then
            ShowCertificate()
        End If
    End Sub
    Sub ShowCertificate()
        Try
            Dim dtt As DataTable
            dtt = objvenderCertificate.getDataaNew(SupplierID, CertificateID)
            For Each row As DataRow In dtt.Rows
                pdfData = DirectCast(row("CertificateImage"), Byte())
            Next
            Response.ContentType = "application/pdf"
            Dim bytes As Byte() = pdfData
            Using writer As New BinaryWriter(Context.Response.OutputStream)
                writer.Write(bytes, 0, bytes.Length)
            End Using
        Catch ex As Exception

        End Try
    End Sub
End Class
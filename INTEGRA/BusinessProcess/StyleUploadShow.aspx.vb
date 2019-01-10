Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Public Class StyleUploadShow
    Inherits System.Web.UI.Page
    Dim objStyleUploads As New StyleUploads
    Dim pdfData As Byte()
    Dim IDD As Long
    Dim StyleID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        IDD = Request.QueryString("ID")
        StyleID = Request.QueryString("StyleID")
        If Not Page.IsPostBack Then
            ShowFile()
        End If
    End Sub
    Sub ShowFile()
        Try
            Dim dtt As DataTable
            dtt = objStyleUploads.ShowFIle(IDD, StyleID)
            For Each row As DataRow In dtt.Rows
                pdfData = DirectCast(row("UploadPicture"), Byte())
            Next
            Response.ContentType = "image/jpeg"
            Dim bytes As Byte() = pdfData
            Using writer As New BinaryWriter(Context.Response.OutputStream)
                writer.Write(bytes, 0, bytes.Length)
            End Using
        Catch ex As Exception

        End Try
    End Sub

End Class
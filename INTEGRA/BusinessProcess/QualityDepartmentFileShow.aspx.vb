Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Public Class QualityDepartmentFileShow
    Inherits System.Web.UI.Page
    Dim objQDInspectionUpload As New QDInspectionUpload
    Dim pdfData As Byte()
    Dim IDD As Long
    Dim POID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        IDD = Request.QueryString("ID")
        POID = Request.QueryString("POID")
        If Not Page.IsPostBack Then
            ShowFile()
        End If
    End Sub
    Sub ShowFile()
        Try
            Dim dtt As DataTable
            dtt = objQDInspectionUpload.ShowFIle(IDD, POID)
            For Each row As DataRow In dtt.Rows
                pdfData = DirectCast(row("FileByte"), Byte())
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
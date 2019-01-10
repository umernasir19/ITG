Imports SmartControls.Controls
Imports System.Data
Imports System.Data.DataTable
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports Telerik.Web.UI
Imports Integra.EuroCentra
Imports System.Web.UI.WebControls
Imports System
Public Class EnquiriesDatabaseUploadShow
    Inherits System.Web.UI.Page
    Dim objEnquiresImageDetail As New EnquiresImageDetail
    Dim pdfData As Byte()
    Dim EnquiresImageDetailID As Long
    Dim EnquiriesSystemID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        EnquiriesSystemID = Request.QueryString("EnquiriesSystemID")
        EnquiresImageDetailID = Request.QueryString("EnquiresImageDetailID")
        If Not Page.IsPostBack Then
            ShowFile()
        End If
    End Sub
    Sub ShowFile()
        Try
            Dim dtt As DataTable
            'dtt = ObjTechPackMaster.ShowFIle(IDD, TechPackMasterID)
            'For Each row As DataRow In dtt.Rows
            '    pdfData = DirectCast(row("UploadPicture"), Byte())
            'Next
            'Response.ContentType = "image/jpeg"
            'Dim bytes As Byte() = pdfData
            'Using writer As New BinaryWriter(Context.Response.OutputStream)
            '    writer.Write(bytes, 0, bytes.Length)
            'End Using


            '------------------------
            dtt = objEnquiresImageDetail.ShowFIleNew(EnquiriesSystemID, EnquiresImageDetailID)
            Dim document As Byte() = DirectCast(dtt.Rows(0)("UploadPicture"), Byte())
            'Response.BinaryWrite(document);
            Dim fileExt As String = System.IO.Path.GetExtension(dtt.Rows(0)("FileName"))
            Dim strExtenstion As String = fileExt.ToString()
            Dim DocName As String = dtt.Rows(0)("FileName").ToString()
            Response.Clear()
            Response.Buffer = True
            If strExtenstion = ".doc" OrElse strExtenstion = ".docx" Then
                Response.ContentType = "application/vnd.ms-word"
                Response.AddHeader("content-disposition", "inline;filename=" & DocName & ".doc")
            ElseIf strExtenstion = ".xls" OrElse strExtenstion = ".xlsx" Then
                Response.ContentType = "application/vnd.ms-excel"
                Response.AddHeader("content-disposition", "inline;filename=" & DocName & ".xls")
            ElseIf strExtenstion = ".pdf" Then
                Response.ContentType = "application/pdf"
                Response.AddHeader("content-disposition", "inline;filename=" & DocName & ".pdf")
            ElseIf strExtenstion = ".jpg" Or strExtenstion = ".JPG" Then
                Response.ContentType = "image/jpeg"
                Response.AddHeader("content-disposition", "inline;filename=" & DocName & ".jpg")
            End If
            Response.Charset = ""
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Response.BinaryWrite(document)
            Response.[End]()
        Catch ex As Exception

        End Try
    End Sub

End Class
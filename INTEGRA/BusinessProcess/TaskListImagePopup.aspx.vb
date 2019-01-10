Imports SmartControls.Controls
Imports System.Data
Imports System.Data.DataTable
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Public Class TaskListImagePopup
    Inherits System.Web.UI.Page
    Dim pdfData As Byte()
    Dim IDD As Long
    Dim lPATTERNDEPARTMENTTASKLISTMstid, lPATTERNDEPARTMENTTASKLISTDtlid As Long
    Dim FileNameTP As String
    Dim bytesTP As Byte()
    Dim ObjPatternDepartTaskListDtl As New PatternDepartTaskListDtl
    Dim objPatternDepartTaskListMst As New PatternDepartTaskListMstNew
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lPATTERNDEPARTMENTTASKLISTDtlid = Request.QueryString("PATTERNDEPARTMENTTASKLISTDtlid")
        lPATTERNDEPARTMENTTASKLISTMstid = Request.QueryString("PATTERNDEPARTMENTTASKLISTMstid")
        FileNameTP = Session("FileNameTP")
        bytesTP = Session("ImageByteTP")
        If Not Page.IsPostBack Then
            ShowFile()
        End If
    End Sub
    Private Function GetFileContent(ByVal imageFilePath As String) As Byte()
        Dim fileStream As Stream = New FileStream(imageFilePath, FileMode.Open)
        Dim fileContent As Byte() = New Byte(fileStream.Length - 1) {}
        fileStream.Read(fileContent, 0, CInt(fileStream.Length))
        fileStream.Close()
        Return fileContent
    End Function
    Sub ShowFile()
        Try
            Dim dtt As DataTable
            dtt = objPatternDepartTaskListMst.ShowFIle(lPATTERNDEPARTMENTTASKLISTDtlid, lPATTERNDEPARTMENTTASKLISTMstid)
            Dim document As Byte() = DirectCast(dtt.Rows(0)("UploadPictureTP"), Byte())
            Dim fileExt As String = System.IO.Path.GetExtension(dtt.Rows(0)("FileNameTP"))
            Dim strExtenstion As String = fileExt.ToString()
            Dim DocName As String = dtt.Rows(0)("FileNameTP").ToString()
            Response.Clear()
            Response.Buffer = True
            If strExtenstion = ".doc" OrElse strExtenstion = ".docx" Then
                Response.ContentType = "application/vnd.ms-word"
                Response.AddHeader("content-disposition", "inline;filename=" & DocName & ".doc")
            ElseIf strExtenstion = ".xls" Then
                Response.ContentType = "application/vnd.ms-excel"
                Response.AddHeader("content-disposition", "inline;filename=" & DocName & ".xls")
            ElseIf strExtenstion = ".xlsx" Then
                Response.ContentType = "application/vnd.ms-excel"
                Response.AddHeader("content-disposition", "inline;filename=" & DocName & ".xlsx")
            ElseIf strExtenstion = ".pdf" Then
                Response.ContentType = "application/pdf"
                Response.AddHeader("content-disposition", "inline;filename=" & DocName & ".pdf")
            ElseIf strExtenstion = ".PDF" Then
                Response.ContentType = "application/pdf"
                Response.AddHeader("content-disposition", "inline;filename=" & DocName & ".PDF")
            ElseIf strExtenstion = ".jpg" Then
                Response.ContentType = "image/jpeg"
                Response.AddHeader("content-disposition", "inline;filename=" & DocName & ".jpg")
            ElseIf strExtenstion = ".JPEG" Then
                Response.ContentType = "image/jpeg"
                Response.AddHeader("content-disposition", "inline;filename=" & DocName & ".JPEG")
            ElseIf strExtenstion = ".JPG" Then
                Response.ContentType = "image/jpeg"
                Response.AddHeader("content-disposition", "inline;filename=" & DocName & ".JPG")
            End If
            Response.Charset = ""
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Response.BinaryWrite(document)
            Response.[End]()
        Catch ex As Exception

        End Try
    End Sub

End Class

﻿Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports Telerik.Web.UI
Imports Integra.EuroCentra
Imports System.Web.UI.WebControls
Imports System
Public Class DPStyleDatabaseFrontImage
    Inherits System.Web.UI.Page

    Dim pdfData As Byte()

    Dim FileNameTP As String
    Dim bytesTP As Byte()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      
        FileNameTP = Session("FileNameFrontImage")
        bytesTP = Session("ImageByteFrontImage")
        If Not Page.IsPostBack Then
            ShowFile()
        End If
    End Sub
    Sub ShowFile()
        Try
            Dim document As Byte() = DirectCast(bytesTP, Byte())
            Dim fileExt As String = System.IO.Path.GetExtension(FileNameTP)
            Dim strExtenstion As String = fileExt.ToString()
            Dim DocName As String = FileNameTP.ToString()

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
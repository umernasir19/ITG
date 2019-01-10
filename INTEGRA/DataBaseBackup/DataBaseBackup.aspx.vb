'**************************************************************************************
'*      Form  F_name         :   MRPfrmColor.aspx
'*      Class Description  :    Add / Edit Page for entity "BankReceiptVoucherAdd"
'*      Core Class         :    MRPfrmColor.vb
'**************************************************************************************

Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
 
Imports System.Data.DataTable
Imports Telerik.Web.UI
 
Public Class DataBaseBackup
    Inherits System.Web.UI.Page
    Dim objDataBaseClass As New DataBaseClass
    Dim objcargo As New Cargo
    Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblDate.Text = Format(Date.Now, "dd-MMM-yyyy")
        If Not Page.IsPostBack Then

        End If

    End Sub
    Protected Sub btnDownload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDownload.Click
        Try
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/DataBaseBackup2/"))
                System.IO.File.Delete(Uploadedfiles)
            Next

            Dim FileName As String = "GIA-" + lblDate.Text
            Dim MyPath As String = Request.PhysicalApplicationPath + "/DataBaseBackup2/"
            objcargo.GetDBBackup(MyPath, FileName)
            Response.ContentType = "MDF"
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName)
            Response.TransmitFile(MyPath + "/" + FileName)
            Response.End()
            ' DirectCast(Me.Page.Master, MasterPage).ShowMessgae("DataBase Backup Create Successfully .")

        Catch ex As Exception

        End Try
    End Sub

End Class

Imports System
Imports Telerik.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web
Imports Telerik.Web.UI.Barcode


Public Class fq
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            RadBarcode1.Text = "http://localhost:3252/BusinessProcess/QRCodeMGT.aspx?IPOID=9533"
            ' RadBarcode1.GetImage.Save(Server.MapPath("~/POQRCodes/MGT/"))
            RadBarcode1.GetImage.Save(Server.MapPath("~/POQRCodes/QRCodeMGT.png"))
        End If
    End Sub

End Class
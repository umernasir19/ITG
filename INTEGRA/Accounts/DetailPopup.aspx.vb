Imports System.Data
Imports System.Data.DataTable
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Drawing.Color
Imports System.Drawing.KnownColor
Imports System.Web
Imports System.Reflection
Imports System.Drawing
Public Class DetailPopup
    Inherits System.Web.UI.Page
    Dim objGeneralCode As New GeneralCode
    Dim dtWashingDatabase As New DataTable
    Dim dr As DataRow
    Dim lJobOrderID, lJoborderDetailid, lStyleAssortmentMasterID As Long
    Dim UserId As Long
    Dim DtStyleAssortmentDetail As New DataTable
    Dim dtGrid As New DataTable
    Dim Styles, JobType As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Session("dtGrid") = Nothing
            BindGrid()
        End If
    End Sub
    Private Sub BindGrid()
        Try
            Dim objDatatble2 As DataTable
            objDatatble2 = Session("dtDetailInv")
            If objDatatble2.Rows.Count > 0 Then
                dgpaymentDetailInvoicewise.Visible = True
                dgpaymentDetailInvoicewise.RecordCount = objDatatble2.Rows.Count
                dgpaymentDetailInvoicewise.DataSource = objDatatble2
                dgpaymentDetailInvoicewise.DataBind()
            Else
                dgpaymentDetailInvoicewise.Visible = False
            End If
            Dim TotalWHTaxAmt As Decimal = 0
            Dim TotalSTaxAmt As Decimal = 0
            Dim x As Integer
            Dim CheckdstatusForInvoiceInfo As New CheckBox
            Dim ChkStatus As New CheckBox
            For x = 0 To dgpaymentDetailInvoicewise.Items.Count - 1

                CheckdstatusForInvoiceInfo = DirectCast(dgpaymentDetailInvoicewise.Items(x).FindControl("lblCheckdstatusForInvoiceInfo"), CheckBox)
                TotalWHTaxAmt = TotalWHTaxAmt + Val(dgpaymentDetailInvoicewise.Items(x).Cells(8).Text)
                TotalSTaxAmt = TotalSTaxAmt + Val(dgpaymentDetailInvoicewise.Items(x).Cells(9).Text)
                Dim datechk As Date = dgpaymentDetailInvoicewise.Items(x).Cells(2).Text
                dgpaymentDetailInvoicewise.Items(x).Cells(2).Text = datechk
                CheckdstatusForInvoiceInfo.Checked = True


            Next
        Catch ex As Exception
        End Try
    End Sub
End Class

Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Public Class VenderCertificates
    Inherits System.Web.UI.Page
    Dim objCertificate As New Certificate
    Dim objVendor As New Vender
    Dim objvenderCertificate As New VenderCertificate
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindCertificate()
            BindSupplier()
        End If
    End Sub
    Sub BindCertificate()
        Try
            Dim dtMarchandizer As DataTable = objCertificate.GetVenderCertificate
            cmbCertificate.DataSource = dtMarchandizer
            cmbCertificate.DataTextField = "Certificate"
            cmbCertificate.DataValueField = "CertificateID"
            cmbCertificate.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Sub BindSupplier()
        Try
            Dim dtSupplier As DataTable = objVendor.getDataforBindCombo
            With cmbVendor
                .DataSource = dtSupplier
                .DataTextField = "VenderName"
                .DataValueField = "VenderLibraryID"
                .DataBind()
            End With
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Dim ExpiryDate As String = txtExpiryDate.SelectedDate.ToString()
        If ExpiryDate = "" Then
            lblmsg.Text = "Not Save"
        ElseIf FileUpload1.FileName = "" Then
            lblmsg.Text = "Not Save"
        Else
            'First chk if this vendor have this Certificate already then replace existing one
            Dim dtExist As DataTable
            dtExist = objvenderCertificate.getDataa(cmbVendor.SelectedValue, cmbCertificate.SelectedValue)
            If dtExist.Rows.Count > 0 Then
                With objvenderCertificate
                    .VenderCertificateID = dtExist.Rows(0)("VenderCertificateID")
                    .CertificateImage = SaveImginByte()
                    .CertificateID = cmbCertificate.SelectedValue
                    .Venderid = cmbVendor.SelectedValue
                    .CertificateExpire = txtExpiryDate.SelectedDate
                    .SaveVenderCertificate()
                End With
            Else
                With objvenderCertificate
                    .VenderCertificateID = 0
                    .CertificateImage = SaveImginByte()
                    .CertificateID = cmbCertificate.SelectedValue
                    .Venderid = cmbVendor.SelectedValue
                    .CertificateExpire = txtExpiryDate.SelectedDate
                    .SaveVenderCertificate()
                End With
            End If
         
            lblmsg.Text = "Certificate Save"
        End If
    End Sub
    Function SaveImginByte() As Object
        Try
            Dim imgByte As Byte() = Nothing
            If FileUpload1.HasFile AndAlso Not FileUpload1.PostedFile Is Nothing Then
                'To create a PostedFile
                Dim File As HttpPostedFile = FileUpload1.PostedFile
                'Create byte Array with file len
                imgByte = New Byte(File.ContentLength - 1) {}
                'force the control to load data in array
                File.InputStream.Read(imgByte, 0, File.ContentLength)
            End If
            Return imgByte
        Catch ex As Exception
        End Try
    End Function

    'Dim dtt As DataTable
    'dtt = objvenderCertificate.getDataa(cmbVendor.SelectedValue)
    'Dim pdfData As Byte()
    'For Each row As DataRow In dtt.Rows
    '    pdfData = DirectCast(row("CertificateImage"), Byte())
    'Next
    'Response.ContentType = "application/pdf"
    'Dim bytes As Byte() = pdfData
    'Using writer As New BinaryWriter(Context.Response.OutputStream)
    '    writer.Write(bytes, 0, bytes.Length)
    'End Using

End Class
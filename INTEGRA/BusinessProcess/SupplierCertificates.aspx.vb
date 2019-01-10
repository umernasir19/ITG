Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports System.IO
Imports Telerik.Web.UI
Imports System.Runtime.Serialization.Formatters.Binary
Public Class SupplierCertificates
    Inherits System.Web.UI.Page
    Dim objCertificate As New Certificate
    Dim objVendor As New Vender
    Dim objvenderCertificate As New VenderCertificate
    Dim SupplierID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SupplierID = objVendor.DecryptString(Request.QueryString("SupplierID"))
        If Not Page.IsPostBack Then
            BindCertificate()
            BindSupplier()
            If SupplierID > 0 Then
                cmbVendor.SelectedValue = SupplierID
                cmbVendor.Enabled = False

                'View 
                Dim objDataView As DataView
                objDataView = LoadData()
                Session("objComplianceStatus") = objDataView
                BindGrid()
            End If
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
                    ' .CertificateID = cmbCertificate.SelectedValue
                    .Venderid = cmbVendor.SelectedValue
                    '  .CertificateExpire = txtExpiryDate.SelectedDate
                    .SaveVenderCertificate()
                End With
            Else
                With objvenderCertificate
                    .VenderCertificateID = 0
                    .CertificateImage = SaveImginByte()
                    '  .CertificateID = cmbCertificate.SelectedValue
                    .Venderid = cmbVendor.SelectedValue
                    '  .CertificateExpire = txtExpiryDate.SelectedDate
                    .SaveVenderCertificate()
                End With
            End If

            lblmsg.Text = "Certificate Save"

            'View 
            Dim objDataView As DataView
            objDataView = LoadData()
            Session("objComplianceStatus") = objDataView
            BindGrid()

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

    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            objDataView = Session("objComplianceStatus")
            dgComplianceStatuss.DataSource = objDataView
            dgComplianceStatuss.DataBind()
            upcmbAction.Update()
        Catch ex As Exception
        End Try
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objvenderCertificate.getCertificateSupplierData(SupplierID)
        Dim dtEmailDuplicate As New DataTable
        Dim DtEmailInfo As New DataTable
        'Make Email forSocial Compliance  ... Always 90 days, 
        Dim objWIPChart As New WIPChart
        Dim Dr As DataRow
        With dtEmailDuplicate
            .Columns.Add("VenderLibraryID", GetType(String))
            .Columns.Add("CertificateID", GetType(String))
            .Columns.Add("Supplier", GetType(String))
            .Columns.Add("Certificate", GetType(String))
            .Columns.Add("Validity", GetType(String))
            .Columns.Add("Status", GetType(String))
        End With
        'Bind Grid
        'For 90 days
        Dim xx As Integer
        Dim Tdays As TimeSpan
        For xx = 0 To objDataTable.Rows.Count - 1
            Dim CertificateExpire As Date = objDataTable.Rows(xx)("CertificateExpire")
            If objDataTable.Rows(xx)("CertificateExpire") < Date.Now Then
                Dr = dtEmailDuplicate.NewRow()
                Dr("VenderLibraryID") = objDataTable.Rows(xx)("VenderLibraryID")
                Dr("CertificateID") = objDataTable.Rows(xx)("CertificateID")
                Dr("Supplier") = objDataTable.Rows(xx)("vendername")
                Dr("Certificate") = objDataTable.Rows(xx)("Certificate")
                Dr("Validity") = CertificateExpire.ToString("dd-MM-yyyy")
                Dr("Status") = "Expired"
                dtEmailDuplicate.Rows.Add(Dr)
            ElseIf objDataTable.Rows(xx)("CertificateExpire") < Date.Now.AddDays(90) Then
                Dr = dtEmailDuplicate.NewRow()
                Dr("VenderLibraryID") = objDataTable.Rows(xx)("VenderLibraryID")
                Dr("CertificateID") = objDataTable.Rows(xx)("CertificateID")
                Dr("Supplier") = objDataTable.Rows(xx)("vendername")
                Dr("Certificate") = objDataTable.Rows(xx)("Certificate")
                Dr("Validity") = CertificateExpire.ToString("dd-MM-yyyy")
                Tdays = CertificateExpire.Subtract(Date.Now)
                Dr("Status") = Tdays.Days.ToString() + " days left to expire"
                dtEmailDuplicate.Rows.Add(Dr)
            ElseIf objDataTable.Rows(xx)("CertificateExpire") > Date.Now.AddDays(90) Then
                Dr = dtEmailDuplicate.NewRow()
                Dr("VenderLibraryID") = objDataTable.Rows(xx)("VenderLibraryID")
                Dr("CertificateID") = objDataTable.Rows(xx)("CertificateID")
                Dr("Supplier") = objDataTable.Rows(xx)("vendername")
                Dr("Certificate") = objDataTable.Rows(xx)("Certificate")
                Dr("Validity") = CertificateExpire.ToString("dd-MM-yyyy")
                Dr("Status") = "Active"
                dtEmailDuplicate.Rows.Add(Dr)
            End If
        Next
        objDataView = New DataView(dtEmailDuplicate)
        Return objDataView
    End Function
    Protected Sub dgPurchaseOrder_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgComplianceStatuss.ItemCommand
        Try
            Select Case e.CommandName
                Case "Edit"
                    Dim VenderLibraryID As Long = dgComplianceStatuss.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim CertificateID As Long = dgComplianceStatuss.Items(e.Item.ItemIndex).Cells(1).Text

                    ScriptManager.RegisterClientScriptBlock(Me.UpdatePanel1, Me.UpdatePanel1.GetType(), "New ClientScript", "window.open('CertificatePopup.aspx?SupplierID=" & Vender.EncryptData(VenderLibraryID) & "&CertificateID=" & CertificateID & "', 'PopUpWindowName', 'left=12, top=60, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no');", True)
            End Select
        Catch ex As Exception
        End Try

    End Sub


End Class
Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Public Class ActiveSupplier
    Inherits System.Web.UI.Page
    Dim objVender As New Vender
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objDataview As DataView
        If Not Page.IsPostBack Then
            Try
                objDataview = LoadData()
                Session("objDataView") = objDataview
                BindGrid()
            Catch ex As Exception

            End Try
        End If
    End Sub
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            objDataView = Session("objDataView")
            dgSupplier.DataSource = objDataView
            dgSupplier.DataBind()

            Dim x As Integer
            Dim cmbCertificate As DropDownList
            Dim lblCertificate As Label
            Dim objVenderCertificate As New VenderCertificate
            For x = 0 To dgSupplier.Items.Count - 1
                Dim item As GridDataItem = DirectCast(dgSupplier.MasterTableView.Items(x), GridDataItem)
                cmbCertificate = CType(dgSupplier.Items(x).FindControl("cmbCertificate"), DropDownList)
                lblCertificate = CType(dgSupplier.Items(x).FindControl("lblCertificate"), Label)

                Dim VenderLibraryID As Long = item("VenderLibraryID").Text
                Dim dtCertificate As DataTable = objVenderCertificate.getVendorCertificateInfo(VenderLibraryID)
                If dtCertificate.Rows.Count > 0 Then
                    cmbCertificate.DataSource = dtCertificate
                    cmbCertificate.DataTextField = "Certificate"
                    cmbCertificate.DataValueField = "CertificateID"
                    cmbCertificate.DataBind()

                    cmbCertificate.Visible = True
                    lblCertificate.Visible = False
                Else
                    lblCertificate.Visible = True
                    cmbCertificate.Visible = False
                    lblCertificate.Text = "No Certificate Found"
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objVender.GetActiveSupplierNew
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
End Class
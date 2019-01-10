Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO

Public Class SupplierProfileView
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
    ' Procedure that Binds the Grid
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

                    'cmbCertificate.Visible = True
                    cmbCertificate.Visible = False
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
        objDataTable = objVender.GetActiveVendorNewNew

        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Protected Sub RadButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RadButton1.Click
        Response.Redirect("~/SupplierSetup/SupplierProfile.aspx")
    End Sub
    Protected Sub dgSupplier_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles dgSupplier.NeedDataSource
        dgSupplier.DataSource = objVender.GetActiveVendorNewNew
    End Sub
    Protected Sub dgSupplier_ItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles dgSupplier.ItemCreated
        If TypeOf e.Item Is GridFilteringItem Then
            Dim filterItem As GridFilteringItem = DirectCast(e.Item, GridFilteringItem)
        End If
    End Sub
    Protected Sub dgSupplier_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles dgSupplier.PageIndexChanged
        BindGrid()
    End Sub
    Protected Sub dgSupplier_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles dgSupplier.SortCommand
        BindGrid()
    End Sub
End Class
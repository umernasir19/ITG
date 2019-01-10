Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO

Public Class ComplianceStatus
    Inherits System.Web.UI.Page
    Dim objVenderCertificate As New VenderCertificate
    Dim VenderLibraryID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim objDataView As DataView
            objDataView = LoadData()
            Session("objComplianceStatus") = objDataView
            BindGrid()
        End If

    End Sub
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            objDataView = Session("objComplianceStatus")
            dgComplianceStatus.DataSource = objDataView
            dgComplianceStatus.DataBind()
            upcmbAction.Update()
        Catch ex As Exception
        End Try
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objVenderCertificate.getCertificateDataNew()
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
            Dim CertificateExpire As Date = objDataTable.Rows(xx)("ExpiryDate")
            If objDataTable.Rows(xx)("ExpiryDate") < Date.Now Then
                Dr = dtEmailDuplicate.NewRow()
                Dr("VenderLibraryID") = objDataTable.Rows(xx)("VenderLibraryID")
                Dr("CertificateID") = objDataTable.Rows(xx)("VenderSocialComplianceID")
                Dr("Supplier") = objDataTable.Rows(xx)("vendername")
                Dr("Certificate") = objDataTable.Rows(xx)("CertificateName")
                Dr("Validity") = CertificateExpire.ToString("dd-MM-yyyy")
                Dr("Status") = "Expired"
                dtEmailDuplicate.Rows.Add(Dr)
            ElseIf objDataTable.Rows(xx)("ExpiryDate") < Date.Now.AddDays(90) Then
                Dr = dtEmailDuplicate.NewRow()
                Dr("VenderLibraryID") = objDataTable.Rows(xx)("VenderLibraryID")
                Dr("CertificateID") = objDataTable.Rows(xx)("VenderSocialComplianceID")
                Dr("Supplier") = objDataTable.Rows(xx)("vendername")
                Dr("Certificate") = objDataTable.Rows(xx)("CertificateName")
                Dr("Validity") = CertificateExpire.ToString("dd-MM-yyyy")
                Tdays = CertificateExpire.Subtract(Date.Now)
                Dr("Status") = Tdays.Days.ToString() + " days left to expire"
                dtEmailDuplicate.Rows.Add(Dr)
            ElseIf objDataTable.Rows(xx)("ExpiryDate") > Date.Now.AddDays(90) Then
                Dr = dtEmailDuplicate.NewRow()
                Dr("VenderLibraryID") = objDataTable.Rows(xx)("VenderLibraryID")
                Dr("CertificateID") = objDataTable.Rows(xx)("VenderSocialComplianceID")
                Dr("Supplier") = objDataTable.Rows(xx)("vendername")
                Dr("Certificate") = objDataTable.Rows(xx)("CertificateName")
                Dr("Validity") = CertificateExpire.ToString("dd-MM-yyyy")
                Dr("Status") = "Active"
                dtEmailDuplicate.Rows.Add(Dr)
            End If
        Next
        objDataView = New DataView(dtEmailDuplicate)
        Return objDataView
    End Function
    Protected Sub dgComplianceStatus_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgComplianceStatus.ItemCommand
        Select Case e.CommandName
            Case Is = "ViewCertificate"
                Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                Dim VenderLibraryID As String = item("VenderLibraryID").Text
                Dim CertificateID As String = item("CertificateID").Text
                ' Response.Write("<script> window.open('CertificatePopup.aspx?SupplierID=" & VenderLibraryID & "&CertificateID=" & CertificateID & "', 'newwindow', 'left=12, top=60, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")
                ScriptManager.RegisterClientScriptBlock(Me.upcmbAction, Me.upcmbAction.GetType(), "New ClientScript", "window.open('CertificatePopup.aspx?SupplierID=" & VenderLibraryID & "&CertificateID=" & CertificateID & "', 'newwindow', 'left=12, top=60, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no');", True)
        End Select
    End Sub
    Protected Sub dgComplianceStatus_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles dgComplianceStatus.NeedDataSource
        Dim objDataView As DataView
        objDataView = Session("objComplianceStatus")
        dgComplianceStatus.DataSource = objDataView
        ' dgComplianceStatus.DataSource = objVenderCertificate.getCertificateData()
        upcmbAction.Update()
    End Sub
    Protected Sub dgComplianceStatus_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles dgComplianceStatus.SortCommand
        BindGrid()
        upcmbAction.Update()
    End Sub
    'Protected Sub dgComplianceStatus_ItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles dgComplianceStatus.ItemCreated
    '    If TypeOf e.Item Is GridFilteringItem Then
    '        Dim filterItem As GridFilteringItem = DirectCast(e.Item, GridFilteringItem)
    '    End If
    'End Sub
    Protected Sub dgComplianceStatus_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles dgComplianceStatus.PageIndexChanged
        BindGrid()
        upcmbAction.Update()
    End Sub

End Class
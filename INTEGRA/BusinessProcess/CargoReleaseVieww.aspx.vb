Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Public Class CargoReleaseVieww
    Inherits System.Web.UI.Page
    Dim objCargo As New Cargo
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Expires = 0
        Dim objDataView As DataView
        If Not Page.IsPostBack Then
            Try
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()
            Catch objUDException As UDException
            End Try
            If CLng(Session("Userid")) = 26 Then
                btnCheckCurrency.Visible = True
            Else
                btnCheckCurrency.Visible = False
            End If
        End If
        PageHeader("Shipment Release")
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    ' Procedure that Binds the Grid
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            objDataView = Session("objDataView")
            If objDataView.Count > 0 Then
                dgCargo.Visible = True
                dgCargo.DataSource = objDataView
                dgCargo.DataBind()
            Else
                dgCargo.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objCargo.GetCargoinfoNewMaxFieldsLatest
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function

    Protected Sub dgCargo_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles dgCargo.NeedDataSource
        BindGrid()
    End Sub

    Protected Sub dgCargo_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles dgCargo.PageIndexChanged
        BindGrid()
    End Sub

    Protected Sub dgCargo_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles dgCargo.SortCommand
        BindGrid()
    End Sub

    Protected Sub btnAddShipment_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddShipment.Click
        Session("dtArticle") = Nothing
        Session("dtSelection") = Nothing
        Response.Redirect("CargoRelease.aspx")
    End Sub

    Protected Sub btnCheckCurrency_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCheckCurrency.Click
        Try
            Dim dt, dtcargodetail As New DataTable
            Dim x, y As Integer
            Dim ObjCragodetail As New CargoDetail
            dt = objCargo.GetCargoinfoNewMaxFieldsLatest
            'Now check in Invoice all pos have one currency
            For x = 0 To dt.Rows.Count - 1
                dtcargodetail = ObjCragodetail.Getalldata(dt.Rows(x)("Cargoid"))
                If dtcargodetail.Rows.Count = 1 Then
                    objCargo.UpdateCurrency(dt.Rows(x)("Cargoid"), dtcargodetail.Rows(0)("currency"))
                Else
                    objCargo.UpdateCurrency(dt.Rows(x)("Cargoid"), "NoCurrency")
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
End Class
Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Public Class GIACodingCustomerView
    Inherits System.Web.UI.Page
    Dim objGIACodingCustomer As New GIACodingCustomer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objDataView As DataView
        If Not Page.IsPostBack Then
            Try
                objDataView = LoadData("ALL", "ALL")
                Session("objDataView") = objDataView
                BindGrid()
            Catch objUDException As UDException
            End Try
        End If
        PageHeader("Customer GIA Number Control Panel")
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
                dgLKZ.Visible = True
                dgLKZ.DataSource = objDataView
                dgLKZ.DataBind()
            Else
                dgLKZ.Visible = False
            End If
            TryCast(dgLKZ.MasterTableView.GetColumn("SupplierID"), GridBoundColumn).Display = False
            TryCast(dgLKZ.MasterTableView.GetColumn("CustomerID"), GridBoundColumn).Display = False
        Catch ex As Exception
        End Try
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData(ByVal Vender, ByVal Buyer) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objGIACodingCustomer.CheckALlLKZ(Vender, Buyer)
        objDataView = New DataView(objDataTable)

        Return objDataView
    End Function
    Protected Sub cmdAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdAdd.Click
        Response.Redirect("GIACodingCustomerEntry.aspx")
    End Sub
End Class
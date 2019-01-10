Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports System.IO
Public Class D_StyleLibraryMainView
    Inherits System.Web.UI.Page
    Dim objD_Style As New D_Style
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LoadData()


        End If
    End Sub
    ' Function that Loads the data and return dataview
    Sub LoadData()

        Dim objDataTable As DataTable
        objDataTable = objD_Style.ShowAll()

        DataList1.DataSource = objDataTable
        DataList1.DataBind()
    End Sub
    Protected Sub DataList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DataList1.SelectedIndexChanged

    End Sub
End Class
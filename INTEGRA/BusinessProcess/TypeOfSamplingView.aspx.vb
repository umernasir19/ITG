Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.Xml
Imports System.IO
Public Class TypeOfSamplingView
    Inherits System.Web.UI.Page
    Dim objTypeOfSampling As New TypeOfSampling
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Try
                Dim objDataView As DataView
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()
            Catch objUDException As UDException
            End Try
        End If
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objTypeOfSampling.GetDataForView()
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            objDataView = Session("objDataView")
            If objDataView.Count > 0 Then
                dgTypeOfSamplingView.DataSource = objDataView
                dgTypeOfSamplingView.DataBind()

            Else
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub BtnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnAdd.Click
        Try
            Response.Redirect("TypeOfSamplingEntry.aspx")
        Catch ex As Exception

        End Try
    End Sub

End Class
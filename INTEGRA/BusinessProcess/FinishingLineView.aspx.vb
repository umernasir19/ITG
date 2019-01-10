Imports System.Data
Imports Integra.EuroCentra
Public Class FinishingLineView
    Inherits System.Web.UI.Page
    Dim objFinishingLine As New FinishingLine
    Dim objFinishingLineDetail As New FinishingLineDetail
    Dim IPOID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        IPOID = Request.QueryString("IPOID")
        Dim objDataView As DataView
        If Not Page.IsPostBack Then
            objDataView = LoadData()
            Session("objDataView") = objDataView
            BindGrid()
        End If
    End Sub
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            objDataView = Session("objDataView")
            dgFinishingLineView.DataSource = objDataView
            dgFinishingLineView.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData() As ICollection
        Dim objDataView As New DataView
        Dim objDataTable As New DataTable
        objDataTable = objFinishingLine.GetData(IPOID)
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
End Class
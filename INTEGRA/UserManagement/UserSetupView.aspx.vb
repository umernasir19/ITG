Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class UserSetupView
    Inherits System.Web.UI.Page
    Dim objDataView As DataView
    Dim ObjTblRND As New TblDPRND
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        objDataView = LoadData()
        Session("objDataView") = objDataView
        BindGrid()
    End Sub
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            objDataView = Session("objDataView")
            dgRoleSetupView.DataSource = objDataView
            dgRoleSetupView.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = ObjTblRND.GetDataForUserSetupView()
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Protected Sub btnAddRoleSetup_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddRoleSetup.Click
        Try
            Response.Redirect("UserSetup.aspx")
        Catch ex As Exception

        End Try
    End Sub
End Class

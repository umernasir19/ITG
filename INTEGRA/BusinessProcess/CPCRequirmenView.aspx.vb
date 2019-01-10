Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Net
Imports System.Net.Mail
Imports Integra.EuroCentra
Public Class CPCRequirmenView
    Inherits System.Web.UI.Page

    Dim objtblCPRequirmenBuyer As New tblCPRequirmenBuyer
    Dim objDataView As DataView
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objDataView As DataView
        If Not Page.IsPostBack Then
            Try
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()
            Catch objUDException As UDException
            End Try
        End If
        PageHeader("Critical Path Supplier End Requirment")
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
            Dim strSortExpression As String
            objDataView = Session("objDataView")
            If objDataView.Count > 0 Then
                dgCPCRequirment.Visible = True
                strSortExpression = dgCPCRequirment.SortExpression
                If strSortExpression <> "" Then
                    objDataView.Sort = strSortExpression
                    If Not dgCPCRequirment.IsSortedAscending Then
                        objDataView.Sort += " DESC"
                    End If
                End If
                dgCPCRequirment.RecordCount = objDataView.Count
                dgCPCRequirment.DataSource = objDataView
                dgCPCRequirment.DataBind()
            Else
                dgCPCRequirment.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    ' Function that Loads the data and return dataview
    Function LoadData() As ICollection

        Dim objDataTable As DataTable
        objDataTable = objtblCPRequirmenBuyer.GetAllh()
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    'PageChanged (NOT private otherwise unaccessible from the page)
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs)
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs)

    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
        Response.Redirect("CPCRequirmenEntry.aspx")
    End Sub
    Protected Sub dgCPCRequirment_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgCPCRequirment.ItemCommand
        Select Case e.CommandName
            Case Is = "Remove"
                Dim CPRequirmentBID As Long = dgCPCRequirment.Items(e.Item.ItemIndex).Cells(0).Text
                objtblCPRequirmenBuyer.deletepodtl(CPRequirmentBID)
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()


        End Select
    End Sub


End Class
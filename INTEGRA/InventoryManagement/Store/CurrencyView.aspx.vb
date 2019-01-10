Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Xml
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Public Class CurrencyView
    Inherits System.Web.UI.Page
    Dim ObjIMSCurrency As New IMSCurrency2
    Dim ObjDepartmentDataBase As New DepartmetDataBase
    Dim UserId As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objDataView As DataView
        UserId = Session("UserId")
        If Not Page.IsPostBack Then
            Try
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()
                GetRights()
            Catch objUDException As UDException
            End Try
            PageHeader("Currency Database")
        End If
    End Sub
    Sub GetRights()
        Dim Path As String = Request.Url.AbsolutePath()
        Dim PathArr() As String = Path.Split("/")
        Dim Path7 As String = PathArr(PathArr.Length - 3)
        Dim Path5 As String = PathArr(PathArr.Length - 2)
        Dim Path6 As String = PathArr(PathArr.Length - 1)
        Dim Path4 As String = Path7 + "/" + Path5 + "/" + Path6
        Dim dt As DataTable
        dt = ObjDepartmentDataBase.CheckdataWithAccess(UserId, Path4)
        If dt.Rows.Count > 0 Then
            Dim Add As String = dt.Rows(0)("AddStatus")
            Dim View As String = dt.Rows(0)("ViewStatus")
            Dim Delete As String = dt.Rows(0)("DeleteStatus")
            If Add = 1 Then
                btnCurrency.Enabled = True
            Else
                btnCurrency.Enabled = False
            End If
            If View = 1 Then
                Dim x As Long
                For x = 0 To dgCurrency.Items.Count - 1
                    Dim lnkEditt As ImageButton = CType(dgCurrency.Items(x).FindControl("lnkEdit"), ImageButton)
                    lnkEditt.Enabled = True
                Next
            Else
                Dim x As Long
                For x = 0 To dgCurrency.Items.Count - 1
                    Dim lnkEditt As ImageButton = CType(dgCurrency.Items(x).FindControl("lnkEdit"), ImageButton)
                    lnkEditt.Enabled = False
                Next
            End If
            If Delete = 1 Then
                Dim x As Long
                For x = 0 To dgCurrency.Items.Count - 1
                    Dim lnkRemove As ImageButton = CType(dgCurrency.Items(x).FindControl("lnkRemove"), ImageButton)
                    lnkRemove.Enabled = True
                Next
            Else
                Dim x As Long
                For x = 0 To dgCurrency.Items.Count - 1
                    Dim lnkRemove As ImageButton = CType(dgCurrency.Items(x).FindControl("lnkRemove"), ImageButton)
                    lnkRemove.Enabled = False
                Next
            End If
        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Private Sub BindGrid()
        Dim objDataView As DataView
        objDataView = Session("objDataView")
        If objDataView.Count > 0 Then
            dgCurrency.RecordCount = objDataView.Count
            dgCurrency.DataSource = objDataView
            dgCurrency.DataBind()
            Dim gridItem As DataGridItem
            Dim iPos As Long = 1
            For Each gridItem In dgCurrency.Items
                With gridItem
                    Dim lblSrNo As Label = CType(.FindControl("lblSNo"), Label)
                    lblSrNo.Text = iPos
                    iPos += 1
                End With
            Next
        Else
        End If
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = ObjIMSCurrency.GetIMSCurrencyAll
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        BindGrid()
    End Sub
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs)
        BindGrid()
    End Sub
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs)
    End Sub
    Protected Sub dgCurrency_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgCurrency.ItemCommand
        Try
            Select Case e.CommandName
                Case Is = "Edit"
                    Dim IMSCurrencyID As Long = dgCurrency.Items(e.Item.ItemIndex).Cells(0).Text
                    Response.Redirect("CurrencyEntry.aspx?IMSCurrencyID=" & IMSCurrencyID & "")
                Case Is = "Remove"
                    Dim IMSCurrencyID As Long = dgCurrency.Items(e.Item.ItemIndex).Cells(0).Text
                    ObjIMSCurrency.DeleteDetail(IMSCurrencyID)
                    Dim objDataView As DataView
                    Dim objDataTable As DataTable
                    objDataTable = ObjIMSCurrency.GetIMSCurrencyAll
                    objDataView = New DataView(objDataTable)
                    Session("objDataView") = objDataView
                    BindGrid()
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnCurrency_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCurrency.Click
        Try
            Response.Redirect("../Store/CurrencyEntry.aspx")
        Catch ex As Exception
        End Try
    End Sub
End Class

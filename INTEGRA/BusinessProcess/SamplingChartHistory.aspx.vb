Imports System.Data
Imports Integra.EuroCentra
Public Class SamplingChartHistory
    Inherits System.Web.UI.Page
    Dim ObjSampleTNAChartHistory As New SampleTNAChartHistory
    Dim ProcessID As String
    Dim StyleID As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ProcessID = Request.QueryString("lProcessID")
        StyleID = Request.QueryString("StyleID")
        Dim objDataView As DataView
        If Not Page.IsPostBack Then
            Try
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()
            Catch objUDException As UDException
            End Try
        End If
        PageHeader("Sampling History View")
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
        Dim ImgBtn As ImageButton = Master.FindControl("Impak")
        ImgBtn.Enabled = False
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = ObjSampleTNAChartHistory.GetTNAChartHistoryByProcess(ProcessID, StyleID)
        lblProcessName.Text = objDataTable.Rows(0)("Process")
        lblPONo.Text = objDataTable.Rows(0)("styleno")
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Private Sub BindGrid()
        Dim objDataView As DataView
        '  Dim strSortExpression As String
        objDataView = Session("objDataView")
        If objDataView.Count > 0 Then
            dgprocessHistory.VirtualItemCount = objDataView.Count
            dgprocessHistory.DataSource = objDataView
            dgprocessHistory.DataBind()
        Else
        End If
    End Sub
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs)
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs)
        'BindGrid()
    End Sub
End Class
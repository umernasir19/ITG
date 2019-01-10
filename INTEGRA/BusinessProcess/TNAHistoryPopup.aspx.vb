Imports System.Data
Imports Integra.EuroCentra
Public Class TNAHistoryPopup
    Inherits System.Web.UI.Page
    Dim ObjProcessHistory As New TNAChartHistory
    Dim ProcessID As String
    Dim POID As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Expires = 0
        ProcessID = Request.QueryString("lProcessID")
        POID = Request.QueryString("lPOID")
        Dim objDataView As DataView
        If Not Page.IsPostBack Then
            Try
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()
            Catch objUDException As UDException
            End Try
        End If
        ' PageHeader("Milestone History View")
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
        objDataTable = ObjProcessHistory.GetTNAChartHistoryByProcess(ProcessID, POID)
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Private Sub BindGrid()
        Dim objDataView As DataView

        Dim dtprocessandPOP As DataTable
        dtprocessandPOP = ObjProcessHistory.GetPONOAndProcess(ProcessID, POID)
        lblProcessName.Text = dtprocessandPOP.Rows(0)("Process")
        lblPONo.Text = dtprocessandPOP.Rows(0)("PONo")

        '  Dim strSortExpression As String
        objDataView = Session("objDataView")
        If objDataView.Count > 0 Then
            lblmsg.Visible = False
            'strSortExpression = dgprocessHistory.SortExpression
            'If strSortExpression <> "" Then
            '    objDataView.Sort = strSortExpression
            '    If Not dgprocessHistory.IsSortedAscending Then
            '        objDataView.Sort += " DESC"
            '    End If
            'End If
            'dgprocessHistory.RecordCount = objDataView.Count
            dgprocessHistory.VirtualItemCount = objDataView.Count
            dgprocessHistory.DataSource = objDataView
            dgprocessHistory.DataBind()

            ''------------- Set Style of Grid
            'dgprocessHistory.Columns(0).ItemStyle().ForeColor = Drawing.Color.Green
            'dgprocessHistory.Columns(0).ItemStyle().Font.Bold = True
            'dgprocessHistory.Columns(0).ItemStyle().Font.Size = 9
            ''-------------Status
            'dgprocessHistory.Columns(1).ItemStyle().ForeColor = Drawing.Color.Green
            'dgprocessHistory.Columns(1).ItemStyle().Font.Bold = True
            'dgprocessHistory.Columns(1).ItemStyle().Font.Size = 9
            ''-------------- Estimated Date
            'dgprocessHistory.Columns(2).ItemStyle().ForeColor = Drawing.Color.Yellow
            'dgprocessHistory.Columns(2).ItemStyle().Font.Bold = True
            'dgprocessHistory.Columns(2).ItemStyle().Font.Size = 9
            ''-------------- Actual Date
            'dgprocessHistory.Columns(3).ItemStyle().ForeColor = Drawing.Color.Red
            'dgprocessHistory.Columns(3).ItemStyle().Font.Bold = True
            'dgprocessHistory.Columns(3).ItemStyle().Font.Size = 9
            ''-------------- Remarks
            'dgprocessHistory.Columns(4).ItemStyle().ForeColor = Drawing.Color.Red
            'dgprocessHistory.Columns(4).ItemStyle().Font.Bold = True
            'dgprocessHistory.Columns(4).ItemStyle().Font.Size = 9


        Else
            lblmsg.Visible = True
            lblmsg.Text = "Not Record Found."
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
    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Try
            Response.Redirect("TNAChartPopup.aspx?lPOID=" & POID & "")
        Catch objUDException As UDException
        End Try

    End Sub
End Class

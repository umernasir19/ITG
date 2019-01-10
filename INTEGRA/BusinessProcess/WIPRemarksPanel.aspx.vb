Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO

Public Class WIPRemarksPanel
    Inherits System.Web.UI.Page
    Dim lPOID As Long
    Dim lPODetailID As Long
    Dim dr As System.Data.DataRow
    Dim dt As New DataTable
    Dim objWIPChart As New WIPChart

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lPOID = Request.QueryString("lPOID")
        lPODetailID = Request.QueryString("lPODetailID")
        Dim objDataView As DataView
        If Not Page.IsPostBack Then
            objDataView = LoadData()
            Session("objDataView") = objDataView
            BindGrid()
            btnclose.Visible = False
            btnsaveSave.Visible = True
            txtWIPRemarks.ReadOnly = False
            chkApplyInAll.Enabled = True

        End If
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objWIPChart.GetAllWIPProcess(lPOID, lPODetailID)
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    ' Procedure that Binds the Grid
    Private Sub BindGrid()
        Dim objDataView As DataView
        'Dim strSortExpression As String
        objDataView = Session("objDataView")

        dlWIPRemarks.DataSource = objDataView
        dlWIPRemarks.DataBind()
        Dim TotalRemarks As String = objDataView.Count
        lblHeading.Text = "WIP Comments » (" + TotalRemarks + ")"

        'Else
        'End If
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

    End Sub
    Protected Sub UpdateSession(ByVal sender As Object, ByVal e As System.EventArgs)
         
    End Sub
    Protected Sub btnsaveSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsaveSave.Click
        Try
            Session("dtWIPSelection") = Nothing
            If txtWIPRemarks.Text = "" Then
                'Not Save
            Else
                If (Not CType(Session("dtWIPSelection"), DataTable) Is Nothing) Then
                    dt = Session("dtWIPSelection")
                Else
                    dt = New DataTable
                    With dt
                        .Columns.Add("POID", GetType(Long))
                        .Columns.Add("PODetailID", GetType(Long))
                        .Columns.Add("Remarks", GetType(String))
                        .Columns.Add("ApplyinAllSelection", GetType(String))
                    End With
                End If
                dr = dt.NewRow()
                dr("POID") = lPOID
                dr("PODetailID") = lPODetailID
                dr("Remarks") = txtWIPRemarks.Text
                If chkApplyInAll.Checked = True Then
                    dr("ApplyinAllSelection") = "YES"
                Else
                    dr("ApplyinAllSelection") = "NO"
                End If
                dt.Rows.Add(dr)
                Session("dtWIPSelection") = dt
                btnclose.Visible = True
                btnsaveSave.Visible = False
                txtWIPRemarks.ReadOnly = True
                chkApplyInAll.Enabled = False
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
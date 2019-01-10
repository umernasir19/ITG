Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class NumberingView
    Inherits System.Web.UI.Page
    Dim objStyleAssortmentMaster As New StyleAssortmentMaster
    Dim objFabricationMaster As New FabricationMaster
    Dim objCuttingProMst As New CuttingProMst
    Dim objTempAccCheckListSize As New TempAccCheckListSize
    Dim objTempCuttingPro As New TempCuttingPro
    Dim Dr As DataRow
    Dim objTempZipperCheckListSize As New TempZipperCheckListSize
    Dim objAccCheckListMst As New AccCheckListMst
    Dim Userid As Long
    Dim ObjDepartmentDataBase As New DepartmetDataBase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objDataView As DataView
        Userid = CLng(Session("Userid"))
        If Not Page.IsPostBack Then
            Try
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()
                FinalData()
            Catch objUDException As UDException
            End Try
        End If
        PageHeader("Numbering View")
    End Sub
    Protected Sub txtSearch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        Try
            Dim dt1 As DataTable = objStyleAssortmentMaster.JOViewForNumberingNumberingNo(txtSearch.Text)
            Dim dt2 As DataTable = objStyleAssortmentMaster.JOViewForNumberingSesaon(txtSearch.Text)
            Dim dt3 As DataTable = objStyleAssortmentMaster.JOViewForNumberingCustomer(txtSearch.Text)
            Dim dt4 As DataTable = objStyleAssortmentMaster.JOViewForNumberingSrNo(txtSearch.Text)
            Dim dt5 As DataTable = objStyleAssortmentMaster.JOViewForNumberingBrand(txtSearch.Text)
            If dt1.Rows.Count > 0 Then
                dgView.DataSource = dt1
                dgView.DataBind()

                Dim fdt As DataTable = objStyleAssortmentMaster.GetNumberingFinalDataNumberingNo(txtSearch.Text)
                dgViewreceiving.DataSource = fdt
                dgViewreceiving.DataBind()

            ElseIf dt2.Rows.Count > 0 Then
                dgView.DataSource = dt2
                dgView.DataBind()

                Dim fdt As DataTable = objStyleAssortmentMaster.GetNumberingFinalDataSeason(txtSearch.Text)
                dgViewreceiving.DataSource = fdt
                dgViewreceiving.DataBind()

            ElseIf dt3.Rows.Count > 0 Then
                dgView.DataSource = dt3
                dgView.DataBind()

                Dim fdt As DataTable = objStyleAssortmentMaster.GetNumberingFinalDataCustomer(txtSearch.Text)
                dgViewreceiving.DataSource = fdt
                dgViewreceiving.DataBind()

            ElseIf dt4.Rows.Count > 0 Then
                dgView.DataSource = dt4
                dgView.DataBind()

                Dim fdt As DataTable = objStyleAssortmentMaster.GetNumberingFinalDataSrno(txtSearch.Text)
                dgViewreceiving.DataSource = fdt
                dgViewreceiving.DataBind()

            ElseIf dt5.Rows.Count > 0 Then
                dgView.DataSource = dt5
                dgView.DataBind()

                Dim fdt As DataTable = objStyleAssortmentMaster.GetNumberingFinalDataBrand(txtSearch.Text)
                dgViewreceiving.DataSource = fdt
                dgViewreceiving.DataBind()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Private Sub BindGrid()
        Dim objDataView As DataView
        objDataView = Session("objDataView")
        dgView.RecordCount = objDataView.Count
        dgView.DataSource = objDataView
        dgView.DataBind()
    End Sub
    Sub FinalData()
        Dim dt As DataTable = objStyleAssortmentMaster.GetNumberingFinalData()
        dgViewreceiving.DataSource = dt
        dgViewreceiving.DataBind()
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objStyleAssortmentMaster.JOViewForNumbering
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgView.PageIndexChanged
        BindGrid()
    End Sub
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgView.SortCommand
        BindGrid()
    End Sub
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgView.ItemDataBound
    End Sub
    Protected Sub dgView_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgView.ItemCommand
        Try
            Select Case e.CommandName
                Case "View"
                    Dim JobOrderID As String = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim JoborderDetailid As String = dgView.Items(e.Item.ItemIndex).Cells(1).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("NumberingEntry.aspx?JobOrderID=" & JobOrderID & "&JoborderDetailid=" & JoborderDetailid & "")
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub dgViewreceiving_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgViewreceiving.ItemCommand
        Try
            Select Case e.CommandName
                Case "Weight"
                    Dim NumberingFinalID As String = dgViewreceiving.Items(e.Item.ItemIndex).Cells(0).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("NumberingWeightEntry.aspx?NumberingFinalID=" & NumberingFinalID & "")
            End Select
        Catch ex As Exception
        End Try
    End Sub
End Class


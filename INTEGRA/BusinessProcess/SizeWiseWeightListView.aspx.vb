Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class SizeWiseWeightListView
    Inherits System.Web.UI.Page

    Dim objStyleAssortmentMaster As New StyleAssortmentMaster
    Dim objFabricationMaster As New FabricationMaster
    Dim objDataView As DataView
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Try
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()
            Catch objUDException As UDException
            End Try
        End If
        PageHeader("Size Wise Weight List View")
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
        Dim x As Integer

        For x = 0 To dgView.Items.Count - 1
            Dim lnkOk As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkOk"), ImageButton)
            Dim lnkEdit As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEdit"), ImageButton)

         
            Dim lnkRemove As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkRemove"), ImageButton)

            Dim StyleAssortmentMasterID As Long = dgView.Items.Item(x).Cells(0).Text
            If StyleAssortmentMasterID = 0 Then
                lnkOk.Visible = False
                lnkEdit.Visible = True
                lnkRemove.Visible = False

            Else
                lnkOk.Visible = True
                lnkEdit.Visible = False
                lnkRemove.Visible = True
            End If

          

        Next
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objStyleAssortmentMaster.ViewForSizeWiseWeightList
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgView.PageIndexChanged
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgView.SortCommand
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgView.ItemDataBound
        'BindGrid()
    End Sub
    Protected Sub dgView_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgView.ItemCommand
        Try
            Select Case e.CommandName
                Case "StyleAssortmanr"
                    Dim JobOrderID As String = dgView.Items(e.Item.ItemIndex).Cells(1).Text
                    Dim JoborderDetailid As String = dgView.Items(e.Item.ItemIndex).Cells(2).Text
                    Dim Styles As String = dgView.Items(e.Item.ItemIndex).Cells(8).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("SizeWiseWeightList.aspx?JobOrderID=" & JobOrderID & "&JoborderDetailid=" & JoborderDetailid & "&Styles=" & Styles & "")
                Case "Edit"
                    Dim SizeWiseWeightListMstID As String = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim JobOrderID As String = dgView.Items(e.Item.ItemIndex).Cells(1).Text
                    Dim JoborderDetailid As String = dgView.Items(e.Item.ItemIndex).Cells(2).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("SizeWiseWeightList.aspx?SizeWiseWeightListMstID=" & SizeWiseWeightListMstID & "&JobOrderID=" & JobOrderID & "&JoborderDetailid=" & JoborderDetailid & "")


                Case Is = "Remove"
                    Dim LSizeWiseWeightListMstID As String = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    objStyleAssortmentMaster.DeleteSizeWiseMst(LSizeWiseWeightListMstID)
                    objStyleAssortmentMaster.DeleteSizeWiseDtl(LSizeWiseWeightListMstID)
                        objDataView = LoadData()
                        Session("objDataView") = objDataView
                        BindGrid()





            End Select

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtSearch_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtSearch.TextChanged
        Try
            Dim dt1 As DataTable = objStyleAssortmentMaster.ViewForBrandSizeWeightView(txtSearch.Text)
            Dim dt2 As DataTable = objStyleAssortmentMaster.ViewForBuyerSizeWeightView(txtSearch.Text)
            Dim dt3 As DataTable = objStyleAssortmentMaster.ViewForStyleSizeWeightView(txtSearch.Text)
            Dim dt4 As DataTable = objStyleAssortmentMaster.ViewForSrNoSizeWeightView(txtSearch.Text)
            Dim dt5 As DataTable = objStyleAssortmentMaster.ViewForSeasonSizeWeightView(txtSearch.Text)

            If dt1.Rows.Count > 0 Then
                dgView.DataSource = dt1
                dgView.DataBind()
                Dim x As Integer

                For x = 0 To dgView.Items.Count - 1
                    Dim lnkOk As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkOk"), ImageButton)
                    Dim lnkEdit As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEdit"), ImageButton)

                  
                    Dim lnkRemove As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkRemove"), ImageButton)

                    Dim StyleAssortmentMasterID As Long = dgView.Items.Item(x).Cells(0).Text
                    If StyleAssortmentMasterID = 0 Then
                        lnkOk.Visible = False
                        lnkEdit.Visible = True
                        lnkRemove.Visible = False

                    Else
                        lnkOk.Visible = True
                        lnkEdit.Visible = False
                        lnkRemove.Visible = True
                    End If

                 
                Next
            ElseIf dt2.Rows.Count > 0 Then
                dgView.DataSource = dt2
                dgView.DataBind()
                Dim x As Integer

                For x = 0 To dgView.Items.Count - 1
                    Dim lnkOk As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkOk"), ImageButton)
                    Dim lnkEdit As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEdit"), ImageButton)

                  
                    Dim lnkRemove As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkRemove"), ImageButton)

                    Dim StyleAssortmentMasterID As Long = dgView.Items.Item(x).Cells(0).Text
                    If StyleAssortmentMasterID = 0 Then
                        lnkOk.Visible = False
                        lnkEdit.Visible = True
                        lnkRemove.Visible = False

                    Else
                        lnkOk.Visible = True
                        lnkEdit.Visible = False
                        lnkRemove.Visible = True
                    End If

                   

                Next
            ElseIf dt3.Rows.Count > 0 Then
                dgView.DataSource = dt3
                dgView.DataBind()
                Dim x As Integer

                For x = 0 To dgView.Items.Count - 1
                    Dim lnkOk As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkOk"), ImageButton)
                    Dim lnkEdit As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEdit"), ImageButton)

                  
                    Dim lnkRemove As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkRemove"), ImageButton)

                    Dim StyleAssortmentMasterID As Long = dgView.Items.Item(x).Cells(0).Text
                    If StyleAssortmentMasterID = 0 Then
                        lnkOk.Visible = False
                        lnkEdit.Visible = True
                        lnkRemove.Visible = False

                    Else
                        lnkOk.Visible = True
                        lnkEdit.Visible = False
                        lnkRemove.Visible = True
                    End If

               

                Next
            ElseIf dt4.Rows.Count > 0 Then
                dgView.DataSource = dt4
                dgView.DataBind()
                Dim x As Integer

                For x = 0 To dgView.Items.Count - 1
                    Dim lnkOk As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkOk"), ImageButton)
                    Dim lnkEdit As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEdit"), ImageButton)

                   
                    Dim lnkRemove As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkRemove"), ImageButton)

                    Dim StyleAssortmentMasterID As Long = dgView.Items.Item(x).Cells(0).Text
                    If StyleAssortmentMasterID = 0 Then
                        lnkOk.Visible = False
                        lnkEdit.Visible = True
                        lnkRemove.Visible = False

                    Else
                        lnkOk.Visible = True
                        lnkEdit.Visible = False
                        lnkRemove.Visible = True
                    End If

                   

                Next

            ElseIf dt5.Rows.Count > 0 Then
                dgView.DataSource = dt5
                dgView.DataBind()
                Dim x As Integer

                For x = 0 To dgView.Items.Count - 1
                    Dim lnkOk As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkOk"), ImageButton)
                    Dim lnkEdit As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEdit"), ImageButton)

                    
                    Dim lnkRemove As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkRemove"), ImageButton)

                    Dim StyleAssortmentMasterID As Long = dgView.Items.Item(x).Cells(0).Text
                    If StyleAssortmentMasterID = 0 Then
                        lnkOk.Visible = False
                        lnkEdit.Visible = True
                        lnkRemove.Visible = False

                    Else
                        lnkOk.Visible = True
                        lnkEdit.Visible = False
                        lnkRemove.Visible = True
                    End If

                  

                Next

            Else
                Dim dt6 As DataTable = objStyleAssortmentMaster.View
                dgView.DataSource = dt6
                dgView.DataBind()
                Dim x As Integer

                For x = 0 To dgView.Items.Count - 1
                    Dim lnkOk As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkOk"), ImageButton)
                    Dim lnkEdit As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEdit"), ImageButton)

                 
                    Dim lnkRemove As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkRemove"), ImageButton)

                    Dim StyleAssortmentMasterID As Long = dgView.Items.Item(x).Cells(0).Text
                    If StyleAssortmentMasterID = 0 Then
                        lnkOk.Visible = False
                        lnkEdit.Visible = True
                        lnkRemove.Visible = False

                    Else
                        lnkOk.Visible = True
                        lnkEdit.Visible = False
                        lnkRemove.Visible = True
                    End If

                  

                Next
            End If


        Catch ex As Exception

        End Try

    End Sub
End Class


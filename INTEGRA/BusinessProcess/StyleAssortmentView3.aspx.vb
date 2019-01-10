Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class StyleAssortmentViewNew
    Inherits System.Web.UI.Page
    Dim objStyleAssortmentMaster As New StyleAssortmentMaster
    Dim objFabricationMaster As New FabricationMaster
    Dim objDataView As DataView
    Dim DeleteStatus As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DeleteStatus = Request.QueryString("DeleteStatus")
        If Not Page.IsPostBack Then
            Try
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()
          
                'If DeleteStatus = 1 Then
                '    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Can Not Be Deleted")
                'End If
            Catch objUDException As UDException
            End Try
        End If
        PageHeader("Style Assortment View")
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Private Sub BindGrid()
        Dim objDataView As DataView
        objDataView = Session("objDataView")
        dgView.DataSource = objDataView
        dgView.DataBind()
        SaveGridCheck()

    End Sub
    Sub SaveGridCheck()
        For i As Integer = 0 To dgView.Items.Count - 1

            Dim lnkEdit As ImageButton = CType(dgView.Items(i).FindControl("lnkEdit"), ImageButton)
            Dim lnkRemove As ImageButton = CType(dgView.Items(i).FindControl("lnkRemove"), ImageButton)


            Dim item As GridDataItem = DirectCast(dgView.MasterTableView.Items(i), GridDataItem)
            Dim StyleAssortmentMasterID As Long = item("StyleAssortmentMasterID").Text

            If StyleAssortmentMasterID = 0 Then
                item.BackColor = Drawing.Color.SkyBlue
                'lnkEdit.Visible = True
                'lnkRemove.Visible = False

            Else
                item.BackColor = Drawing.Color.Pink
                'lnkEdit.Visible = False
                'lnkRemove.Visible = True
            End If




        Next
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objStyleAssortmentMaster.View
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Protected Sub dgView_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgView.ItemCommand
        Try
            Select Case e.CommandName

                Case Is = "StyleAssortmanr"
                    Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                    Dim JobOrderID As Long = item("JobOrderID").Text
                    Dim JoborderDetailid As Long = item("JoborderDetailid").Text
                    Dim Style As String = item("Style").Text
                    Dim StyleAssortmentMasterID As Long = item("StyleAssortmentMasterID").Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")

                    If StyleAssortmentMasterID = 0 Then
                        Response.Redirect("StyleAssortmentEntry.aspx?JobOrderID=" & JobOrderID & "&JoborderDetailid=" & JoborderDetailid & "&Styles=" & Style & "")

                    Else
                        Response.Redirect("StyleAssortmentEntry.aspx?StyleAssortmentMasterID=" & StyleAssortmentMasterID & "&JobOrderID=" & JobOrderID & "&JoborderDetailid=" & JoborderDetailid & "")

                    End If

                    'Case Is = "Edit"
                    '    Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                    '    Dim JobOrderID As Long = item("JobOrderID").Text
                    '    Dim JoborderDetailid As Long = item("JoborderDetailid").Text
                    '    Dim StyleAssortmentMasterID As Long = item("StyleAssortmentMasterID").Text
                    '    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")

                Case Is = "Delete"

                    Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                    Dim StyleAssortmentMasterID As Long = item("StyleAssortmentMasterID").Text

                    Dim dt As DataTable = objStyleAssortmentMaster.CheckStyleAssortmentDetailIDForCuttingForAssotmentView(StyleAssortmentMasterID)
                    Dim dtt As DataTable = objStyleAssortmentMaster.CheckStyleAssortmentDetailIDForChecklistForAssotmentView(StyleAssortmentMasterID)
                    If dt.Rows.Count > 0 Or dtt.Rows.Count > 0 Then
                        'DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Can Not Be Deleted")
                        'Response.Redirect("StyleAssortmentView.aspx?DeleteStatus=1")

                    Else
                        objStyleAssortmentMaster.DeleteStyleAssortmentMasterForAssortmentView(StyleAssortmentMasterID)
                        objStyleAssortmentMaster.DeleteStyleAssortmentDetailForAssortmentView(StyleAssortmentMasterID)
                        Response.Redirect("StyleAssortmentView.aspx")
                        objDataView = LoadData()
                        Session("objDataView") = objDataView
                        BindGrid()
                    End If


            End Select
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub dgView_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles dgView.NeedDataSource

     
            dgView.DataSource = objStyleAssortmentMaster.View()
            SaveGridCheck()


    End Sub
   
    
    Protected Sub dgView_ItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles dgView.ItemCreated
        If TypeOf e.Item Is GridFilteringItem Then
            Dim filterItem As GridFilteringItem = DirectCast(e.Item, GridFilteringItem)
    
            dgView.DataSource = objStyleAssortmentMaster.View()

            SaveGridCheck()
        End If
    End Sub
    Protected Sub dgView_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles dgView.PageIndexChanged

        BindGrid()


    End Sub
    Protected Sub dgView_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles dgView.SortCommand
        BindGrid()

    End Sub
End Class

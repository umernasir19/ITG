Imports System.Data
Imports Integra.EuroCentra
Imports Telerik.Web.UI
Public Class MasterOrderForCustomer
    Inherits System.Web.UI.Page
    Dim objPo As New PurchaseOrder
    Dim objUser As New User
    Dim UserID As Long
    Dim dtUser As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UserID = CLng(Session("Userid"))
        Response.Expires = 0
        Dim objDataview As DataView
        If Not Page.IsPostBack Then
            Try
                imgReset.Visible = False

                objDataview = LoadData()
                Session("objDataView") = objDataview
                BindGrid()
            Catch ex As Exception

            End Try
        End If
    End Sub
    ' Procedure that Binds the Grid
    Private Sub BindGrid()
        Dim objDataView As DataView
        objDataView = Session("objDataView")
        dgMasterOrderForCustomer.DataSource = objDataView
        dgMasterOrderForCustomer.DataBind()
        updgMasterOrderForCustomer.Update()
    End Sub
    Function LoadData() As ICollection
        Try
            dtUser = objUser.GetUSerInfoNew(UserID)
            Dim objDataView As DataView
            Dim objDataTable As DataTable
            objDataTable = objPo.GetMasterOrderForCustomer(dtUser.Rows(0)("EmployeeId"))
            objDataView = New DataView(objDataTable)
            Return objDataView
        Catch ex As Exception

        End Try
    End Function
    Protected Sub dgMasterOrderForCustomer_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles dgMasterOrderForCustomer.NeedDataSource
        dtUser = objUser.GetUSerInfoNew(UserID)
        dgMasterOrderForCustomer.DataSource = objPo.GetMasterOrderForCustomer(dtUser.Rows(0)("EmployeeId"))
    End Sub
    Protected Sub dgMasterOrderForCustomer_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles dgMasterOrderForCustomer.PageIndexChanged
        BindGrid()
    End Sub
    Protected Sub dgMasterOrderForCustomer_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles dgMasterOrderForCustomer.SortCommand
        BindGrid()
    End Sub
    Protected Sub cmbAction_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbAction.SelectedIndexChanged
        Try
            UserID = CLng(Session("Userid"))
            dtUser = objUser.GetUSerInfoNew(UserID)

            If cmbAction.SelectedValue = 0 Then
                'No Work
            ElseIf cmbAction.SelectedValue = 1 Then 'Backlog: Yarn Procurement
                Dim objWIPChart As New WIPChart
                Dim objDataTable As New DataTable
                objDataTable = objPo.GetMasterOrderForCustomer(dtUser.Rows(0)("EmployeeId"))
                Dim dt As New DataTable
                dt = objDataTable.Clone()

                Dim x As Integer
                For x = 0 To objDataTable.Rows.Count - 1
                    Dim POLeadTime As Long = objDataTable.Rows(x)("TimeSpame")
                    POLeadTime = (POLeadTime * 10) / 100
                    Dim ProcessTargetDate As Date = objDataTable.Rows(x)("PlacementDatee")
                    ProcessTargetDate = ProcessTargetDate.AddDays(POLeadTime)

                    If ProcessTargetDate < Date.Now.Date Then
                        'Now check in WIP this order History
                        Dim dtWIPStatus As DataTable
                        dtWIPStatus = objWIPChart.GetArticleForMasterMailYarnProcurement(objDataTable.Rows(x)("POID"))
                        If dtWIPStatus.Rows.Count > 0 Then
                        Else
                            Dim drRow As DataRow = objDataTable.Rows(x)
                            dt.NewRow()
                            Dim dr As DataRow = drRow
                            dt.ImportRow(drRow)
                        End If
                    End If
                Next
                If dt.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Order(s) delayed at Yarn Proc.")
                    cmbAction.SelectedValue = 0
                    Dim objDataView As DataView
                    objDataView = New DataView(dt)
                    Session("objDataView") = objDataView
                    dgMasterOrderForCustomer.Controls.Clear()
                    BindGrid()
                    imgReset.Visible = True
                    updgMasterOrderForCustomer.Update()

                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("No Record Found")
                    cmbAction.SelectedValue = 0

                End If

            ElseIf cmbAction.SelectedValue = 2 Then 'Backlog: Fabric In-house
                Dim objWIPChart As New WIPChart
                Dim objDataTable As New DataTable
                objDataTable = objPo.GetMasterOrderForCustomer(dtUser.Rows(0)("EmployeeId"))
                Dim dt As New DataTable
                dt = objDataTable.Clone()

                Dim x As Integer
                For x = 0 To objDataTable.Rows.Count - 1
                    Dim POLeadTime As Long = objDataTable.Rows(x)("TimeSpame")
                    POLeadTime = (POLeadTime * 45) / 100
                    Dim ProcessTargetDate As Date = objDataTable.Rows(x)("PlacementDatee")
                    ProcessTargetDate = ProcessTargetDate.AddDays(POLeadTime)

                    If ProcessTargetDate < Date.Now.Date Then
                        'Now check in WIP this order History
                        Dim dtWIPStatus As DataTable
                        dtWIPStatus = objWIPChart.GetPOForMasterMail(objDataTable.Rows(x)("POID"))
                        If dtWIPStatus.Rows.Count > 0 Then
                        Else
                            Dim drRow As DataRow = objDataTable.Rows(x)
                            dt.NewRow()
                            Dim dr As DataRow = drRow
                            dt.ImportRow(drRow)
                        End If
                    End If
                Next
                If dt.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Order(s) delayed at Fabric Proc.")
                    cmbAction.SelectedValue = 0
                    Dim objDataView As DataView
                    objDataView = New DataView(dt)
                    Session("objDataView") = objDataView
                    dgMasterOrderForCustomer.Controls.Clear()
                    BindGrid()
                    imgReset.Visible = True
                    updgMasterOrderForCustomer.Update()
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("No Record Found")
                    cmbAction.SelectedValue = 0
                End If
            ElseIf cmbAction.SelectedValue = 3 Then 'Backlog: Cutting
                Dim objWIPChart As New WIPChart
                Dim objDataTable As New DataTable
                objDataTable = objPo.GetMasterOrderForCustomer(dtUser.Rows(0)("EmployeeId"))
                Dim dt As New DataTable
                dt = objDataTable.Clone()

                Dim x As Integer
                For x = 0 To objDataTable.Rows.Count - 1
                    Dim POLeadTime As Long = objDataTable.Rows(x)("TimeSpame")
                    POLeadTime = (POLeadTime * 70) / 100
                    Dim ProcessTargetDate As Date = objDataTable.Rows(x)("PlacementDatee")
                    ProcessTargetDate = ProcessTargetDate.AddDays(POLeadTime)

                    If ProcessTargetDate < Date.Now.Date Then
                        'Now check in WIP this order History
                        Dim dtWIPStatus As DataTable
                        dtWIPStatus = objWIPChart.GetArticleForMasterMailCutting(objDataTable.Rows(x)("POID"))
                        If dtWIPStatus.Rows.Count > 0 Then
                        Else
                            Dim drRow As DataRow = objDataTable.Rows(x)
                            dt.NewRow()
                            Dim dr As DataRow = drRow
                            dt.ImportRow(drRow)
                        End If
                    End If
                Next
                If dt.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Order(s) delayed at Cutting")
                    cmbAction.SelectedValue = 0
                    Dim objDataView As DataView
                    objDataView = New DataView(dt)
                    Session("objDataView") = objDataView
                    dgMasterOrderForCustomer.Controls.Clear()
                    BindGrid()
                    imgReset.Visible = True
                    updgMasterOrderForCustomer.Update()
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("No Record Found")
                    cmbAction.SelectedValue = 0
                End If
            ElseIf cmbAction.SelectedValue = 4 Then 'Order(s) under packing stage
                Dim objWIPChart As New WIPChart
                Dim objDataTable As New DataTable
                objDataTable = objPo.GetMasterOrderForCustomer(dtUser.Rows(0)("EmployeeId"))
                Dim dt As New DataTable
                dt = objDataTable.Clone()

                Dim x As Integer
                For x = 0 To objDataTable.Rows.Count - 1
                    'Now check in WIP this order History
                        Dim dtWIPStatus As DataTable
                        dtWIPStatus = objWIPChart.GetPOPacking(objDataTable.Rows(x)("POID"))
                    If dtWIPStatus.Rows.Count > 0 Then
                        Dim drRow As DataRow = objDataTable.Rows(x)
                        dt.NewRow()
                        Dim dr As DataRow = drRow
                        dt.ImportRow(drRow)
                    Else

                    End If
                Next
                If dt.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Order(s) under packing stage")
                    cmbAction.SelectedValue = 0
                    Dim objDataView As DataView
                    objDataView = New DataView(dt)
                    Session("objDataView") = objDataView
                    dgMasterOrderForCustomer.Controls.Clear()
                    BindGrid()
                    imgReset.Visible = True
                    updgMasterOrderForCustomer.Update()
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("No Record Found")
                    cmbAction.SelectedValue = 0
                End If
            ElseIf cmbAction.SelectedValue = 5 Then 'Order Released
                Dim objWIPChart As New WIPChart
                Dim objDataTable As New DataTable
                objDataTable = objPo.GetMasterOrderForCustomer(dtUser.Rows(0)("EmployeeId"))
                Dim dt As New DataTable
                dt = objDataTable.Clone()

                Dim x As Integer
                For x = 0 To objDataTable.Rows.Count - 1
                   
                        Dim dtWIPStatus As DataTable
                        dtWIPStatus = objWIPChart.GetPOReleased(objDataTable.Rows(x)("POID"))
                        If dtWIPStatus.Rows.Count > 0 Then
                            Dim drRow As DataRow = objDataTable.Rows(x)
                            dt.NewRow()
                            Dim dr As DataRow = drRow
                            dt.ImportRow(drRow)
                        Else
                        End If

                Next
                If dt.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Order Released")
                    cmbAction.SelectedValue = 0
                    Dim objDataView As DataView
                    objDataView = New DataView(dt)
                    Session("objDataView") = objDataView
                    dgMasterOrderForCustomer.Controls.Clear()
                    BindGrid()
                    imgReset.Visible = True
                    updgMasterOrderForCustomer.Update()
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("No Record Found")
                    cmbAction.SelectedValue = 0
                End If

            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub imgReset_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgReset.Click
        Try
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
            Dim objDataview As DataView
            objDataview = LoadData()
            Session("objDataView") = objDataview
            BindGrid()
            updgMasterOrderForCustomer.Update()
        Catch ex As Exception

        End Try
    End Sub

End Class
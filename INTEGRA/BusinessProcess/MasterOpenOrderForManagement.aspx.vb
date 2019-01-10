Imports System.Data
Imports Integra.EuroCentra
Imports Telerik.Web.UI
Imports System.IO
Public Class MasterOpenOrderForManagement
    Inherits System.Web.UI.Page
    Dim objPo As New PurchaseOrder
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Expires = 0
        Dim objDataview As DataView
        If Not Page.IsPostBack Then
            Try
                objDataview = LoadData()
                Session("objDataView") = objDataview
                BindGrid()
                updgMasterOrderForManagement.Update()
            Catch ex As Exception
            End Try
        End If
    End Sub
    ' Procedure that Binds the Grid
    Private Sub BindGrid()
        Dim objDataView As DataView
        objDataView = Session("objDataView")
        dgMasterOrderForManagement.DataSource = objDataView
        dgMasterOrderForManagement.DataBind()
        updgMasterOrderForManagement.Update()
    End Sub
    Function LoadData() As ICollection
        Try
            Dim objDataView As DataView
            Dim objDataTable As DataTable
            objDataTable = objPo.GetMasterOpenOrderForManagement()
            objDataView = New DataView(objDataTable)
            Return objDataView
        Catch ex As Exception
        End Try
    End Function
    Protected Sub cmbAction_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbAction.SelectedIndexChanged
        Try
            If cmbAction.SelectedValue = 0 Then
                'No Work
            ElseIf cmbAction.SelectedValue = 1 Then
                'Check Row Checked or not
                Dim x As Integer
                Dim chkSelect As CheckBox
                Session("IPOIDManagement") = ""
                For x = 0 To dgMasterOrderForManagement.Items.Count - 1
                    Dim item As GridDataItem = DirectCast(dgMasterOrderForManagement.MasterTableView.Items(x), GridDataItem)
                    chkSelect = CType(dgMasterOrderForManagement.Items(x).FindControl("chkSelect"), CheckBox)
                    If chkSelect.Checked = True Then
                        If Session("IPOIDManagement") = "" Then
                            Session("IPOIDManagement") = item("POID").Text
                        ElseIf Session("IPOIDManagement") = item("POID").Text Then
                            Session("IPOIDManagement") = item("POID").Text
                        Else
                            Session("IPOIDManagement") = Nothing
                            Session("IPOIDManagement") = "POMultiple"
                            Exit For
                        End If
                    End If
                Next
                'End Check

                If Session("IPOIDManagement") = "POMultiple" Then
                    cmbAction.SelectedValue = 0
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("You Can Select Single Order.")
                ElseIf Session("IPOIDManagement") = "" Then
                    cmbAction.SelectedValue = 0
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("No Row Selected")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    cmbAction.SelectedValue = 0
                    ' Response.Write("<script> window.open('PurchaseOrderPreviewPopup.aspx?lPOID=" & CLng(Session("IPOIDManagement")) & "', 'newwindow', 'left=12, top=30, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")
                    ScriptManager.RegisterClientScriptBlock(Me.upcmbAction, Me.upcmbAction.GetType(), "New ClientScript", "window.open('PurchaseOrderPreviewPopup.aspx?lPOID=" & CLng(Session("IPOIDManagement")) & "', 'newwindow', 'left=12, top=30, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no');", True)
                End If
            ElseIf cmbAction.SelectedValue = 2 Then
                'Check Row Checked or not
                Dim x As Integer
                Dim chkSelect As CheckBox
                Session("IPOIDManagement") = ""
                For x = 0 To dgMasterOrderForManagement.Items.Count - 1
                    Dim item As GridDataItem = DirectCast(dgMasterOrderForManagement.MasterTableView.Items(x), GridDataItem)
                    chkSelect = CType(dgMasterOrderForManagement.Items(x).FindControl("chkSelect"), CheckBox)
                    If chkSelect.Checked = True Then
                        If Session("IPOIDManagement") = "" Then
                            Session("IPOIDManagement") = item("POID").Text
                        ElseIf Session("IPOIDManagement") = item("POID").Text Then
                            Session("IPOIDManagement") = item("POID").Text
                        Else
                            Session("IPOIDManagement") = Nothing
                            Session("IPOIDManagement") = "POMultiple"
                            Exit For
                        End If
                    End If
                Next
                'End Check

                If Session("IPOIDManagement") = "POMultiple" Then
                    cmbAction.SelectedValue = 0
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("You Can Select Single Order.")
                ElseIf Session("IPOIDManagement") = "" Then
                    cmbAction.SelectedValue = 0
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("No Row Selected")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    cmbAction.SelectedValue = 0
                    If (Directory.Exists(Server.MapPath("~/OriginalPurchaseorderPDF/" & CLng(Session("IPOIDManagement")) & ""))) Then
                        Dim strFileSize As String = ""
                        Dim di As New IO.DirectoryInfo(Server.MapPath("~/OriginalPurchaseorderPDF/" & CLng(Session("IPOIDManagement")) & ""))
                        Dim aryFi As IO.FileInfo() = di.GetFiles("*.pdf")
                        Dim fi As IO.FileInfo
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                        For Each fi In aryFi
                            Response.ClearHeaders()
                            Response.ClearContent()
                            Response.ContentType = "application/octet-stream"
                            Response.Charset = "UTF-8"
                            Response.AddHeader("content-disposition", "attachment; filename=" & fi.Name)
                            Response.WriteFile(Server.MapPath("~/OriginalPurchaseorderPDF/" & CLng(Session("IPOIDManagement")) & "/" & fi.Name & ""))
                            Response.End()
                        Next
                    Else
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("File Not Found")
                        cmbAction.SelectedValue = 0
                    End If
                End If
            ElseIf cmbAction.SelectedValue = 3 Then
                'Check Row Checked or not
                Dim x As Integer
                Dim chkSelect As CheckBox
                Session("IPOIDManagement") = ""
                For x = 0 To dgMasterOrderForManagement.Items.Count - 1
                    Dim item As GridDataItem = DirectCast(dgMasterOrderForManagement.MasterTableView.Items(x), GridDataItem)
                    chkSelect = CType(dgMasterOrderForManagement.Items(x).FindControl("chkSelect"), CheckBox)
                    If chkSelect.Checked = True Then
                        If Session("IPOIDManagement") = "" Then
                            Session("IPOIDManagement") = item("POID").Text
                        ElseIf Session("IPOIDManagement") = item("POID").Text Then
                            Session("IPOIDManagement") = item("POID").Text
                        Else
                            Session("IPOIDManagement") = Nothing
                            Session("IPOIDManagement") = "POMultiple"
                            Exit For
                        End If
                    End If
                Next
                'End Check

                If Session("IPOIDManagement") = "POMultiple" Then
                    cmbAction.SelectedValue = 0
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("You Can Select Single Order.")
                ElseIf Session("IPOIDManagement") = "" Then
                    cmbAction.SelectedValue = 0
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("No Row Selected")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    cmbAction.SelectedValue = 0
                    ' Response.Write("<script> window.open('ProductionTracking.aspx?lPOID=" & CLng(Session("IPOIDManagement")) & "', 'newwindow', 'left=12, top=30, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")
                    ScriptManager.RegisterClientScriptBlock(Me.upcmbAction, Me.upcmbAction.GetType(), "New ClientScript", "window.open('ProductionTracking.aspx?lPOID=" & CLng(Session("IPOIDManagement")) & "', 'newwindow', 'left=92, top=70, height=550, width=400, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no');", True)
                End If
            ElseIf cmbAction.SelectedValue = 4 Then 'Backlog: Yarn Procurement
                Dim objWIPChart As New WIPChart
                Dim objDataTable As New DataTable
                objDataTable = objPo.GetMasterOpenOrderForManagementBacklog()
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
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Backlog: Yarn Procurement")
                    cmbAction.SelectedValue = 0
                    Dim objDataView As DataView
                    objDataView = New DataView(dt)
                    Session("objDataView") = objDataView
                    dgMasterOrderForManagement.Controls.Clear()
                    BindGrid()
                    updgMasterOrderForManagement.Update()
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("No Record Found")
                    cmbAction.SelectedValue = 0
                End If
            ElseIf cmbAction.SelectedValue = 5 Then 'Backlog: Fabric In-house
                Dim objWIPChart As New WIPChart
                Dim objDataTable As New DataTable
                objDataTable = objPo.GetMasterOpenOrderForManagementBacklog()
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
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Backlog: Fabric In-house")
                    cmbAction.SelectedValue = 0
                    Dim objDataView As DataView
                    objDataView = New DataView(dt)
                    Session("objDataView") = objDataView
                    dgMasterOrderForManagement.Controls.Clear()
                    BindGrid()
                    updgMasterOrderForManagement.Update()
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("No Record Found")
                    cmbAction.SelectedValue = 0
                End If
            ElseIf cmbAction.SelectedValue = 6 Then 'Backlog: Cutting
                Dim objWIPChart As New WIPChart
                Dim objDataTable As New DataTable
                objDataTable = objPo.GetMasterOpenOrderForManagementBacklog()
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
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Backlog: Cutting")
                    cmbAction.SelectedValue = 0
                    Dim objDataView As DataView
                    objDataView = New DataView(dt)
                    Session("objDataView") = objDataView
                    dgMasterOrderForManagement.Controls.Clear()
                    BindGrid()
                    updgMasterOrderForManagement.Update()
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("No Record Found")
                    cmbAction.SelectedValue = 0
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Function GetWeekStartDate(ByVal year As Integer, ByVal week As Integer) As DateTime
        Dim jan1 As New DateTime(year, 1, 1)
        Dim day As Integer = CInt(jan1.DayOfWeek) - 1
        Dim delta As Integer = (If(day < 4, -day, 7 - day)) + 7 * (week - 1)

        Return jan1.AddDays(delta)
    End Function
    Protected Sub dgMasterOrderForManagement_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles dgMasterOrderForManagement.NeedDataSource
        dgMasterOrderForManagement.DataSource = objPo.GetMasterOrderForManagement()
    End Sub
    Protected Sub dgMasterOrderForManagement_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles dgMasterOrderForManagement.SortCommand
        BindGrid()
        updgMasterOrderForManagement.Update()
    End Sub
    Protected Sub dgMasterOrderForManagement_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles dgMasterOrderForManagement.PageIndexChanged
        BindGrid()
        updgMasterOrderForManagement.Update()
    End Sub
    Protected Sub imgReset_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgReset.Click
        Try
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
            Dim objDataview As DataView
            objDataview = LoadData()
            Session("objDataView") = objDataview
            BindGrid()
            updgMasterOrderForManagement.Update()
        Catch ex As Exception

        End Try
    End Sub

End Class
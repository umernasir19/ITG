﻿Imports System.Data
Imports Integra.EuroCentra
Imports Telerik.Web.UI

Public Class MasterOrderForMerchandisers
    Inherits System.Web.UI.Page
    Dim objPo As New PurchaseOrder
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Expires = 0
        Dim objDataview As DataView
        If Not Page.IsPostBack Then
            Try
                objDataview = LoadData()
                Session("objDataView1") = objDataview
                BindGrid()
            Catch ex As Exception
            End Try
        End If
    End Sub
    ' Procedure that Binds the Grid
    Private Sub BindGrid()
        Dim objDataView As DataView
        objDataView = Session("objDataView1")
        dgMasterOrderForMerchandiser.DataSource = objDataView
        dgMasterOrderForMerchandiser.DataBind()
    End Sub
    Function LoadData() As ICollection
        Try
            Dim objDataView As DataView
            Dim objDataTable As DataTable
            objDataTable = objPo.GetMasterOrderForMerchantNew(CLng(Session("Userid")))
            objDataView = New DataView(objDataTable)
            Return objDataView
        Catch ex As Exception

        End Try
    End Function
    Protected Sub dgMasterOrderForMerchandiser_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles dgMasterOrderForMerchandiser.NeedDataSource
        dgMasterOrderForMerchandiser.DataSource = objPo.GetMasterOrderForMerchantNew(CLng(Session("Userid")))
    End Sub
    Protected Sub cmbAction_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbAction.SelectedIndexChanged
        Try
            If cmbAction.SelectedValue = 0 Then
                'msg
            ElseIf cmbAction.SelectedValue = 1 Then
                'Check Row Checked or not
                Dim x As Integer
                Dim chkSelect As CheckBox
                Session("IPOID") = ""
                For x = 0 To dgMasterOrderForMerchandiser.Items.Count - 1
                    Dim item As GridDataItem = DirectCast(dgMasterOrderForMerchandiser.MasterTableView.Items(x), GridDataItem)
                    chkSelect = CType(dgMasterOrderForMerchandiser.Items(x).FindControl("chkSelected"), CheckBox)
                    If chkSelect.Checked = True Then
                        If Session("IPOID") = "" Then
                            Session("IPOID") = item("POID").Text
                        ElseIf Session("IPOID") = item("POID").Text Then
                            Session("IPOID") = item("POID").Text
                        Else
                            Session("IPOID") = Nothing
                            Session("IPOID") = "POMultiple"
                            Exit For
                        End If
                    End If
                Next
                'End Check

                If Session("IPOID") = "POMultiple" Then
                    cmbAction.SelectedValue = 0
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("You Can Select Multiple Article of Single Order.")
                ElseIf Session("IPOID") = "" Then
                    cmbAction.SelectedValue = 0
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("No Row Selected")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    cmbAction.SelectedValue = 0
                    ' Response.Write("<script> window.open('PurchaseOrderPreview.aspx?lPOID=" & CLng(Session("IPOID")) & "', 'newwindow', 'left=12, top=30, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")
                    ScriptManager.RegisterClientScriptBlock(Me.upcmbAction, Me.upcmbAction.GetType(), "New ClientScript", "window.open('PurchaseOrderPreviewPopup.aspx?lPOID=" & CLng(Session("IPOID")) & "', 'newwindow', 'left=12, top=30, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no');", True)
                End If
            ElseIf cmbAction.SelectedValue = 2 Then
                'Check Row Checked or not
                Dim x As Integer
                Dim chkSelect As CheckBox
                Session("IPOID") = ""
                For x = 0 To dgMasterOrderForMerchandiser.Items.Count - 1
                    Dim item As GridDataItem = DirectCast(dgMasterOrderForMerchandiser.MasterTableView.Items(x), GridDataItem)
                    chkSelect = CType(dgMasterOrderForMerchandiser.Items(x).FindControl("chkSelected"), CheckBox)
                    If chkSelect.Checked = True Then
                        If Session("IPOID") = "" Then
                            Session("IPOID") = item("POID").Text
                        ElseIf Session("IPOID") = item("POID").Text Then
                            Session("IPOID") = item("POID").Text
                        Else
                            Session("IPOID") = Nothing
                            Session("IPOID") = "POMultiple"
                            Exit For
                        End If
                    End If
                Next
                'End Check

                If Session("IPOID") = "POMultiple" Then
                    cmbAction.SelectedValue = 0
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("You Can Select Multiple Article of Single Order.")
                ElseIf Session("IPOID") = "" Then
                    cmbAction.SelectedValue = 0
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("No Row Selected")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    cmbAction.SelectedValue = 0
                    ScriptManager.RegisterClientScriptBlock(Me.upcmbAction, Me.upcmbAction.GetType(), "New ClientScript", "window.open('WIPtemprory.aspx?lPOID=" & CLng(Session("IPOID")) & "', 'newwindow', 'left=50, top=30, height=600, width=720, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no');", True)
                End If
            ElseIf cmbAction.SelectedValue = 3 Then
                'Check Row Checked or not
                Dim x As Integer
                Dim chkSelect As CheckBox
                Session("IPOID") = ""
                For x = 0 To dgMasterOrderForMerchandiser.Items.Count - 1
                    Dim item As GridDataItem = DirectCast(dgMasterOrderForMerchandiser.MasterTableView.Items(x), GridDataItem)
                    chkSelect = CType(dgMasterOrderForMerchandiser.Items(x).FindControl("chkSelected"), CheckBox)
                    If chkSelect.Checked = True Then
                        If Session("IPOID") = "" Then
                            Session("IPOID") = item("POID").Text
                        ElseIf Session("IPOID") = item("POID").Text Then
                            Session("IPOID") = item("POID").Text
                        Else
                            Session("IPOID") = Nothing
                            Session("IPOID") = "POMultiple"
                            Exit For
                        End If
                    End If
                Next
                'End Check

                If Session("IPOID") = "POMultiple" Then
                    cmbAction.SelectedValue = 0
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("You Can Select Multiple Article of Single Order.")
                ElseIf Session("IPOID") = "" Then
                    cmbAction.SelectedValue = 0
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("No Row Selected")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    cmbAction.SelectedValue = 0
                    ' Response.Write("<script> window.open('PORevisedShipment.aspx?lPOID=" & CLng(Session("IPOID")) & "', 'newwindow', 'left=12, top=30, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")
                    ScriptManager.RegisterClientScriptBlock(Me.upcmbAction, Me.upcmbAction.GetType(), "New ClientScript", "window.open('PORevisedShipment.aspx?lPOID=" & CLng(Session("IPOID")) & "', 'newwindow', 'left=12, top=30, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no');", True)
                End If
            ElseIf cmbAction.SelectedValue = 4 Then
                'Check Row Checked or not
                Dim x As Integer
                Dim chkSelect As CheckBox
                Session("IPOID") = ""
                For x = 0 To dgMasterOrderForMerchandiser.Items.Count - 1
                    Dim item As GridDataItem = DirectCast(dgMasterOrderForMerchandiser.MasterTableView.Items(x), GridDataItem)
                    chkSelect = CType(dgMasterOrderForMerchandiser.Items(x).FindControl("chkSelected"), CheckBox)
                    If chkSelect.Checked = True Then
                        If Session("IPOID") = "" Then
                            Session("IPOID") = item("POID").Text
                        ElseIf Session("IPOID") = item("POID").Text Then
                            Session("IPOID") = item("POID").Text
                        Else
                            Session("IPOID") = Nothing
                            Session("IPOID") = "POMultiple"
                            Exit For
                        End If
                    End If
                Next
                'End Check

                If Session("IPOID") = "POMultiple" Then
                    cmbAction.SelectedValue = 0
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("You Can Select Multiple Article of Single Order.")
                ElseIf Session("IPOID") = "" Then
                    cmbAction.SelectedValue = 0
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("No Row Selected")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    cmbAction.SelectedValue = 0
                    '    Response.Write("<script> window.open('SplitShipment.aspx?lPOID=" & CLng(Session("IPOID")) & "', 'newwindow', 'left=12, top=30, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")
                    ScriptManager.RegisterClientScriptBlock(Me.upcmbAction, Me.upcmbAction.GetType(), "New ClientScript", "window.open('SplitShipment.aspx?lPOID=" & CLng(Session("IPOID")) & "', 'newwindow', 'left=12, top=30, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no');", True)
                End If
            ElseIf cmbAction.SelectedValue = 5 Then
                'Check Row Checked or not
                Dim x As Integer
                Dim chkSelect As CheckBox
                Session("IPOID") = ""
                For x = 0 To dgMasterOrderForMerchandiser.Items.Count - 1
                    Dim item As GridDataItem = DirectCast(dgMasterOrderForMerchandiser.MasterTableView.Items(x), GridDataItem)
                    chkSelect = CType(dgMasterOrderForMerchandiser.Items(x).FindControl("chkSelected"), CheckBox)
                    If chkSelect.Checked = True Then
                        If Session("IPOID") = "" Then
                            Session("IPOID") = item("POID").Text
                        ElseIf Session("IPOID") = item("POID").Text Then
                            Session("IPOID") = item("POID").Text
                        Else
                            Session("IPOID") = Nothing
                            Session("IPOID") = "POMultiple"
                            Exit For
                        End If
                    End If
                Next
                'End Check

                If Session("IPOID") = "POMultiple" Then
                    cmbAction.SelectedValue = 0
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("You Can Select Single Order.")
                ElseIf Session("IPOID") = "" Then
                    cmbAction.SelectedValue = 0
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("No Row Selected")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    cmbAction.SelectedValue = 0
                    Response.Redirect("TNAChartView.aspx?POID=" & CLng(Session("IPOID")) & "")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub dgMasterOrderForMerchandiser_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles dgMasterOrderForMerchandiser.SortCommand
        BindGrid()
        'Default sort order Descending

        'If Not e.Item.OwnerTableView.SortExpressions.ContainsExpression(e.SortExpression) Then
        '    Dim sortExpr As New GridSortExpression()
        '    sortExpr.FieldName = e.SortExpression
        '    sortExpr.SortOrder = GridSortOrder.Ascending

        '    e.Item.OwnerTableView.SortExpressions.AddSortExpression(sortExpr)
        'End If


    End Sub
    Protected Sub dgMasterOrderForMerchandiser_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles dgMasterOrderForMerchandiser.PageIndexChanged
        BindGrid()
    End Sub

End Class



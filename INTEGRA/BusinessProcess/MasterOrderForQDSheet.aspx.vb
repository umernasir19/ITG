Imports System.Data
Imports Integra.EuroCentra
Imports Telerik.Web.UI
Public Class MasterOrderForQDSheet
    Inherits System.Web.UI.Page
    Dim objPo As New PurchaseOrder
    Dim POID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        POID = Request.QueryString("lPOID")
        Response.Expires = 0
        Dim objDataview As DataView
        If Not Page.IsPostBack Then
            Try
                objDataview = LoadData()
                Session("objDataViewQD") = objDataview
                BindGrid()
            Catch ex As Exception

            End Try
        End If
    End Sub
    ' Procedure that Binds the Grid
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            objDataView = Session("objDataViewQD")
            dgMasterOrderForQD.DataSource = objDataView
            dgMasterOrderForQD.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Function LoadData() As ICollection
        Try
            Dim objDataView As DataView
            Dim objDataTable As DataTable
            objDataTable = objPo.GetMasterOrderForQD()
            objDataView = New DataView(objDataTable)
            Return objDataView
        Catch ex As Exception

        End Try
    End Function
    Protected Sub dgMasterOrderForQD_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles dgMasterOrderForQD.NeedDataSource
        dgMasterOrderForQD.DataSource = objPo.GetMasterOrderForQD()
    End Sub
    Protected Sub dgMasterOrderForQD_ItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles dgMasterOrderForQD.ItemCreated
        If TypeOf e.Item Is GridFilteringItem Then
            Dim filterItem As GridFilteringItem = DirectCast(e.Item, GridFilteringItem)
        End If
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
                For x = 0 To dgMasterOrderForQD.Items.Count - 1
                    Dim item As GridDataItem = DirectCast(dgMasterOrderForQD.MasterTableView.Items(x), GridDataItem)
                    chkSelect = CType(dgMasterOrderForQD.Items(x).FindControl("chkSelected"), CheckBox)
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
                    'Response.Write("<script> window.open('QualityDepartmentPopup.aspx?lPOID=" & CLng(Session("IPOID")) & "', 'newwindow', 'left=12, top=30, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")
                    ScriptManager.RegisterClientScriptBlock(Me.upcmbAction, Me.upcmbAction.GetType(), "New ClientScript", "window.open('QualityDepartmentPopup.aspx?lPOID=" & CLng(Session("IPOID")) & "', 'newwindow', 'left=12, top=30, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no');", True)
                End If
            ElseIf cmbAction.SelectedValue = 2 Then
                'Check Row Checked or not
                Dim x As Integer
                Dim chkSelect As CheckBox
                Session("IPOID") = ""
                For x = 0 To dgMasterOrderForQD.Items.Count - 1
                    Dim item As GridDataItem = DirectCast(dgMasterOrderForQD.MasterTableView.Items(x), GridDataItem)
                    chkSelect = CType(dgMasterOrderForQD.Items(x).FindControl("chkSelected"), CheckBox)
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
                    'Response.Write("<script> window.open('PurchaseOrderPreviewPopup.aspx?lPOID=" & CLng(Session("IPOID")) & "', 'newwindow', 'left=12, top=30, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")
                    ScriptManager.RegisterClientScriptBlock(Me.upcmbAction, Me.upcmbAction.GetType(), "New ClientScript", "window.open('PurchaseOrderPreviewPopup.aspx?lPOID=" & CLng(Session("IPOID")) & "', 'newwindow', 'left=12, top=30, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no');", True)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub dgMasterOrderForQD_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles dgMasterOrderForQD.PageIndexChanged
        BindGrid()
    End Sub
    Protected Sub dgMasterOrderForQD_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles dgMasterOrderForQD.SortCommand
        BindGrid()
    End Sub
End Class
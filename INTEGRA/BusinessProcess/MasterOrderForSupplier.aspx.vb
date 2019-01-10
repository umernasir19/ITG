Imports System.Data
Imports Integra.EuroCentra
Imports Telerik.Web.UI

Public Class MasterOrderForSupplier
    Inherits System.Web.UI.Page
    Dim objPo As New PurchaseOrder
    Dim objUser As New User
    Dim UserID As Long
    Dim dtUser As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Expires = 0
        Dim objDataview As DataView
        If Not Page.IsPostBack Then
            Try
                UserID = CLng(Session("Userid"))
                dtUser = objUser.GetUSerInfoNew(UserID)
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
        dgMasterOrderForSupplier.DataSource = objDataView
        dgMasterOrderForSupplier.DataBind()
    End Sub
    Function LoadData() As ICollection
        Try
            Dim objDataView As DataView
            Dim objDataTable As DataTable
            objDataTable = objPo.GetMasterOrderForSupplier(dtUser.Rows(0)("EmployeeId"))
            objDataView = New DataView(objDataTable)
            Return objDataView
        Catch ex As Exception

        End Try
    End Function
    Protected Sub cmbAction_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbAction.SelectedIndexChanged
        Try
            If cmbAction.SelectedValue = 0 Then
                'msg
            ElseIf cmbAction.SelectedValue = 1 Then
                'Check Row Checked or not
                Dim x As Integer
                Dim chkSelect As CheckBox
                Session("IPOID") = ""
                For x = 0 To dgMasterOrderForSupplier.Items.Count - 1
                    Dim item As GridDataItem = DirectCast(dgMasterOrderForSupplier.MasterTableView.Items(x), GridDataItem)
                    chkSelect = CType(dgMasterOrderForSupplier.Items(x).FindControl("chkSelect"), CheckBox)
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
                    ' Response.Write("<script> window.open('ICRSupplierPopup.aspx?lPOID=" & CLng(Session("IPOID")) & "', 'newwindow', 'left=12, top=30, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")
                    ScriptManager.RegisterClientScriptBlock(Me.upcmbAction, Me.upcmbAction.GetType(), "New ClientScript", "window.open('ICRSupplierPopup.aspx?lPOID=" & CLng(Session("IPOID")) & "', 'newwindow', 'left=12, top=30, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no');", True)
                End If
            ElseIf cmbAction.SelectedValue = 2 Then
                'Check Row Checked or not
                Dim x As Integer
                Dim chkSelect As CheckBox
                Session("CustomerName") = ""
                Session("EKNumber") = ""
                Session("ShipmentMode") = ""
                Session("ShipmentTerm") = ""
                Session("Currency") = ""

                For x = 0 To dgMasterOrderForSupplier.Items.Count - 1
                    Dim item As GridDataItem = DirectCast(dgMasterOrderForSupplier.MasterTableView.Items(x), GridDataItem)
                    chkSelect = CType(dgMasterOrderForSupplier.Items(x).FindControl("chkSelect"), CheckBox)
                    If chkSelect.Checked = True Then

                        If Session("CustomerName") = "" Then
                            Session("CustomerName") = item("CustomerName").Text
                        ElseIf Session("CustomerName") = item("CustomerName").Text Then
                            Session("CustomerName") = item("CustomerName").Text
                        Else
                            Session("CustomerName") = Nothing
                            Session("CustomerName") = "CustomerNameMultiple"
                            Exit For
                        End If
                        '--EKNumber
                        If Session("EKNumber") = "" Then
                            Session("EKNumber") = item("EKNumber").Text
                        ElseIf Session("EKNumber") = item("EKNumber").Text Then
                            Session("EKNumber") = item("EKNumber").Text
                        Else
                            Session("EKNumber") = Nothing
                            Session("EKNumber") = "EKNumberMultiple"
                            Exit For
                        End If
                        '--ShipmentMode
                        If Session("ShipmentMode") = "" Then
                            Session("ShipmentMode") = item("ShipmentMode").Text
                        ElseIf Session("ShipmentMode") = item("ShipmentMode").Text Then
                            Session("ShipmentMode") = item("ShipmentMode").Text
                        Else
                            Session("ShipmentMode") = Nothing
                            Session("ShipmentMode") = "ShipmentModeMultiple"
                            Exit For
                        End If
                        '--ShipmentTerm
                        If Session("ShipmentTerm") = "" Then
                            Session("ShipmentTerm") = item("ShipmentTerm").Text
                        ElseIf Session("ShipmentTerm") = item("ShipmentTerm").Text Then
                            Session("ShipmentTerm") = item("ShipmentTerm").Text
                        Else
                            Session("ShipmentTerm") = Nothing
                            Session("ShipmentTerm") = "ShipmentTermMultiple"
                            Exit For
                        End If
                        '--Currency
                        If Session("Currency") = "" Then
                            Session("Currency") = item("Currency").Text
                        ElseIf Session("Currency") = item("Currency").Text Then
                            Session("Currency") = item("Currency").Text
                        Else
                            Session("Currency") = Nothing
                            Session("Currency") = "CurrencyMultiple"
                            Exit For
                        End If
                    End If
                Next
                '--EndCheck
                If Session("CustomerName") = "CustomerNameMultiple" Then
                    cmbAction.SelectedValue = 0
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("You Can Select Multiple Article of Single Customer.")
                ElseIf Session("CustomerName") = "" Then
                    cmbAction.SelectedValue = 0
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("No Row Selected")
                ElseIf Session("EKNumber") = "EKNumberMultiple" Then
                    cmbAction.SelectedValue = 0
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("You Can Select Multiple Article of Single Dept.")
                ElseIf Session("EKNumber") = "" Then
                    cmbAction.SelectedValue = 0
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("No Row Selected")
                ElseIf Session("ShipmentMode") = "ShipmentModeMultiple" Then
                    cmbAction.SelectedValue = 0
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("You Can Select Multiple Article of Single Shipment Mode.")
                ElseIf Session("ShipmentMode") = "" Then
                    cmbAction.SelectedValue = 0
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("No Row Selected")
                ElseIf Session("ShipmentTerm") = "ShipmentTermMultiple" Then
                    cmbAction.SelectedValue = 0
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("You Can Select Multiple Article of Single Shipment Term.")
                ElseIf Session("ShipmentTerm") = "" Then
                    cmbAction.SelectedValue = 0
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("No Row Selected")
                ElseIf Session("Currency") = "CurrencyMultiple" Then
                    cmbAction.SelectedValue = 0
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("You Can Select Multiple Article of Single Currency.")
                ElseIf Session("Currency") = "" Then
                    cmbAction.SelectedValue = 0
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("No Row Selected")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    cmbAction.SelectedValue = 0

                    '----For CommaSeparated
                    Dim StrPOID As String = "("
                    Dim StrPODetailID As String = "("

                    For x = 0 To dgMasterOrderForSupplier.Items.Count - 1
                        Dim item As GridDataItem = DirectCast(dgMasterOrderForSupplier.MasterTableView.Items(x), GridDataItem)
                        chkSelect = CType(dgMasterOrderForSupplier.Items(x).FindControl("chkSelect"), CheckBox)
                        If chkSelect.Checked = True Then
                            Dim POID As String = item("POID").Text
                            Dim PODetailID As String = item("PODetailID").Text

                            StrPOID = StrPOID + POID + ","
                            StrPODetailID = StrPODetailID + PODetailID + ","

                        End If

                    Next
                    StrPOID = StrPOID + ")"
                    StrPODetailID = StrPODetailID + ")"

                    StrPOID = Replace(StrPOID, ",)", ")")
                    StrPODetailID = Replace(StrPODetailID, ",)", ")")

                    ' Response.Write("<script> window.open('CommercialInvoices.aspx?lPOID=" & StrPOID & "&lPODetailID=" & StrPODetailID & "', 'newwindow', 'left=12, top=30, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")
                    Response.Redirect("CommercialInvoices.aspx?lPOID=" & StrPOID & "&lPODetailID=" & StrPODetailID & "")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub dgMasterOrderForSupplier_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles dgMasterOrderForSupplier.NeedDataSource
        'Dim startRowIndex As Integer = IIf((ShouldApplySortFilterOrGroup()), 0, dgMasterOrderForSupplier.CurrentPageIndex * dgMasterOrderForSupplier.PageSize)
        'Dim maximumRows As Integer = IIf((ShouldApplySortFilterOrGroup()), objPo.SelectCount(), dgMasterOrderForSupplier.PageSize)
        'dgMasterOrderForSupplier.AllowCustomPaging = Not ShouldApplySortFilterOrGroup()
        dgMasterOrderForSupplier.DataSource = objPo.GetMasterOrderForSupplier(dtUser.Rows(0)("EmployeeId"))
    End Sub
    Protected Sub dgMasterOrderForSupplier_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles dgMasterOrderForSupplier.PageIndexChanged
        BindGrid()
    End Sub
    Protected Sub dgMasterOrderForSupplier_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles dgMasterOrderForSupplier.SortCommand
        BindGrid()
    End Sub

End Class
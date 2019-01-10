Imports System.Data
Imports Integra.EuroCentra
Imports Telerik.Web.UI
Imports System.IO
Public Class MasterOrderDetailsForMerchandisers
    Inherits System.Web.UI.Page
    Dim objPo As New PurchaseOrder
    Dim POID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        POID = Request.QueryString("lPOID")
        Dim objDataview As DataView
        If Not Page.IsPostBack Then
            Try
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
        dgMasterOrderForSupplyChain.DataSource = objDataView
        dgMasterOrderForSupplyChain.DataBind()
    End Sub
    Function LoadData() As ICollection
        Try
            Dim objDataView As DataView
            Dim objDataTable As DataTable
            objDataTable = objPo.GetMasterOrderDetailsForMerchantD(CLng(Session("Userid")))
            objDataView = New DataView(objDataTable)
            Return objDataView
        Catch ex As Exception

        End Try
    End Function
    Protected Sub dgMasterOrderForSupplyChain_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgMasterOrderForSupplyChain.ItemCommand
        Try
            Select Case e.CommandName
                Case Is = "Customer"
                    Dim ID As Integer = 0
                    Response.Write("<script> window.open('PurchaseOrderAdd.aspx?, 'newwindow', 'left=450, top=210, height=400, width=450, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")
            End Select
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub dgMasterOrderForSupplyChain_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles dgMasterOrderForSupplyChain.NeedDataSource
        dgMasterOrderForSupplyChain.DataSource = objPo.GetMasterOrderDetailsForMerchantD(CLng(Session("Userid")))
    End Sub
    Protected Sub dgMasterOrderForSupplyChain_ItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles dgMasterOrderForSupplyChain.ItemCreated
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
                Session("IPOIDSupply") = ""
                For x = 0 To dgMasterOrderForSupplyChain.Items.Count - 1
                    Dim item As GridDataItem = DirectCast(dgMasterOrderForSupplyChain.MasterTableView.Items(x), GridDataItem)
                    chkSelect = CType(dgMasterOrderForSupplyChain.Items(x).FindControl("chkSelect"), CheckBox)
                    If chkSelect.Checked = True Then
                        If Session("IPOIDSupply") = "" Then
                            Session("IPOIDSupply") = item("POID").Text
                        ElseIf Session("IPOIDSupply") = item("POID").Text Then
                            Session("IPOIDSupply") = item("POID").Text
                        Else
                            Session("IPOIDSupply") = Nothing
                            Session("IPOIDSupply") = "POMultiple"
                            Exit For
                        End If
                    End If
                Next
                'End Check

                If Session("IPOIDSupply") = "POMultiple" Then
                    cmbAction.SelectedValue = 0
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("You Can Select Single Order.")
                ElseIf Session("IPOIDSupply") = "" Then
                    cmbAction.SelectedValue = 0
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("No Row Selected")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    cmbAction.SelectedValue = 0
                    ' Response.Write("<script> window.open('PurchaseOrderPreview.aspx?lPOID=" & CLng(Session("IPOIDSupply")) & "', 'newwindow', 'left=12, top=30, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")
                    ScriptManager.RegisterClientScriptBlock(Me.upcmbAction, Me.upcmbAction.GetType(), "New ClientScript", "window.open('PurchaseOrderPreviewPopup.aspx?lPOID=" & CLng(Session("IPOIDSupply")) & "', 'newwindow', 'left=12, top=30, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no');", True)
                End If
            ElseIf cmbAction.SelectedValue = 2 Then
                'Check Row Checked or not
                Dim x As Integer
                Dim chkSelect As CheckBox
                Session("IPOIDSupply") = ""
                For x = 0 To dgMasterOrderForSupplyChain.Items.Count - 1
                    Dim item As GridDataItem = DirectCast(dgMasterOrderForSupplyChain.MasterTableView.Items(x), GridDataItem)
                    chkSelect = CType(dgMasterOrderForSupplyChain.Items(x).FindControl("chkSelect"), CheckBox)
                    If chkSelect.Checked = True Then
                        If Session("IPOIDSupply") = "" Then
                            Session("IPOIDSupply") = item("POID").Text
                        ElseIf Session("IPOIDSupply") = item("POID").Text Then
                            Session("IPOIDSupply") = item("POID").Text
                        Else
                            Session("IPOIDSupply") = Nothing
                            Session("IPOIDSupply") = "POMultiple"
                            Exit For
                        End If
                    End If
                Next
                'End Check

                If Session("IPOIDSupply") = "POMultiple" Then
                    cmbAction.SelectedValue = 0
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("You Can Select Single Order.")
                ElseIf Session("IPOIDSupply") = "" Then
                    cmbAction.SelectedValue = 0
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("No Row Selected")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    cmbAction.SelectedValue = 0
                    If (Directory.Exists(Server.MapPath("~/OriginalPurchaseorderPDF/" & CLng(Session("IPOIDSupply")) & ""))) Then
                        Dim strFileSize As String = ""
                        Dim di As New IO.DirectoryInfo(Server.MapPath("~/OriginalPurchaseorderPDF/" & CLng(Session("IPOIDSupply")) & ""))
                        Dim aryFi As IO.FileInfo() = di.GetFiles("*.pdf")
                        Dim fi As IO.FileInfo
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                        For Each fi In aryFi
                            Response.ClearHeaders()
                            Response.ClearContent()
                            Response.ContentType = "application/octet-stream"
                            Response.Charset = "UTF-8"
                            Response.AddHeader("content-disposition", "attachment; filename=" & fi.Name)
                            Response.WriteFile(Server.MapPath("~/OriginalPurchaseorderPDF/" & CLng(Session("IPOIDSupply")) & "/" & fi.Name & ""))
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
                Session("IPOIDSupply") = ""
                For x = 0 To dgMasterOrderForSupplyChain.Items.Count - 1
                    Dim item As GridDataItem = DirectCast(dgMasterOrderForSupplyChain.MasterTableView.Items(x), GridDataItem)
                    chkSelect = CType(dgMasterOrderForSupplyChain.Items(x).FindControl("chkSelect"), CheckBox)
                    If chkSelect.Checked = True Then
                        If Session("IPOIDSupply") = "" Then
                            Session("IPOIDSupply") = item("POID").Text
                        ElseIf Session("IPOIDSupply") = item("POID").Text Then
                            Session("IPOIDSupply") = item("POID").Text
                        Else
                            Session("IPOIDSupply") = Nothing
                            Session("IPOIDSupply") = "POMultiple"
                            Exit For
                        End If
                    End If
                Next
                'End Check

                If Session("IPOIDSupply") = "POMultiple" Then
                    cmbAction.SelectedValue = 0
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("You Can Select Single Order.")
                ElseIf Session("IPOIDSupply") = "" Then
                    cmbAction.SelectedValue = 0
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("No Row Selected")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    cmbAction.SelectedValue = 0
                    Response.Redirect("TNAChartView.aspx?POID=" & CLng(Session("IPOIDSupply")) & "")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub dgMasterOrderForSupplyChain_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles dgMasterOrderForSupplyChain.PageIndexChanged
        BindGrid()
    End Sub
    Protected Sub dgMasterOrderForSupplyChain_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles dgMasterOrderForSupplyChain.SortCommand
        BindGrid()
    End Sub


End Class
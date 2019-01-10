Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class RequisitionerRequestApproval
    Inherits System.Web.UI.Page
    Dim objRequisitionerInfo As New RequisitionerInfoClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objDataView As DataView
        If Not Page.IsPostBack Then
          
            PageHeader(" Requisitioner Approval")
            Try
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()
            Catch objUDException As UDException
            End Try

        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub

    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            objDataView = Session("objDataView")
            If objDataView.Count > 0 Then
                dgApproval.Visible = True
                dgApproval.DataSource = objDataView
                dgApproval.DataBind()
            Else
                dgApproval.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objRequisitionerInfo.GetRequisitionerApprovalView
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function

    Protected Sub cmdAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdAdd.Click

    End Sub

    Protected Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgApproval.SortCommand
        BindGrid()
    End Sub

    Protected Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgApproval.PageIndexChanged
        BindGrid()
    End Sub


    Protected Sub dgApproval_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgApproval.ItemCommand
        Select Case e.CommandName
            Case Is = "Approval"
                Dim x As Integer
                For x = 0 To dgApproval.Items.Count - 1
                    Dim lInventoryRequestMasterID As Long = dgApproval.Items(e.Item.ItemIndex).Cells(0).Text()


                    Dim st As StringBuilder = New StringBuilder()
                    st.Append("<script language='javascript'>")
                    st.Append("var w = window.open('RequisitionerRequestApprovalPopUp.aspx?lInventoryRequestMasterID=" & lInventoryRequestMasterID & "','PopUpWindowName','left=200, top=150, height=400, width=600, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no,titlebar=0');") '//opens the pop up
                    st.Append("w.focus()")
                    st.Append("</script>")
                    Page.RegisterStartupScript("PopUpwindowOpen", st.ToString())
                Next
               

        End Select
    End Sub
End Class
Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Public Class QRCodeMerchant
    Inherits System.Web.UI.Page
    Dim objPurchaseOrder As New PurchaseOrder
    Dim IPOID As Long
    Dim objWIPProcess As New WIPProcess
    Dim objWIPChart As New WIPChart

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objDataView As DataView
        IPOID = Request.QueryString("lPOID")
        If Not Page.IsPostBack Then
            Try
                If IPOID > 0 Then
                    objDataView = LoadData(IPOID)
                    Session("objDataView") = objDataView
                    BindGrid()
                End If

            Catch objUDException As UDException
            End Try
        End If
    End Sub
  
    ' Procedure that Binds the Grid
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            Dim strSortExpression As String
            objDataView = Session("objDataView")
            If objDataView.Count > 0 Then
                dgPurchaseOrder.Visible = True
                strSortExpression = dgPurchaseOrder.SortExpression
                If strSortExpression <> "" Then
                    objDataView.Sort = strSortExpression
                    If Not dgPurchaseOrder.IsSortedAscending Then
                        objDataView.Sort += " DESC"
                    End If
                End If
                dgPurchaseOrder.RecordCount = objDataView.Count
                dgPurchaseOrder.DataSource = objDataView
                dgPurchaseOrder.DataBind()

                lblPONO.Text = objDataView.Item(0)("PONO")
                lblShipment.Text = objDataView.Item(0)("ShipmentDate")
                lblCustomer.Text = objDataView.Item(0)("CustomerName")
                lblSupplier.Text = objDataView.Item(0)("VenderName")


                Dim x As Integer
                Dim PoRefNO As Integer
                Dim cmbWIPProcess As DropDownList
                Dim dtWIP As New DataTable
                dtWIP = objWIPProcess.GetWIPProcessForNewStyle()
                Dim dtWIPP As New DataTable
                dtWIPP = objWIPProcess.GetWIPProcessForRepeatStyle()
                Dim dtCurrentWIPprocess As New DataTable

                For x = 0 To dgPurchaseOrder.RecordCount - 1
                    PoRefNO = Convert.ToInt32(dgPurchaseOrder.Items(x).Cells(2).Text)
                    cmbWIPProcess = CType(dgPurchaseOrder.Items(x).FindControl("cmbWIPProcess"), DropDownList)
                    If PoRefNO = 0 Then
                        With cmbWIPProcess
                            .DataSource = dtWIP
                            .DataTextField = "ProcessName"
                            .DataValueField = "WIPProcessID"
                            .DataBind()
                            .Items.Insert(0, New ListItem("Select...", "0"))
                        End With
                        'Now show Current WIP Process in Dropdown
                        dtCurrentWIPprocess = objWIPChart.GetCurrentWIPProcess(dgPurchaseOrder.Items(x).Cells(0).Text, dgPurchaseOrder.Items(x).Cells(1).Text)
                        If dtCurrentWIPprocess.Rows.Count > 0 Then
                            cmbWIPProcess.SelectedValue = dtCurrentWIPprocess.Rows(0)("WIPProcessID")
                        Else
                            cmbWIPProcess.SelectedValue = 0
                        End If
                    Else
                        With cmbWIPProcess
                            .DataSource = dtWIPP
                            .DataTextField = "ProcessName"
                            .DataValueField = "WIPProcessID"
                            .DataBind()
                            .Items.Insert(0, New ListItem("Select...", "0"))
                        End With
                        'Now show Current WIP Process in Dropdown
                        dtCurrentWIPprocess = objWIPChart.GetCurrentWIPProcess(dgPurchaseOrder.Items(x).Cells(0).Text, dgPurchaseOrder.Items(x).Cells(1).Text)
                        If dtCurrentWIPprocess.Rows.Count > 0 Then
                            cmbWIPProcess.SelectedValue = dtCurrentWIPprocess.Rows(0)("WIPProcessID")
                        Else
                            cmbWIPProcess.SelectedValue = 0
                        End If
                    End If
                Next
            Else
                dgPurchaseOrder.Visible = False
            End If

        Catch ex As Exception
        End Try
    End Sub
    ' Function that Loads the data and return dataview
    Function LoadData(ByVal IPOID As Long) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objPurchaseOrder.TemproryFUN(IPOID)
        objDataView = New DataView(objDataTable)

        Return objDataView
    End Function
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs)
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgPurchaseOrder.ItemDataBound
        'BindGrid()

    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            SavePOTracking()
            Dim x As Integer
            Dim chkWIPProcess As CheckBox ' get the update check box status
            For x = 0 To dgPurchaseOrder.Items.Count - 1
                chkWIPProcess = CType(dgPurchaseOrder.Items(x).FindControl("chkWIPProcess"), CheckBox)
                If chkWIPProcess.Checked = True Then
                    Dim cmbWIPProcess As DropDownList = CType(dgPurchaseOrder.Items(x).FindControl("cmbWIPProcess"), DropDownList)
                    Dim IPOID As Integer = dgPurchaseOrder.Items(x).Cells(0).Text
                    Dim IPODetailID As Integer = dgPurchaseOrder.Items(x).Cells(1).Text

                    If Not cmbWIPProcess.SelectedValue = 0 Then
                        With objWIPChart
                            .WIPChartId = 0
                            .WIPProcessID = cmbWIPProcess.SelectedValue
                            .POID = IPOID
                            .POdetailID = IPODetailID
                            .Remarks = ""
                            .Status = "Created"
                            .CreationDate = Date.Now
                            .Userid = CLng(Session("Userid"))
                            .SaveWIPChart()
                            'After Save Make False Checkbox 
                            chkWIPProcess.Checked = False
                        End With
                        lblMsg.Text = "Your WIP Save Successfully"
                    Else
                        'Make False Checkbox 

                        'Not save
                    End If
                Else
                    'lblMSG.Text = "Record NOT Saved"
                    ' lblMSG.Visible = True
                End If
            Next

        Catch ex As Exception
        End Try
 
    End Sub
    Sub SavePOTracking()
        Try
            Dim x As Integer
            Dim chkWIPProcess As CheckBox ' get the update check box status
            For x = 0 To dgPurchaseOrder.Items.Count - 1
                chkWIPProcess = CType(dgPurchaseOrder.Items(x).FindControl("chkWIPProcess"), CheckBox)
                If chkWIPProcess.Checked = True Then
                    Dim cmbWIPProcess As DropDownList = CType(dgPurchaseOrder.Items(x).FindControl("cmbWIPProcess"), DropDownList)
                    Dim IPOID As Integer = dgPurchaseOrder.Items(x).Cells(0).Text
                    Dim IPODetailID As Integer = dgPurchaseOrder.Items(x).Cells(1).Text
                    If Not cmbWIPProcess.SelectedValue = 0 Then
                        Dim objPOtracking As New POTracking
                        With objPOtracking
                            .PoTrackingID = 0
                            .CreationDate = Date.Now
                            .POID = IPOID
                            .TrackingObject = "WIP Status: " + cmbWIPProcess.SelectedItem.Text
                            .SavePOTracking()
                        End With
                        Exit For
                    End If

                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbWIPProcess_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim x As Integer = 0
        Dim ddlcmbWIPProcess As DropDownList = DirectCast(sender, DropDownList)
        Dim row As DataGridItem = DirectCast(ddlcmbWIPProcess.NamingContainer, DataGridItem)
        'Dim ddlAddLabTestShortName As DropDownList = DirectCast(row.FindControl("cmbWIPProcess"), DropDownList)
        Dim index As Integer = row.ItemIndex

        For x = 0 To dgPurchaseOrder.Items.Count - 1
            Dim cmbWIPProcess As DropDownList = CType(dgPurchaseOrder.Items(x).FindControl("cmbWIPProcess"), DropDownList)
            Dim chkWIPProcess As CheckBox = CType(dgPurchaseOrder.Items(x).FindControl("chkWIPProcess"), CheckBox)
            If index = 0 Then
                Dim cmbWIPProcesss As DropDownList = CType(dgPurchaseOrder.Items(index).FindControl("cmbWIPProcess"), DropDownList)
                If cmbWIPProcesss.SelectedValue = 0 Then
                    cmbWIPProcess.SelectedValue = 0
                    chkWIPProcess.Checked = False
                Else
                    cmbWIPProcess.SelectedValue = cmbWIPProcesss.SelectedValue
                    chkWIPProcess.Checked = True
                End If
            Else
                'it mean indivl drop down clik, so no action,But Just check if Selct then chkbox false
                If cmbWIPProcess.SelectedValue = 0 Then
                    chkWIPProcess.Checked = False
                Else
                    chkWIPProcess.Checked = True
                End If
            End If
        Next
    End Sub


End Class
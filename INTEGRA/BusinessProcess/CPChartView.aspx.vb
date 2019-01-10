Imports System.Data
Imports Integra.EuroCentra
Imports Telerik.Web.UI
Imports System.IO
Public Class CPChartView
    Inherits System.Web.UI.Page
    Dim objCPChart As New CPChart
    Dim objCPChartHistory As New CPChartHistory
    Dim objPurchaseOrder As New PurchaseOrder
    Dim lPOID As Long
    Dim GeneralCode As New GeneralCode
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lPOID = Request.QueryString("lPOID")
        Dim objDataView As DataView
        If Not Page.IsPostBack Then
            Dim dtExist As DataTable = objCPChart.POIDExistCPChart(lPOID)
            lblMssg.Text = ""
            If dtExist.Rows.Count > 0 Then
                objDataView = LoadDataEdit()
                Session("objDataView2") = objDataView
                BindGridEdit()
            Else
                objDataView = LoadData()
                Session("objDataView2") = objDataView
                BindGrid()
            End If
            POInfo()
        End If
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objCPChart.GetProcessFirstTime()
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Private Sub BindGrid()
        Dim objDataView As DataView
        Dim strSortExpression As String
        objDataView = Session("objDataView2")
        If objDataView.Count > 0 Then
            strSortExpression = dgPurchaseOrder.SortExpression
            If strSortExpression <> "" Then
                objDataView.Sort = strSortExpression
                If Not dgPurchaseOrder.IsSortedAscending Then
                    objDataView.Sort += " DESC"
                End If
            End If
            dgPurchaseOrder.Visible = True
            dgPurchaseOrder.RecordCount = objDataView.Count
            dgPurchaseOrder.DataSource = objDataView
            dgPurchaseOrder.DataBind()
        Else
            dgPurchaseOrder.Visible = False
        End If
    End Sub
    Sub POInfo()
        Try
            Dim dt As DataTable = objPurchaseOrder.GetPOInfo(lPOID)
            lblStyle.Text = dt.Rows(0)("StyleNo")
            lblCustomer.Text = dt.Rows(0)("CustomerName")
            lblSupplier.Text = dt.Rows(0)("venderName")
            lblShipemntDate.Text = dt.Rows(0)("ShipmentDatee")
            lblPONO.Text = dt.Rows(0)("PONO")

        Catch ex As Exception

        End Try
    End Sub
    Function LoadDataEdit() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objCPChart.GetChartEdit(lPOID)
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Private Sub BindGridEdit()
        Dim objDataView As DataView
        Dim strSortExpression As String
        objDataView = Session("objDataView2")
        If objDataView.Count > 0 Then
            strSortExpression = dgPurchaseOrder.SortExpression
            If strSortExpression <> "" Then
                objDataView.Sort = strSortExpression
                If Not dgPurchaseOrder.IsSortedAscending Then
                    objDataView.Sort += " DESC"
                End If
            End If
            dgPurchaseOrder.Visible = True
            dgPurchaseOrder.RecordCount = objDataView.Count
            dgPurchaseOrder.DataSource = objDataView
            dgPurchaseOrder.DataBind()

            Dim x As Integer
            For x = 0 To dgPurchaseOrder.Items.Count - 1
                Dim txtQuantity As TextBox = CType(dgPurchaseOrder.Items(x).FindControl("txtQuantity"), TextBox)
                Dim txtTargetSubmission As TextBox = CType(dgPurchaseOrder.Items(x).FindControl("txtTargetSubmission"), TextBox)
                Dim txtIstSubmission As TextBox = CType(dgPurchaseOrder.Items(x).FindControl("txtIstSubmission"), TextBox)
                Dim txtDHLorFEDEX As TextBox = CType(dgPurchaseOrder.Items(x).FindControl("txtDHLorFEDEX"), TextBox)
                Dim cmbFeedBackReceived As DropDownList = CType(dgPurchaseOrder.Items(x).FindControl("cmbFeedBackReceived"), DropDownList)
                Dim txtRevisedTarget As TextBox = CType(dgPurchaseOrder.Items(x).FindControl("txtRevisedTarget"), TextBox)
                Dim txtRevisedSubmission As TextBox = CType(dgPurchaseOrder.Items(x).FindControl("txtRevisedSubmission"), TextBox)
                Dim txtDHLorFEDEX1 As TextBox = CType(dgPurchaseOrder.Items(x).FindControl("txtDHLorFEDEX1"), TextBox)
                Dim cmbFeedBackReceived1 As DropDownList = CType(dgPurchaseOrder.Items(x).FindControl("cmbFeedBackReceived1"), DropDownList)
                Dim txtRemarks As TextBox = CType(dgPurchaseOrder.Items(x).FindControl("txtRemarks"), TextBox)

                If objDataView.Table.Rows(x)("Quantity") = 0 Then
                    txtQuantity.Text = ""
                Else
                    txtQuantity.Text = objDataView.Table.Rows(x)("Quantity")
                End If
                txtTargetSubmission.Text = objDataView.Table.Rows(x)("TargetSubmissionn")
                txtIstSubmission.Text = objDataView.Table.Rows(x)("IstSubmissionn")
                txtDHLorFEDEX.Text = objDataView.Table.Rows(x)("DHLorFEDEX")
                cmbFeedBackReceived.SelectedValue = objDataView.Table.Rows(x)("FeedBackReceived")
                txtRevisedTarget.Text = objDataView.Table.Rows(x)("RevisedTargett")
                txtRevisedSubmission.Text = objDataView.Table.Rows(x)("RevisedSubmissionn")
                txtDHLorFEDEX1.Text = objDataView.Table.Rows(x)("DHLorFEDEX1")
                cmbFeedBackReceived1.SelectedValue = objDataView.Table.Rows(x)("FeedBackReceived1")
                txtRemarks.Text = objDataView.Table.Rows(x)("Remarks")
            Next
        Else
            dgPurchaseOrder.Visible = False
        End If
    End Sub
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs)
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs)
        'BindGrid()
    End Sub
    Protected Sub btnSaveAll_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSaveAll.Click
        Try
            'SELECT Convert(Varchar,convert(datetime, FeedBackReceived , 103),103) from cpchart
            'where convert(datetime, FeedBackReceived , 103) >'04/23/2014'
            Dim x As Long
            For x = 0 To dgPurchaseOrder.Items.Count - 1
                Dim txtQuantity As TextBox = CType(dgPurchaseOrder.Items(x).FindControl("txtQuantity"), TextBox)
                Dim txtTargetSubmission As TextBox = CType(dgPurchaseOrder.Items(x).FindControl("txtTargetSubmission"), TextBox)
                Dim txtIstSubmission As TextBox = CType(dgPurchaseOrder.Items(x).FindControl("txtIstSubmission"), TextBox)
                Dim txtDHLorFEDEX As TextBox = CType(dgPurchaseOrder.Items(x).FindControl("txtDHLorFEDEX"), TextBox)
                Dim cmbFeedBackReceived As DropDownList = CType(dgPurchaseOrder.Items(x).FindControl("cmbFeedBackReceived"), DropDownList)
                Dim txtRevisedTarget As TextBox = CType(dgPurchaseOrder.Items(x).FindControl("txtRevisedTarget"), TextBox)
                Dim txtRevisedSubmission As TextBox = CType(dgPurchaseOrder.Items(x).FindControl("txtRevisedSubmission"), TextBox)
                Dim txtDHLorFEDEX1 As TextBox = CType(dgPurchaseOrder.Items(x).FindControl("txtDHLorFEDEX1"), TextBox)
                Dim cmbFeedBackReceived1 As DropDownList = CType(dgPurchaseOrder.Items(x).FindControl("cmbFeedBackReceived1"), DropDownList)
                Dim txtRemarks As TextBox = CType(dgPurchaseOrder.Items(x).FindControl("txtRemarks"), TextBox)
                Dim chkStatus As CheckBox = CType(dgPurchaseOrder.Items(x).FindControl("chkStatus"), CheckBox)
                If chkStatus.Checked = True Then
                    With objCPChart
                        .CPChartID = dgPurchaseOrder.Items(x).Cells(0).Text
                        .CreationDate = Date.Now()
                        .CPProcessID = dgPurchaseOrder.Items(x).Cells(1).Text
                        .POID = lPOID
                        .Quantity = Val(txtQuantity.Text)
                        If txtTargetSubmission.Text = "" Then
                            .TargetSubmission = ""
                        Else
                            Dim Year As String = txtTargetSubmission.Text.Substring(6, 4)
                            Dim Day As String = txtTargetSubmission.Text.Substring(0, 2)
                            Dim Month As String = txtTargetSubmission.Text.Substring(3, 2)
                            .TargetSubmission = Year.ToString() + Month.ToString() + Day.ToString()
                        End If
                        If txtIstSubmission.Text = "" Then
                            .IstSubmission = ""
                        Else
                            Dim Year As String = txtIstSubmission.Text.Substring(6, 4)
                            Dim Day As String = txtIstSubmission.Text.Substring(0, 2)
                            Dim Month As String = txtIstSubmission.Text.Substring(3, 2)
                            .IstSubmission = Year.ToString() + Month.ToString() + Day.ToString()
                        End If
                        .DHLorFEDEX = txtDHLorFEDEX.Text
                        .FeedBackReceived = cmbFeedBackReceived.SelectedItem.Text
                        If txtRevisedTarget.Text = "" Then
                            .RevisedTarget = ""
                        Else
                            Dim Year As String = txtRevisedTarget.Text.Substring(6, 4)
                            Dim Day As String = txtRevisedTarget.Text.Substring(0, 2)
                            Dim Month As String = txtRevisedTarget.Text.Substring(3, 2)
                            .RevisedTarget = Year.ToString() + Month.ToString() + Day.ToString()
                        End If
                        If txtRevisedSubmission.Text = "" Then
                            .RevisedSubmission = ""
                        Else
                            Dim Year As String = txtRevisedSubmission.Text.Substring(6, 4)
                            Dim Day As String = txtRevisedSubmission.Text.Substring(0, 2)
                            Dim Month As String = txtRevisedSubmission.Text.Substring(3, 2)
                            .RevisedSubmission = Year.ToString() + Month.ToString() + Day.ToString()
                        End If
                        .DHLorFEDEX1 = txtDHLorFEDEX1.Text
                        .FeedBackReceived1 = cmbFeedBackReceived1.SelectedItem.Text
                        .Remarks = txtRemarks.Text
                        .SaveCPChart()
                    End With

                    With objCPChartHistory
                        .CPChartHistoryID = 0
                        .CreationDate = Date.Now()
                        If dgPurchaseOrder.Items(x).Cells(0).Text = 0 Then
                            .CPChartID = objCPChart.GetId()
                        Else
                            .CPChartID = dgPurchaseOrder.Items(x).Cells(0).Text
                        End If
                        .CPProcessID = dgPurchaseOrder.Items(x).Cells(1).Text
                        .Quantity = Val(txtQuantity.Text)
                        If txtTargetSubmission.Text = "" Then
                            .TargetSubmission = ""
                        Else
                            Dim Year As String = txtTargetSubmission.Text.Substring(6, 4)
                            Dim Day As String = txtTargetSubmission.Text.Substring(0, 2)
                            Dim Month As String = txtTargetSubmission.Text.Substring(3, 2)
                            .TargetSubmission = Year.ToString() + Month.ToString() + Day.ToString()
                        End If
                        If txtIstSubmission.Text = "" Then
                            .IstSubmission = ""
                        Else
                            Dim Year As String = txtIstSubmission.Text.Substring(6, 4)
                            Dim Day As String = txtIstSubmission.Text.Substring(0, 2)
                            Dim Month As String = txtIstSubmission.Text.Substring(3, 2)
                            .IstSubmission = Year.ToString() + Month.ToString() + Day.ToString()
                        End If
                        .DHLorFEDEX = txtDHLorFEDEX.Text
                        .FeedBackReceived = cmbFeedBackReceived.SelectedItem.Text
                        If txtRevisedTarget.Text = "" Then
                            .RevisedTarget = ""
                        Else
                            Dim Year As String = txtRevisedTarget.Text.Substring(6, 4)
                            Dim Day As String = txtRevisedTarget.Text.Substring(0, 2)
                            Dim Month As String = txtRevisedTarget.Text.Substring(3, 2)
                            .RevisedTarget = Year.ToString() + Month.ToString() + Day.ToString()
                        End If
                        If txtRevisedSubmission.Text = "" Then
                            .RevisedSubmission = ""
                        Else
                            Dim Year As String = txtRevisedSubmission.Text.Substring(6, 4)
                            Dim Day As String = txtRevisedSubmission.Text.Substring(0, 2)
                            Dim Month As String = txtRevisedSubmission.Text.Substring(3, 2)
                            .RevisedSubmission = Year.ToString() + Month.ToString() + Day.ToString()
                        End If
                        .DHLorFEDEX1 = txtDHLorFEDEX1.Text
                        .FeedBackReceived1 = cmbFeedBackReceived1.SelectedItem.Text
                        .Remarks = txtRemarks.Text
                        .SaveCPChartHistory()
                    End With
                    lblMssg.Text = "Save Successfully"
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub dgPurchaseOrder_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgPurchaseOrder.ItemCommand
        Try
            Select Case e.CommandName
                Case "History"
                    Dim CPChartID As Long = dgPurchaseOrder.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim CPProcessID As Long = dgPurchaseOrder.Items(e.Item.ItemIndex).Cells(1).Text
                    Response.Redirect("CPChartHistoryView.aspx?lPOID=" & lPOID & "&CPProcessID=" & CPProcessID & "")
            End Select
        Catch ex As Exception
        End Try

    End Sub


End Class
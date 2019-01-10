Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Public Class CommercialInvoicesPopup
    Inherits System.Web.UI.Page
    Dim objPo As New PurchaseOrder
    Dim Dr As DataRow
    Dim Dt As New DataTable
    Dim CustomerName1 As String
    Dim Eknumber As String
    Dim Currency As String
    Dim ShipmentTerm As String
    Dim ShipmentMode As String
    Dim dtt As System.Data.DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CustomerName1 = Request.QueryString("Customername")
        Eknumber = Request.QueryString("Eknumber")
        Currency = Request.QueryString("Currency")
        ShipmentTerm = Request.QueryString("ShipmentTerm")
        ShipmentMode = Request.QueryString("ShipmentMode")

        Response.Expires = 0
        If Not Page.IsPostBack Then
            Session("dtSelection") = Nothing
            cmdSelect.Visible = False
        End If
    End Sub
    ' Procedure that Binds the Grid
    Private Sub BindGrid()
        Dim objDataView As DataView
        objDataView = Session("objDataView")
        If objDataView.Count > 0 Then
            dgCommercialInvoiceSelection.Visible = True
            dgCommercialInvoiceSelection.DataSource = objDataView
            dgCommercialInvoiceSelection.DataBind()
            cmdSelect.Visible = True
        Else
            dgCommercialInvoiceSelection.Visible = False
        End If
    End Sub
    Function LoadData(ByVal PONO As String) As ICollection
        Try
            Dim objDataView As DataView
            Dim objDataTable As DataTable
            objDataTable = objPo.GetCommercialInvoiceFrPopupr(PONO)
            objDataView = New DataView(objDataTable)
            Return objDataView
        Catch ex As Exception
        End Try
    End Function
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        Dim objDataView As DataView
        Try
            objDataView = LoadData(txtPONO.Text)
            Session("objDataView") = objDataView
            BindGrid()
        Catch objUDException As UDException
        End Try
    End Sub
    Protected Sub cmdSelect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSelect.Click
        Try
            'Check Row Checked or not
            Dim x As Integer
            Dim chkSelect As CheckBox

            For x = 0 To dgCommercialInvoiceSelection.Items.Count - 1
                Dim item As GridDataItem = DirectCast(dgCommercialInvoiceSelection.MasterTableView.Items(x), GridDataItem)
                chkSelect = CType(dgCommercialInvoiceSelection.Items(x).FindControl("chkSelect"), CheckBox)
                If chkSelect.Checked = True Then
                    If CustomerName1 <> item("CustomerName1").Text Then
                        lblpopupMSG.Text = "You Can Select Multiple Article of Single Customer."
                        Exit For
                    ElseIf Eknumber <> item("EKNumber").Text Then
                        lblpopupMSG.Text = "You Can Select Multiple Article of Single Dept."
                        Exit For
                    ElseIf ShipmentMode <> item("ShipmentMode").Text Then
                        lblpopupMSG.Text = "You Can Select Multiple Article of Single Shipment Mode."
                        Exit For
                    ElseIf ShipmentTerm <> item("ShipmentTerm").Text Then
                        lblpopupMSG.Text = "You Can Select Multiple Article of Single Shipment Term."
                        Exit For
                    ElseIf Currency <> item("Currency").Text Then
                        lblpopupMSG.Text = "You Can Select Multiple Article of Single Currency."
                        Exit For
                    Else
                        lblpopupMSG.Text = " "
                        If (Not CType(Session("dtSelection"), DataTable) Is Nothing) Then
                            dtt = Session("dtSelection")
                        Else
                            dtt = New DataTable
                            With dtt
                                .Columns.Add("CommercialInvoiceDetailID", GetType(Long))
                                .Columns.Add("POID", GetType(Long))
                                .Columns.Add("PODetailID", GetType(Long))
                                .Columns.Add("StyleID", GetType(Long))
                                .Columns.Add("StyleNo", GetType(String))
                                .Columns.Add("PONO", GetType(String))
                                .Columns.Add("Article", GetType(String))
                                .Columns.Add("Size", GetType(String))
                                .Columns.Add("Color", GetType(String))
                                .Columns.Add("Quantity", GetType(String))
                                .Columns.Add("Rate", GetType(String))
                                .Columns.Add("Value", GetType(Decimal))
                                .Columns.Add("UOM", GetType(String))
                            End With
                        End If
                        Dr = dtt.NewRow()
                        Dr("CommercialInvoiceDetailID") = item("CommercialInvoiceDetailID").Text
                        Dr("POID") = item("POID").Text
                        Dr("PODetailID") = item("PODetailID").Text
                        Dr("StyleID") = item("StyleID").Text
                        Dr("StyleNo") = item("StyleNo").Text
                        Dr("PONO") = item("PONO").Text
                        Dr("Article") = item("Article").Text
                        Dr("Size") = item("Size").Text
                        Dr("Color") = item("Colorway").Text
                        Dr("Quantity") = item("ItemQty").Text
                        Dr("Rate") = item("Rate").Text
                        Dr("Value") = Math.Round(CDec((item("ItemQty").Text) * (item("Rate").Text)), 2)
                        Dr("UOM") = ""
                        dtt.Rows.Add(Dr)
                        Session("dtSelection") = dtt
                    End If
                End If
            Next


            'Dim x As Integer
            'Dim chkSelect As CheckBox
            'Dim dtt As System.Data.DataTable
            'Dim bShouldAdd As Boolean = True
            'Dim isEmployeeExist As Boolean = False
            'For x = 0 To dgCommercialInvoiceSelection.Items.Count - 1
            '    Dim item As GridDataItem = DirectCast(dgCommercialInvoiceSelection.MasterTableView.Items(x), GridDataItem)
            '    chkSelect = CType(dgCommercialInvoiceSelection.Items(x).FindControl("chkSelect"), CheckBox)
            '    If chkSelect.Checked = True Then

            '        If (Not CType(Session("dtSelection"), DataTable) Is Nothing) Then
            '            dtt = Session("dtSelection")
            '        Else
            '            dtt = New DataTable
            '            With dtt
            '                .Columns.Add("CommercialInvoiceDetailID", GetType(Long))
            '                .Columns.Add("POID", GetType(Long))
            '                .Columns.Add("PODetailID", GetType(Long))
            '                .Columns.Add("StyleID", GetType(Long))
            '                .Columns.Add("StyleNo", GetType(String))
            '                .Columns.Add("PONO", GetType(String))
            '                .Columns.Add("Article", GetType(String))
            '                .Columns.Add("Size", GetType(String))
            '                .Columns.Add("Color", GetType(String))
            '                .Columns.Add("Quantity", GetType(String))
            '                .Columns.Add("Rate", GetType(String))
            '                .Columns.Add("Value", GetType(Decimal))
            '                .Columns.Add("UOM", GetType(String))
            '            End With
            '        End If


            '        Dr = dtt.NewRow()
            '        Dr("CommercialInvoiceDetailID") = item("CommercialInvoiceDetailID").Text
            '        Dr("POID") = item("POID").Text
            '        Dr("PODetailID") = item("PODetailID").Text
            '        Dr("StyleID") = item("StyleID").Text
            '        Dr("StyleNo") = item("StyleNo").Text
            '        Dr("PONO") = item("PONO").Text
            '        Dr("Article") = item("Article").Text
            '        Dr("Size") = item("Size").Text
            '        Dr("Color") = item("Colorway").Text
            '        Dr("Quantity") = item("ItemQty").Text
            '        Dr("Rate") = item("Rate").Text
            '        Dr("Value") = Math.Round(CDec((item("ItemQty").Text) * (item("Rate").Text)), 2)
            '        Dr("UOM") = ""
            '        dtt.Rows.Add(Dr)
            '    End If
            'Next

            'Session("dtSelection") = dtt
        Catch ex As Exception

        End Try
    End Sub

End Class